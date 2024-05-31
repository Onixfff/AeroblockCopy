namespace quality
{
    partial class AddDryMix
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
            this.label3 = new System.Windows.Forms.Label();
            this.sieve_residue = new System.Windows.Forms.TextBox();
            this.idLaborant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.comment = new System.Windows.Forms.RichTextBox();
            this.sieveResidue_100gram = new System.Windows.Forms.TextBox();
            this.weight_gram = new System.Windows.Forms.TextBox();
            this.waterPercent = new System.Windows.Forms.TextBox();
            this.water_ml = new System.Windows.Forms.TextBox();
            this.sampleNumber = new System.Windows.Forms.TextBox();
            this.glueType = new System.Windows.Forms.TextBox();
            this.label_comment = new System.Windows.Forms.Label();
            this.label_deep = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label_water = new System.Windows.Forms.Label();
            this.label_waterMl = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_weight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Остаток на сите 0,63, %";
            // 
            // sieve_residue
            // 
            this.sieve_residue.Location = new System.Drawing.Point(269, 295);
            this.sieve_residue.Name = "sieve_residue";
            this.sieve_residue.Size = new System.Drawing.Size(129, 20);
            this.sieve_residue.TabIndex = 41;
            // 
            // idLaborant
            // 
            this.idLaborant.Location = new System.Drawing.Point(269, 331);
            this.idLaborant.Name = "idLaborant";
            this.idLaborant.Size = new System.Drawing.Size(129, 20);
            this.idLaborant.TabIndex = 40;
            this.idLaborant.Click += new System.EventHandler(this.TextBox_laborant_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Лаборант";
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(176, 512);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(103, 49);
            this.button_submit.TabIndex = 38;
            this.button_submit.Text = "Отправить";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.Button_submit_Click);
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(269, 378);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(129, 106);
            this.comment.TabIndex = 37;
            this.comment.Text = "";
            // 
            // sieveResidue_100gram
            // 
            this.sieveResidue_100gram.Location = new System.Drawing.Point(269, 257);
            this.sieveResidue_100gram.Name = "sieveResidue_100gram";
            this.sieveResidue_100gram.Size = new System.Drawing.Size(129, 20);
            this.sieveResidue_100gram.TabIndex = 36;
            // 
            // weight_gram
            // 
            this.weight_gram.Location = new System.Drawing.Point(312, 145);
            this.weight_gram.Name = "weight_gram";
            this.weight_gram.Size = new System.Drawing.Size(86, 20);
            this.weight_gram.TabIndex = 35;
            // 
            // waterPercent
            // 
            this.waterPercent.Location = new System.Drawing.Point(312, 221);
            this.waterPercent.Name = "waterPercent";
            this.waterPercent.Size = new System.Drawing.Size(86, 20);
            this.waterPercent.TabIndex = 34;
            // 
            // water_ml
            // 
            this.water_ml.Location = new System.Drawing.Point(312, 182);
            this.water_ml.Name = "water_ml";
            this.water_ml.Size = new System.Drawing.Size(86, 20);
            this.water_ml.TabIndex = 33;
            // 
            // sampleNumber
            // 
            this.sampleNumber.Location = new System.Drawing.Point(269, 109);
            this.sampleNumber.Name = "sampleNumber";
            this.sampleNumber.Size = new System.Drawing.Size(129, 20);
            this.sampleNumber.TabIndex = 32;
            // 
            // glueType
            // 
            this.glueType.Location = new System.Drawing.Point(269, 69);
            this.glueType.Name = "glueType";
            this.glueType.Size = new System.Drawing.Size(129, 20);
            this.glueType.TabIndex = 31;
            // 
            // label_comment
            // 
            this.label_comment.AutoSize = true;
            this.label_comment.Location = new System.Drawing.Point(31, 422);
            this.label_comment.Name = "label_comment";
            this.label_comment.Size = new System.Drawing.Size(77, 13);
            this.label_comment.TabIndex = 30;
            this.label_comment.Text = "Комментарий";
            // 
            // label_deep
            // 
            this.label_deep.AutoSize = true;
            this.label_deep.Location = new System.Drawing.Point(31, 260);
            this.label_deep.Name = "label_deep";
            this.label_deep.Size = new System.Drawing.Size(181, 13);
            this.label_deep.TabIndex = 29;
            this.label_deep.Text = "Остаток на сите 0,63, г ( на 100 г )";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(31, 152);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(51, 13);
            this.label_time.TabIndex = 28;
            this.label_time.Text = "Масса, г";
            // 
            // label_water
            // 
            this.label_water.AutoSize = true;
            this.label_water.Location = new System.Drawing.Point(31, 224);
            this.label_water.Name = "label_water";
            this.label_water.Size = new System.Drawing.Size(46, 13);
            this.label_water.TabIndex = 27;
            this.label_water.Text = "Вода, %";
            // 
            // label_waterMl
            // 
            this.label_waterMl.AutoSize = true;
            this.label_waterMl.Location = new System.Drawing.Point(31, 189);
            this.label_waterMl.Name = "label_waterMl";
            this.label_waterMl.Size = new System.Drawing.Size(52, 13);
            this.label_waterMl.TabIndex = 26;
            this.label_waterMl.Text = "Вода, мл";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(31, 112);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(76, 13);
            this.label_name.TabIndex = 25;
            this.label_name.Text = "Номер пробы";
            // 
            // label_weight
            // 
            this.label_weight.AutoSize = true;
            this.label_weight.Location = new System.Drawing.Point(31, 72);
            this.label_weight.Name = "label_weight";
            this.label_weight.Size = new System.Drawing.Size(125, 13);
            this.label_weight.TabIndex = 24;
            this.label_weight.Text = "Вид клея (сухой смеси)\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Дата";
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(269, 27);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(129, 20);
            this.data.TabIndex = 22;
            // 
            // AddDryMix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 578);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sieve_residue);
            this.Controls.Add(this.idLaborant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.sieveResidue_100gram);
            this.Controls.Add(this.weight_gram);
            this.Controls.Add(this.waterPercent);
            this.Controls.Add(this.water_ml);
            this.Controls.Add(this.sampleNumber);
            this.Controls.Add(this.glueType);
            this.Controls.Add(this.label_comment);
            this.Controls.Add(this.label_deep);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_water);
            this.Controls.Add(this.label_waterMl);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_weight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.data);
            this.Name = "AddDryMix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить данные";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sieve_residue;
        private System.Windows.Forms.TextBox idLaborant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.RichTextBox comment;
        private System.Windows.Forms.TextBox sieveResidue_100gram;
        private System.Windows.Forms.TextBox weight_gram;
        private System.Windows.Forms.TextBox waterPercent;
        private System.Windows.Forms.TextBox water_ml;
        private System.Windows.Forms.TextBox sampleNumber;
        private System.Windows.Forms.TextBox glueType;
        private System.Windows.Forms.Label label_comment;
        private System.Windows.Forms.Label label_deep;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_water;
        private System.Windows.Forms.Label label_waterMl;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_weight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker data;
    }
}