namespace quality
{
    partial class AddLimeBlankings
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
            this.button_post = new System.Windows.Forms.Button();
            this.comment = new System.Windows.Forms.RichTextBox();
            this.quenchingTemperature = new System.Windows.Forms.TextBox();
            this.timeBlanking_min = new System.Windows.Forms.TextBox();
            this.hitch_gram = new System.Windows.Forms.TextBox();
            this.temperature = new System.Windows.Forms.TextBox();
            this.testTime = new System.Windows.Forms.TextBox();
            this.numberCar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label_water = new System.Windows.Forms.Label();
            this.label_waterMl = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_with = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // idLaborant
            // 
            this.idLaborant.Location = new System.Drawing.Point(268, 288);
            this.idLaborant.Name = "idLaborant";
            this.idLaborant.Size = new System.Drawing.Size(129, 20);
            this.idLaborant.TabIndex = 94;
            this.idLaborant.Click += new System.EventHandler(this.TextBox_laborant_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 93;
            this.label4.Text = "Лаборант";
            // 
            // button_post
            // 
            this.button_post.Location = new System.Drawing.Point(175, 469);
            this.button_post.Name = "button_post";
            this.button_post.Size = new System.Drawing.Size(103, 49);
            this.button_post.TabIndex = 92;
            this.button_post.Text = "Отправить";
            this.button_post.UseVisualStyleBackColor = true;
            this.button_post.Click += new System.EventHandler(this.Button_post_Click);
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(157, 336);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(240, 106);
            this.comment.TabIndex = 91;
            this.comment.Text = "";
            // 
            // quenchingTemperature
            // 
            this.quenchingTemperature.Location = new System.Drawing.Point(311, 248);
            this.quenchingTemperature.Name = "quenchingTemperature";
            this.quenchingTemperature.Size = new System.Drawing.Size(86, 20);
            this.quenchingTemperature.TabIndex = 90;
            // 
            // timeBlanking_min
            // 
            this.timeBlanking_min.Location = new System.Drawing.Point(311, 206);
            this.timeBlanking_min.Name = "timeBlanking_min";
            this.timeBlanking_min.Size = new System.Drawing.Size(86, 20);
            this.timeBlanking_min.TabIndex = 89;
            // 
            // hitch_gram
            // 
            this.hitch_gram.Location = new System.Drawing.Point(311, 174);
            this.hitch_gram.Name = "hitch_gram";
            this.hitch_gram.Size = new System.Drawing.Size(86, 20);
            this.hitch_gram.TabIndex = 88;
            // 
            // temperature
            // 
            this.temperature.Location = new System.Drawing.Point(311, 135);
            this.temperature.Name = "temperature";
            this.temperature.Size = new System.Drawing.Size(86, 20);
            this.temperature.TabIndex = 87;
            // 
            // testTime
            // 
            this.testTime.Location = new System.Drawing.Point(311, 103);
            this.testTime.Name = "testTime";
            this.testTime.Size = new System.Drawing.Size(86, 20);
            this.testTime.TabIndex = 86;
            // 
            // numberCar
            // 
            this.numberCar.Location = new System.Drawing.Point(268, 65);
            this.numberCar.Name = "numberCar";
            this.numberCar.Size = new System.Drawing.Size(129, 20);
            this.numberCar.TabIndex = 85;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 380);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Комментарий";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 13);
            this.label6.TabIndex = 83;
            this.label6.Text = "Температура гашения, t ° C";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(30, 213);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(112, 13);
            this.label_time.TabIndex = 82;
            this.label_time.Text = "Время гашения, мин";
            // 
            // label_water
            // 
            this.label_water.AutoSize = true;
            this.label_water.Location = new System.Drawing.Point(30, 177);
            this.label_water.Name = "label_water";
            this.label_water.Size = new System.Drawing.Size(62, 13);
            this.label_water.TabIndex = 81;
            this.label_water.Text = "Навеска, г";
            // 
            // label_waterMl
            // 
            this.label_waterMl.AutoSize = true;
            this.label_waterMl.Location = new System.Drawing.Point(30, 142);
            this.label_waterMl.Name = "label_waterMl";
            this.label_waterMl.Size = new System.Drawing.Size(100, 13);
            this.label_waterMl.TabIndex = 80;
            this.label_waterMl.Text = "Температура, t ° C";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(30, 106);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(124, 13);
            this.label_name.TabIndex = 79;
            this.label_name.Text = "Время испытания, мин";
            // 
            // label_with
            // 
            this.label_with.AutoSize = true;
            this.label_with.Location = new System.Drawing.Point(30, 68);
            this.label_with.Name = "label_with";
            this.label_with.Size = new System.Drawing.Size(79, 13);
            this.label_with.TabIndex = 78;
            this.label_with.Text = "Номер вагона";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 77;
            this.label12.Text = "Дата";
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(268, 28);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(129, 20);
            this.data.TabIndex = 76;
            // 
            // AddLimeBlankings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 541);
            this.Controls.Add(this.idLaborant);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_post);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.quenchingTemperature);
            this.Controls.Add(this.timeBlanking_min);
            this.Controls.Add(this.hitch_gram);
            this.Controls.Add(this.temperature);
            this.Controls.Add(this.testTime);
            this.Controls.Add(this.numberCar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_water);
            this.Controls.Add(this.label_waterMl);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_with);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.data);
            this.Name = "AddLimeBlankings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить данные";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idLaborant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_post;
        private System.Windows.Forms.RichTextBox comment;
        private System.Windows.Forms.TextBox quenchingTemperature;
        private System.Windows.Forms.TextBox timeBlanking_min;
        private System.Windows.Forms.TextBox hitch_gram;
        private System.Windows.Forms.TextBox temperature;
        private System.Windows.Forms.TextBox testTime;
        private System.Windows.Forms.TextBox numberCar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_water;
        private System.Windows.Forms.Label label_waterMl;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_with;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker data;
    }
}