namespace Fakultet
{
    partial class FormIspisIspitaZaStudenta
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
            this.labelKonacnaOcjena = new System.Windows.Forms.Label();
            this.dataGridViewPopisIspita = new System.Windows.Forms.DataGridView();
            this.labelUspjesno = new System.Windows.Forms.Label();
            this.buttonPocetna = new System.Windows.Forms.Button();
            this.buttonNatrag = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopisIspita)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelKonacnaOcjena
            // 
            this.labelKonacnaOcjena.AutoSize = true;
            this.labelKonacnaOcjena.BackColor = System.Drawing.Color.Transparent;
            this.labelKonacnaOcjena.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKonacnaOcjena.Location = new System.Drawing.Point(29, 379);
            this.labelKonacnaOcjena.Name = "labelKonacnaOcjena";
            this.labelKonacnaOcjena.Size = new System.Drawing.Size(138, 23);
            this.labelKonacnaOcjena.TabIndex = 1;
            this.labelKonacnaOcjena.Text = "Konačna ocjena:";
            // 
            // dataGridViewPopisIspita
            // 
            this.dataGridViewPopisIspita.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewPopisIspita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPopisIspita.Location = new System.Drawing.Point(33, 156);
            this.dataGridViewPopisIspita.Name = "dataGridViewPopisIspita";
            this.dataGridViewPopisIspita.Size = new System.Drawing.Size(1217, 220);
            this.dataGridViewPopisIspita.TabIndex = 2;
            this.dataGridViewPopisIspita.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPopisIspita_CellClick);
            this.dataGridViewPopisIspita.SelectionChanged += new System.EventHandler(this.dataGridViewPopisIspita_SelectionChanged);
            // 
            // labelUspjesno
            // 
            this.labelUspjesno.AutoSize = true;
            this.labelUspjesno.BackColor = System.Drawing.Color.Transparent;
            this.labelUspjesno.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUspjesno.Location = new System.Drawing.Point(984, 379);
            this.labelUspjesno.Name = "labelUspjesno";
            this.labelUspjesno.Size = new System.Drawing.Size(225, 23);
            this.labelUspjesno.TabIndex = 3;
            this.labelUspjesno.Text = "Uspješno ste prijavili ispit.";
            // 
            // buttonPocetna
            // 
            this.buttonPocetna.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPocetna.Location = new System.Drawing.Point(11, 12);
            this.buttonPocetna.Name = "buttonPocetna";
            this.buttonPocetna.Size = new System.Drawing.Size(84, 43);
            this.buttonPocetna.TabIndex = 4;
            this.buttonPocetna.Text = "Naslovna";
            this.buttonPocetna.UseVisualStyleBackColor = true;
            this.buttonPocetna.Click += new System.EventHandler(this.buttonPocetna_Click);
            // 
            // buttonNatrag
            // 
            this.buttonNatrag.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNatrag.Location = new System.Drawing.Point(103, 12);
            this.buttonNatrag.Name = "buttonNatrag";
            this.buttonNatrag.Size = new System.Drawing.Size(75, 43);
            this.buttonNatrag.TabIndex = 5;
            this.buttonNatrag.Text = "Natrag";
            this.buttonNatrag.UseVisualStyleBackColor = true;
            this.buttonNatrag.Click += new System.EventHandler(this.buttonNatrag_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonNatrag);
            this.panel1.Controls.Add(this.buttonPocetna);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1371, 66);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel Light", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(287, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 33);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Corbel Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(198, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 33);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kolegij:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // FormIspisIspitaZaStudenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 640);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelUspjesno);
            this.Controls.Add(this.dataGridViewPopisIspita);
            this.Controls.Add(this.labelKonacnaOcjena);
            this.Name = "FormIspisIspitaZaStudenta";
            this.Text = "Student - pregled ispita na kolegiju";
            this.Load += new System.EventHandler(this.FormIspisIspitaZaStudenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopisIspita)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelKonacnaOcjena;
        private System.Windows.Forms.DataGridView dataGridViewPopisIspita;
        private System.Windows.Forms.Label labelUspjesno;
        private System.Windows.Forms.Button buttonPocetna;
        private System.Windows.Forms.Button buttonNatrag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}