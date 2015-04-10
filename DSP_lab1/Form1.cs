using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace DSP_lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Value = _windowSize;
        }

        private float[] _speechFile;
        private WaveFormat _speechFileFormat;
        private int _windowSize = 200;

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                using (var reader = new WaveFileReader(openFileDialog1.FileName))
                {
                    _speechFile = new float[reader.SampleCount];
                    chart1.Series[0].Points.Clear();
                    for (int i = 0; i < reader.SampleCount; i++)
                    {
                        _speechFile[i] = reader.ReadNextSampleFrame()[0];
                        chart1.Series[0].Points.AddXY(i, _speechFile[i]);
                    }
                    _speechFileFormat = reader.WaveFormat;
                }

                var tm = new FileInfo(openFileDialog1.FileName);
                Text = string.Concat(tm.Name, "@", _speechFileFormat.SampleRate, "Hz");

                var energySignal = Energy();
                var corellationOneSignal = CorrelationOne();
                var zerosCrossingSignal = ZerosCrossing();

                WriteParameter(energySignal, "energy.wav");
                WriteParameter(corellationOneSignal, "corellation.wav");
                WriteParameter(zerosCrossingSignal, "zeros.wav");
            }
        }

        private void WriteParameter(float[] signal, string fileName)
        {
            using (var writer = new WaveFileWriter(fileName, _speechFileFormat))
            {
                writer.WriteSamples(signal, 0, signal.Length);
            }
        }

        private float[] Energy()
        {
            var tmp = new float[_speechFile.Length - _windowSize];
            chart2.Series[0].Points.Clear();
            for (int i = 0; i < _speechFile.Length - _windowSize; i++)
            {
                for (int j = 0; j < _windowSize; j++)
                {
                    tmp[i] += (float)Math.Pow(_speechFile[i + j], 2);
                }
                tmp[i] = (float)(30.0f*Math.Log10(tmp[i]/_windowSize));
                chart2.Series[0].Points.AddXY(i, tmp[i]);
            }
            return tmp;
        }

        private float[] CorrelationOne()
        {
            var tmp = new float[_speechFile.Length - _windowSize];
            chart3.Series[0].Points.Clear();
            for (int i = 0; i < _speechFile.Length - _windowSize; i++)
            {
                double energy = 0;
                for (int j = 0; j < _windowSize - 1; j++)
                {
                    energy += Math.Pow(_speechFile[i + j], 2);
                    tmp[i] += _speechFile[i]*_speechFile[j + 1];
                }
                tmp[i] = (float)(50.0f*(tmp[i]/energy));
                chart3.Series[0].Points.AddXY(i, tmp[i]);
            }
            return tmp;
        }

        private float[] ZerosCrossing()
        {
            var tmp = new float[_speechFile.Length - _windowSize];
            chart4.Series[0].Points.Clear();
            for (int i = 0; i < _speechFile.Length - _windowSize; i++)
            {
                int zeroes = 0;
                for (int j = 0; j < _windowSize - 1; j++)
                {
                    if (_speechFile[i + j]*_speechFile[i + j + 1] < 0.0)
                        zeroes++;
                }
                tmp[i] = (float) (zeroes/2.0*_windowSize);
                chart4.Series[0].Points.AddXY(i, tmp[i]);
            }
            return tmp;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _windowSize = (int)numericUpDown1.Value;
        }
    }
}
