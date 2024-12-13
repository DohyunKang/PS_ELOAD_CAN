namespace PS_ELOAD_Serial
{
    partial class Sequence2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView2;  // OK 버튼 추가

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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.CreateButton2 = new System.Windows.Forms.Button();
            this.DeleteButton2 = new System.Windows.Forms.Button();
            this.OptionButton2 = new System.Windows.Forms.Button();
            this.SelectButton2 = new System.Windows.Forms.Button();
            this.LoopButton2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 14);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(600, 350);
            this.dataGridView2.TabIndex = 0;
            // 
            // CreateButton2
            // 
            this.CreateButton2.Location = new System.Drawing.Point(391, 385);
            this.CreateButton2.Name = "CreateButton2";
            this.CreateButton2.Size = new System.Drawing.Size(100, 35);
            this.CreateButton2.TabIndex = 2;
            this.CreateButton2.Text = "Create";
            this.CreateButton2.UseVisualStyleBackColor = true;
            // 
            // DeleteButton2
            // 
            this.DeleteButton2.Location = new System.Drawing.Point(512, 385);
            this.DeleteButton2.Name = "DeleteButton2";
            this.DeleteButton2.Size = new System.Drawing.Size(100, 35);
            this.DeleteButton2.TabIndex = 3;
            this.DeleteButton2.Text = "Delete";
            this.DeleteButton2.UseVisualStyleBackColor = true;
            // 
            // OptionButton2
            // 
            this.OptionButton2.Location = new System.Drawing.Point(12, 385);
            this.OptionButton2.Name = "OptionButton2";
            this.OptionButton2.Size = new System.Drawing.Size(100, 35);
            this.OptionButton2.TabIndex = 4;
            this.OptionButton2.Text = "Option";
            this.OptionButton2.UseVisualStyleBackColor = true;
            // 
            // SelectButton2
            // 
            this.SelectButton2.Location = new System.Drawing.Point(132, 385);
            this.SelectButton2.Name = "SelectButton2";
            this.SelectButton2.Size = new System.Drawing.Size(100, 35);
            this.SelectButton2.TabIndex = 5;
            this.SelectButton2.Text = "Select";
            this.SelectButton2.UseVisualStyleBackColor = true;
            // 
            // LoopButton2
            // 
            this.LoopButton2.Location = new System.Drawing.Point(265, 385);
            this.LoopButton2.Name = "LoopButton2";
            this.LoopButton2.Size = new System.Drawing.Size(100, 35);
            this.LoopButton2.TabIndex = 6;
            this.LoopButton2.Text = "Loop";
            this.LoopButton2.UseVisualStyleBackColor = true;
            this.LoopButton2.Click += new System.EventHandler(this.LoopButton_Click);
            // 
            // Sequence2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 444);
            this.Controls.Add(this.LoopButton2);
            this.Controls.Add(this.SelectButton2);
            this.Controls.Add(this.OptionButton2);
            this.Controls.Add(this.DeleteButton2);
            this.Controls.Add(this.CreateButton2);
            this.Controls.Add(this.dataGridView2);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Sequence2";
            this.Text = "Sequence Program List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateButton2;
        private System.Windows.Forms.Button DeleteButton2;
        private System.Windows.Forms.Button OptionButton2;
        private System.Windows.Forms.Button SelectButton2;
        private System.Windows.Forms.Button LoopButton2;
    }
}
