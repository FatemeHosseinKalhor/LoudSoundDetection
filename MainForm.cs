using System;
using System.Media;
using System.Windows.Forms;
using NAudio.Wave; // ??????? ?? ???????? NAudio ???? ??? ??? ?? ???????

namespace SoundDetectorApp
{
    public partial class MainForm : Form
    {
        private WaveInEvent waveIn; // ????????? ??? ?? ???????
        private const float Threshold = 0.7f; // ?????? ????? ???
        private bool isListening = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                StartListening(); // ???? ??? ???
                btnToggle.Text = "Stop Listening";
                lblStatus.Text = "Status: Listening...";
            }
            else
            {
                StopListening(); // ???? ??? ???
                btnToggle.Text = "Start Listening";
                lblStatus.Text = "Status: Stopped";
            }

            isListening = !isListening; // ????? ?????
        }

        private void StartListening()
        {
            waveIn = new WaveInEvent();
            waveIn.DataAvailable += OnDataAvailable; // ????? ?? ???????? ????
            waveIn.WaveFormat = new WaveFormat(44100, 1); // ????? ????: 44100 ????? ????
            waveIn.StartRecording(); // ???? ??? ???
        }

        private void StopListening()
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
                waveIn.Dispose(); // ???????? ?????
                waveIn = null;
            }
        }

        private bool hasShownAlert = false;

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            float maxAmplitude = 0; // ?????? ????? ???

            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index]);
                float amplitude = Math.Abs(sample / 40000f); // ?????????? ?????
                if (amplitude > maxAmplitude)
                    maxAmplitude = amplitude;
            }

            this.Invoke((MethodInvoker)(() =>
            {
                lblAmplitude.Text = $"Sound Level: {maxAmplitude:F2}"; // ????? ?????

                if (maxAmplitude > Threshold && !hasShownAlert)
                {
                    hasShownAlert = true;
                    Console.Beep(1000, 500); // ??? ?????
                    MessageBox.Show("It Was Loud", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (maxAmplitude <= Threshold)
                {
                    hasShownAlert = false;
                }
            }));
        }
    }  
}
