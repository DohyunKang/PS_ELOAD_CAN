namespace PS_ELOAD_Serial
{
    partial class Main
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
            this.ELoad = new System.Windows.Forms.GroupBox();
            this.SequenceRun = new System.Windows.Forms.Button();
            this.periodNumeric = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.ApplyButton3 = new System.Windows.Forms.Button();
            this.ModeButton = new System.Windows.Forms.Button();
            this.switch1 = new NationalInstruments.UI.WindowsForms.Switch();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CRButton = new System.Windows.Forms.RadioButton();
            this.CVButton = new System.Windows.Forms.RadioButton();
            this.CCButton = new System.Windows.Forms.RadioButton();
            this.ParameterButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PowerSupply = new System.Windows.Forms.GroupBox();
            this.ApplyButton2 = new System.Windows.Forms.Button();
            this.PSOCP = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.PSOVP = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.OutPutButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.PSCurrent = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.PSVoltage = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.switch2 = new NationalInstruments.UI.WindowsForms.Switch();
            this.waveformGraph2 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot2 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis2 = new NationalInstruments.UI.XAxis();
            this.yAxis2 = new NationalInstruments.UI.YAxis();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOCP = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblOVP = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.lblPV = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.PS_LED = new NationalInstruments.UI.WindowsForms.Led();
            this.E_LED = new NationalInstruments.UI.WindowsForms.Led();
            this.PSELOADCURRENT = new System.Windows.Forms.Button();
            this.ELoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.periodNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switch1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.PowerSupply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PSOCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOVP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSVoltage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PS_LED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.E_LED)).BeginInit();
            this.SuspendLayout();
            // 
            // ELoad
            // 
            this.ELoad.Controls.Add(this.SequenceRun);
            this.ELoad.Controls.Add(this.periodNumeric);
            this.ELoad.Controls.Add(this.label20);
            this.ELoad.Controls.Add(this.LoadButton);
            this.ELoad.Controls.Add(this.ApplyButton3);
            this.ELoad.Controls.Add(this.ModeButton);
            this.ELoad.Controls.Add(this.switch1);
            this.ELoad.Controls.Add(this.label8);
            this.ELoad.Controls.Add(this.comboBox1);
            this.ELoad.Controls.Add(this.label1);
            this.ELoad.Controls.Add(this.label2);
            this.ELoad.Controls.Add(this.CRButton);
            this.ELoad.Controls.Add(this.CVButton);
            this.ELoad.Controls.Add(this.CCButton);
            this.ELoad.Location = new System.Drawing.Point(20, 38);
            this.ELoad.Name = "ELoad";
            this.ELoad.Size = new System.Drawing.Size(232, 454);
            this.ELoad.TabIndex = 1;
            this.ELoad.TabStop = false;
            this.ELoad.Text = "ELoad";
            // 
            // SequenceRun
            // 
            this.SequenceRun.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SequenceRun.Location = new System.Drawing.Point(127, 138);
            this.SequenceRun.Name = "SequenceRun";
            this.SequenceRun.Size = new System.Drawing.Size(99, 39);
            this.SequenceRun.TabIndex = 46;
            this.SequenceRun.Text = "Sequence Run/Stop";
            this.SequenceRun.UseVisualStyleBackColor = true;
            this.SequenceRun.Click += new System.EventHandler(this.SequenceRun_Click);
            // 
            // periodNumeric
            // 
            this.periodNumeric.DecimalPlaces = 2;
            this.periodNumeric.Location = new System.Drawing.Point(55, 235);
            this.periodNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.periodNumeric.Name = "periodNumeric";
            this.periodNumeric.Size = new System.Drawing.Size(120, 21);
            this.periodNumeric.TabIndex = 45;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(45, 203);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(137, 12);
            this.label20.TabIndex = 45;
            this.label20.Text = "Eload parameter period";
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LoadButton.Location = new System.Drawing.Point(142, 273);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 39);
            this.LoadButton.TabIndex = 39;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // ApplyButton3
            // 
            this.ApplyButton3.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ApplyButton3.Location = new System.Drawing.Point(16, 273);
            this.ApplyButton3.Name = "ApplyButton3";
            this.ApplyButton3.Size = new System.Drawing.Size(75, 39);
            this.ApplyButton3.TabIndex = 38;
            this.ApplyButton3.Text = "Apply";
            this.ApplyButton3.UseVisualStyleBackColor = true;
            this.ApplyButton3.Click += new System.EventHandler(this.ApplyButton3_Click);
            // 
            // ModeButton
            // 
            this.ModeButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ModeButton.Location = new System.Drawing.Point(6, 138);
            this.ModeButton.Name = "ModeButton";
            this.ModeButton.Size = new System.Drawing.Size(99, 39);
            this.ModeButton.TabIndex = 39;
            this.ModeButton.Text = "Sequence Mode";
            this.ModeButton.UseVisualStyleBackColor = true;
            // 
            // switch1
            // 
            this.switch1.Location = new System.Drawing.Point(55, 335);
            this.switch1.Name = "switch1";
            this.switch1.Size = new System.Drawing.Size(120, 85);
            this.switch1.SwitchStyle = NationalInstruments.UI.SwitchStyle.HorizontalSlide3D;
            this.switch1.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "COM PORT";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(96, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "Connect ( ON / OFF )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "< Mode >";
            // 
            // CRButton
            // 
            this.CRButton.AutoSize = true;
            this.CRButton.Location = new System.Drawing.Point(152, 58);
            this.CRButton.Name = "CRButton";
            this.CRButton.Size = new System.Drawing.Size(40, 16);
            this.CRButton.TabIndex = 5;
            this.CRButton.Text = "CR";
            this.CRButton.UseVisualStyleBackColor = true;
            this.CRButton.CheckedChanged += new System.EventHandler(this.CRButton_CheckedChanged);
            // 
            // CVButton
            // 
            this.CVButton.AutoSize = true;
            this.CVButton.Location = new System.Drawing.Point(94, 58);
            this.CVButton.Name = "CVButton";
            this.CVButton.Size = new System.Drawing.Size(40, 16);
            this.CVButton.TabIndex = 4;
            this.CVButton.Text = "CV";
            this.CVButton.UseVisualStyleBackColor = true;
            // 
            // CCButton
            // 
            this.CCButton.AutoSize = true;
            this.CCButton.Location = new System.Drawing.Point(35, 58);
            this.CCButton.Name = "CCButton";
            this.CCButton.Size = new System.Drawing.Size(41, 16);
            this.CCButton.TabIndex = 3;
            this.CCButton.Text = "CC";
            this.CCButton.UseVisualStyleBackColor = true;
            this.CCButton.CheckedChanged += new System.EventHandler(this.CCButton_CheckedChanged);
            // 
            // ParameterButton
            // 
            this.ParameterButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ParameterButton.Location = new System.Drawing.Point(450, 254);
            this.ParameterButton.Margin = new System.Windows.Forms.Padding(0);
            this.ParameterButton.Name = "ParameterButton";
            this.ParameterButton.Size = new System.Drawing.Size(99, 39);
            this.ParameterButton.TabIndex = 40;
            this.ParameterButton.Text = "Parameter Load";
            this.ParameterButton.UseVisualStyleBackColor = true;
            this.ParameterButton.Click += new System.EventHandler(this.ParameterButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox5.Controls.Add(this.lblCurrent);
            this.groupBox5.Controls.Add(this.lblVoltage);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.ParameterButton);
            this.groupBox5.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox5.Location = new System.Drawing.Point(328, 138);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(565, 310);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ELoad Parameter";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrent.Location = new System.Drawing.Point(248, 195);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(38, 37);
            this.lblCurrent.TabIndex = 27;
            this.lblCurrent.Text = "0";
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVoltage.Location = new System.Drawing.Point(248, 103);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(38, 37);
            this.lblVoltage.TabIndex = 26;
            this.lblVoltage.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(13, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(213, 37);
            this.label11.TabIndex = 25;
            this.label11.Text = "E/L Current";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(10, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(216, 37);
            this.label12.TabIndex = 24;
            this.label12.Text = "E/L Voltage";
            // 
            // PowerSupply
            // 
            this.PowerSupply.Controls.Add(this.ApplyButton2);
            this.PowerSupply.Controls.Add(this.PSOCP);
            this.PowerSupply.Controls.Add(this.label7);
            this.PowerSupply.Controls.Add(this.PSOVP);
            this.PowerSupply.Controls.Add(this.label15);
            this.PowerSupply.Controls.Add(this.OutPutButton);
            this.PowerSupply.Controls.Add(this.ApplyButton);
            this.PowerSupply.Controls.Add(this.PSCurrent);
            this.PowerSupply.Controls.Add(this.label6);
            this.PowerSupply.Controls.Add(this.PSVoltage);
            this.PowerSupply.Controls.Add(this.label3);
            this.PowerSupply.Controls.Add(this.label4);
            this.PowerSupply.Controls.Add(this.switch2);
            this.PowerSupply.Location = new System.Drawing.Point(20, 552);
            this.PowerSupply.Name = "PowerSupply";
            this.PowerSupply.Size = new System.Drawing.Size(232, 463);
            this.PowerSupply.TabIndex = 27;
            this.PowerSupply.TabStop = false;
            this.PowerSupply.Text = "PowerSupply";
            // 
            // ApplyButton2
            // 
            this.ApplyButton2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ApplyButton2.Location = new System.Drawing.Point(78, 289);
            this.ApplyButton2.Name = "ApplyButton2";
            this.ApplyButton2.Size = new System.Drawing.Size(75, 39);
            this.ApplyButton2.TabIndex = 37;
            this.ApplyButton2.Text = "Apply";
            this.ApplyButton2.UseVisualStyleBackColor = true;
            // 
            // PSOCP
            // 
            this.PSOCP.DecimalPlaces = 2;
            this.PSOCP.Location = new System.Drawing.Point(97, 240);
            this.PSOCP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PSOCP.Name = "PSOCP";
            this.PSOCP.Size = new System.Drawing.Size(120, 21);
            this.PSOCP.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 35;
            this.label7.Text = "OCP (A)";
            // 
            // PSOVP
            // 
            this.PSOVP.DecimalPlaces = 2;
            this.PSOVP.Location = new System.Drawing.Point(97, 198);
            this.PSOVP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PSOVP.Name = "PSOVP";
            this.PSOVP.Size = new System.Drawing.Size(120, 21);
            this.PSOVP.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 200);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "OVP (V)";
            // 
            // OutPutButton
            // 
            this.OutPutButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.OutPutButton.Location = new System.Drawing.Point(142, 130);
            this.OutPutButton.Name = "OutPutButton";
            this.OutPutButton.Size = new System.Drawing.Size(75, 39);
            this.OutPutButton.TabIndex = 32;
            this.OutPutButton.Text = "OutPut";
            this.OutPutButton.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ApplyButton.Location = new System.Drawing.Point(16, 130);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 39);
            this.ApplyButton.TabIndex = 31;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            // 
            // PSCurrent
            // 
            this.PSCurrent.DecimalPlaces = 2;
            this.PSCurrent.Location = new System.Drawing.Point(97, 81);
            this.PSCurrent.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PSCurrent.Name = "PSCurrent";
            this.PSCurrent.Size = new System.Drawing.Size(120, 21);
            this.PSCurrent.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "Current (A)";
            // 
            // PSVoltage
            // 
            this.PSVoltage.DecimalPlaces = 2;
            this.PSVoltage.Location = new System.Drawing.Point(97, 39);
            this.PSVoltage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PSVoltage.Name = "PSVoltage";
            this.PSVoltage.Size = new System.Drawing.Size(120, 21);
            this.PSVoltage.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Voltage (V)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 438);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "Connect ( ON / OFF )";
            // 
            // switch2
            // 
            this.switch2.Location = new System.Drawing.Point(55, 350);
            this.switch2.Name = "switch2";
            this.switch2.Size = new System.Drawing.Size(120, 85);
            this.switch2.SwitchStyle = NationalInstruments.UI.SwitchStyle.HorizontalSlide3D;
            this.switch2.TabIndex = 25;
            // 
            // waveformGraph2
            // 
            this.waveformGraph2.Location = new System.Drawing.Point(294, 601);
            this.waveformGraph2.Name = "waveformGraph2";
            this.waveformGraph2.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot2});
            this.waveformGraph2.Size = new System.Drawing.Size(649, 254);
            this.waveformGraph2.TabIndex = 31;
            this.waveformGraph2.UseColorGenerator = true;
            this.waveformGraph2.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis2});
            this.waveformGraph2.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
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
            this.xAxis2.Mode = NationalInstruments.UI.AxisMode.Fixed;
            this.xAxis2.Range = new NationalInstruments.UI.Range(0D, 100D);
            // 
            // yAxis2
            // 
            this.yAxis2.Caption = "Volt (V)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOCP);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.lblOVP);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.lblPC);
            this.groupBox1.Controls.Add(this.lblPV);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(277, 891);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 96);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PowerSupply Parameter";
            // 
            // lblOCP
            // 
            this.lblOCP.AutoSize = true;
            this.lblOCP.Location = new System.Drawing.Point(461, 67);
            this.lblOCP.Name = "lblOCP";
            this.lblOCP.Size = new System.Drawing.Size(11, 12);
            this.lblOCP.TabIndex = 32;
            this.lblOCP.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(358, 67);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 12);
            this.label19.TabIndex = 31;
            this.label19.Text = "P/S OCP";
            // 
            // lblOVP
            // 
            this.lblOVP.AutoSize = true;
            this.lblOVP.Location = new System.Drawing.Point(228, 67);
            this.lblOVP.Name = "lblOVP";
            this.lblOVP.Size = new System.Drawing.Size(11, 12);
            this.lblOVP.TabIndex = 30;
            this.lblOVP.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(121, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 12);
            this.label17.TabIndex = 29;
            this.label17.Text = "P/S OVP";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Location = new System.Drawing.Point(461, 28);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(11, 12);
            this.lblPC.TabIndex = 27;
            this.lblPC.Text = "0";
            // 
            // lblPV
            // 
            this.lblPV.AutoSize = true;
            this.lblPV.Location = new System.Drawing.Point(227, 28);
            this.lblPV.Name = "lblPV";
            this.lblPV.Size = new System.Drawing.Size(11, 12);
            this.lblPV.TabIndex = 26;
            this.lblPV.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(358, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 12);
            this.label13.TabIndex = 25;
            this.label13.Text = "P/S Current";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(120, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 12);
            this.label14.TabIndex = 24;
            this.label14.Text = "P/S Voltage";
            // 
            // PS_LED
            // 
            this.PS_LED.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.PS_LED.Location = new System.Drawing.Point(277, 552);
            this.PS_LED.Name = "PS_LED";
            this.PS_LED.Size = new System.Drawing.Size(64, 64);
            this.PS_LED.TabIndex = 38;
            // 
            // E_LED
            // 
            this.E_LED.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.E_LED.Location = new System.Drawing.Point(345, 68);
            this.E_LED.Name = "E_LED";
            this.E_LED.Size = new System.Drawing.Size(64, 64);
            this.E_LED.TabIndex = 39;
            // 
            // PSELOADCURRENT
            // 
            this.PSELOADCURRENT.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PSELOADCURRENT.Location = new System.Drawing.Point(547, 503);
            this.PSELOADCURRENT.Margin = new System.Windows.Forms.Padding(0);
            this.PSELOADCURRENT.Name = "PSELOADCURRENT";
            this.PSELOADCURRENT.Size = new System.Drawing.Size(141, 50);
            this.PSELOADCURRENT.TabIndex = 41;
            this.PSELOADCURRENT.Text = "P/S <-> ELOAD CURRENT";
            this.PSELOADCURRENT.UseVisualStyleBackColor = true;
            this.PSELOADCURRENT.Click += new System.EventHandler(this.PSELOADCURRENT_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 844);
            this.Controls.Add(this.PSELOADCURRENT);
            this.Controls.Add(this.E_LED);
            this.Controls.Add(this.PS_LED);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.waveformGraph2);
            this.Controls.Add(this.PowerSupply);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.ELoad);
            this.Name = "Main";
            this.ELoad.ResumeLayout(false);
            this.ELoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.periodNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switch1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.PowerSupply.ResumeLayout(false);
            this.PowerSupply.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PSOCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOVP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSVoltage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PS_LED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.E_LED)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ELoad;
        private System.Windows.Forms.RadioButton CVButton;
        private System.Windows.Forms.RadioButton CCButton; 
        private System.Windows.Forms.RadioButton CRButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.GroupBox PowerSupply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private NationalInstruments.UI.WindowsForms.Switch switch2;
        private NationalInstruments.UI.WindowsForms.WaveformGraph waveformGraph2;
        private NationalInstruments.UI.WaveformPlot waveformPlot2;
        private NationalInstruments.UI.XAxis xAxis2;
        private NationalInstruments.UI.YAxis yAxis2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lblPV;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown PSCurrent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown PSVoltage;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button OutPutButton;
        private System.Windows.Forms.Button ApplyButton2;
        private System.Windows.Forms.NumericUpDown PSOCP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown PSOVP;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblOCP;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblOVP;
        private System.Windows.Forms.Label label17;
        private NationalInstruments.UI.WindowsForms.Led PS_LED;
        private NationalInstruments.UI.WindowsForms.Switch switch1;
        private System.Windows.Forms.Button ModeButton;
        private System.Windows.Forms.Button ParameterButton;
        private NationalInstruments.UI.WindowsForms.Led E_LED;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button ApplyButton3;
        private System.Windows.Forms.NumericUpDown periodNumeric;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button SequenceRun;
        private System.Windows.Forms.Button PSELOADCURRENT;
    }
}

