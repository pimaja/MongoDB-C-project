using MongoDB.Bson;
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
using System.Reflection;
using System.Windows.Forms;
using System.Globalization;

namespace Fakultet
{
    public partial class Forma8 : Form
    {

        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("ispiti");
        static IMongoCollection<Student> collectionSt = db.GetCollection<Student>("studenti");
        //static IMongoCollection<Kolegij> collectionKo = db.GetCollection<Kolegij>("kolegiji");        
        int dobiveno;
        Forma4 prethodnaForma;

        public void ReadAllDocuments(int sifra) // Početno postavljanje
        {


            List<string> kolone = new List<string>();
            kolone.Add("JMBAG");
            kolone.Add("Ime");
            kolone.Add("prezime");
            List<Student> list_studenti = collectionSt.AsQueryable().ToList<Student>();
            int i = 0;
            int br = 0;


            foreach (Student s in list_studenti)
            {
                foreach (KolegijStudenta k in s.KolegijiStudenta)
                {
                    //if (k.Naziv=="Oblikovanje i analiza algoritama")
                    //ovaj dio makni ako ne radi


                    foreach (IspitStudenta i_studenta in k.IspitiStudenta)
                    {

                        if (br == 0)
                        {
                            string a = (i + 1).ToString();
                            kolone.Add("Ispit" + a);
                            i++;
                        }
                    }
                    if (br == 0)
                        kolone.Add("Ocjena");
                    br++;

                }

            }
            for (int j = 0; j < kolone.Count; j++)
                listBox1.Items.Add(kolone[j]);
            br = 0;
            foreach (Student s in list_studenti)
            {

                foreach (KolegijStudenta k in s.KolegijiStudenta)
                {     // K.Naziv 
                    if (k.Isvu_sifra == sifra)
                    {
                        br++;
                        listBox1.Items.Add(s.Jmbag);
                        listBox1.Items.Add(s.Ime);
                        listBox1.Items.Add(s.Prezime);

                        foreach (IspitStudenta i_studenta in k.IspitiStudenta)
                        {
                            if (i_studenta.Rezultat == null)
                                listBox1.Items.Add("prijavljen");
                            else
                                listBox1.Items.Add(i_studenta.Rezultat);

                        }
                        // Mia T : promijenila ovaj uvjet u ifu da vidim jel mi MR radi
                        //if (k.Ocjena == "null")
                        if ( k.Ocjena == null )
                            listBox1.Items.Add(" ");
                        else
                            listBox1.Items.Add(k.Ocjena);

                        // Mia T
                        label7.Text = k.Naziv;

                    }
                }

            }
            int t = i + 4;
            i = t * br;
            listBox1.Items.Add(i.ToString());
            listBox1.Items.Add(t.ToString());
            for (int j = 0; j < listBox1.Items.Count; j++)
            {
                listBox1.SetSelected(j, true);
                kolone.Add(listBox1.SelectedItems[j].ToString());
            }


            for (int j = t; j < kolone.Count; j++)
                listBox2.Items.Add(kolone[j]);

            dataGridView2.ColumnCount = i / br;
            dataGridView2.RowCount = br;

            for (var j = 0; j < dataGridView2.ColumnCount; j++)
                dataGridView2.Columns[j].Name = kolone[j];

            for (var j = 0; j < dataGridView2.RowCount; j++)
            {
                int z = 0;
                while (z < dataGridView2.ColumnCount)
                {

                    dataGridView2.Rows[j].Cells[z].Value = kolone[dataGridView2.ColumnCount + z + (j + 1) * (dataGridView2.ColumnCount)];
                    z++;
                }

                // Mia T
                dataGridView2.Rows[j].Height = 20;
            }

            // Mia T - sirine i visine stupaca i redaka
            dataGridView2.Columns[0].Width = 100;
            dataGridView2.Columns[1].Width = 100;
            dataGridView2.Columns[2].Width = 100;
            dataGridView2.Columns[3].Width = 100;
            dataGridView2.Columns[4].Width = 100;
            dataGridView2.Columns[5].Width = 100;
            dataGridView2.Columns[6].Width = 100;
            dataGridView2.Width = 100 + 100 + 100 + 100 + 100 + 100 + 100 + 4;
            dataGridView2.Font = new Font("Corbel", 11);

            // Mia T
            // Sakrij zadnji, prazni redak:
            dataGridView2.AllowUserToAddRows = false;
            // Sakrij prvi, prazni stupac:
            dataGridView2.RowHeadersVisible = false;
            // Da se ne može ručno namještati veličina stupaca/redaka:
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;


            listBox1.Hide();
            listBox2.Hide();

            double prosjecnaOcjenaKolegija = 0;
            //MapReduce za prosječnu ocjenu kolegija
            string mapf = @"
                    function(){
                        for (var idx = 0; idx < this.kolegiji.length; idx++){
                            if( !this.kolegiji[idx].ocjena ) continue;

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

            //string zaMessageBox = "";

            try
            {
                var results = collection.MapReduce(map, reduce, options).ToList();
                Console.WriteLine("yay");

                // Ispis preko BsonValue
                foreach (BsonValue elem in results)
                {
                    Console.WriteLine(elem);
                    if (elem["_id"] == dobiveno)
                    {
                        Console.WriteLine("Direktno iz polja:" + elem["value"]["avg"].ToString());
                        prosjecnaOcjenaKolegija = double.Parse(elem["value"]["avg"].ToString(), CultureInfo.InvariantCulture);
                        Console.WriteLine("Odmah nakon parsiranja:" + prosjecnaOcjenaKolegija);
                        prosjecnaOcjenaKolegija = Math.Round(prosjecnaOcjenaKolegija, 2);

                        Console.WriteLine("prosjecnaOcjenaKolegija:" + prosjecnaOcjenaKolegija);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred {ex.Message}");
            }

            if (prosjecnaOcjenaKolegija == 0)
                Prosjecna_ocj_lbl.Text = "Trenutno nijedna ocjena na kolegiju nije zaključena.";
            else
            {
                if (prosjecnaOcjenaKolegija.ToString() == "NaN")
                {
                    for (var j = 0; j < dataGridView2.RowCount; j++)
                    {
                        string pom = dataGridView2.Rows[j].Cells[6].Value.ToString();

                        if (int.TryParse(pom, out _))
                        {
                            Prosjecna_ocj_lbl.Text = pom;
                            break;
                        }

                    }
                }
                else
                    Prosjecna_ocj_lbl.Text = prosjecnaOcjenaKolegija.ToString();
            }       

    }



        // tu mogu dobit podatak o kojem se podatku radi
        public Forma8(int Nkolegija, Forma4 forma)
        {
            InitializeComponent();
            // pronadi sve studente koji slusaju ovaj kolegij te ih ispisi iz studenti
            // te rezultate pojedinog ispita za pojedini ispit
            //MessageBox.Show(Nkolegija.ToString());
            dobiveno = Nkolegija;
            prethodnaForma = forma;
            ReadAllDocuments(dobiveno);


            var documents = collectionSt.Find(new BsonDocument()).ToList();


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
        

        private void Forma8_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //-------------------------------------------------------
            // fja za update
            if (textBox2.Text == "" && textBox3.Text == "")
                MessageBox.Show("Odaberi studenta");
            else
            {   //skuzi kako da se uneseni broj bude 1.0 2.0 3.0 5.0                
                if (!int.TryParse(textBox4.Text, out _))
                    MessageBox.Show("Ocjena mora biti cijeli broj");
                else if (int.Parse(textBox4.Text) > 5 || int.Parse(textBox4.Text) < 1)
                    MessageBox.Show("neispravan broj");
                else
                {
                    var filter = Builders<Student>.Filter.Eq("ime", textBox2.Text) & Builders<Student>.Filter.Eq("jmbag", int.Parse(textBox3.Text));
                    var update = Builders<Student>.Update.Set("kolegiji.$[i].ocjena", textBox4.Text);
                    // i.naziv promjeniti na ono sto dobijes
                    //MessageBox.Show(dobiveno.ToString());
                    // ovdje
                    var arrayFilters = new List<ArrayFilterDefinition> { new JsonArrayFilterDefinition<Student>("{'i.isvu_sifra':" + dobiveno + "}") };
                    var updateOptions = new UpdateOptions { ArrayFilters = arrayFilters };
                    collectionSt.UpdateOne(filter, update, updateOptions);

                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    // ovdje takoder
                    //koliko++;
                    ReadAllDocuments(dobiveno);
                }
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
