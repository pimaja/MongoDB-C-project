namespace Fakultet
{
    partial class Pregled_po_studentima
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
            this.Popis_studenata = new System.Windows.Forms.ListView();
            this.JMBAG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ime_i_prezime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rezultat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pohrani_rezultat_btn = new System.Windows.Forms.Button();
            this.Unos_rezultata_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Prosjek_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonNatrag = new System.Windows.Forms.Button();
            this.buttonPocetna = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Popis_studenata
            // 
            this.Popis_studenata.BackColor = System.Drawing.Color.AliceBlue;
            this.Popis_studenata.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.JMBAG,
            this.Ime_i_prezime,
            this.Rezultat});
            this.Popis_studenata.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Popis_studenata.FullRowSelect = true;
            this.Popis_studenata.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Popis_studenata.HideSelection = false;
            this.Popis_studenata.Location = new System.Drawing.Point(57, 201);
            this.Popis_studenata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Popis_studenata.Name = "Popis_studenata";
            this.Popis_studenata.Size = new System.Drawing.Size(609, 339);
            this.Popis_studenata.TabIndex = 0;
            this.Popis_studenata.UseCompatibleStateImageBehavior = false;
            this.Popis_studenata.View = System.Windows.Forms.View.Details;
            this.Popis_studenata.SelectedIndexChanged += new System.EventHandler(this.Popis_studenata_SelectedIndexChanged);
            // 
            // JMBAG
            // 
            this.JMBAG.Text = "JMBAG";
            this.JMBAG.Width = 150;
            // 
            // Ime_i_prezime
            // 
            this.Ime_i_prezime.Text = "Ime i prezime";
            this.Ime_i_prezime.Width = 150;
            // 
            // Rezultat
            // 
            this.Rezultat.Text = "Rezultat";
            this.Rezultat.Width = 150;
            // 
            // Pohrani_rezultat_btn
            // 
            this.Pohrani_rezultat_btn.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pohrani_rezultat_btn.Location = new System.Drawing.Point(1156, 369);
            this.Pohrani_rezultat_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pohrani_rezultat_btn.Name = "Pohrani_rezultat_btn";
            this.Pohrani_rezultat_btn.Size = new System.Drawing.Size(109, 41);
            this.Pohrani_rezultat_btn.TabIndex = 1;
            this.Pohrani_rezultat_btn.Text = "POHRANI";
            this.Pohrani_rezultat_btn.UseVisualStyleBackColor = true;
            this.Pohrani_rezultat_btn.Click += new System.EventHandler(this.Pohrani_rezultat_btn_Click);
            // 
            // Unos_rezultata_textBox
            // 
            this.Unos_rezultata_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unos_rezultata_textBox.Location = new System.Drawing.Point(980, 374);
            this.Unos_rezultata_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Unos_rezultata_textBox.Name = "Unos_rezultata_textBox";
            this.Unos_rezultata_textBox.Size = new System.Drawing.Size(145, 30);
            this.Unos_rezultata_textBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(848, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Za unos ili izmjenu rezultata studenta, odaberite studenta s popisa, \r\nunesite re" +
    "zultat u donju kućicu te ga pohranite:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 559);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prosječni rezultat ispita za unesene rezultate:";
            // 
            // Prosjek_lbl
            // 
            this.Prosjek_lbl.AutoSize = true;
            this.Prosjek_lbl.BackColor = System.Drawing.Color.Transparent;
            this.Prosjek_lbl.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prosjek_lbl.ForeColor = System.Drawing.Color.Black;
            this.Prosjek_lbl.Location = new System.Drawing.Point(429, 559);
            this.Prosjek_lbl.Name = "Prosjek_lbl";
            this.Prosjek_lbl.Size = new System.Drawing.Size(35, 23);
            this.Prosjek_lbl.TabIndex = 5;
            this.Prosjek_lbl.Text = "0%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(739, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(847, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonNatrag);
            this.panel1.Controls.Add(this.buttonPocetna);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1828, 81);
            this.panel1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel Light", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(379, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 41);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Corbel Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(264, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 41);
            this.label6.TabIndex = 8;
            this.label6.Text = "Kolegij:";
            // 
            // buttonNatrag
            // 
            this.buttonNatrag.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNatrag.Location = new System.Drawing.Point(137, 15);
            this.buttonNatrag.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonNatrag.Name = "buttonNatrag";
            this.buttonNatrag.Size = new System.Drawing.Size(100, 53);
            this.buttonNatrag.TabIndex = 5;
            this.buttonNatrag.Text = "Natrag";
            this.buttonNatrag.UseVisualStyleBackColor = true;
            this.buttonNatrag.Click += new System.EventHandler(this.buttonNatrag_Click);
            // 
            // buttonPocetna
            // 
            this.buttonPocetna.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPocetna.Location = new System.Drawing.Point(15, 15);
            this.buttonPocetna.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPocetna.Name = "buttonPocetna";
            this.buttonPocetna.Size = new System.Drawing.Size(112, 53);
            this.buttonPocetna.TabIndex = 4;
            this.buttonPocetna.Text = "Naslovna";
            this.buttonPocetna.UseVisualStyleBackColor = true;
            this.buttonPocetna.Click += new System.EventHandler(this.buttonPocetna_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(431, 158);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 29);
            this.label7.TabIndex = 11;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(52, 158);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(372, 29);
            this.label8.TabIndex = 10;
            this.label8.Text = "Popis studenata prijavljenih za ispit:";
            // 
            // Pregled_po_studentima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1827, 814);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Prosjek_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Unos_rezultata_textBox);
            this.Controls.Add(this.Pohrani_rezultat_btn);
            this.Controls.Add(this.Popis_studenata);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Pregled_po_studentima";
            this.Text = "Nastavnik - pregled ispita po studentima";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pregled_po_studentima_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Popis_studenata;
        private System.Windows.Forms.ColumnHeader JMBAG;
        private System.Windows.Forms.ColumnHeader Ime_i_prezime;
        private System.Windows.Forms.ColumnHeader Rezultat;
        private System.Windows.Forms.Button Pohrani_rezultat_btn;
        private System.Windows.Forms.TextBox Unos_rezultata_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Prosjek_lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonNatrag;
        private System.Windows.Forms.Button buttonPocetna;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}