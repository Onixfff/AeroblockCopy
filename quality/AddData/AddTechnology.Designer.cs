namespace quality
{
    partial class AddTechnology
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
            this.oilConsumption_litr = new System.Windows.Forms.TextBox();
            this.label_time1 = new System.Windows.Forms.Label();
            this.idRecipe = new System.Windows.Forms.TextBox();
            this.label_Acp = new System.Windows.Forms.Label();
            this.idLaborant = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.comment = new System.Windows.Forms.RichTextBox();
            this.tKon = new System.Windows.Forms.TextBox();
            this.solidWaterPercent = new System.Windows.Forms.TextBox();
            this.dryWeight_kg = new System.Windows.Forms.TextBox();
            this.CaO_Percent = new System.Windows.Forms.TextBox();
            this.stirrerTemperature = new System.Windows.Forms.TextBox();
            this.ripeningTime_min = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_ = new System.Windows.Forms.Label();
            this.label_water = new System.Windows.Forms.Label();
            this.label_waterMl = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_with = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.chamberT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_hourMin = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // oilConsumption_litr
            // 
            this.oilConsumption_litr.Location = new System.Drawing.Point(261, 318);
            this.oilConsumption_litr.Name = "oilConsumption_litr";
            this.oilConsumption_litr.Size = new System.Drawing.Size(129, 20);
            this.oilConsumption_litr.TabIndex = 103;
            // 
            // label_time1
            // 
            this.label_time1.AutoSize = true;
            this.label_time1.Location = new System.Drawing.Point(23, 321);
            this.label_time1.Name = "label_time1";
            this.label_time1.Size = new System.Drawing.Size(90, 13);
            this.label_time1.TabIndex = 102;
            this.label_time1.Text = "Расход масла, л";
            // 
            // idRecipe
            // 
            this.idRecipe.Location = new System.Drawing.Point(261, 277);
            this.idRecipe.Name = "idRecipe";
            this.idRecipe.Size = new System.Drawing.Size(129, 20);
            this.idRecipe.TabIndex = 101;
            // 
            // label_Acp
            // 
            this.label_Acp.AutoSize = true;
            this.label_Acp.Location = new System.Drawing.Point(23, 277);
            this.label_Acp.Name = "label_Acp";
            this.label_Acp.Size = new System.Drawing.Size(129, 13);
            this.label_Acp.TabIndex = 100;
            this.label_Acp.Text = "№ рецепта ( плотность )";
            // 
            // idLaborant
            // 
            this.idLaborant.Location = new System.Drawing.Point(261, 398);
            this.idLaborant.Name = "idLaborant";
            this.idLaborant.Size = new System.Drawing.Size(129, 20);
            this.idLaborant.TabIndex = 99;
            this.idLaborant.Click += new System.EventHandler(this.TextBox_laborant_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "Лаборант";
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(166, 582);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(103, 49);
            this.button_submit.TabIndex = 97;
            this.button_submit.Text = "Отправить";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.Button_submit_Click);
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(150, 443);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(240, 106);
            this.comment.TabIndex = 96;
            this.comment.Text = "";
            // 
            // tKon
            // 
            this.tKon.Location = new System.Drawing.Point(261, 237);
            this.tKon.Name = "tKon";
            this.tKon.Size = new System.Drawing.Size(129, 20);
            this.tKon.TabIndex = 95;
            // 
            // solidWaterPercent
            // 
            this.solidWaterPercent.Location = new System.Drawing.Point(304, 195);
            this.solidWaterPercent.Name = "solidWaterPercent";
            this.solidWaterPercent.Size = new System.Drawing.Size(86, 20);
            this.solidWaterPercent.TabIndex = 94;
            // 
            // dryWeight_kg
            // 
            this.dryWeight_kg.Location = new System.Drawing.Point(304, 163);
            this.dryWeight_kg.Name = "dryWeight_kg";
            this.dryWeight_kg.Size = new System.Drawing.Size(86, 20);
            this.dryWeight_kg.TabIndex = 93;
            // 
            // CaO_Percent
            // 
            this.CaO_Percent.Location = new System.Drawing.Point(304, 124);
            this.CaO_Percent.Name = "CaO_Percent";
            this.CaO_Percent.Size = new System.Drawing.Size(86, 20);
            this.CaO_Percent.TabIndex = 92;
            // 
            // stirrerTemperature
            // 
            this.stirrerTemperature.Location = new System.Drawing.Point(261, 92);
            this.stirrerTemperature.Name = "stirrerTemperature";
            this.stirrerTemperature.Size = new System.Drawing.Size(129, 20);
            this.stirrerTemperature.TabIndex = 91;
            // 
            // ripeningTime_min
            // 
            this.ripeningTime_min.Location = new System.Drawing.Point(261, 58);
            this.ripeningTime_min.Name = "ripeningTime_min";
            this.ripeningTime_min.Size = new System.Drawing.Size(129, 20);
            this.ripeningTime_min.TabIndex = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 89;
            this.label5.Text = "Комментарий";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Tкон, ° C";
            // 
            // label_
            // 
            this.label_.AutoSize = true;
            this.label_.Location = new System.Drawing.Point(23, 199);
            this.label_.Name = "label_";
            this.label_.Size = new System.Drawing.Size(104, 13);
            this.label_.TabIndex = 87;
            this.label_.Text = "Вода/тв. вещ-ва, %";
            // 
            // label_water
            // 
            this.label_water.AutoSize = true;
            this.label_water.Location = new System.Drawing.Point(23, 163);
            this.label_water.Name = "label_water";
            this.label_water.Size = new System.Drawing.Size(74, 13);
            this.label_water.TabIndex = 86;
            this.label_water.Text = "Сухой вес, кг";
            // 
            // label_waterMl
            // 
            this.label_waterMl.AutoSize = true;
            this.label_waterMl.Location = new System.Drawing.Point(23, 128);
            this.label_waterMl.Name = "label_waterMl";
            this.label_waterMl.Size = new System.Drawing.Size(42, 13);
            this.label_waterMl.TabIndex = 85;
            this.label_waterMl.Text = "CaO, %";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(23, 92);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(106, 13);
            this.label_name.TabIndex = 84;
            this.label_name.Text = "Темп. мешалки, ° С";
            // 
            // label_with
            // 
            this.label_with.AutoSize = true;
            this.label_with.Location = new System.Drawing.Point(23, 58);
            this.label_with.Name = "label_with";
            this.label_with.Size = new System.Drawing.Size(103, 13);
            this.label_with.TabIndex = 83;
            this.label_with.Text = "Время созревания";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 82;
            this.label12.Text = "Дата";
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(126, 13);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(129, 20);
            this.data.TabIndex = 81;
            // 
            // chamberT
            // 
            this.chamberT.Location = new System.Drawing.Point(261, 359);
            this.chamberT.Name = "chamberT";
            this.chamberT.Size = new System.Drawing.Size(129, 20);
            this.chamberT.TabIndex = 105;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "T камеры, ( max ) ° C";
            // 
            // comboBox_hourMin
            // 
            this.comboBox_hourMin.FormattingEnabled = true;
            this.comboBox_hourMin.Items.AddRange(new object[] {
            "10:00",
            "12:00",
            "14:00",
            "16:00",
            "18:00"});
            this.comboBox_hourMin.Location = new System.Drawing.Point(261, 12);
            this.comboBox_hourMin.Name = "comboBox_hourMin";
            this.comboBox_hourMin.Size = new System.Drawing.Size(129, 21);
            this.comboBox_hourMin.TabIndex = 106;
            // 
            // AddTechnology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 643);
            this.Controls.Add(this.comboBox_hourMin);
            this.Controls.Add(this.chamberT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oilConsumption_litr);
            this.Controls.Add(this.label_time1);
            this.Controls.Add(this.idRecipe);
            this.Controls.Add(this.label_Acp);
            this.Controls.Add(this.idLaborant);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.tKon);
            this.Controls.Add(this.solidWaterPercent);
            this.Controls.Add(this.dryWeight_kg);
            this.Controls.Add(this.CaO_Percent);
            this.Controls.Add(this.stirrerTemperature);
            this.Controls.Add(this.ripeningTime_min);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_);
            this.Controls.Add(this.label_water);
            this.Controls.Add(this.label_waterMl);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_with);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.data);
            this.Name = "AddTechnology";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить данные";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox oilConsumption_litr;
        private System.Windows.Forms.Label label_time1;
        private System.Windows.Forms.TextBox idRecipe;
        private System.Windows.Forms.Label label_Acp;
        private System.Windows.Forms.TextBox idLaborant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.RichTextBox comment;
        private System.Windows.Forms.TextBox tKon;
        private System.Windows.Forms.TextBox solidWaterPercent;
        private System.Windows.Forms.TextBox dryWeight_kg;
        private System.Windows.Forms.TextBox CaO_Percent;
        private System.Windows.Forms.TextBox stirrerTemperature;
        private System.Windows.Forms.TextBox ripeningTime_min;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_;
        private System.Windows.Forms.Label label_water;
        private System.Windows.Forms.Label label_waterMl;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_with;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker data;
        private System.Windows.Forms.TextBox chamberT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_hourMin;
    }
}