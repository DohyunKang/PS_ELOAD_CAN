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
            this.lblVoltage_Max = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblVoltage_Min = new System.Windows.Forms.Label();
            this.lblVoltage_Avg = new System.Windows.Forms.Label();
            this.lblCurrent_Max = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrent_Min = new System.Windows.Forms.Label();
            this.lblCurrent_Avg = new System.Windows.Forms.Label();
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
            this.waveformPlot_Max = new NationalInstruments.UI.WaveformPlot();
            this.waveformPlot_Min = new NationalInstruments.UI.WaveformPlot();
            this.waveformPlot_Avg = new NationalInstruments.UI.WaveformPlot();
            this.legend1 = new NationalInstruments.UI.WindowsForms.Legend();
            this.Real = new NationalInstruments.UI.LegendItem();
            this.Max = new NationalInstruments.UI.LegendItem();
            this.Min = new NationalInstruments.UI.LegendItem();
            this.Avg = new NationalInstruments.UI.LegendItem();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.legend1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox5.Controls.Add(this.lblVoltage_Max);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.lblVoltage_Min);
            this.groupBox5.Controls.Add(this.lblVoltage_Avg);
            this.groupBox5.Controls.Add(this.lblCurrent_Max);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.lblCurrent_Min);
            this.groupBox5.Controls.Add(this.lblCurrent_Avg);
            this.groupBox5.Controls.Add(this.StopButton);
            this.groupBox5.Controls.Add(this.ReadButton);
            this.groupBox5.Controls.Add(this.lblVoltage_DAQ);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.lblCurrent_DAQ);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox5.Location = new System.Drawing.Point(13, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(459, 495);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "P/S <----> ELOAD";
            // 
            // lblVoltage_Max
            // 
            this.lblVoltage_Max.AutoSize = true;
            this.lblVoltage_Max.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVoltage_Max.Location = new System.Drawing.Point(356, 82);
            this.lblVoltage_Max.Name = "lblVoltage_Max";
            this.lblVoltage_Max.Size = new System.Drawing.Size(21, 20);
            this.lblVoltage_Max.TabIndex = 55;
            this.lblVoltage_Max.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(268, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 54;
            this.label3.Text = "Max";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(231, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 53;
            this.label7.Text = "Average";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(273, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 20);
            this.label8.TabIndex = 52;
            this.label8.Text = "Min";
            // 
            // lblVoltage_Min
            // 
            this.lblVoltage_Min.AutoSize = true;
            this.lblVoltage_Min.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVoltage_Min.Location = new System.Drawing.Point(356, 187);
            this.lblVoltage_Min.Name = "lblVoltage_Min";
            this.lblVoltage_Min.Size = new System.Drawing.Size(21, 20);
            this.lblVoltage_Min.TabIndex = 51;
            this.lblVoltage_Min.Text = "0";
            // 
            // lblVoltage_Avg
            // 
            this.lblVoltage_Avg.AutoSize = true;
            this.lblVoltage_Avg.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVoltage_Avg.Location = new System.Drawing.Point(356, 135);
            this.lblVoltage_Avg.Name = "lblVoltage_Avg";
            this.lblVoltage_Avg.Size = new System.Drawing.Size(21, 20);
            this.lblVoltage_Avg.TabIndex = 50;
            this.lblVoltage_Avg.Text = "0";
            // 
            // lblCurrent_Max
            // 
            this.lblCurrent_Max.AutoSize = true;
            this.lblCurrent_Max.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrent_Max.Location = new System.Drawing.Point(356, 258);
            this.lblCurrent_Max.Name = "lblCurrent_Max";
            this.lblCurrent_Max.Size = new System.Drawing.Size(21, 20);
            this.lblCurrent_Max.TabIndex = 49;
            this.lblCurrent_Max.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(268, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Max";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(231, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "Average";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(273, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Min";
            // 
            // lblCurrent_Min
            // 
            this.lblCurrent_Min.AutoSize = true;
            this.lblCurrent_Min.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrent_Min.Location = new System.Drawing.Point(356, 365);
            this.lblCurrent_Min.Name = "lblCurrent_Min";
            this.lblCurrent_Min.Size = new System.Drawing.Size(21, 20);
            this.lblCurrent_Min.TabIndex = 45;
            this.lblCurrent_Min.Text = "0";
            // 
            // lblCurrent_Avg
            // 
            this.lblCurrent_Avg.AutoSize = true;
            this.lblCurrent_Avg.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrent_Avg.Location = new System.Drawing.Point(356, 312);
            this.lblCurrent_Avg.Name = "lblCurrent_Avg";
            this.lblCurrent_Avg.Size = new System.Drawing.Size(21, 20);
            this.lblCurrent_Avg.TabIndex = 44;
            this.lblCurrent_Avg.Text = "0";
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StopButton.Location = new System.Drawing.Point(354, 429);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(88, 50);
            this.StopButton.TabIndex = 43;
            this.StopButton.Text = "STOP";
            this.StopButton.UseVisualStyleBackColor = true;
            
            // 
            // ReadButton
            // 
            this.ReadButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ReadButton.Location = new System.Drawing.Point(228, 429);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(88, 50);
            this.ReadButton.TabIndex = 42;
            this.ReadButton.Text = "READ";
            this.ReadButton.UseVisualStyleBackColor = true;
            
            // 
            // lblVoltage_DAQ
            // 
            this.lblVoltage_DAQ.AutoSize = true;
            this.lblVoltage_DAQ.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVoltage_DAQ.Location = new System.Drawing.Point(183, 82);
            this.lblVoltage_DAQ.Name = "lblVoltage_DAQ";
            this.lblVoltage_DAQ.Size = new System.Drawing.Size(21, 20);
            this.lblVoltage_DAQ.TabIndex = 29;
            this.lblVoltage_DAQ.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(24, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "AI VOLTAGE";
            // 
            // lblCurrent_DAQ
            // 
            this.lblCurrent_DAQ.AutoSize = true;
            this.lblCurrent_DAQ.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrent_DAQ.Location = new System.Drawing.Point(183, 258);
            this.lblCurrent_DAQ.Name = "lblCurrent_DAQ";
            this.lblCurrent_DAQ.Size = new System.Drawing.Size(21, 20);
            this.lblCurrent_DAQ.TabIndex = 27;
            this.lblCurrent_DAQ.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(24, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "AI CURRENT";
            // 
            // waveformGraph1
            // 
            this.waveformGraph1.Location = new System.Drawing.Point(494, 80);
            this.waveformGraph1.Name = "waveformGraph1";
            this.waveformGraph1.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot2,
            this.waveformPlot_Max,
            this.waveformPlot_Min,
            this.waveformPlot_Avg});
            this.waveformGraph1.Size = new System.Drawing.Size(550, 289);
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
            // 
            // yAxis2
            // 
            this.yAxis2.Caption = "Current (A)";
            // 
            // waveformPlot_Max
            // 
            this.waveformPlot_Max.LineWidth = 5F;
            this.waveformPlot_Max.XAxis = this.xAxis2;
            this.waveformPlot_Max.YAxis = this.yAxis2;
            // 
            // waveformPlot_Min
            // 
            this.waveformPlot_Min.LineColor = System.Drawing.Color.Yellow;
            this.waveformPlot_Min.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.waveformPlot_Min.LineWidth = 5F;
            this.waveformPlot_Min.XAxis = this.xAxis2;
            this.waveformPlot_Min.YAxis = this.yAxis2;
            // 
            // waveformPlot_Avg
            // 
            this.waveformPlot_Avg.LineColor = System.Drawing.Color.BlueViolet;
            this.waveformPlot_Avg.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            this.waveformPlot_Avg.LineWidth = 5F;
            this.waveformPlot_Avg.XAxis = this.xAxis2;
            this.waveformPlot_Avg.YAxis = this.yAxis2;
            // 
            // legend1
            // 
            this.legend1.Items.AddRange(new NationalInstruments.UI.LegendItem[] {
            this.Real,
            this.Max,
            this.Min,
            this.Avg});
            this.legend1.Location = new System.Drawing.Point(1050, 160);
            this.legend1.Name = "legend1";
            this.legend1.Size = new System.Drawing.Size(127, 126);
            this.legend1.TabIndex = 33;
            // 
            // Real
            // 
            this.Real.Source = this.waveformPlot2;
            this.Real.Text = "Real_Current";
            // 
            // Max
            // 
            this.Max.Source = this.waveformPlot_Max;
            this.Max.Text = "Max_Current";
            // 
            // Min
            // 
            this.Min.Source = this.waveformPlot_Min;
            this.Min.Text = "Min_Current";
            // 
            // Avg
            // 
            this.Avg.Source = this.waveformPlot_Avg;
            this.Avg.Text = "Avg_Current";
            // 
            // Ps_Eload_Current
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 516);
            this.Controls.Add(this.legend1);
            this.Controls.Add(this.waveformGraph1);
            this.Controls.Add(this.groupBox5);
            this.Name = "Ps_Eload_Current";
            this.Text = "+";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.legend1)).EndInit();
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
        private System.Windows.Forms.Label lblCurrent_Max;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrent_Min;
        private System.Windows.Forms.Label lblCurrent_Avg;
        private System.Windows.Forms.Label lblVoltage_Max;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblVoltage_Min;
        private System.Windows.Forms.Label lblVoltage_Avg;
        private NationalInstruments.UI.WaveformPlot waveformPlot_Max;
        private NationalInstruments.UI.WaveformPlot waveformPlot_Min;
        private NationalInstruments.UI.WaveformPlot waveformPlot_Avg;
        private NationalInstruments.UI.WindowsForms.Legend legend1;
        private NationalInstruments.UI.LegendItem Real;
        private NationalInstruments.UI.LegendItem Max;
        private NationalInstruments.UI.LegendItem Min;
        private NationalInstruments.UI.LegendItem Avg;
    }
}