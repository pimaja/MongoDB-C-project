namespace Fakultet
{
    partial class Forma5
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
            this.Popis_ispita = new System.Windows.Forms.ListView();
            this.Ispit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sadrzaj_ispita = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Datum_odrzavanja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vrijeme_odrzavanja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Trajanje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prijava_do = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Odjava_do = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nacin_polaganja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Predavaonica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ime_kolegija = new System.Windows.Forms.Label();
            this.Pregled_po_studentima_btn = new System.Windows.Forms.Button();
            this.Dodaj_novi_ispit_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Ukloni_ispit_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonNatrag = new System.Windows.Forms.Button();
            this.buttonPocetna = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Izmijeni_ispit_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Popis_ispita
            // 
            this.Popis_ispita.BackColor = System.Drawing.Color.AliceBlue;
            this.Popis_ispita.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ispit,
            this.Sadrzaj_ispita,
            this.Datum_odrzavanja,
            this.Vrijeme_odrzavanja,
            this.Trajanje,
            this.Prijava_do,
            this.Odjava_do,
            this.Nacin_polaganja,
            this.Predavaonica});
            this.Popis_ispita.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Popis_ispita.FullRowSelect = true;
            this.Popis_ispita.GridLines = true;
            this.Popis_ispita.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Popis_ispita.HideSelection = false;
            this.Popis_ispita.Location = new System.Drawing.Point(29, 162);
            this.Popis_ispita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Popis_ispita.Name = "Popis_ispita";
            this.Popis_ispita.Size = new System.Drawing.Size(1753, 312);
            this.Popis_ispita.TabIndex = 0;
            this.Popis_ispita.UseCompatibleStateImageBehavior = false;
            this.Popis_ispita.View = System.Windows.Forms.View.Details;
            this.Popis_ispita.SelectedIndexChanged += new System.EventHandler(this.Popis_ispita_SelectedIndexChanged);
            // 
            // Ispit
            // 
            this.Ispit.Text = "ID ispita";
            this.Ispit.Width = 70;
            // 
            // Sadrzaj_ispita
            // 
            this.Sadrzaj_ispita.Text = "Sadržaj ispita";
            this.Sadrzaj_ispita.Width = 500;
            // 
            // Datum_odrzavanja
            // 
            this.Datum_odrzavanja.Text = "Datum održavanja";
            this.Datum_odrzavanja.Width = 130;
            // 
            // Vrijeme_odrzavanja
            // 
            this.Vrijeme_odrzavanja.Text = "Vrijeme održavanja";
            this.Vrijeme_odrzavanja.Width = 130;
            // 
            // Trajanje
            // 
            this.Trajanje.Text = "Trajanje";
            this.Trajanje.Width = 90;
            // 
            // Prijava_do
            // 
            this.Prijava_do.Text = "Prijava do";
            this.Prijava_do.Width = 90;
            // 
            // Odjava_do
            // 
            this.Odjava_do.Text = "Odjava do";
            this.Odjava_do.Width = 90;
            // 
            // Nacin_polaganja
            // 
            this.Nacin_polaganja.Text = "Način polaganja";
            this.Nacin_polaganja.Width = 110;
            // 
            // Predavaonica
            // 
            this.Predavaonica.Text = "Predavaonica";
            this.Predavaonica.Width = 100;
            // 
            // ime_kolegija
            // 
            this.ime_kolegija.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ime_kolegija.AutoSize = true;
            this.ime_kolegija.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ime_kolegija.Location = new System.Drawing.Point(585, 22);
            this.ime_kolegija.Name = "ime_kolegija";
            this.ime_kolegija.Size = new System.Drawing.Size(132, 38);
            this.ime_kolegija.TabIndex = 1;
            this.ime_kolegija.Text = "Kolegij: ";
            this.ime_kolegija.Click += new System.EventHandler(this.ime_kolegija_Click);
            // 
            // Pregled_po_studentima_btn
            // 
            this.Pregled_po_studentima_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Pregled_po_studentima_btn.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pregled_po_studentima_btn.Location = new System.Drawing.Point(1375, 503);
            this.Pregled_po_studentima_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pregled_po_studentima_btn.Name = "Pregled_po_studentima_btn";
            this.Pregled_po_studentima_btn.Size = new System.Drawing.Size(380, 62);
            this.Pregled_po_studentima_btn.TabIndex = 2;
            this.Pregled_po_studentima_btn.Text = "PREGLED PO STUDENTIMA";
            this.Pregled_po_studentima_btn.UseVisualStyleBackColor = true;
            this.Pregled_po_studentima_btn.Click += new System.EventHandler(this.Pregled_po_studentima_btn_Click);
            // 
            // Dodaj_novi_ispit_btn
            // 
            this.Dodaj_novi_ispit_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Dodaj_novi_ispit_btn.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dodaj_novi_ispit_btn.Location = new System.Drawing.Point(34, 34);
            this.Dodaj_novi_ispit_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dodaj_novi_ispit_btn.Name = "Dodaj_novi_ispit_btn";
            this.Dodaj_novi_ispit_btn.Size = new System.Drawing.Size(231, 62);
            this.Dodaj_novi_ispit_btn.TabIndex = 3;
            this.Dodaj_novi_ispit_btn.Text = "DODAJ NOVI ISPIT";
            this.Dodaj_novi_ispit_btn.UseVisualStyleBackColor = true;
            this.Dodaj_novi_ispit_btn.Click += new System.EventHandler(this.Dodaj_novi_ispit_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Popis ispita:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Ukloni_ispit_btn
            // 
            this.Ukloni_ispit_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Ukloni_ispit_btn.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ukloni_ispit_btn.Location = new System.Drawing.Point(704, 34);
            this.Ukloni_ispit_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ukloni_ispit_btn.Name = "Ukloni_ispit_btn";
            this.Ukloni_ispit_btn.Size = new System.Drawing.Size(231, 62);
            this.Ukloni_ispit_btn.TabIndex = 5;
            this.Ukloni_ispit_btn.Text = "UKLONI ISPIT";
            this.Ukloni_ispit_btn.UseVisualStyleBackColor = true;
            this.Ukloni_ispit_btn.Click += new System.EventHandler(this.Ukloni_ispit_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonNatrag);
            this.panel1.Controls.Add(this.buttonPocetna);
            this.panel1.Controls.Add(this.ime_kolegija);
            this.panel1.Location = new System.Drawing.Point(3, -4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1828, 81);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel Light", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(379, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 41);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Corbel Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(264, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 41);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kolegij:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(704, 518);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(629, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Za detalje i unos rezultata studenata, odaberite ispit i kliknite:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RosyBrown;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Izmijeni_ispit_btn);
            this.panel2.Controls.Add(this.Dodaj_novi_ispit_btn);
            this.panel2.Controls.Add(this.Ukloni_ispit_btn);
            this.panel2.Location = new System.Drawing.Point(409, 622);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(985, 126);
            this.panel2.TabIndex = 11;
            // 
            // Izmijeni_ispit_btn
            // 
            this.Izmijeni_ispit_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Izmijeni_ispit_btn.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Izmijeni_ispit_btn.Location = new System.Drawing.Point(376, 31);
            this.Izmijeni_ispit_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Izmijeni_ispit_btn.Name = "Izmijeni_ispit_btn";
            this.Izmijeni_ispit_btn.Size = new System.Drawing.Size(231, 62);
            this.Izmijeni_ispit_btn.TabIndex = 6;
            this.Izmijeni_ispit_btn.Text = "IZMIJENI ISPIT";
            this.Izmijeni_ispit_btn.UseVisualStyleBackColor = true;
            this.Izmijeni_ispit_btn.Click += new System.EventHandler(this.Izmijeni_ispit_btn_Click);
            // 
            // Forma5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1827, 816);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pregled_po_studentima_btn);
            this.Controls.Add(this.Popis_ispita);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Forma5";
            this.Text = "Nastavnik - pregled ispita na kolegiju";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Popis_ispita;
        private System.Windows.Forms.ColumnHeader Ispit;
        private System.Windows.Forms.ColumnHeader Sadrzaj_ispita;
        private System.Windows.Forms.ColumnHeader Datum_odrzavanja;
        private System.Windows.Forms.Label ime_kolegija;
        private System.Windows.Forms.Button Pregled_po_studentima_btn;
        private System.Windows.Forms.Button Dodaj_novi_ispit_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Ukloni_ispit_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonNatrag;
        private System.Windows.Forms.Button buttonPocetna;
        private System.Windows.Forms.ColumnHeader Vrijeme_odrzavanja;
        private System.Windows.Forms.ColumnHeader Trajanje;
        private System.Windows.Forms.ColumnHeader Prijava_do;
        private System.Windows.Forms.ColumnHeader Odjava_do;
        private System.Windows.Forms.ColumnHeader Nacin_polaganja;
        private System.Windows.Forms.ColumnHeader Predavaonica;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Izmijeni_ispit_btn;
    }
}

