using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MongoDB.Bson;

namespace Fakultet
{
    public partial class FormPocetna : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("ispiti");
        static IMongoCollection<Kolegij> collection_kolegiji = db.GetCollection<Kolegij>("kolegiji");
        static IMongoCollection<Student> collection_studenti = db.GetCollection<Student>("studenti");
        static IMongoCollection<Nastavnik> collection_nastavnici = db.GetCollection<Nastavnik>("nastavnici");

        // Konstruktor
        public FormPocetna()
        {
            InitializeComponent();

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

        private void buttonStudent_Click(object sender, EventArgs e)
        {
            // Pokaži sljedeću formu (ispis kolegija studenta)
            //string imeStudenta = textBoxIme.Text;
            //string prezimeStudenta = textBoxPrezime.Text;

            Int64 jmbag;
            bool jeLiIspravanBroj = Int64.TryParse(textBoxJMBAG.Text, out jmbag);
            if (!jeLiIspravanBroj)
            {
                MessageBox.Show("Unesite JMBAG u pravilnom obliku.");
                return;
            }

            var studenti = collection_studenti.Find(s => s.Jmbag == jmbag).ToList();
            if (studenti.Count == 0)
            {
                MessageBox.Show("Ne postoji student s unesenim JMBAG-om, provjerite jeste li dobro unijeli podatke.");
                return;
            }

            FormIspisKolegija forma = new FormIspisKolegija(jmbag);
            //this.Close();
            this.Hide();
            forma.Show();


            /*
            listBox1.Items.Clear();
            List<Kolegij> list = collection_kolegiji.AsQueryable().ToList<Kolegij>();
            foreach (Kolegij p in list)
            {
                listBox1.Items.Add(p.Id);
                listBox1.Items.Add(p.Isvu_sifra);

                foreach (IspitNaKolegiju c in p.IspitiNaKolegiju)
                {
                    listBox1.Items.Add(c.Ispit_id);
                    listBox1.Items.Add(c.Datum_odrzavanja);
                    listBox1.Items.Add("\n");
                }
                listBox1.Items.Add("KRAJ ISPITA, SLJEDECI KOLEGIJ:\n");
            }
            */
        }

        private void buttonNastavnik_Click(object sender, EventArgs e)
        {
            // Pokaži sljedeću formu (ispis kolegija nastavnika)
            Int64 oibNastavnika; ;
            bool jeLiIspravanBroj = Int64.TryParse(textBoxOIB.Text, out oibNastavnika);
            if (!jeLiIspravanBroj)
            {
                MessageBox.Show("Unesite OIB u pravilnom obliku.");
                return;
            }

            var nastavnici = collection_nastavnici.Find(n => n.Oib == oibNastavnika).ToList();
            if (nastavnici.Count > 0)
            {
                FormIspisKolegijaNastavnika forma = new FormIspisKolegijaNastavnika(oibNastavnika);
                this.Hide();
                forma.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Ne postoji nastavnik s unesenim imenom i prezimenom, provjerite jeste li dobro unijeli podatke.");
            }

        }

        private void FormPocetna_Load(object sender, EventArgs e)
        {

        }
    }
}
