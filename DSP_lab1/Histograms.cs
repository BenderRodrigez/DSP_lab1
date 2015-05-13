using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DSP_lab1
{
    public partial class Histograms : Form
    {
        private const int IntervalNumber = 10;

        private float[] _generalSignal;
        public float[] GeneralSignal
        {
            set
            {
                _generalSignal = value;
                var maxVal = _generalSignal.Max();
                var minVal = _generalSignal.Min();
                var avgVal = _generalSignal.Average();
                generalTrack.Maximum = (decimal)maxVal;
                generalTrack.Minimum = (decimal)minVal;
                generalTrack.Value = (decimal)avgVal;
                generalLabel.Text = @"Гистограмма обобщённого пр-ка (порог " + avgVal + @"):";
                SetGeneralHistogramm();
            }
        }

        public Histograms()
        {
            InitializeComponent();
        }

        private void SetGeneralHistogramm()
        {
            var border = (float)generalTrack.Value;
            var passSpans = new int[IntervalNumber+1];
            var declineSpans = new int[IntervalNumber+1];
            var max = _generalSignal.Max();
            var min = _generalSignal.Min();
            var spanSize = Math.Abs(max - min) / (IntervalNumber);
            generalLabel.Text = @"Гистограмма обобщённого пр-ка (порог " + border + @"):";

            for (int i = 0; i < _generalSignal.Length; i++)
            {
                var index = (int)Math.Round(Math.Abs(_generalSignal[i] - min) / spanSize);
                passSpans[index] = (_generalSignal[i] > border)
                    ? passSpans[index] + 1
                    : passSpans[index];
                declineSpans[index] = (_generalSignal[i] <= border)
                    ? declineSpans[index] + 1
                    : declineSpans[index];
            }

            generalChart.Series[0].Points.Clear();
            generalChart.Series[1].Points.Clear();
            for (int i = 1; i < passSpans.Length; i++)
            {
                if (passSpans[i] > 0)
                    generalChart.Series[0].Points.Add(new DataPoint(i * spanSize, passSpans[i]/(double)_generalSignal.Length));
                if (declineSpans[i] > 0)
                    generalChart.Series[1].Points.Add(new DataPoint(i * spanSize, declineSpans[i] / (double)_generalSignal.Length));
            }
        }

        private void generalTrack_ValueChanged(object sender, EventArgs e)
        {
            SetGeneralHistogramm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var owner = (Form1) (Owner);
            owner.BorderValue = (float) generalTrack.Value;
        }
    }
}
