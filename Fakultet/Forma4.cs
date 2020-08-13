using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Threading;

namespace Fakultet
{
    public partial class Forma4 : Form
    {
        // Mia T
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("ispiti");
        static IMongoCollection<Kolegij> collection_kolegiji = db.GetCollection<Kolegij>("kolegiji");

        int dobiveno;
        double prosjecnaOcjenaKolegija;
        FormIspisKolegijaNastavnika prethodnaForma;

        // staviti int sifra        

        //Konstruktor
        public Forma4(int isvu_kolegija, FormIspisKolegijaNastavnika forma)
        {
            dobiveno = isvu_kolegija;
            // Mia T - za gumb natrag
            prethodnaForma = forma;

            InitializeComponent();


            // Mia T - dizajn

            // Da se forma otvori u full screen obliku
            this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = FormBorderStyle.None; // s ovim se ne vidi na taskbar traka
            this.WindowState = FormWindowState.Maximized;
            this.Dock = DockStyle.Fill;
            this.BringToFront();

            // Background i panel stretch
            //Image myimage = new Bitmap(@"C:\Users\Mia\Desktop\faks\napredneBazePodataka\AplikacijaZaIspite\AplikacijaZaIspite\images\background-pmf-lightblue2.png");
            Image myimage = new Bitmap(@"C:\Users\Mia\Desktop\Faks\RACUNARSTVO 2019_2020\2. SEMESTAR\Napredne baze podataka\projekt\Fakultet\images\background-pmf-lightblue2.png");
            this.BackgroundImage = myimage;
            panel1.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;
        }

        public Forma4()
        {            
        }

        private void Forma4_Load(object sender, EventArgs e)
        {
            // InitializeComponent();
            // ovdje maknuti komentar
            //dobiveno = sifra;

            // Mia T
            List<Kolegij> list_kolegiji = collection_kolegiji.AsQueryable().ToList<Kolegij>();
            foreach (Kolegij k_svi in list_kolegiji)
            {
                if (k_svi.Isvu_sifra == dobiveno)
                {
                    // Mia T
                    label2.Text = k_svi.Naziv;

                    // Mia T - o kolegiju
                    labelNaziv.Text = k_svi.Naziv;
                    labelISVU.Text = k_svi.Isvu_sifra.ToString();
                    labelECTS.Text = k_svi.Ects_bodovi.ToString();
                    labelSemestar.Text = k_svi.Semestar;
                    labelIzborna.Text = k_svi.Izborna_grupa;
                    labelNositelj.Text = k_svi.Nositelj;
                    labelNastavnisadrzaj.Text = k_svi.Nastavni_sadrzaji;
                }
            }
        }

        private void Kolegiji_Click(object sender, EventArgs e)
        {

            //Prelazak u formu 5
            Forma5 forma = new Forma5(dobiveno, this);
            forma.Show();
            this.Hide();


        }

        private void openNewForm(object obj)
        {


        }

        private void studenti_Click(object sender, EventArgs e)
        {

            Forma8 newForm2 = new Forma8(dobiveno, this);
            newForm2.Show();
            this.Hide();
        }

        // Mia T
        private void buttonNatrag_Click(object sender, EventArgs e)
        {
            prethodnaForma.Show();
            this.Close();
        }

        // Mia T
        private void buttonPocetna_Click(object sender, EventArgs e)
        {
            FormPocetna forma = new FormPocetna();
            forma.Show();
            this.Close();
        }
    }
}
