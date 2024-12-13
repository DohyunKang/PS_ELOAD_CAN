namespace PS_ELOAD_Serial
{
    partial class ProgramForm2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxProgramName2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk2;
        private System.Windows.Forms.Button buttonCancel2;

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
            this.textBoxProgramName2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk2 = new System.Windows.Forms.Button();
            this.buttonCancel2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxProgramName2
            // 
            this.textBoxProgramName2.Location = new System.Drawing.Point(131, 30);
            this.textBoxProgramName2.Name = "textBoxProgramName2";
            this.textBoxProgramName2.Size = new System.Drawing.Size(200, 22);
            this.textBoxProgramName2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Program Name:";
            // 
            // buttonOk2
            // 
            this.buttonOk2.Location = new System.Drawing.Point(90, 84);
            this.buttonOk2.Name = "buttonOk2";
            this.buttonOk2.Size = new System.Drawing.Size(100, 23);
            this.buttonOk2.TabIndex = 2;
            this.buttonOk2.Text = "OK";
            this.buttonOk2.UseVisualStyleBackColor = true;
            this.buttonOk2.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel2
            // 
            this.buttonCancel2.Location = new System.Drawing.Point(210, 84);
            this.buttonCancel2.Name = "buttonCancel2";
            this.buttonCancel2.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel2.TabIndex = 3;
            this.buttonCancel2.Text = "Cancel";
            this.buttonCancel2.UseVisualStyleBackColor = true;
            this.buttonCancel2.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ProgramForm2
            // 
            this.ClientSize = new System.Drawing.Size(398, 150);
            this.Controls.Add(this.buttonCancel2);
            this.Controls.Add(this.buttonOk2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProgramName2);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProgramForm2";
            this.Text = "Create New Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
