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
    public partial class Pregled_po_studentima : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("ispiti");
        static IMongoCollection<Student> kolekcijaStudent = db.GetCollection<Student>("studenti");
        static IMongoCollection<Kolegij> kolekcijaKolegij = db.GetCollection<Kolegij>("kolegiji");
        int isvu_sifra; 
        int ispit_id;
        string jmbag;
        string datum_odrzavanja;
        // Mia T
        Forma5 prethodnaForma;

        //Update popisa studenata
        public void ReadAllStudenti()
        {
            //Filtriraj i popiši studente koji su obavili ili prijavili zadani kolegij, a koji nemaju zaključenu ocjenu
            List<Student> list = kolekcijaStudent.AsQueryable().ToList<Student>();

            foreach (var s in list)
            {
                var kolegijStudent = s.KolegijiStudenta.Find(k => k.Isvu_sifra == isvu_sifra && k.Ocjena == null);
                var kolegijStudent_saOcjenom = s.KolegijiStudenta.Find(k => k.Isvu_sifra == isvu_sifra && k.Ocjena != null);

                if (kolegijStudent != null)
                {
                    // Mia T
                    label5.Text = kolegijStudent.Naziv;

                    var ispit = kolegijStudent.IspitiStudenta.Find(i => i.Ispit_id == ispit_id && (i.Status == "prijavljen" || i.Status == "obavljen"));

                    if (ispit != null)
                    {
                        ListViewItem item = new ListViewItem(new[]{
                            s.Jmbag.ToString(),
                            s.Ime + " " + s.Prezime,
                            ispit.Rezultat
                        });

                        Popis_studenata.Items.Add(item);

                        // Mia T
                        List<Kolegij> list_kolegiji = kolekcijaKolegij.AsQueryable().ToList<Kolegij>();
                        foreach (Kolegij kolegij_miat in list_kolegiji)
                        {
                            if (kolegij_miat.Isvu_sifra == isvu_sifra)
                            {
                                foreach(IspitNaKolegiju ispit_miat in kolegij_miat.IspitiNaKolegiju)
                                {
                                    if(ispit_miat.Ispit_id == ispit.Ispit_id)
                                    {
                                        label7.Text = ispit_miat.Sadrzaj;
                                    }
                                }
                            }
                        }
                        label7.Text += " (" + ispit.Ispit_id + ")";
                    }
                }
                else if(kolegijStudent == null && kolegijStudent_saOcjenom != null)
                {
                    label5.Text = kolegijStudent_saOcjenom.Naziv;

                    var ispit = kolegijStudent_saOcjenom.IspitiStudenta.Find(i => i.Ispit_id == ispit_id);

                    if (ispit != null)
                    {
                        ListViewItem item = new ListViewItem(new[]{
                            s.Jmbag.ToString(),
                            s.Ime + " " + s.Prezime,
                            ispit.Rezultat
                        });

                        Popis_studenata.Items.Add(item);
                    }

                    label5.Visible = false;
                    label7.Visible = false;
                    label1.Visible = false;
                    Unos_rezultata_textBox.Visible = false;
                    Pohrani_rezultat_btn.Visible = false;                    
                    //Popis_studenata.Visible = false;
                    label4.Text = "Svim studentima ovog kolegija je zaključena ocjena i nije moguća korekcija.";
                }
            }           

                //MapReduce za prosječni rezultat ispita
                string mapf = @"
                    function(){
                        for (var idx = 0; idx < this.kolegiji.length; idx++){
                            for(var j = 0; j < this.kolegiji[idx].ispiti.length; j++){
	                            if( !this.kolegiji[idx].ispiti[j].rezultat ) continue;

	                            var key = this.kolegiji[idx].ispiti[j].ispit_id;

                                var rezultat = this.kolegiji[idx].ispiti[j].rezultat;
	                            var rezultat_bez_postotka = rezultat.slice(0, -1);
                                var rezultat_broj = parseInt(rezultat_bez_postotka);
                                var value = { count: 1, rezultat: rezultat_broj };

	                            emit(key, value);
	                        }
                        }
                    }";


                string reducef = @"
	                function(keyProdName, values){
	                    reducedVal = { count: 0, rezultat: 0 };

	                    for(var i = 0; i < values.length; i++){
		                    reducedVal.count += values[i].count;
		                    reducedVal.rezultat += values[i].rezultat;
	                    }

	                    return reducedVal;
                    }";


                string finalizef = @"
	                function(key, reducedVal){
	                    reducedVal.avg = reducedVal.rezultat/reducedVal.count;
	                    return reducedVal;
                    }";



                IMongoCollection<Student> collection = db.GetCollection<Student>("studenti");
                BsonJavaScript map = new BsonJavaScript(mapf);
                BsonJavaScript reduce = new BsonJavaScript(reducef);
                FilterDefinitionBuilder<Student> filterBuilder = new FilterDefinitionBuilder<Student>();
                FilterDefinition<Student> filter = filterBuilder.Empty;
                //FilterDefinition<Student> filter = filterBuilder.Where(s => s.KolegijiStudenta.Any(k => k.Isvu_sifra == kolegij_isvu_int));
                MapReduceOptions<Student, BsonDocument> options = new MapReduceOptions<Student, BsonDocument>
                {
                    Filter = filter,
                    MaxTime = TimeSpan.FromMinutes(1),
                    Finalize = new BsonJavaScript(finalizef),
                    OutputOptions = MapReduceOutputOptions.Inline,
                    Verbose = true
                };

                var prosjeciPoIspitu = new Dictionary<int, string>();

                try
                {
                    var results2 = collection.MapReduce(map, reduce, options).ToList();
                    Console.WriteLine("yay3");


                    // Ispis preko BsonValue
                    foreach (BsonValue elem in results2)
                    {
                        Console.WriteLine(elem);

                        // Makni zadnju znamenku ispita da vidis jel to ispit iz zeljenog kolegija (id_ispita = isvu+znamenka)
                        string id_ispita = elem["_id"].ToString();
                        string isvu_kolegija = id_ispita.Remove(id_ispita.Length - 1);
                        //Console.WriteLine("Vidi : " + isvu_kolegija + ", " + isvu_sifra);
                        if (isvu_kolegija == isvu_sifra.ToString())
                        {
                        // Zaokruzi avg na dvije decimale i dodaj "%" te dodaj u dictionary 
                            Console.WriteLine("Direktno iz dictionary-a:" + elem["value"]["avg"].ToString());
                            double prosjek = double.Parse(elem["value"]["avg"].ToString(), CultureInfo.InvariantCulture);
                            Console.WriteLine("nakon double.Parse: " + prosjek);
                            prosjek = Math.Round(prosjek, 2);                          
                            string postotak = prosjek.ToString() + "%";                           

                            prosjeciPoIspitu.Add(Int32.Parse(id_ispita), postotak);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred {ex.Message}");
                }


            //Provjera je li ispit pisan
            var kolegij = kolekcijaKolegij.Find(k => k.Isvu_sifra == isvu_sifra).ToList();
                foreach (Kolegij k in kolegij)
                {
                    var ispit = k.IspitiNaKolegiju.Find(i => i.Ispit_id == ispit_id);
                    datum_odrzavanja = ispit.Datum_odrzavanja;
                    //Console.WriteLine("Datum odrzavanja: " + datum_odrzavanja);
                }

                DateTime danasnjiDatum = DateTime.Now;
                DateTime datumOdrzavanja = DateTime.ParseExact(datum_odrzavanja, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (datumOdrzavanja > danasnjiDatum)
                {
                    label1.Visible = false;
                    Unos_rezultata_textBox.Visible = false;
                    Pohrani_rezultat_btn.Visible = false;
                    label2.Visible = false;
                    Prosjek_lbl.Visible = false;
                    label2.Visible = false;
                    label4.Text = "Ispit još nije pisan! Ovo je popis studenata koji su prijavili ispit.";
                }
            else
            {
                if (prosjeciPoIspitu.ContainsKey(ispit_id))
                {
                    Console.WriteLine("Prosjek:" + prosjeciPoIspitu[ispit_id]);
                    Prosjek_lbl.Text = prosjeciPoIspitu[ispit_id];
                }
            }
          }
        
        public Pregled_po_studentima()
        {
            InitializeComponent();
            ReadAllStudenti();

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

        public Pregled_po_studentima(string id_ispita, int isvu_kolegija, Forma5 forma)
        {
            InitializeComponent();
            ispit_id = int.Parse(id_ispita);
            isvu_sifra = isvu_kolegija;
            // Mia T
            prethodnaForma = forma;
            ReadAllStudenti();

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
        private void Pregled_po_studentima_Load(object sender, EventArgs e)
        {
        }

        private void Popis_studenata_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Popis_studenata.SelectedItems.Count > 0)
            {
                jmbag = Popis_studenata.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void Pohrani_rezultat_btn_Click(object sender, EventArgs e)        
        {                     

            if (Popis_studenata.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberi prvo za kojeg studenta želiš ažurirati rezultat!");
            }           
            else if (String.IsNullOrEmpty(Unos_rezultata_textBox.Text))
            {
                MessageBox.Show("Unesi novi rezultat!");
            }
            else
            { 
                double jmbag_student = Double.Parse(jmbag);                

                var updateDef_1 = Builders<Student>.Update.Set("kolegiji.$[i].ispiti.$[j].rezultat", Unos_rezultata_textBox.Text);

                var arrayFilters_1 = new List<ArrayFilterDefinition> { new JsonArrayFilterDefinition<Student>(@"{'i.isvu_sifra':" + isvu_sifra + "}"),
                     new JsonArrayFilterDefinition<Student>(@"{'j.ispit_id':" + ispit_id + "}") };

                var updateOptions_1 = new UpdateOptions { ArrayFilters = arrayFilters_1 };

                kolekcijaStudent.UpdateOne(s => s.Jmbag == jmbag_student && s.KolegijiStudenta.Any(k => k.Isvu_sifra == isvu_sifra
                   && k.IspitiStudenta.Any(i => i.Ispit_id == ispit_id)),updateDef_1, updateOptions_1);

                //Korekcija statusa - vjerojatno treba samo korigirat u "obavljen"??????????
                var updateDef_2 = Builders<Student>.Update.Set("kolegiji.$[i].ispiti.$[j].status", "obavljen");

                var arrayFilters_2 = new List<ArrayFilterDefinition> { new JsonArrayFilterDefinition<Student>(@"{'i.isvu_sifra':" + isvu_sifra + "}"),
                     new JsonArrayFilterDefinition<Student>(@"{'j.ispit_id':" + ispit_id + "}") };

                var updateOptions_2 = new UpdateOptions { ArrayFilters = arrayFilters_2 };

                kolekcijaStudent.UpdateOne(s => s.Jmbag == jmbag_student && s.KolegijiStudenta.Any(k => k.Isvu_sifra == isvu_sifra
                   && k.IspitiStudenta.Any(i => i.Ispit_id == ispit_id)), updateDef_2, updateOptions_2);

                Popis_studenata.Items.Clear();
                ReadAllStudenti();
            }
        }

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
