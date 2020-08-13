using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fakultet
{
    public partial class Forma5 : System.Windows.Forms.Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("ispiti");
        static IMongoCollection<Kolegij> kolekcijaKolegij = db.GetCollection<Kolegij>("kolegiji");
        static IMongoCollection<Student> kolekcijaStudent = db.GetCollection<Student>("studenti");       

        string id_ispita;
        int isvu_sifra;
        string datum_odrzavanja;
        Forma4 prethodnaForma;
        public void ReadAllIspiti()
        {
            var kolegij = kolekcijaKolegij.Find(k => k.Isvu_sifra == isvu_sifra).ToList();
            //ToList() - iz razloga što Find može vratit i više objekata, nije mu vidljivo da će za naš slučaj vratiti samo 1
            foreach (var k in kolegij)
            {
                // Mia T - izmijenila ove labele da mi pasu dizajnu
                //ime_kolegija.Text = "Kolegij: "+ k.Naziv;
                label2.Text = k.Naziv;
                ime_kolegija.Visible = false;
                /*
                foreach(var i in k.IspitiNaKolegiju)
                {                   
                    ListViewItem item = new ListViewItem(new[]{
                            i.Ispit_id.ToString(),
                            i.Sadrzaj,
                            i.Datum_odrzavanja
                        });

                    Popis_ispita.Items.Add(item);
                }
                */
                //Mia T: dodala stvari u gornji foreach - izbrisi cijeli donji foreach i odkomentiraj gornji da bi bilo sve po starom kak si ti MiaM napravila!
                foreach (var i in k.IspitiNaKolegiju)
                {
                    ListViewItem item = new ListViewItem(new[]{
                            i.Ispit_id.ToString(),
                            i.Sadrzaj,
                            i.Datum_odrzavanja,
                            i.Vrijeme_odrzavanja + ":00",
                            i.Trajanje.ToString() + " minuta",
                            i.Prijava_do,
                            i.Odjava_do,
                            i.Nacin_polaganja,
                            i.Predavaonica
                        });

                    Popis_ispita.Items.Add(item);
                }
            }
        }
        public Forma5()
        {
            InitializeComponent();
            ReadAllIspiti();
        }
        public Forma5(int isvu_kolegija, Forma4 forma)
        {            
            InitializeComponent();
            isvu_sifra = isvu_kolegija;
            // Mia T
            prethodnaForma = forma;

            ReadAllIspiti();

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

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Pregled_po_studentima_btn_Click(object sender, EventArgs e)
        {
            if (Popis_ispita.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberi prvo za koji ispit želiš pregled!");
            }
            else
            {
                Pregled_po_studentima forma6 = new Pregled_po_studentima(id_ispita,isvu_sifra,this);                
                forma6.Show(/*this*/);
                // Mia T
                this.Hide();
            }
        }

        private void Popis_ispita_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Popis_ispita.SelectedItems.Count > 0)
            {
                id_ispita= Popis_ispita.SelectedItems[0].SubItems[0].Text;              
            }
        }

        private void Dodaj_novi_ispit_btn_Click(object sender, EventArgs e)
        {           
               Dodaj_novi_ispit  forma7 = new Dodaj_novi_ispit(prethodnaForma,isvu_sifra);
               this.Hide();
               forma7.Show();
        }
        private void Izmijeni_ispit_btn_Click(object sender, EventArgs e)
        {
            if (Popis_ispita.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberi prvo koji ispit želiš izmijeniti!");
            }
            else
            {   
                //Treba paziti na to da ne možemo izmijeniti ispit koji je već pisan
                var kolegij = kolekcijaKolegij.Find(k => k.Isvu_sifra == isvu_sifra).ToList();
                foreach (Kolegij k in kolegij)
                {
                    var ispit = k.IspitiNaKolegiju.Find(i => i.Ispit_id == int.Parse(id_ispita));
                    datum_odrzavanja = ispit.Datum_odrzavanja;
                }

                DateTime danasnjiDatum = DateTime.Now;
                DateTime datumOdrzavanja = DateTime.ParseExact(datum_odrzavanja, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (datumOdrzavanja < danasnjiDatum)
                {

                    MessageBox.Show("Ispit je već pisan i nije ga moguće izmijeniti");
                }
                else
                {
                    Dodaj_novi_ispit forma7 = new Dodaj_novi_ispit(prethodnaForma, isvu_sifra, int.Parse(id_ispita), "izmijeni");
                    this.Hide();
                    forma7.Show();
                }
            }            
        }

        private void Ukloni_ispit_btn_Click(object sender, EventArgs e)
        {
            if (Popis_ispita.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberi prvo koji ispit želiš ukloniti!");
            }
            else
            {   //Brisanje potrebno obaviti i iz kolekcije "kolegiji", i iz kolekcije "studenti", i to samo u slučaju da ispit još nije pisan
                var kolegij = kolekcijaKolegij.Find(k => k.Isvu_sifra == isvu_sifra).ToList();
                foreach (Kolegij k in kolegij)
                {
                    var ispit = k.IspitiNaKolegiju.Find(i => i.Ispit_id == int.Parse(id_ispita));
                    datum_odrzavanja = ispit.Datum_odrzavanja;
                    //Console.WriteLine("Datum odrzavanja: " + datum_odrzavanja);
                }

                DateTime danasnjiDatum = DateTime.Now;
                DateTime datumOdrzavanja = DateTime.ParseExact(datum_odrzavanja, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (datumOdrzavanja > danasnjiDatum)
                {

                    var update_kolegij = Builders<Kolegij>.Update.PullFilter(k => k.IspitiNaKolegiju, i => i.Ispit_id == Int32.Parse(id_ispita));
                    var result = kolekcijaKolegij.FindOneAndUpdateAsync(k => k.Isvu_sifra == isvu_sifra, update_kolegij).Result;
                    var update_student = Builders<Student>.Update.PullFilter("kolegiji.$[i].ispiti", Builders<BsonDocument>.Filter.Eq("ispit_id", Int32.Parse(id_ispita)));
                    var arrayFilters = new List<ArrayFilterDefinition> { new JsonArrayFilterDefinition<Student>(@"{'i.isvu_sifra':" + isvu_sifra + "}") };
                    var updateOptions = new UpdateOptions { ArrayFilters = arrayFilters };

                    kolekcijaStudent.UpdateMany(s => s.KolegijiStudenta.Any(k => k.Isvu_sifra == isvu_sifra
                                                && k.IspitiStudenta.Any(i => i.Ispit_id == Int32.Parse(id_ispita))), update_student, updateOptions);

                    Popis_ispita.Items.Clear();
                    ReadAllIspiti();
                }
                else
                {
                    MessageBox.Show("Ispit je već pisan i nije ga moguće ukloniti");
                }
            }
        }

        private void ime_kolegija_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Mia T
        private void buttonPocetna_Click(object sender, EventArgs e)
        {
            FormPocetna forma = new FormPocetna();
            forma.Show();
            this.Close();
        }

        private void buttonNatrag_Click(object sender, EventArgs e)
        {
            prethodnaForma.Show();
            this.Close();
        }        
    }
}
