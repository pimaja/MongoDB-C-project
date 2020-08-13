using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fakultet
{
    public partial class FormIspisKolegijaNastavnika : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("ispiti");
        static IMongoCollection<Kolegij> collection_kolegiji = db.GetCollection<Kolegij>("kolegiji");
        static IMongoCollection<Student> collection_studenti = db.GetCollection<Student>("studenti");
        static IMongoCollection<Nastavnik> collection_nastavnici = db.GetCollection<Nastavnik>("nastavnici");

        Int64 OibNastavnika;

        // Konstruktor
        public FormIspisKolegijaNastavnika(Int64 oib)
        {
            OibNastavnika = oib;

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

        private void FormIspisKolegijaNastavnika_Load(object sender, EventArgs e)
        {
            listViewPopisKolegijaNastavnika.Visible = true;
            label2.Visible = false;

            // Uredi listView
            listViewPopisKolegijaNastavnika.View = View.Details;
            listViewPopisKolegijaNastavnika.Columns.Add("ISVU šifra", 80, HorizontalAlignment.Left);
            listViewPopisKolegijaNastavnika.Columns.Add("Naziv kolegija", 400, HorizontalAlignment.Left);
            listViewPopisKolegijaNastavnika.FullRowSelect = true;
            listViewPopisKolegijaNastavnika.MultiSelect = false;
            listViewPopisKolegijaNastavnika.Width = 80 + 400 + 4;
            listViewPopisKolegijaNastavnika.Font = new Font("Corbel", 11);

            // Pronađi odgovarajućeg nastavnika koji se ulogirao
            var nastavnici = collection_nastavnici.Find(n => n.Oib == OibNastavnika).ToList();
            foreach (var n in nastavnici)
            {

                // O meni
                labelIme.Text = n.Ime;
                labelPrezime.Text = n.Prezime;
                labelOIB.Text = n.Oib.ToString();

                // Ako ne drzi nijedan kolegij
                if (n.KolegijiNastavnika.Count == 0)
                {
                    listViewPopisKolegijaNastavnika.Visible = false;
                    label2.Visible = true;
                    label2.Text = "U bazi ne postoji nijedan kolegij kojeg držite.";
                }

                // Dodaj kolegije jedan po jedan u listView
                foreach (KolegijNastavnika k in n.KolegijiNastavnika)
                {
                    ListViewItem item = new ListViewItem(k.Isvu_sifra.ToString());
                    item.SubItems.Add(k.Naziv);
                    listViewPopisKolegijaNastavnika.Items.Add(item);
                }
            }
        }

        private void buttonPocetna_Click(object sender, EventArgs e)
        {
            FormPocetna forma = new FormPocetna();
            forma.Show();
            this.Close();
        }

        private void buttonOdaberi_Click(object sender, EventArgs e)
        {
            // Ako je dobro označen jedan kolegij, pokaži sljedeću (Fabinu) formu (ispis opcija)
            if (listViewPopisKolegijaNastavnika.SelectedItems.Count > 0)
            {
                string kolegij_isvu = listViewPopisKolegijaNastavnika.SelectedItems[0].Text;
                System.Console.WriteLine(kolegij_isvu);
                //double ocjenaZaFabu = 0;


                // MapReduce za prosjecnu ocjenu ovog kolegija, proslijedi ga u sljedecu formu
                int kolegij_isvu_int = Int32.Parse(kolegij_isvu);

              /*  string mapf = @"
                    function(){
                        for (var idx = 0; idx < this.kolegiji.length; idx++){
                            if( this.kolegiji[idx].ocjena == 'null' ) continue;

                            var key = this.kolegiji[idx].isvu_sifra;

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

                string zaMessageBox = "";

                try
                {
                    var results = collection.MapReduce(map, reduce, options).ToList();
                    Console.WriteLine("yay");

                    // Ispis preko BsonValue
                    foreach (BsonValue elem in results)
                    {
                        Console.WriteLine(elem);
                        if (elem["_id"] == kolegij_isvu_int)
                        {
                            ocjenaZaFabu = double.Parse(elem["value"]["avg"].ToString());
                            ocjenaZaFabu = Math.Round(ocjenaZaFabu, 2);
                            zaMessageBox += "Inače ide Fabina forma tu.\n\nProsječna ocjena na ovom kolegiju: " + ocjenaZaFabu;
                            //MessageBox.Show("Inače ide Fabina forma tu.\n\nProsječna ocjena na ovom kolegiju: " + ocjena);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred {ex.Message}");
                }



                // Map Reduce za Miju - prosjecna ocjena ispita s ovog kolegija
                mapf = @"
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


                reducef = @"
	                function(keyProdName, values){
	                    reducedVal = { count: 0, rezultat: 0 };

	                    for(var i = 0; i < values.length; i++){
		                    reducedVal.count += values[i].count;
		                    reducedVal.rezultat += values[i].rezultat;
	                    }

	                    return reducedVal;
                    }";


                finalizef = @"
	                function(key, reducedVal){
	                    reducedVal.avg = reducedVal.rezultat/reducedVal.count;
	                    return reducedVal;
                    }";


                map = new BsonJavaScript(mapf);
                reduce = new BsonJavaScript(reducef);
                options = new MapReduceOptions<Student, BsonDocument>
                {
                    Filter = filter,
                    MaxTime = TimeSpan.FromMinutes(1),
                    Finalize = new BsonJavaScript(finalizef),
                    OutputOptions = MapReduceOutputOptions.Inline,
                    Verbose = true
                };

                var dictionaryZaMiju = new Dictionary<int, string>();

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
                        Console.WriteLine("Vidi : " + isvu_kolegija + ", " + kolegij_isvu);
                        if (isvu_kolegija == kolegij_isvu)
                        {
                            // Zaokruzi avg na dvije decimale i dodaj "%" te dodaj u dictionary
                            double prosjek = double.Parse(elem["value"]["avg"].ToString());
                            prosjek = Math.Round(prosjek, 2);
                            string postotak = prosjek.ToString() + "%";

                            dictionaryZaMiju.Add(Int32.Parse(id_ispita), postotak);
                        }
                    }



                    foreach (int key in dictionaryZaMiju.Keys)
                        Console.WriteLine(key + " : " + dictionaryZaMiju[key]);

                    //MessageBox.Show(zaMessageBox);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred {ex.Message}");
                }*/


                // Fabina forma:
                Forma4 forma
                    = new Forma4(/*imeNastavnika, prezimeNastavnika, */kolegij_isvu_int, this); // TREBA I M/R REZ
                forma.Show();
                this.Hide();

                //MessageBox.Show("Ovo je umjesto nove (Fabine) forme, hellooooo! Ocjena prosjecna: " + ocjenaZaFabu);
                //MessageBox.Show(zaMessageBox);
            }

            // Ako nije dobro označen niti jedan kolegij, izbaci upozoravajuću poruku
            else
                MessageBox.Show("Nije odabran nijedan kolegij.");
        }
    }
}
