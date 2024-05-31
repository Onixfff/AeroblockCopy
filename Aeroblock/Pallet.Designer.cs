namespace Aeroblock
{
    partial class Pallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pallet));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ts_list = new System.Windows.Forms.ToolStripButton();
            this.ts_add = new System.Windows.Forms.ToolStripButton();
            this.ts_edit = new System.Windows.Forms.ToolStripButton();
            this.ts_del = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_company = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_company)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_list,
            this.ts_add,
            this.ts_edit,
            this.ts_del});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.toolStrip1.Size = new System.Drawing.Size(800, 57);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ts_list
            // 
            this.ts_list.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_list.Image = ((System.Drawing.Image)(resources.GetObject("ts_list.Image")));
            this.ts_list.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_list.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.ts_list.Name = "ts_list";
            this.ts_list.Size = new System.Drawing.Size(54, 54);
            this.ts_list.Text = "toolStripButton1";
            this.ts_list.ToolTipText = "Список";
            // 
            // ts_add
            // 
            this.ts_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_add.Image = ((System.Drawing.Image)(resources.GetObject("ts_add.Image")));
            this.ts_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_add.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.ts_add.Name = "ts_add";
            this.ts_add.Size = new System.Drawing.Size(54, 54);
            this.ts_add.Text = "toolStripButton2";
            this.ts_add.ToolTipText = "Добавить компанию";
            this.ts_add.Click += new System.EventHandler(this.ts_add_Click);
            // 
            // ts_edit
            // 
            this.ts_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_edit.Image = ((System.Drawing.Image)(resources.GetObject("ts_edit.Image")));
            this.ts_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_edit.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.ts_edit.Name = "ts_edit";
            this.ts_edit.Size = new System.Drawing.Size(54, 54);
            this.ts_edit.Text = "toolStripButton3";
            this.ts_edit.ToolTipText = "Редактировать";
            // 
            // ts_del
            // 
            this.ts_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_del.Image = ((System.Drawing.Image)(resources.GetObject("ts_del.Image")));
            this.ts_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_del.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.ts_del.Name = "ts_del";
            this.ts_del.Size = new System.Drawing.Size(54, 54);
            this.ts_del.Text = "toolStripButton4";
            this.ts_del.ToolTipText = "Закрыть компанию";
            // 
            // dataGridView_company
            // 
            this.dataGridView_company.AllowUserToAddRows = false;
            this.dataGridView_company.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_company.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_company.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_company.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_company.Location = new System.Drawing.Point(0, 57);
            this.dataGridView_company.Name = "dataGridView_company";
            this.dataGridView_company.RowHeadersVisible = false;
            this.dataGridView_company.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_company.Size = new System.Drawing.Size(800, 393);
            this.dataGridView_company.TabIndex = 2;
            // 
            // Pallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView_company);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Pallet";
            this.ShowIcon = false;
            this.Text = "Движение паллет";
            this.Load += new System.EventHandler(this.Pallet_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_company)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ts_list;
        private System.Windows.Forms.ToolStripButton ts_add;
        private System.Windows.Forms.ToolStripButton ts_edit;
        private System.Windows.Forms.ToolStripButton ts_del;
        private System.Windows.Forms.DataGridView dataGridView_company;
    }
}