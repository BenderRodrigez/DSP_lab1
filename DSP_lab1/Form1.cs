using System;
using System.IO;
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
            noiseLevelUD.Value = _noiseLevel;
            cutFrequencyUD.Value = (decimal)_cutFrequency;
        }
        /*-----------Настройки анализа-------------*/
        private float[] _speechFile;
        private WaveFormat _speechFileFormat;
        private int _windowSize = 200;
        private int _noiseLevel = 0;
        private float _cutFrequency = 300.0f;
        /*-----------------------------------------*/

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
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
                //формируем заголовок формочки
                var tm = new FileInfo(openFileDialog1.FileName);
                Text = string.Concat(tm.Name, "@", _speechFileFormat.SampleRate, "Hz");
                //считаем функции
                var energySignal = Energy();
                var corellationOneSignal = CorrelationOne();
                var zerosCrossingSignal = ZerosCrossing();
                //записываем результат в WAV файл
                WriteParameter(energySignal, "energy.wav");
                WriteParameter(corellationOneSignal, "corellation.wav");
                WriteParameter(zerosCrossingSignal, "zeros.wav");
            }
        }

        /// <summary>
        /// Записывает массив float в wav файл
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="fileName"></param>
        private void WriteParameter(float[] signal, string fileName)
        {
            using (var writer = new WaveFileWriter(fileName, _speechFileFormat))
            {
                writer.WriteSamples(signal, 0, signal.Length);
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
            for (int i = 0; i < file.Length - _windowSize; i++)
            {
                for (int j = 0; j < _windowSize; j++)
                {
                    tmp[i] += (float)Math.Pow(file[i + j], 2);
                }
                tmp[i] = (float) (30.0f*Math.Log10(tmp[i]/_windowSize));
                energyChart.Series[0].Points.AddXY(i, tmp[i]);
            }
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
            autocorellationChart.Series[0].Points.Clear();

            for (int i = 0; i < file.Length; i++)
                file[i] *= (checkBox1.Checked) ? (float) (rand.NextDouble()*(_noiseLevel/100.0f)) : 1.0f;

            for (int i = 0; i < file.Length - _windowSize; i++)
            {
                double energy = 0;
                for (int j = 0; j < _windowSize - 1; j++)
                {
                    energy += Math.Pow(file[i + j], 2);
                    tmp[i] += file[i + j]*file[i + j + 1];
                }
                tmp[i] = (float) (50.0f*(tmp[i]/energy));
                autocorellationChart.Series[0].Points.AddXY(i, tmp[i]);
            }
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
            for (int i = 0; i < _speechFile.Length - _windowSize; i++)
            {
                int zeroes = 0;
                for (int j = 0; j < _windowSize - 1; j++)
                {
                    if (_speechFile[i + j]*_speechFile[i + j + 1] < 0.0)
                        zeroes++;
                }
                tmp[i] = (float) (zeroes/2.0*_windowSize);
                zeroCrossingChart.Series[0].Points.AddXY(i, tmp[i]);
            }
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
            _noiseLevel = (int) noiseLevelUD.Value;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            cutFrequencyUD.Enabled = checkBox2.Checked;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            _cutFrequency = (float)cutFrequencyUD.Value;
        }
    }
}
