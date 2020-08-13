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
    public partial class FormIspisKolegija : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("ispiti");
        static IMongoCollection<Kolegij> collection_kolegiji = db.GetCollection<Kolegij>("kolegiji");
        static IMongoCollection<Student> collection_studenti = db.GetCollection<Student>("studenti");
        static IMongoCollection<Nastavnik> collection_nastavnici = db.GetCollection<Nastavnik>("nastavnici");

        Int64 jmbagStudenta;

        // Konstruktor
        public FormIspisKolegija(Int64 jmbag)
        {
            jmbagStudenta = jmbag;
            
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

        private void FormIspisKolegija_Load(object sender, EventArgs e)
        {
            listViewPopisKolegija.Visible = true;
            label9.Visible = false;

            // 1. Ispiši podatke studenta
            List<Student> list = collection_studenti.AsQueryable().ToList<Student>();

            // Pronađi odgovarajućeg studenta (onaj koji se ulogirao)
            foreach (Student s in list)
            {
                if (s.Jmbag == jmbagStudenta)
                {
                    // Podaci o studentu - lijeva strana forme
                    labelIme.Text = s.Ime;
                    labelPrezime.Text = s.Prezime;
                    labelJmbag.Text = s.Jmbag.ToString();
                    labelRazina.Text = s.Razina;
                    labelSmjer.Text = s.Smjer;

                    // Ako ne postoji nijedan upisan kolegij
                    if(s.KolegijiStudenta.Count == 0)
                    {
                        listViewPopisKolegija.Visible = false;
                        label9.Visible = true;
                        label9.Text = "Nije upisan nijedan kolegij.";
                    }

                    // Dodaj sve njegove kolegije jedan po jedan u listView
                    foreach (KolegijStudenta k in s.KolegijiStudenta)
                    {
                        ListViewItem item = new ListViewItem(k.Isvu_sifra.ToString());
                        item.SubItems.Add(k.Naziv);
                        item.SubItems.Add(k.Ects_bodovi.ToString());
                        if(k.Ocjena == null)
                            item.SubItems.Add("Nije zaključena ocjena.");
                        else
                            item.SubItems.Add(k.Ocjena);
                        listViewPopisKolegija.Items.Add(item);
                    }
                }
            }


            // 2. Map Reduce za prosječnu ocjenu semestra
            double prosjecnaOcjena = 0;

            string mapf = @"
                function(){
                    for (var idx = 0; idx < this.kolegiji.length; idx++){
                        if( !this.kolegiji[idx].ocjena ) continue;

                        var key = this.jmbag;

                        var ocjena_int = parseInt(this.kolegiji[idx].ocjena);
                        var value = {count: 1, ocjena: ocjena_int};

                        emit(key, value);
                    }
                }";


            string reducef = @"
	            function(keyProdName, values){
	                reducedVal = { count: 0, rezultat: 0 };

	                for(var i = 0; i < values.length; i++){
		                reducedVal.count += values[i].count;
		                reducedVal.rezultat += values[i].ocjena;
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
            FilterDefinition<Student> filter = filterBuilder.Where(s => s.Jmbag == jmbagStudenta);
            MapReduceOptions<Student, BsonDocument> options = new MapReduceOptions<Student, BsonDocument>
            {
                Filter = filter,
                MaxTime = TimeSpan.FromMinutes(1),
                Finalize = new BsonJavaScript(finalizef),
                OutputOptions = MapReduceOutputOptions.Inline,
                Verbose = true
            };
            try
            {
                var results = collection.MapReduce(map, reduce, options).ToList();
                //Console.WriteLine("yay");

                // Ako postoji avg ocjena (ako je zakljucena za bar jedan kolegij onda ce postojati avg)
                if (results.Count > 0)
                {
                    // Ispis preko BsonValue
                    foreach (BsonValue elem in results)
                    {
                        Console.WriteLine(elem);
                        prosjecnaOcjena = double.Parse( elem["value"]["avg"].ToString(), CultureInfo.InvariantCulture);
                        prosjecnaOcjena = Math.Round(prosjecnaOcjena, 2);
                        labelProsjecnaOcjenaStudenta.Text = "Prosjek ocjena položenih kolegija: " + prosjecnaOcjena;
                    }
                }

                // Ako nijedna ocjena nije zakljucena za ovog studenta
                else
                    labelProsjecnaOcjenaStudenta.Text = "Prosjek ocjena položenih kolegija: Trenutno nijedna ocjena nije zaključena.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred {ex.Message}");
            }


            // 3. Map Reduce za TEŽINSKU prosječnu ocjenu semestra
            double tezinskaProsjecnaOcjena = 0;

            string mapf2 = @"
                function(){
                    for (var idx = 0; idx < this.kolegiji.length; idx++){
                        if( !this.kolegiji[idx].ocjena ) continue;

                        var key = this.jmbag;

                        var ocjena_int = parseInt(this.kolegiji[idx].ocjena);
                        var value = { ocjena: ocjena_int, ects: this.kolegiji[idx].ects_bodovi };

                        emit(key, value);
                    }
                }";


            string reducef2 = @"
	            function(keyProdName, values){
	                reducedVal = { rezultat: 0, ects: 0 };

	                for(var i = 0; i < values.length; i++){
		                reducedVal.rezultat += (values[i].ocjena * values[i].ects);
		                reducedVal.ects += values[i].ects;
	                }

	                return reducedVal;
                }";


            string finalizef2 = @"
	            function(key, reducedVal){
	                reducedVal.avg = reducedVal.rezultat/reducedVal.ects;
	                return reducedVal;
                }";


            IMongoCollection<Student> collection2 = db.GetCollection<Student>("studenti");
            BsonJavaScript map2 = new BsonJavaScript(mapf2);
            BsonJavaScript reduce2 = new BsonJavaScript(reducef2);
            FilterDefinitionBuilder<Student> filterBuilder2 = new FilterDefinitionBuilder<Student>();
            FilterDefinition<Student> filter2 = filterBuilder.Where(s => s.Jmbag == jmbagStudenta);
            MapReduceOptions<Student, BsonDocument> options2 = new MapReduceOptions<Student, BsonDocument>
            {
                Filter = filter2,
                MaxTime = TimeSpan.FromMinutes(1),
                Finalize = new BsonJavaScript(finalizef2),
                OutputOptions = MapReduceOutputOptions.Inline,
                Verbose = true
            };
            try
            {
                var results2 = collection.MapReduce(map2, reduce2, options2).ToList();
                //Console.WriteLine("yay");

                // Ako postoji avg ocjena (ako je zakljucena za bar jedan kolegij onda ce postojati avg)
                if (results2.Count > 0)
                {
                    // Ispis preko BsonValue
                    foreach (BsonValue elem in results2)
                    {
                        Console.WriteLine(elem);
                        tezinskaProsjecnaOcjena = double.Parse(elem["value"]["avg"].ToString(), CultureInfo.InvariantCulture);
                        tezinskaProsjecnaOcjena = Math.Round(tezinskaProsjecnaOcjena, 2);
                        labelTezinskaProsjecnaOcjenaStudenta.Text = "Težinski prosjek ocjena položenih kolegija: " + tezinskaProsjecnaOcjena;
                    }
                }

                // Ako nijedna ocjena nije zakljucena za ovog studenta
                else
                    labelTezinskaProsjecnaOcjenaStudenta.Text = "Težinski prosjek ocjena položenih kolegija: Trenutno nijedna ocjena nije zaključena.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred {ex.Message}");
            }
        }

        private void buttonNaslovna_Click(object sender, EventArgs e)
        {
            FormPocetna forma = new FormPocetna();
            this.Close();
            forma.Show();
        }

        private void buttonOdaberiKolegij_Click(object sender, EventArgs e)
        {
            // Ako je dobro označen jedan kolegij, pokaži sljedeću formu (ispis ispita)
            if (listViewPopisKolegija.SelectedItems.Count > 0)
            {
                string kolegij_isvu = listViewPopisKolegija.SelectedItems[0].Text;
                FormIspisIspitaZaStudenta forma
                    = new FormIspisIspitaZaStudenta(jmbagStudenta, kolegij_isvu, this);
                this.Hide();
                forma.Show();
            }

            // Ako nije dobro označen niti jedan kolegij, izbaci upozoravajuću poruku
            else
                MessageBox.Show("Nije odabran nijedan kolegij.");
        }
    }
}
