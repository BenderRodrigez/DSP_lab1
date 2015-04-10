namespace DSP_lab1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.fileChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.energyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.autocorellationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.zeroCrossingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.windowSizeUD = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.noiseLevelUD = new System.Windows.Forms.NumericUpDown();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cutFrequencyUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.fileChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.energyChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autocorellationChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zeroCrossingChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowSizeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noiseLevelUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cutFrequencyUD)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(534, 173);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(95, 23);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Открыть файл";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "WAVE файлы|*.wav";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Звуковой файл:";
            // 
            // fileChart
            // 
            chartArea1.Name = "ChartArea1";
            this.fileChart.ChartAreas.Add(chartArea1);
            this.fileChart.Location = new System.Drawing.Point(12, 29);
            this.fileChart.Name = "fileChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.fileChart.Series.Add(series1);
            this.fileChart.Size = new System.Drawing.Size(512, 128);
            this.fileChart.TabIndex = 3;
            this.fileChart.Text = "chart1";
            // 
            // energyChart
            // 
            chartArea2.Name = "ChartArea1";
            this.energyChart.ChartAreas.Add(chartArea2);
            this.energyChart.Location = new System.Drawing.Point(12, 189);
            this.energyChart.Name = "energyChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series1";
            this.energyChart.Series.Add(series2);
            this.energyChart.Size = new System.Drawing.Size(512, 128);
            this.energyChart.TabIndex = 4;
            this.energyChart.Text = "chart2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Энергия сигнала:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Автокорелляция с единичной задержкой:";
            // 
            // autocorellationChart
            // 
            chartArea3.Name = "ChartArea1";
            this.autocorellationChart.ChartAreas.Add(chartArea3);
            this.autocorellationChart.Location = new System.Drawing.Point(12, 352);
            this.autocorellationChart.Name = "autocorellationChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series1";
            this.autocorellationChart.Series.Add(series3);
            this.autocorellationChart.Size = new System.Drawing.Size(512, 128);
            this.autocorellationChart.TabIndex = 6;
            this.autocorellationChart.Text = "chart3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 500);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Число переходов через \"0\":";
            // 
            // zeroCrossingChart
            // 
            chartArea4.Name = "ChartArea1";
            this.zeroCrossingChart.ChartAreas.Add(chartArea4);
            this.zeroCrossingChart.Location = new System.Drawing.Point(12, 516);
            this.zeroCrossingChart.Name = "zeroCrossingChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Series1";
            this.zeroCrossingChart.Series.Add(series4);
            this.zeroCrossingChart.Size = new System.Drawing.Size(512, 128);
            this.zeroCrossingChart.TabIndex = 8;
            this.zeroCrossingChart.Text = "chart4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Интервал анализа:";
            // 
            // windowSizeUD
            // 
            this.windowSizeUD.Location = new System.Drawing.Point(534, 25);
            this.windowSizeUD.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.windowSizeUD.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.windowSizeUD.Name = "windowSizeUD";
            this.windowSizeUD.Size = new System.Drawing.Size(120, 20);
            this.windowSizeUD.TabIndex = 11;
            this.windowSizeUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.windowSizeUD.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(534, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Предзашумление";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // noiseLevelUD
            // 
            this.noiseLevelUD.Enabled = false;
            this.noiseLevelUD.Location = new System.Drawing.Point(534, 85);
            this.noiseLevelUD.Name = "noiseLevelUD";
            this.noiseLevelUD.Size = new System.Drawing.Size(120, 20);
            this.noiseLevelUD.TabIndex = 13;
            this.noiseLevelUD.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(534, 112);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(53, 17);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.Text = "ФНЧ";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // cutFrequencyUD
            // 
            this.cutFrequencyUD.Enabled = false;
            this.cutFrequencyUD.Location = new System.Drawing.Point(534, 136);
            this.cutFrequencyUD.Maximum = new decimal(new int[] {
            5512,
            0,
            0,
            0});
            this.cutFrequencyUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cutFrequencyUD.Name = "cutFrequencyUD";
            this.cutFrequencyUD.Size = new System.Drawing.Size(120, 20);
            this.cutFrequencyUD.TabIndex = 15;
            this.cutFrequencyUD.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.cutFrequencyUD.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 661);
            this.Controls.Add(this.cutFrequencyUD);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.noiseLevelUD);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.windowSizeUD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.zeroCrossingChart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.autocorellationChart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.energyChart);
            this.Controls.Add(this.fileChart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openFileButton);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.energyChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autocorellationChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zeroCrossingChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowSizeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noiseLevelUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cutFrequencyUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart fileChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart energyChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart autocorellationChart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart zeroCrossingChart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown windowSizeUD;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown noiseLevelUD;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.NumericUpDown cutFrequencyUD;
    }
}

