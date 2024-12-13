namespace PS_ELOAD_Serial
{
    partial class Option_list
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewOptions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewOptions = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOptions
            // 
            this.dataGridViewOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOptions.Location = new System.Drawing.Point(12, 14);
            this.dataGridViewOptions.Name = "dataGridViewOptions";
            this.dataGridViewOptions.Size = new System.Drawing.Size(560, 350);
            this.dataGridViewOptions.TabIndex = 0;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(472, 384);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 35);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Option_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 442);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.dataGridViewOptions);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Option_list";
            this.Text = "Program Setting Options";
            this.Load += new System.EventHandler(this.Option_list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button DeleteButton;
    }
}
