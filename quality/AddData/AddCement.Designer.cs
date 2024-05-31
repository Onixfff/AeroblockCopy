namespace quality
{
    partial class AddCement
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
            this.idLaborant = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.comment = new System.Windows.Forms.RichTextBox();
            this.estleImmersionDepth_mm = new System.Windows.Forms.TextBox();
            this.pestleMovementTime_min = new System.Windows.Forms.TextBox();
            this.waterPercent = new System.Windows.Forms.TextBox();
            this.water_ml = new System.Windows.Forms.TextBox();
            this.denomination = new System.Windows.Forms.TextBox();
            this.sampleWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label_water = new System.Windows.Forms.Label();
            this.label_waterMl = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_weight = new System.Windows.Forms.Label();
            this.label_data = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // idLaborant
            // 
            this.idLaborant.Location = new System.Drawing.Point(267, 289);
            this.idLaborant.Name = "idLaborant";
            this.idLaborant.Size = new System.Drawing.Size(129, 20);
            this.idLaborant.TabIndex = 56;
            this.idLaborant.Click += new System.EventHandler(this.TextBox_laborant_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Лаборант";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(174, 470);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(103, 49);
            this.buttonUpdate.TabIndex = 54;
            this.buttonUpdate.Text = "Отправить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(156, 337);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(240, 106);
            this.comment.TabIndex = 53;
            this.comment.Text = "";
            // 
            // estleImmersionDepth_mm
            // 
            this.estleImmersionDepth_mm.Location = new System.Drawing.Point(267, 249);
            this.estleImmersionDepth_mm.Name = "estleImmersionDepth_mm";
            this.estleImmersionDepth_mm.Size = new System.Drawing.Size(129, 20);
            this.estleImmersionDepth_mm.TabIndex = 52;
            // 
            // pestleMovementTime_min
            // 
            this.pestleMovementTime_min.Location = new System.Drawing.Point(310, 207);
            this.pestleMovementTime_min.Name = "pestleMovementTime_min";
            this.pestleMovementTime_min.Size = new System.Drawing.Size(86, 20);
            this.pestleMovementTime_min.TabIndex = 51;
            // 
            // waterPercent
            // 
            this.waterPercent.Location = new System.Drawing.Point(310, 175);
            this.waterPercent.Name = "waterPercent";
            this.waterPercent.Size = new System.Drawing.Size(86, 20);
            this.waterPercent.TabIndex = 50;
            // 
            // water_ml
            // 
            this.water_ml.Location = new System.Drawing.Point(310, 136);
            this.water_ml.Name = "water_ml";
            this.water_ml.Size = new System.Drawing.Size(86, 20);
            this.water_ml.TabIndex = 49;
            // 
            // denomination
            // 
            this.denomination.Location = new System.Drawing.Point(267, 104);
            this.denomination.Name = "denomination";
            this.denomination.Size = new System.Drawing.Size(129, 20);
            this.denomination.TabIndex = 48;
            // 
            // sampleWeight
            // 
            this.sampleWeight.Location = new System.Drawing.Point(267, 70);
            this.sampleWeight.Name = "sampleWeight";
            this.sampleWeight.Size = new System.Drawing.Size(129, 20);
            this.sampleWeight.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Комментарий";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Глубина погружения пестика, мм (6±1)";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(29, 214);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(163, 13);
            this.label_time.TabIndex = 44;
            this.label_time.Text = "Время движения пестика, мин";
            // 
            // label_water
            // 
            this.label_water.AutoSize = true;
            this.label_water.Location = new System.Drawing.Point(29, 178);
            this.label_water.Name = "label_water";
            this.label_water.Size = new System.Drawing.Size(46, 13);
            this.label_water.TabIndex = 43;
            this.label_water.Text = "Вода, %";
            // 
            // label_waterMl
            // 
            this.label_waterMl.AutoSize = true;
            this.label_waterMl.Location = new System.Drawing.Point(29, 143);
            this.label_waterMl.Name = "label_waterMl";
            this.label_waterMl.Size = new System.Drawing.Size(52, 13);
            this.label_waterMl.TabIndex = 42;
            this.label_waterMl.Text = "Вода, мл";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(29, 107);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(83, 13);
            this.label_name.TabIndex = 41;
            this.label_name.Text = "Наименование";
            // 
            // label_weight
            // 
            this.label_weight.AutoSize = true;
            this.label_weight.Location = new System.Drawing.Point(29, 73);
            this.label_weight.Name = "label_weight";
            this.label_weight.Size = new System.Drawing.Size(86, 13);
            this.label_weight.TabIndex = 40;
            this.label_weight.Text = "Масса пробы, г";
            // 
            // label_data
            // 
            this.label_data.AutoSize = true;
            this.label_data.Location = new System.Drawing.Point(29, 35);
            this.label_data.Name = "label_data";
            this.label_data.Size = new System.Drawing.Size(33, 13);
            this.label_data.TabIndex = 39;
            this.label_data.Text = "Дата";
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(267, 29);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(129, 20);
            this.data.TabIndex = 38;
            // 
            // AddCement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 540);
            this.Controls.Add(this.idLaborant);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.estleImmersionDepth_mm);
            this.Controls.Add(this.pestleMovementTime_min);
            this.Controls.Add(this.waterPercent);
            this.Controls.Add(this.water_ml);
            this.Controls.Add(this.denomination);
            this.Controls.Add(this.sampleWeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_water);
            this.Controls.Add(this.label_waterMl);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_weight);
            this.Controls.Add(this.label_data);
            this.Controls.Add(this.data);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCement";
            this.Text = "Добавить данные";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox idLaborant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.RichTextBox comment;
        private System.Windows.Forms.TextBox estleImmersionDepth_mm;
        private System.Windows.Forms.TextBox pestleMovementTime_min;
        private System.Windows.Forms.TextBox waterPercent;
        private System.Windows.Forms.TextBox water_ml;
        private System.Windows.Forms.TextBox denomination;
        private System.Windows.Forms.TextBox sampleWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_water;
        private System.Windows.Forms.Label label_waterMl;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_weight;
        private System.Windows.Forms.Label label_data;
        private System.Windows.Forms.DateTimePicker data;
    }
}