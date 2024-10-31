namespace MarketAnalyzer
{
    partial class ProductsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            ProductsGrid = new DataGridView();
            SearchText = new TextBox();
            PricesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            CalculateChangeBtn = new Button();
            biggestIncreaseBtn = new Button();
            biggestDecreaseBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)ProductsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PricesChart).BeginInit();
            SuspendLayout();
            // 
            // ProductsGrid
            // 
            ProductsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductsGrid.Location = new Point(16, 89);
            ProductsGrid.Margin = new Padding(5, 6, 5, 6);
            ProductsGrid.Name = "ProductsGrid";
            ProductsGrid.Size = new Size(931, 715);
            ProductsGrid.TabIndex = 0;
            ProductsGrid.CellDoubleClick += ProductsGrid_CellDoubleClick;
            // 
            // SearchText
            // 
            SearchText.Location = new Point(13, 32);
            SearchText.Margin = new Padding(4, 3, 4, 3);
            SearchText.Name = "SearchText";
            SearchText.Size = new Size(934, 34);
            SearchText.TabIndex = 1;
            SearchText.TextChanged += SearchText_TextChanged;
            // 
            // PricesChart
            // 
            chartArea2.Name = "ChartArea1";
            PricesChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            PricesChart.Legends.Add(legend2);
            PricesChart.Location = new Point(982, 89);
            PricesChart.Name = "PricesChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            PricesChart.Series.Add(series2);
            PricesChart.Size = new Size(678, 716);
            PricesChart.TabIndex = 2;
            PricesChart.Text = "chart1";
            // 
            // CalculateChangeBtn
            // 
            CalculateChangeBtn.Location = new Point(18, 816);
            CalculateChangeBtn.Name = "CalculateChangeBtn";
            CalculateChangeBtn.Size = new Size(396, 53);
            CalculateChangeBtn.TabIndex = 3;
            CalculateChangeBtn.Text = "Calculate change";
            CalculateChangeBtn.UseVisualStyleBackColor = true;
            CalculateChangeBtn.Click += CalculateChangeBtn_Click;
            // 
            // biggestIncreaseBtn
            // 
            biggestIncreaseBtn.Location = new Point(982, 816);
            biggestIncreaseBtn.Name = "biggestIncreaseBtn";
            biggestIncreaseBtn.Size = new Size(317, 53);
            biggestIncreaseBtn.TabIndex = 4;
            biggestIncreaseBtn.Text = "Biggest price Increases";
            biggestIncreaseBtn.UseVisualStyleBackColor = true;
            biggestIncreaseBtn.Click += biggestIncreaseBtn_Click;
            // 
            // biggestDecreaseBtn
            // 
            biggestDecreaseBtn.Location = new Point(1343, 816);
            biggestDecreaseBtn.Name = "biggestDecreaseBtn";
            biggestDecreaseBtn.Size = new Size(317, 53);
            biggestDecreaseBtn.TabIndex = 5;
            biggestDecreaseBtn.Text = "Biggest price decreases";
            biggestDecreaseBtn.UseVisualStyleBackColor = true;
            biggestDecreaseBtn.Click += biggestDecreaseBtn_Click;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1701, 918);
            Controls.Add(biggestDecreaseBtn);
            Controls.Add(biggestIncreaseBtn);
            Controls.Add(CalculateChangeBtn);
            Controls.Add(PricesChart);
            Controls.Add(SearchText);
            Controls.Add(ProductsGrid);
            Font = new Font("Century Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ProductsForm";
            Text = "Products";
            Load += ProductsForm_Load;
            ((System.ComponentModel.ISupportInitialize)ProductsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)PricesChart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView ProductsGrid;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.DataVisualization.Charting.Chart PricesChart;
        private Button CalculateChangeBtn;
        private Button biggestIncreaseBtn;
        private Button biggestDecreaseBtn;
    }
}

