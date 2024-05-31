namespace quality
{
    partial class Density
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
            this.dataGridView_density = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_density)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_density
            // 
            this.dataGridView_density.AllowUserToAddRows = false;
            this.dataGridView_density.AllowUserToDeleteRows = false;
            this.dataGridView_density.AllowUserToResizeColumns = false;
            this.dataGridView_density.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_density.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_density.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_density.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_density.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView_density.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_density.Name = "dataGridView_density";
            this.dataGridView_density.ReadOnly = true;
            this.dataGridView_density.RowHeadersVisible = false;
            this.dataGridView_density.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_density.Size = new System.Drawing.Size(776, 426);
            this.dataGridView_density.TabIndex = 0;
            this.dataGridView_density.DoubleClick += new System.EventHandler(this.dataGridView_density_DoubleClick_1);
            // 
            // Density
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView_density);
            this.Name = "Density";
            this.Text = "Density";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_density)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView_density;
    }
}