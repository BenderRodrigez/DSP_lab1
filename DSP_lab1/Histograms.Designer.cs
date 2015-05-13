namespace DSP_lab1
{
    partial class Histograms
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.generalLabel = new System.Windows.Forms.Label();
            this.generalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.generalTrack = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generalChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generalTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.Controls.Add(this.generalLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.generalChart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.generalTrack, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 519);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // generalLabel
            // 
            this.generalLabel.AutoSize = true;
            this.generalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalLabel.Location = new System.Drawing.Point(3, 0);
            this.generalLabel.Name = "generalLabel";
            this.generalLabel.Size = new System.Drawing.Size(440, 27);
            this.generalLabel.TabIndex = 1;
            this.generalLabel.Text = "Гистограмма обобщённого признака:";
            this.generalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // generalChart
            // 
            chartArea1.Name = "ChartArea1";
            this.generalChart.ChartAreas.Add(chartArea1);
            this.tableLayoutPanel1.SetColumnSpan(this.generalChart, 3);
            this.generalChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalChart.Location = new System.Drawing.Point(3, 30);
            this.generalChart.Name = "generalChart";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.IsValueShownAsLabel = true;
            series2.Name = "Series2";
            this.generalChart.Series.Add(series1);
            this.generalChart.Series.Add(series2);
            this.generalChart.Size = new System.Drawing.Size(674, 486);
            this.generalChart.TabIndex = 4;
            this.generalChart.Text = "chart1";
            // 
            // generalTrack
            // 
            this.generalTrack.DecimalPlaces = 2;
            this.generalTrack.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.generalTrack.Location = new System.Drawing.Point(449, 3);
            this.generalTrack.Name = "generalTrack";
            this.generalTrack.Size = new System.Drawing.Size(119, 20);
            this.generalTrack.TabIndex = 12;
            this.generalTrack.ThousandsSeparator = true;
            this.generalTrack.ValueChanged += new System.EventHandler(this.generalTrack_ValueChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(577, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 21);
            this.button1.TabIndex = 13;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Histograms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 519);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Histograms";
            this.Text = "Histograms";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generalChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generalTrack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label generalLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart generalChart;
        private System.Windows.Forms.NumericUpDown generalTrack;
        private System.Windows.Forms.Button button1;
    }
}