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
    //Konstruktor za dodavanje ispita
    public partial class Dodaj_novi_ispit : Form
    {

        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("ispiti");
        static IMongoCollection<Kolegij> kolekcijaKolegij = db.GetCollection<Kolegij>("kolegiji");
        static IMongoCollection<Student> kolekcijaStudent = db.GetCollection<Student>("studenti");

        int isvu_sifra,ispit_id;
        string flag="";
        
        // Mia T - za gumb Natrag
        Forma4 pretprethodnaForma;
        public Dodaj_novi_ispit(Forma4 pretprethodna, int sifra_kolegija)
        {
            isvu_sifra = sifra_kolegija;
            InitializeComponent();

            // Mia T
            pretprethodnaForma = pretprethodna;

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

        //Konstruktor za izmjenu ispita
        public Dodaj_novi_ispit(Forma4 pretprethodna, int sifra_kolegija,int id_ispita, string flag_izmjena)
        {
            isvu_sifra = sifra_kolegija;
            flag = flag_izmjena;
            ispit_id = id_ispita;
            
            InitializeComponent();

            // Da polja budu ispunjena već starim vrijednostima

            var kolegij = kolekcijaKolegij.Find(k => k.Isvu_sifra == isvu_sifra).ToList();
            //ToList() - iz razloga što Find može vratit i više objekata, nije mu vidljivo da će za naš slučaj vratiti samo 1
            foreach (var k in kolegij)
            {                
                foreach (var i in k.IspitiNaKolegiju)
                {
                    if (i.Ispit_id == id_ispita)
                    {
                        Datum_odrzavanja_textBox.Text = i.Datum_odrzavanja;
                        Sadrzaj_textBox.Text = i.Sadrzaj;
                        Vrijeme_odrzavanja_textBox.Text = i.Vrijeme_odrzavanja;
                        Trajanje_textBox.Text = i.Trajanje.ToString();
                        Odjava_do_textBox.Text = i.Odjava_do;
                        Prijava_ispita_do_textBox.Text = i.Prijava_do;
                        Nacin_polaganja_textBox.Text = i.Nacin_polaganja;
                        Predavaonica_textBox.Text = i.Predavaonica;
                    }
                }
            }

            // Mia T
            pretprethodnaForma = pretprethodna;

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

        private void Dodaj_novi_ispit_Load(object sender, EventArgs e)
        {   
            if(flag != "")
            {
                Spremi_btn.Text = "POHRANI IZMJENE";                
            }
        }

        private void Spremi_btn_Click(object sender, EventArgs e)
        {
            // Ako nije pozvan konstruktor za izmjenu podataka o ispitu, onda imamo dodavanje novog ispita
            if (flag == "")
            {
                DateTime danasnjiDatum = DateTime.Now;
                DateTime datumOdrzavanja = DateTime.ParseExact(Datum_odrzavanja_textBox.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                
                //Ako je neki TextBox ostao prazan
                if (String.IsNullOrEmpty(Datum_odrzavanja_textBox.Text) || String.IsNullOrEmpty(Vrijeme_odrzavanja_textBox.Text) ||
                String.IsNullOrEmpty(Prijava_ispita_do_textBox.Text) || String.IsNullOrEmpty(Odjava_do_textBox.Text) ||
                String.IsNullOrEmpty(Nacin_polaganja_textBox.Text) || String.IsNullOrEmpty(Sadrzaj_textBox.Text) ||
                String.IsNullOrEmpty(Trajanje_textBox.Text) || String.IsNullOrEmpty(Predavaonica_textBox.Text))
                {
                    MessageBox.Show("Potrebno je popuniti sva polja!");
                }
                //Ako unosis datum prije danasnjeg
                else if (datumOdrzavanja < danasnjiDatum)
                {
                    MessageBox.Show("Nije moguće unijeti datum ispita raniji od današnjeg!");
                }
                else
                {
                    //Generiranje novog id-a
                    List<Kolegij> list = kolekcijaKolegij.AsQueryable().ToList<Kolegij>();
                    int novi_id = 0;

                    foreach (Kolegij k in list)
                    {
                        if (k.Isvu_sifra == isvu_sifra)
                        {
                            int duljina = k.IspitiNaKolegiju.Count;
                            novi_id = k.IspitiNaKolegiju[duljina - 1].Ispit_id;

                            // Mia T
                            label7.Text = k.Naziv;
                        }
                    }
                    novi_id++;
                    Console.WriteLine("Novi id: " + novi_id);

                    IspitNaKolegiju novi_ispit_kolegij = new IspitNaKolegiju(novi_id, Datum_odrzavanja_textBox.Text,
                                                              Vrijeme_odrzavanja_textBox.Text, Nacin_polaganja_textBox.Text, Prijava_ispita_do_textBox.Text, Odjava_do_textBox.Text,
                                                              Sadrzaj_textBox.Text, double.Parse(Trajanje_textBox.Text),
                                                              Predavaonica_textBox.Text);
                    var updateDef_1 = Builders<Kolegij>.Update.AddToSet("ispiti", novi_ispit_kolegij);
                    kolekcijaKolegij.UpdateOne(k => k.Isvu_sifra == isvu_sifra, updateDef_1);

                    IspitStudenta novi_ispit_studenta = new IspitStudenta(novi_id, "neprijavljen", null);
                    var updateDef_2 = Builders<Student>.Update.AddToSet("kolegiji.$[i].ispiti", novi_ispit_studenta);
                    var arrayFilters = new List<ArrayFilterDefinition> { new JsonArrayFilterDefinition<Student>(@"{'i.isvu_sifra':" + isvu_sifra + "}") };
                    var updateOptions = new UpdateOptions { ArrayFilters = arrayFilters };

                    kolekcijaStudent.UpdateMany(s => s.KolegijiStudenta.Any(k => k.Isvu_sifra == isvu_sifra), updateDef_2, updateOptions);

                    Forma5 forma5 = new Forma5(isvu_sifra, pretprethodnaForma);
                    this.Hide();
                    forma5.Show();
                }
            }

            //Inače, pozvan je konstruktor za izmjenu podataka o ispitu
            else
            {
                DateTime danasnjiDatum = DateTime.Now;
                DateTime datumOdrzavanja = DateTime.ParseExact(Datum_odrzavanja_textBox.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                //Ako je neki TextBox ostao prazan
                if (String.IsNullOrEmpty(Datum_odrzavanja_textBox.Text) || String.IsNullOrEmpty(Vrijeme_odrzavanja_textBox.Text) ||
                String.IsNullOrEmpty(Prijava_ispita_do_textBox.Text) || String.IsNullOrEmpty(Odjava_do_textBox.Text) ||
                String.IsNullOrEmpty(Nacin_polaganja_textBox.Text) || String.IsNullOrEmpty(Sadrzaj_textBox.Text) ||
                String.IsNullOrEmpty(Trajanje_textBox.Text) || String.IsNullOrEmpty(Predavaonica_textBox.Text))
                {
                    MessageBox.Show("Potrebno je popuniti sva polja!");
                }

                //Ako unosis datum prije danasnjeg
                else if (datumOdrzavanja < danasnjiDatum)
                {
                    MessageBox.Show("Nije moguće unijeti datum ispita raniji od današnjeg!");
                }
                else
                {
                    List<Kolegij> list = kolekcijaKolegij.AsQueryable().ToList<Kolegij>();
                    foreach (Kolegij k in list)
                    {
                        if (k.Isvu_sifra == isvu_sifra)
                        {   // Mia T
                            label7.Text = k.Naziv;
                        }
                    }

                    var updateDef_1 = Builders<Kolegij>.Update.Set("ispiti.$[i].datum_odrzavanja", Datum_odrzavanja_textBox.Text)
                                                               .Set("ispiti.$[i].vrijeme_odrzavanja", Vrijeme_odrzavanja_textBox.Text)
                                                               .Set("ispiti.$[i].prijava_do", Prijava_ispita_do_textBox.Text)
                                                               .Set("ispiti.$[i].odjava_do", Odjava_do_textBox.Text)
                                                               .Set("ispiti.$[i].nacin_polaganja", Nacin_polaganja_textBox.Text)
                                                               .Set("ispiti.$[i].sadrzaj", Sadrzaj_textBox.Text)
                                                               .Set("ispiti.$[i].trajanje", double.Parse(Trajanje_textBox.Text))
                                                               .Set("ispiti.$[i].predavaonica", Predavaonica_textBox.Text);


                    var arrayFilters_1 = new List<ArrayFilterDefinition> { new JsonArrayFilterDefinition<Kolegij>(@"{'i.ispit_id':" + ispit_id + "}") };
                    var updateOptions_1 = new UpdateOptions { ArrayFilters = arrayFilters_1 };

                    kolekcijaKolegij.UpdateOne(k => k.Isvu_sifra == isvu_sifra && k.IspitiNaKolegiju.Any(i => i.Ispit_id == ispit_id), updateDef_1,updateOptions_1);
                 

                    Forma5 forma5 = new Forma5(isvu_sifra, pretprethodnaForma);
                    this.Hide();
                    forma5.Show();
                }
            }
        }

        // MIa T
        private void buttonPocetna_Click(object sender, EventArgs e)
        {
            FormPocetna forma = new FormPocetna();
            forma.Show();
            this.Close();
        }

        // Mia T
        private void buttonNatrag_Click(object sender, EventArgs e)
        {
            Forma5 forma = new Forma5(isvu_sifra, pretprethodnaForma);
            forma.Show();
            this.Close();
        }
    }
}
