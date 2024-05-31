namespace quality
{
    partial class Laborant
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
            this.dataGridView_laborant = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_laborant)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_laborant
            // 
            this.dataGridView_laborant.AllowUserToAddRows = false;
            this.dataGridView_laborant.AllowUserToDeleteRows = false;
            this.dataGridView_laborant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_laborant.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_laborant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_laborant.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_laborant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_laborant.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_laborant.Name = "dataGridView_laborant";
            this.dataGridView_laborant.ReadOnly = true;
            this.dataGridView_laborant.RowHeadersVisible = false;
            this.dataGridView_laborant.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_laborant.Size = new System.Drawing.Size(776, 426);
            this.dataGridView_laborant.TabIndex = 0;
            this.dataGridView_laborant.DoubleClick += new System.EventHandler(this.DataGridView_laborant_DoubleClick);
            // 
            // Laborant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView_laborant);
            this.Name = "Laborant";
            this.Text = "Laborant";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_laborant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView_laborant;
    }
}