namespace SoundDetectorApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label lblStatus; // ????? ??? ???

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // ???????? ????? ???
            }
            base.Dispose(disposing);
        }
        private System.Windows.Forms.Label lblAmplitude;
        private void InitializeComponent()
        {
            // ????? ????? ????? ???
            this.lblAmplitude = new System.Windows.Forms.Label();
            this.lblAmplitude.AutoSize = true;
            this.lblAmplitude.Location = new System.Drawing.Point(30, 120);
            this.lblAmplitude.Name = "lblAmplitude";
            this.lblAmplitude.Size = new System.Drawing.Size(140, 17);
            this.lblAmplitude.TabIndex = 2;
            this.lblAmplitude.Text = "Sound Level: 0.00";

            this.Controls.Add(this.lblAmplitude);

            // ???? ????/???? 
            this.btnToggle = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            this.btnToggle.Location = new System.Drawing.Point(30, 30);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(120, 40);
            this.btnToggle.TabIndex = 0;
            this.btnToggle.Text = "Start Listening";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.BtnToggle_Click);

            // ????? ?????
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 90);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(111, 17);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status: Stopped";

            // ??????? ??? ???
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnToggle);
            this.Name = "MainForm";
            this.Text = "Sound Detector";
            this.ResumeLayout(false);
            this.PerformLayout();

            // ?????? ??? ??? ? ????????
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30); // ??? ????????
            this.Font = new System.Drawing.Font("Segoe UI", 10); // ???? ???????
            this.ForeColor = System.Drawing.Color.White; // ??? ????????

            // ?????? ????
            this.btnToggle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnToggle.ForeColor = System.Drawing.Color.White;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.FlatAppearance.BorderSize = 0;

            // ??? ????????
            this.lblStatus.ForeColor = System.Drawing.Color.Gold;
            this.lblAmplitude.ForeColor = System.Drawing.Color.LightSkyBlue;

        }
    }
}
