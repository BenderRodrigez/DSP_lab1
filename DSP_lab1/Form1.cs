﻿using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;

namespace DSP_lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //задаём значения, в менюшках
            windowSizeUD.Value = _windowSize;
            noiseLevelUD.Value = (decimal) _noiseLevel;
            cutFrequencyUD.Value = (decimal) _cutFrequency;
            overlappingUD.Value = (decimal) _overlapping;
        }

        /*-----------Настройки анализа-------------*/
        private float[] _speechFile;
        private WaveFormat _speechFileFormat;
        private int _windowSize = 200;
        private float _noiseLevel = 0.2f;
        private float _cutFrequency = 300.0f;
        private float _overlapping = 0.5f;
        private float[] _generalFeature;
        private byte[] _solution;

        private float _borderValue;
        private bool _borderValueSet = false;
        public float BorderValue
        {
            private get { return _borderValue; }
            set
            {
                _borderValue = value;
                _borderValueSet = true;
                Split();
            }
        }
        /*-----------------------------------------*/

        private void Split()
        {
            _solution = new byte[_generalFeature.Length];
            for (int i = 0; i < _generalFeature.Length; i++)
            {
                if (_generalFeature[i] > _borderValue)
                {
                    _solution[i] = 255;
                }
            }
            ShowResult();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                ReadFile();

                SetInterface();

                //считаем функции
                var energySignal = Energy();
                var corellationOneSignal = CorrelationOne();
                var zerosCrossingSignal = ZerosCrossing();

                //записываем результат в WAV файл
                WriteParameter(energySignal, "energy.wav");
                WriteParameter(corellationOneSignal, "corellation.wav");
                WriteParameter(zerosCrossingSignal, "zeros.wav");

                _generalFeature = new float[energySignal.Length];
                for (int i = 0; i < _generalFeature.Length; i++)
                {
                    _generalFeature[i] = corellationOneSignal[i] * energySignal[i];// / zerosCrossingSignal[i];
                }
                if (!_borderValueSet)
                {
                    var histogramWindow = new Histograms();
                    histogramWindow.Show(this);
                    histogramWindow.GeneralSignal = _generalFeature;
                    _borderValueSet = false;
                }
                else
                {
                    Split();
                }
                WriteToTextFile(_generalFeature, "general.txt");
                WriteToTextFile(energySignal, "energy.txt");
                WriteToTextFile(corellationOneSignal, "corel.txt");
                WriteToTextFile(zerosCrossingSignal, "zeros.txt");
                button1.Enabled = true;
            }
        }

        private void SetInterface()
        {//формируем заголовок формочки
            var tm = new FileInfo(openFileDialog1.FileName);
            Text = string.Concat(tm.Name, "@", _speechFileFormat.SampleRate, "Hz");
            //настраиваем оси
            fileChart.ChartAreas[0].Axes[0].Maximum = _speechFile.Length - 1;
            fileChart.ChartAreas[0].Axes[0].Minimum = 0;

            autocorrelationChart.ChartAreas[0].Axes[0].Maximum = _speechFile.Length - 1;
            autocorrelationChart.ChartAreas[0].Axes[0].Minimum = 0;

            energyChart.ChartAreas[0].Axes[0].Maximum = _speechFile.Length - 1;
            energyChart.ChartAreas[0].Axes[0].Minimum = 0;

            zeroCrossingChart.ChartAreas[0].Axes[0].Maximum = _speechFile.Length - 1;
            zeroCrossingChart.ChartAreas[0].Axes[0].Minimum = 0;
        }

        private void ReadFile()
        {
            using (var reader = new WaveFileReader(openFileDialog1.FileName))
            {
                _speechFile = new float[reader.SampleCount];
                fileChart.Series[0].Points.Clear();
                for (int i = 0; i < reader.SampleCount; i++)
                {//читаем и выводим
                    _speechFile[i] = reader.ReadNextSampleFrame()[0];
                    fileChart.Series[0].Points.AddXY(i, _speechFile[i]);
                }
                _speechFileFormat = reader.WaveFormat;
            }
        }

        private static void WriteToTextFile(float[] signal, string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                foreach (var t in signal)
                {
                    writer.WriteLine(t.ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        /// <summary>
        /// Записывает массив float в wav файл
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="fileName"></param>
        private void WriteParameter(float[] signal, string fileName)
        {
            var max = signal.Max(x=> Math.Abs(x));
            var scaledSignal = signal.Select(x => x/Math.Abs(max)).ToArray();

            using (var writer = new WaveFileWriter(fileName, _speechFileFormat))
            {
                writer.WriteSamples(scaledSignal, 0, signal.Length);
            }
        }

        /// <summary>
        /// Вычисляет значение энергии
        /// </summary>
        /// <returns></returns>
        private float[] Energy()
        {
            var file = new float[_speechFile.Length];
            _speechFile.CopyTo(file,0);
            if (checkBox2.Checked)
            {
                var filter = new Lpf(_cutFrequency, _speechFileFormat.SampleRate);
                file = filter.StartFilter(file);
            }
            var tmp = new float[file.Length - _windowSize];
            energyChart.Series[0].Points.Clear();
            var jump = (int) Math.Round(_windowSize*_overlapping);
            for (int i = 0; i < file.Length - _windowSize; i += jump)
            {
                for (int j = 0; j < _windowSize; j++)
                {
                    tmp[i] += (float) Math.Pow(file[i + j], 2);
                }
                for (int k = i + 1; k < i + jump && k < tmp.Length; k++)
                    tmp[k] = tmp[i];
            }
            energyChart.Series[0].Points.DataBindY(tmp);
            return tmp;
        }

        /// <summary>
        /// Вычисляет автокорреляцию с еденичной задержкой
        /// </summary>
        /// <returns></returns>
        private float[] CorrelationOne()
        {
            var file = new float[_speechFile.Length];
            _speechFile.CopyTo(file, 0);
            var rand = new Random(DateTime.Now.Millisecond);

            var tmp = new float[file.Length - _windowSize];
            autocorrelationChart.Series[0].Points.Clear();

            for (int i = 0; i < file.Length; i+=20)
                file[i] *= (checkBox1.Checked) ? (float) (rand.NextDouble()*_noiseLevel) : 1.0f;

            var jump = (int)Math.Round(_windowSize * _overlapping);
            for (int i = 0; i < file.Length - _windowSize; i += jump)
            {
                double energy = 0.0;
                for (int j = 0; j < _windowSize - 1; j++)
                {
                    energy += Math.Pow(file[i + j], 2);
                    tmp[i] += file[i + j]*file[i + j + 1];
                }
                tmp[i] = (float) (50.0f*(tmp[i]/energy));
                for (int k = i + 1; k < i + jump && k < tmp.Length; k++)
                    tmp[k] = tmp[i];
            }
            var min = tmp.Min();
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] -= min;
            }
            autocorrelationChart.Series[0].Points.DataBindY(tmp);
            return tmp;
        }

        /// <summary>
        /// Вычисляет число переходов через нуль
        /// </summary>
        /// <returns></returns>
        private float[] ZerosCrossing()
        {
            var tmp = new float[_speechFile.Length - _windowSize];
            zeroCrossingChart.Series[0].Points.Clear();

            var jump = (int)Math.Round(_windowSize * _overlapping);
            for (int i = 0; i < _speechFile.Length - _windowSize; i += jump)
            {
                int zeroes = 0;
                for (int j = 0; j < _windowSize - 1; j++)
                {
                    if (_speechFile[i + j]*_speechFile[i + j + 1] < 0.0)
                        zeroes++;
                }
                tmp[i] = (float) (zeroes/2.0*_windowSize);
                for (int k = i + 1; k < i + jump && k < tmp.Length; k++)
                    tmp[k] = tmp[i];
            }
            zeroCrossingChart.Series[0].Points.DataBindY(tmp);
            return tmp;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _windowSize = (int) windowSizeUD.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            noiseLevelUD.Enabled = checkBox1.Checked;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            _noiseLevel = (float) noiseLevelUD.Value;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            cutFrequencyUD.Enabled = checkBox2.Checked;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            _cutFrequency = (float)cutFrequencyUD.Value;
        }

        private void overlappingUD_ValueChanged(object sender, EventArgs e)
        {
            _overlapping = (float) overlappingUD.Value;
        }

        private void fileChart_MouseDown(object sender, MouseEventArgs e)
        {
            var fileGraphics = fileChart.CreateGraphics();
            var energyGraphics = energyChart.CreateGraphics();
            var autocorGraphics = autocorrelationChart.CreateGraphics();
            var zerosGraphics = zeroCrossingChart.CreateGraphics();

            fileGraphics.DrawLine(Pens.Chartreuse, e.X, 0, e.X, fileChart.Width);
            energyGraphics.DrawLine(Pens.Chartreuse, e.X, 0, e.X, energyChart.Width);
            autocorGraphics.DrawLine(Pens.Chartreuse, e.X, 0, e.X, autocorrelationChart.Width);
            zerosGraphics.DrawLine(Pens.Chartreuse, e.X, 0, e.X, zeroCrossingChart.Width);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SetInterface();

            //считаем функции
            var energySignal = Energy();
            var corellationOneSignal = CorrelationOne();
            var zerosCrossingSignal = ZerosCrossing();

            //записываем результат в WAV файл
            WriteParameter(energySignal, "energy.wav");
            WriteParameter(corellationOneSignal, "corellation.wav");
            WriteParameter(zerosCrossingSignal, "zeros.wav");

            _generalFeature = new float[energySignal.Length];
            for (int i = 0; i < _generalFeature.Length; i++)
            {
                _generalFeature[i] = corellationOneSignal[i] * energySignal[i];// / zerosCrossingSignal[i];
            }

            if (!_borderValueSet)
            {
                var histogramWindow = new Histograms();
                histogramWindow.Show(this);
                histogramWindow.GeneralSignal = _generalFeature;
                _borderValueSet = false;
            }
            else
            {
                Split();
            }
        }

        private void ShowResult()
        {
            label2.Text = @"Обобщённый признак:";
            label3.Text = @"Результат распознавания:";

            energyChart.Series[0].Points.Clear();
            energyChart.Series[0].Points.DataBindY(_generalFeature);

            autocorrelationChart.Series[0].Points.Clear();
            autocorrelationChart.Series[0].Points.DataBindY(_solution);
        }
    }
}
