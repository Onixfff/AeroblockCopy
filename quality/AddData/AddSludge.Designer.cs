namespace quality
{
    partial class AddSludge
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
            this.sievePassPercent_0_08 = new System.Windows.Forms.TextBox();
            this.sievePassPercent_0_09 = new System.Windows.Forms.TextBox();
            this.palletAndSandWeigth = new System.Windows.Forms.TextBox();
            this.palletWeightAisle_gram = new System.Windows.Forms.TextBox();
            this.palletWeight_gram = new System.Windows.Forms.TextBox();
            this.placeSelection = new System.Windows.Forms.TextBox();
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
            this.idLaborant.Location = new System.Drawing.Point(265, 284);
            this.idLaborant.Name = "idLaborant";
            this.idLaborant.Size = new System.Drawing.Size(129, 20);
            this.idLaborant.TabIndex = 75;
            this.idLaborant.Click += new System.EventHandler(this.TextBox_laborant_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Лаборант";
            // 
            // button_post
            // 
            this.button_post.Location = new System.Drawing.Point(172, 465);
            this.button_post.Name = "button_post";
            this.button_post.Size = new System.Drawing.Size(103, 49);
            this.button_post.TabIndex = 73;
            this.button_post.Text = "Отправить";
            this.button_post.UseVisualStyleBackColor = true;
            this.button_post.Click += new System.EventHandler(this.Button_post_Click);
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(154, 332);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(240, 106);
            this.comment.TabIndex = 72;
            this.comment.Text = "";
            // 
            // sievePassPercent_0_08
            // 
            this.sievePassPercent_0_08.Location = new System.Drawing.Point(308, 244);
            this.sievePassPercent_0_08.Name = "sievePassPercent_0_08";
            this.sievePassPercent_0_08.Size = new System.Drawing.Size(86, 20);
            this.sievePassPercent_0_08.TabIndex = 71;
            // 
            // sievePassPercent_0_09
            // 
            this.sievePassPercent_0_09.Location = new System.Drawing.Point(308, 202);
            this.sievePassPercent_0_09.Name = "sievePassPercent_0_09";
            this.sievePassPercent_0_09.Size = new System.Drawing.Size(86, 20);
            this.sievePassPercent_0_09.TabIndex = 70;
            // 
            // palletAndSandWeigth
            // 
            this.palletAndSandWeigth.Location = new System.Drawing.Point(308, 170);
            this.palletAndSandWeigth.Name = "palletAndSandWeigth";
            this.palletAndSandWeigth.Size = new System.Drawing.Size(86, 20);
            this.palletAndSandWeigth.TabIndex = 69;
            // 
            // palletWeightAisle_gram
            // 
            this.palletWeightAisle_gram.Location = new System.Drawing.Point(308, 131);
            this.palletWeightAisle_gram.Name = "palletWeightAisle_gram";
            this.palletWeightAisle_gram.Size = new System.Drawing.Size(86, 20);
            this.palletWeightAisle_gram.TabIndex = 68;
            // 
            // palletWeight_gram
            // 
            this.palletWeight_gram.Location = new System.Drawing.Point(308, 99);
            this.palletWeight_gram.Name = "palletWeight_gram";
            this.palletWeight_gram.Size = new System.Drawing.Size(86, 20);
            this.palletWeight_gram.TabIndex = 67;
            this.palletWeight_gram.Text = "372";
            // 
            // placeSelection
            // 
            this.placeSelection.Location = new System.Drawing.Point(265, 61);
            this.placeSelection.Name = "placeSelection";
            this.placeSelection.Size = new System.Drawing.Size(129, 20);
            this.placeSelection.TabIndex = 66;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Комментарий";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Проход через сито 0.08, %";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(27, 209);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(140, 13);
            this.label_time.TabIndex = 63;
            this.label_time.Text = "Проход через сито 0.09, %";
            // 
            // label_water
            // 
            this.label_water.AutoSize = true;
            this.label_water.Location = new System.Drawing.Point(27, 173);
            this.label_water.Name = "label_water";
            this.label_water.Size = new System.Drawing.Size(146, 13);
            this.label_water.TabIndex = 62;
            this.label_water.Text = "Масса поддона +  проход, г";
            // 
            // label_waterMl
            // 
            this.label_waterMl.AutoSize = true;
            this.label_waterMl.Location = new System.Drawing.Point(27, 138);
            this.label_waterMl.Name = "label_waterMl";
            this.label_waterMl.Size = new System.Drawing.Size(129, 13);
            this.label_waterMl.TabIndex = 61;
            this.label_waterMl.Text = "Масса навески песка, г";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(27, 102);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(96, 13);
            this.label_name.TabIndex = 60;
            this.label_name.Text = "Масса поддона, г";
            // 
            // label_with
            // 
            this.label_with.AutoSize = true;
            this.label_with.Location = new System.Drawing.Point(27, 64);
            this.label_with.Name = "label_with";
            this.label_with.Size = new System.Drawing.Size(77, 13);
            this.label_with.TabIndex = 59;
            this.label_with.Text = "Место отбора";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "Дата";
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(265, 24);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(129, 20);
            this.data.TabIndex = 57;
            // 
            // AddSludge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 543);
            this.Controls.Add(this.idLaborant);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_post);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.sievePassPercent_0_08);
            this.Controls.Add(this.sievePassPercent_0_09);
            this.Controls.Add(this.palletAndSandWeigth);
            this.Controls.Add(this.palletWeightAisle_gram);
            this.Controls.Add(this.palletWeight_gram);
            this.Controls.Add(this.placeSelection);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_water);
            this.Controls.Add(this.label_waterMl);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_with);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.data);
            this.Name = "AddSludge";
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
        private System.Windows.Forms.TextBox sievePassPercent_0_08;
        private System.Windows.Forms.TextBox sievePassPercent_0_09;
        private System.Windows.Forms.TextBox palletAndSandWeigth;
        private System.Windows.Forms.TextBox palletWeightAisle_gram;
        private System.Windows.Forms.TextBox palletWeight_gram;
        private System.Windows.Forms.TextBox placeSelection;
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