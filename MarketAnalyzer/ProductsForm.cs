using MarketAnalyzer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace MarketAnalyzer
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }

        List<Product> _products;
        private void ProductsForm_Load(object sender, EventArgs e)
        {
            _products = CSVDataLoader.LoadData();
            CustomizeGridAppearance();
            RefreshGridData();

            ConfigureChart();
        }

        private void CustomizeGridAppearance()
        {
            ProductsGrid.AutoGenerateColumns = false;
            ProductsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ProductsGrid.RowHeadersVisible = false;
            ProductsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewTextBoxColumn titleCol = new DataGridViewTextBoxColumn();
            titleCol.HeaderText = "Title";
            titleCol.DataPropertyName = "Title";


            DataGridViewTextBoxColumn brandCol = new DataGridViewTextBoxColumn();
            brandCol.HeaderText = "Brand";
            brandCol.DataPropertyName = "Brand";

            ProductsGrid.Columns.Add(titleCol);
            ProductsGrid.Columns.Add(brandCol);
        }
        private void RefreshGridData()
        {
            List<Product> searchResult = _products.Where(p => p.Brand.ToLower().Contains(SearchText.Text.ToLower())).ToList();

            ProductsGrid.DataSource = searchResult;
        }
        private async void SearchText_TextChanged(object sender, EventArgs e)
        {
            int lengthBeforePause = SearchText.Text.Length;

            await Task.Delay(300);

            int lengthAfterPause = SearchText.Text.Length;

            if (lengthBeforePause == lengthAfterPause)
            {
                RefreshGridData();
            }
        }
        private void RefreshChart(Product selectedProduct)
        {
            //Clear Chart Series
            PricesChart.Series["Price"].Points.Clear();

            //Adding Points for Prices
            PricesChart.Series["Price"].Points.AddXY("Dec 2021", Calculations.ConvertToDecimal(selectedProduct.Dec2021Price));
            PricesChart.Series["Price"].Points.AddXY("May 2022", Calculations.ConvertToDecimal(selectedProduct.May2022Price));
            PricesChart.Series["Price"].Points.AddXY("Jul 2022", Calculations.ConvertToDecimal(selectedProduct.Jul2022Price));
            PricesChart.Series["Price"].Points.AddXY("Sep 2022", Calculations.ConvertToDecimal(selectedProduct.Sep2022Price));
            PricesChart.Series["Price"].Points.AddXY("Oct 2022", Calculations.ConvertToDecimal(selectedProduct.Oct2022Price));

            //Itterate through all Points and Add Label for each
            foreach (DataPoint point in PricesChart.Series["Price"].Points)
                point.Label = point.YValues[0].ToString();
        }
        private void ConfigureChart()
        {
            PricesChart.Series.Clear();
            PricesChart.ChartAreas.Clear();

            PricesChart.ChartAreas.Add(new ChartArea());
            PricesChart.Series.Add(new Series("Price")
            {
                ChartType = SeriesChartType.SplineArea
            });
        }

        private void ProductsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Product selectedProduct = (Product)ProductsGrid.Rows[e.RowIndex].DataBoundItem;
            RefreshChart(selectedProduct);
        }

        private void CalculateChangeBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = ProductsGrid.SelectedRows;
            if (selectedRows.Count == 0)
                return;

            List<Product> selectedProducts = new List<Product>();

            foreach (DataGridViewRow row in selectedRows)
            {
                selectedProducts.Add((Product)row.DataBoundItem);
            }

            string message = Calculations.CalculateChangeInPrice(selectedProducts);

            MessageBox.Show(message);
        }

        private void biggestIncreaseBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, decimal> brandsWithHighestPriceIncrease = Calculations.CalculateBrandsPriceChange(_products, SortType.Increase);

            string message = "";

            foreach(var brand in brandsWithHighestPriceIncrease)
            {
                message += $"{brand.Key} increased price for {brand.Value}%\n\n";
            }
            MessageBox.Show(message,"Top Brands with Highest Price Increase between Dec 2021 and Oct 2022");
        }

        private void biggestDecreaseBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, decimal> brandsWithHighestPriceDecrease = Calculations.CalculateBrandsPriceChange(_products, SortType.Decrease);

            string message = "";

            foreach (var brand in brandsWithHighestPriceDecrease)
            {
                message += $"{brand.Key} decreased price for {brand.Value}%\n\n";
            }
            MessageBox.Show(message, "Top Brands with Highest Price Decrease between Dec 2021 and Oct 2022");
        }
    }
}
