using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private float[] _speechFile;
        private WaveFormat _speechFileFormat;
        private int windowSize = 200;

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                using (var reader = new WaveFileReader(openFileDialog1.FileName))
                {
                    var file = new float[reader.SampleCount];
                    chart1.Series[0].Points.Clear();
                    for (int i = 0; i < reader.SampleCount; i++)
                    {
                        file[i] = reader.ReadNextSampleFrame()[0];
                        chart1.Series[0].Points.AddXY(i, file[i]);
                    }
                    _speechFile = file;
                    _speechFileFormat = reader.WaveFormat;
                }

                Energy();
                CorrelationOne();
                ZerosCrossing();
            }
        }

        private float[] Energy()
        {
            var tmp = new float[_speechFile.Length - windowSize];
            chart2.Series[0].Points.Clear();
            for (int i = 0; i < _speechFile.Length - windowSize; i++)
            {
                for (int j = 0; j < windowSize; j++)
                {
                    tmp[i] += (float)Math.Pow(_speechFile[i + j], 2);
                }
                tmp[i] = (float)(30.0f*Math.Log10(tmp[i]/windowSize));
                chart2.Series[0].Points.AddXY(i, tmp[i]);
            }
            return tmp;
        }

        private float[] CorrelationOne()
        {
            var tmp = new float[_speechFile.Length - windowSize];
            chart3.Series[0].Points.Clear();
            for (int i = 0; i < _speechFile.Length - windowSize; i++)
            {
                double energy = 0;
                for (int j = 0; j < windowSize - 1; j++)
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
            var tmp = new float[_speechFile.Length - windowSize];
            chart4.Series[0].Points.Clear();
            for (int i = 0; i < _speechFile.Length - windowSize; i++)
            {
                int zeroes = 0;
                for (int j = 0; j < windowSize - 1; j++)
                {
                    if (_speechFile[i + j]*_speechFile[i + j + 1] < 0.0)
                        zeroes++;
                }
                tmp[i] = (float) (zeroes/2.0*windowSize);
                chart4.Series[0].Points.AddXY(i, tmp[i]);
            }
            return tmp;
        }
    }
}
