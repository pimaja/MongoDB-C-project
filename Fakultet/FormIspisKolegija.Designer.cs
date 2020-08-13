namespace Fakultet
{
    partial class FormIspisKolegija
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
            this.listViewPopisKolegija = new System.Windows.Forms.ListView();
            this.columnHeaderIsvu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNazivKolegija = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEcts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOcjena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonOdaberiKolegij = new System.Windows.Forms.Button();
            this.labelOdaberiKolegijSPopisa = new System.Windows.Forms.Label();
            this.labelProsjecnaOcjenaStudenta = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonNaslovna = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelIme = new System.Windows.Forms.Label();
            this.labelPrezime = new System.Windows.Forms.Label();
            this.labelJmbag = new System.Windows.Forms.Label();
            this.labelRazina = new System.Windows.Forms.Label();
            this.labelSmjer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.labelTezinskaProsjecnaOcjenaStudenta = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewPopisKolegija
            // 
            this.listViewPopisKolegija.BackColor = System.Drawing.Color.AliceBlue;
            this.listViewPopisKolegija.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIsvu,
            this.columnHeaderNazivKolegija,
            this.columnHeaderEcts,
            this.columnHeaderOcjena});
            this.listViewPopisKolegija.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewPopisKolegija.FullRowSelect = true;
            this.listViewPopisKolegija.HideSelection = false;
            this.listViewPopisKolegija.Location = new System.Drawing.Point(452, 140);
            this.listViewPopisKolegija.MultiSelect = false;
            this.listViewPopisKolegija.Name = "listViewPopisKolegija";
            this.listViewPopisKolegija.Size = new System.Drawing.Size(693, 338);
            this.listViewPopisKolegija.TabIndex = 0;
            this.listViewPopisKolegija.UseCompatibleStateImageBehavior = false;
            this.listViewPopisKolegija.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderIsvu
            // 
            this.columnHeaderIsvu.Text = "ISVU šifra";
            this.columnHeaderIsvu.Width = 82;
            // 
            // columnHeaderNazivKolegija
            // 
            this.columnHeaderNazivKolegija.Text = "Naziv kolegija";
            this.columnHeaderNazivKolegija.Width = 350;
            // 
            // columnHeaderEcts
            // 
            this.columnHeaderEcts.Text = "ECTS bodovi";
            this.columnHeaderEcts.Width = 95;
            // 
            // columnHeaderOcjena
            // 
            this.columnHeaderOcjena.Text = "Ocjena";
            this.columnHeaderOcjena.Width = 155;
            // 
            // buttonOdaberiKolegij
            // 
            this.buttonOdaberiKolegij.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOdaberiKolegij.Location = new System.Drawing.Point(989, 499);
            this.buttonOdaberiKolegij.Name = "buttonOdaberiKolegij";
            this.buttonOdaberiKolegij.Size = new System.Drawing.Size(156, 28);
            this.buttonOdaberiKolegij.TabIndex = 1;
            this.buttonOdaberiKolegij.Text = "Odaberi kolegij";
            this.buttonOdaberiKolegij.UseVisualStyleBackColor = true;
            this.buttonOdaberiKolegij.Click += new System.EventHandler(this.buttonOdaberiKolegij_Click);
            // 
            // labelOdaberiKolegijSPopisa
            // 
            this.labelOdaberiKolegijSPopisa.AutoSize = true;
            this.labelOdaberiKolegijSPopisa.BackColor = System.Drawing.Color.Transparent;
            this.labelOdaberiKolegijSPopisa.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOdaberiKolegijSPopisa.Location = new System.Drawing.Point(448, 99);
            this.labelOdaberiKolegijSPopisa.Name = "labelOdaberiKolegijSPopisa";
            this.labelOdaberiKolegijSPopisa.Size = new System.Drawing.Size(389, 23);
            this.labelOdaberiKolegijSPopisa.TabIndex = 2;
            this.labelOdaberiKolegijSPopisa.Text = "Odaberite kolegij za detalje o pripadnim ispitima:";
            // 
            // labelProsjecnaOcjenaStudenta
            // 
            this.labelProsjecnaOcjenaStudenta.AutoSize = true;
            this.labelProsjecnaOcjenaStudenta.BackColor = System.Drawing.Color.Transparent;
            this.labelProsjecnaOcjenaStudenta.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProsjecnaOcjenaStudenta.Location = new System.Drawing.Point(448, 503);
            this.labelProsjecnaOcjenaStudenta.Name = "labelProsjecnaOcjenaStudenta";
            this.labelProsjecnaOcjenaStudenta.Size = new System.Drawing.Size(49, 19);
            this.labelProsjecnaOcjenaStudenta.TabIndex = 4;
            this.labelProsjecnaOcjenaStudenta.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.buttonNaslovna);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 66);
            this.panel1.TabIndex = 6;
            // 
            // buttonNaslovna
            // 
            this.buttonNaslovna.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNaslovna.Location = new System.Drawing.Point(12, 17);
            this.buttonNaslovna.Name = "buttonNaslovna";
            this.buttonNaslovna.Size = new System.Drawing.Size(81, 35);
            this.buttonNaslovna.TabIndex = 8;
            this.buttonNaslovna.Text = "Naslovna";
            this.buttonNaslovna.UseVisualStyleBackColor = true;
            this.buttonNaslovna.Click += new System.EventHandler(this.buttonNaslovna_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Corbel Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(97, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 33);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pregled upisanih kolegija";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(920, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 23);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "O meni";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ime:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Prezime:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(90, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "JMBAG:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Razina studija:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "Smjer studija:";
            // 
            // labelIme
            // 
            this.labelIme.AutoSize = true;
            this.labelIme.BackColor = System.Drawing.Color.Transparent;
            this.labelIme.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIme.Location = new System.Drawing.Point(180, 70);
            this.labelIme.Name = "labelIme";
            this.labelIme.Size = new System.Drawing.Size(40, 23);
            this.labelIme.TabIndex = 14;
            this.labelIme.Text = "Ime:";
            // 
            // labelPrezime
            // 
            this.labelPrezime.AutoSize = true;
            this.labelPrezime.BackColor = System.Drawing.Color.Transparent;
            this.labelPrezime.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrezime.Location = new System.Drawing.Point(180, 105);
            this.labelPrezime.Name = "labelPrezime";
            this.labelPrezime.Size = new System.Drawing.Size(40, 23);
            this.labelPrezime.TabIndex = 15;
            this.labelPrezime.Text = "Ime:";
            // 
            // labelJmbag
            // 
            this.labelJmbag.AutoSize = true;
            this.labelJmbag.BackColor = System.Drawing.Color.Transparent;
            this.labelJmbag.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJmbag.Location = new System.Drawing.Point(180, 138);
            this.labelJmbag.Name = "labelJmbag";
            this.labelJmbag.Size = new System.Drawing.Size(40, 23);
            this.labelJmbag.TabIndex = 16;
            this.labelJmbag.Text = "Ime:";
            // 
            // labelRazina
            // 
            this.labelRazina.AutoSize = true;
            this.labelRazina.BackColor = System.Drawing.Color.Transparent;
            this.labelRazina.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRazina.Location = new System.Drawing.Point(180, 174);
            this.labelRazina.Name = "labelRazina";
            this.labelRazina.Size = new System.Drawing.Size(40, 23);
            this.labelRazina.TabIndex = 17;
            this.labelRazina.Text = "Ime:";
            // 
            // labelSmjer
            // 
            this.labelSmjer.AutoSize = true;
            this.labelSmjer.BackColor = System.Drawing.Color.Transparent;
            this.labelSmjer.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSmjer.Location = new System.Drawing.Point(180, 208);
            this.labelSmjer.Name = "labelSmjer";
            this.labelSmjer.Size = new System.Drawing.Size(40, 23);
            this.labelSmjer.TabIndex = 18;
            this.labelSmjer.Text = "Ime:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labelSmjer);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.labelRazina);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.labelJmbag);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.labelPrezime);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.labelIme);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(12, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 271);
            this.panel2.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(448, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 20;
            this.label9.Text = "label9";
            // 
            // labelTezinskaProsjecnaOcjenaStudenta
            // 
            this.labelTezinskaProsjecnaOcjenaStudenta.AutoSize = true;
            this.labelTezinskaProsjecnaOcjenaStudenta.BackColor = System.Drawing.Color.Transparent;
            this.labelTezinskaProsjecnaOcjenaStudenta.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTezinskaProsjecnaOcjenaStudenta.Location = new System.Drawing.Point(449, 537);
            this.labelTezinskaProsjecnaOcjenaStudenta.Name = "labelTezinskaProsjecnaOcjenaStudenta";
            this.labelTezinskaProsjecnaOcjenaStudenta.Size = new System.Drawing.Size(51, 18);
            this.labelTezinskaProsjecnaOcjenaStudenta.TabIndex = 21;
            this.labelTezinskaProsjecnaOcjenaStudenta.Text = "label10";
            // 
            // FormIspisKolegija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 621);
            this.Controls.Add(this.labelTezinskaProsjecnaOcjenaStudenta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelProsjecnaOcjenaStudenta);
            this.Controls.Add(this.labelOdaberiKolegijSPopisa);
            this.Controls.Add(this.buttonOdaberiKolegij);
            this.Controls.Add(this.listViewPopisKolegija);
            this.Name = "FormIspisKolegija";
            this.Text = "Student - pregled kolegija";
            this.Load += new System.EventHandler(this.FormIspisKolegija_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewPopisKolegija;
        private System.Windows.Forms.ColumnHeader columnHeaderIsvu;
        private System.Windows.Forms.ColumnHeader columnHeaderNazivKolegija;
        private System.Windows.Forms.Button buttonOdaberiKolegij;
        private System.Windows.Forms.Label labelOdaberiKolegijSPopisa;
        private System.Windows.Forms.Label labelProsjecnaOcjenaStudenta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNaslovna;
        private System.Windows.Forms.ColumnHeader columnHeaderEcts;
        private System.Windows.Forms.ColumnHeader columnHeaderOcjena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelIme;
        private System.Windows.Forms.Label labelPrezime;
        private System.Windows.Forms.Label labelJmbag;
        private System.Windows.Forms.Label labelRazina;
        private System.Windows.Forms.Label labelSmjer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelTezinskaProsjecnaOcjenaStudenta;
    }
}