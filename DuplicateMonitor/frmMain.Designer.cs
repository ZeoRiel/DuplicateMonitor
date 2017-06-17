namespace DuplicateMonitor
{
    partial class frmMain
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
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkStartStop = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(12, 12);
            this.textBoxOut.Multiline = true;
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(519, 323);
            this.textBoxOut.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(852, 64);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(196, 88);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "button1";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkStartStop
            // 
            this.chkStartStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStartStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStartStop.Location = new System.Drawing.Point(640, 36);
            this.chkStartStop.Name = "chkStartStop";
            this.chkStartStop.Size = new System.Drawing.Size(171, 73);
            this.chkStartStop.TabIndex = 2;
            this.chkStartStop.Text = "Start Monitoring";
            this.chkStartStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStartStop.UseVisualStyleBackColor = true;
            this.chkStartStop.CheckedChanged += new System.EventHandler(this.chkStartStop_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 388);
            this.Controls.Add(this.chkStartStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.textBoxOut);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkStartStop;
    }
}

