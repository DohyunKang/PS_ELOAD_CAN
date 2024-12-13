namespace PS_ELOAD_Serial
{
    partial class Ps_Eload_Current
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.ReadButton = new System.Windows.Forms.Button();
            this.lblVoltage_DAQ = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrent_DAQ = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.waveformGraph1 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot2 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis2 = new NationalInstruments.UI.XAxis();
            this.yAxis2 = new NationalInstruments.UI.YAxis();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox5.Controls.Add(this.StopButton);
            this.groupBox5.Controls.Add(this.ReadButton);
            this.groupBox5.Controls.Add(this.lblVoltage_DAQ);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.lblCurrent_DAQ);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox5.Location = new System.Drawing.Point(15, 2);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(525, 465);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "P/S <----> ELOAD";
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StopButton.Location = new System.Drawing.Point(395, 371);
            this.StopButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(101, 62);
            this.StopButton.TabIndex = 43;
            this.StopButton.Text = "STOP";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ReadButton
            // 
            this.ReadButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ReadButton.Location = new System.Drawing.Point(251, 371);
            this.ReadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(101, 62);
            this.ReadButton.TabIndex = 42;
            this.ReadButton.Text = "READ";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // lblVoltage_DAQ
            // 
            this.lblVoltage_DAQ.AutoSize = true;
            this.lblVoltage_DAQ.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVoltage_DAQ.Location = new System.Drawing.Point(344, 102);
            this.lblVoltage_DAQ.Name = "lblVoltage_DAQ";
            this.lblVoltage_DAQ.Size = new System.Drawing.Size(47, 47);
            this.lblVoltage_DAQ.TabIndex = 29;
            this.lblVoltage_DAQ.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(27, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 47);
            this.label1.TabIndex = 28;
            this.label1.Text = "AI VOLTAGE";
            // 
            // lblCurrent_DAQ
            // 
            this.lblCurrent_DAQ.AutoSize = true;
            this.lblCurrent_DAQ.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrent_DAQ.Location = new System.Drawing.Point(344, 262);
            this.lblCurrent_DAQ.Name = "lblCurrent_DAQ";
            this.lblCurrent_DAQ.Size = new System.Drawing.Size(47, 47);
            this.lblCurrent_DAQ.TabIndex = 27;
            this.lblCurrent_DAQ.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(19, 262);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(297, 47);
            this.label11.TabIndex = 25;
            this.label11.Text = "AI CURRENT";
            // 
            // waveformGraph1
            // 
            this.waveformGraph1.Location = new System.Drawing.Point(571, 15);
            this.waveformGraph1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.waveformGraph1.Name = "waveformGraph1";
            this.waveformGraph1.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot2});
            this.waveformGraph1.Size = new System.Drawing.Size(742, 452);
            this.waveformGraph1.TabIndex = 32;
            this.waveformGraph1.UseColorGenerator = true;
            this.waveformGraph1.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis2});
            this.waveformGraph1.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis2});
            // 
            // waveformPlot2
            // 
            this.waveformPlot2.LineWidth = 5F;
            this.waveformPlot2.XAxis = this.xAxis2;
            this.waveformPlot2.YAxis = this.yAxis2;
            // 
            // xAxis2
            // 
            this.xAxis2.Caption = "Time";
            this.xAxis2.Mode = NationalInstruments.UI.AxisMode.StripChart;
            this.xAxis2.Range = new NationalInstruments.UI.Range(0D, 100D);
            // 
            // yAxis2
            // 
            this.yAxis2.Caption = "Current (A)";
            // 
            // Ps_Eload_Current
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 496);
            this.Controls.Add(this.waveformGraph1);
            this.Controls.Add(this.groupBox5);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Ps_Eload_Current";
            this.Text = "+";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblCurrent_DAQ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblVoltage_DAQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ReadButton;
        private System.Windows.Forms.Button StopButton;
        private NationalInstruments.UI.WindowsForms.WaveformGraph waveformGraph1;
        private NationalInstruments.UI.WaveformPlot waveformPlot2;
        private NationalInstruments.UI.XAxis xAxis2;
        private NationalInstruments.UI.YAxis yAxis2;
    }
}