namespace Fakultet
{
    partial class FormIspisKolegijaNastavnika
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
            this.labelOdaberiKolegij = new System.Windows.Forms.Label();
            this.listViewPopisKolegijaNastavnika = new System.Windows.Forms.ListView();
            this.buttonOdaberi = new System.Windows.Forms.Button();
            this.buttonPocetna = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelOIB = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelPrezime = new System.Windows.Forms.Label();
            this.labelIme = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelOdaberiKolegij
            // 
            this.labelOdaberiKolegij.AutoSize = true;
            this.labelOdaberiKolegij.BackColor = System.Drawing.Color.Transparent;
            this.labelOdaberiKolegij.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOdaberiKolegij.Location = new System.Drawing.Point(494, 124);
            this.labelOdaberiKolegij.Name = "labelOdaberiKolegij";
            this.labelOdaberiKolegij.Size = new System.Drawing.Size(454, 19);
            this.labelOdaberiKolegij.TabIndex = 1;
            this.labelOdaberiKolegij.Text = "Odaberite kolegij za više detalja o pripadnim ispitima i studentima:";
            // 
            // listViewPopisKolegijaNastavnika
            // 
            this.listViewPopisKolegijaNastavnika.BackColor = System.Drawing.Color.AliceBlue;
            this.listViewPopisKolegijaNastavnika.HideSelection = false;
            this.listViewPopisKolegijaNastavnika.Location = new System.Drawing.Point(536, 167);
            this.listViewPopisKolegijaNastavnika.Name = "listViewPopisKolegijaNastavnika";
            this.listViewPopisKolegijaNastavnika.Size = new System.Drawing.Size(469, 292);
            this.listViewPopisKolegijaNastavnika.TabIndex = 2;
            this.listViewPopisKolegijaNastavnika.UseCompatibleStateImageBehavior = false;
            // 
            // buttonOdaberi
            // 
            this.buttonOdaberi.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOdaberi.Location = new System.Drawing.Point(895, 481);
            this.buttonOdaberi.Name = "buttonOdaberi";
            this.buttonOdaberi.Size = new System.Drawing.Size(154, 35);
            this.buttonOdaberi.TabIndex = 3;
            this.buttonOdaberi.Text = "Odaberi kolegij";
            this.buttonOdaberi.UseVisualStyleBackColor = true;
            this.buttonOdaberi.Click += new System.EventHandler(this.buttonOdaberi_Click);
            // 
            // buttonPocetna
            // 
            this.buttonPocetna.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPocetna.Location = new System.Drawing.Point(18, 17);
            this.buttonPocetna.Name = "buttonPocetna";
            this.buttonPocetna.Size = new System.Drawing.Size(90, 36);
            this.buttonPocetna.TabIndex = 4;
            this.buttonPocetna.Text = "Naslovna";
            this.buttonPocetna.UseVisualStyleBackColor = true;
            this.buttonPocetna.Click += new System.EventHandler(this.buttonPocetna_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Corbel Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(121, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 33);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pregled kolegija";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonPocetna);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1371, 66);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.labelOIB);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.labelPrezime);
            this.panel2.Controls.Add(this.labelIme);
            this.panel2.Location = new System.Drawing.Point(29, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 200);
            this.panel2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 23);
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
            // labelOIB
            // 
            this.labelOIB.AutoSize = true;
            this.labelOIB.BackColor = System.Drawing.Color.Transparent;
            this.labelOIB.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOIB.Location = new System.Drawing.Point(170, 138);
            this.labelOIB.Name = "labelOIB";
            this.labelOIB.Size = new System.Drawing.Size(40, 23);
            this.labelOIB.TabIndex = 16;
            this.labelOIB.Text = "Ime:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(119, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "OIB:";
            // 
            // labelPrezime
            // 
            this.labelPrezime.AutoSize = true;
            this.labelPrezime.BackColor = System.Drawing.Color.Transparent;
            this.labelPrezime.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrezime.Location = new System.Drawing.Point(170, 105);
            this.labelPrezime.Name = "labelPrezime";
            this.labelPrezime.Size = new System.Drawing.Size(40, 23);
            this.labelPrezime.TabIndex = 15;
            this.labelPrezime.Text = "Ime:";
            // 
            // labelIme
            // 
            this.labelIme.AutoSize = true;
            this.labelIme.BackColor = System.Drawing.Color.Transparent;
            this.labelIme.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIme.Location = new System.Drawing.Point(170, 70);
            this.labelIme.Name = "labelIme";
            this.labelIme.Size = new System.Drawing.Size(40, 23);
            this.labelIme.TabIndex = 14;
            this.labelIme.Text = "Ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(494, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "label2";
            // 
            // FormIspisKolegijaNastavnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 669);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonOdaberi);
            this.Controls.Add(this.listViewPopisKolegijaNastavnika);
            this.Controls.Add(this.labelOdaberiKolegij);
            this.Name = "FormIspisKolegijaNastavnika";
            this.Text = "Nastavnik - pregled kolegija";
            this.Load += new System.EventHandler(this.FormIspisKolegijaNastavnika_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelOdaberiKolegij;
        private System.Windows.Forms.ListView listViewPopisKolegijaNastavnika;
        private System.Windows.Forms.Button buttonOdaberi;
        private System.Windows.Forms.Button buttonPocetna;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelOIB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelPrezime;
        private System.Windows.Forms.Label labelIme;
        private System.Windows.Forms.Label label2;
    }
}