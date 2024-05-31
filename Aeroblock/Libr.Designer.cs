namespace Aeroblock
{
    partial class Libr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Libr));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ts_add = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.dataGridView_libr = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_libr)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_add,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.toolStrip1.Size = new System.Drawing.Size(694, 57);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ts_add
            // 
            this.ts_add.Checked = true;
            this.ts_add.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ts_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_add.Image = ((System.Drawing.Image)(resources.GetObject("ts_add.Image")));
            this.ts_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_add.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.ts_add.Name = "ts_add";
            this.ts_add.Size = new System.Drawing.Size(54, 54);
            this.ts_add.ToolTipText = "Добавить компанию";
            this.ts_add.Click += new System.EventHandler(this.ts_add_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(300, 57);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // dataGridView_libr
            // 
            this.dataGridView_libr.AllowUserToAddRows = false;
            this.dataGridView_libr.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_libr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_libr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_libr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_libr.Location = new System.Drawing.Point(0, 57);
            this.dataGridView_libr.Name = "dataGridView_libr";
            this.dataGridView_libr.RowHeadersVisible = false;
            this.dataGridView_libr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_libr.Size = new System.Drawing.Size(694, 393);
            this.dataGridView_libr.TabIndex = 3;
            this.dataGridView_libr.DoubleClick += new System.EventHandler(this.dataGridView_libr_DoubleClick);
            // 
            // Libr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 450);
            this.Controls.Add(this.dataGridView_libr);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Libr";
            this.ShowIcon = false;
            this.Text = "Выбрать из справочника";
            this.Load += new System.EventHandler(this.Libr_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_libr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ts_add;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        public System.Windows.Forms.DataGridView dataGridView_libr;
    }
}