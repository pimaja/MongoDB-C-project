using MongoDB.Driver;
using System;
using System.Collections;
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
    public partial class FormIspisIspitaZaStudenta : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("ispiti");
        static IMongoCollection<Kolegij> collection_kolegiji = db.GetCollection<Kolegij>("kolegiji");
        static IMongoCollection<Student> collection_studenti = db.GetCollection<Student>("studenti");
        //static IMongoCollection<Nastavnik> collection_nastavnici = db.GetCollection<Nastavnik>("nastavnici");

        string Kolegij_isvu;
        Int64 JmbagStudenta;
        FormIspisKolegija PrethodnaForma;

        // Konstruktor
        public FormIspisIspitaZaStudenta(Int64 jmbag, string kolegij_isvu, FormIspisKolegija prethodnaForma)
        {
            JmbagStudenta = jmbag;
            Kolegij_isvu = kolegij_isvu;
            PrethodnaForma = prethodnaForma;
            
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

        // Update dataGridViewPopisIspita
        private void updateDataGridView()
        {
            String ispit_id, sadrzaj, datum_odrzavanja, status = "", rok_za_prijavu, rok_za_odjavu, rezultat = ""; // za popunjavanje jednog retka u datagridview
            String ocjena = ""; // za label dolje
            int broj_ispita = 0; // za uređivanje buttona u pojedinim recima

            // Dodaj i uredi stupce u DataGridView
            dataGridViewPopisIspita.ColumnCount = 7;
            dataGridViewPopisIspita.Columns[0].Name = "ID ispita";
            dataGridViewPopisIspita.Columns[0].Width = 70;
            dataGridViewPopisIspita.Columns[1].Name = "Ispit";
            dataGridViewPopisIspita.Columns[1].Width = 430;
            dataGridViewPopisIspita.Columns[2].Name = "Datum održavanja";
            dataGridViewPopisIspita.Columns[2].Width = 100;
            dataGridViewPopisIspita.Columns[3].Name = "Status";
            dataGridViewPopisIspita.Columns[3].Width = 100;
            dataGridViewPopisIspita.Columns[4].Name = "Rok za prijavu";
            dataGridViewPopisIspita.Columns[4].Width = 100;
            dataGridViewPopisIspita.Columns[5].Name = "Rok za odjavu";
            dataGridViewPopisIspita.Columns[5].Width = 100;
            dataGridViewPopisIspita.Columns[6].Name = "Rezultat";
            dataGridViewPopisIspita.Columns[6].Width = 75;

            // Dodaj BUTTON COLUMN
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Ako nije prošao rok, prikazat će se gumb za prijavu/odjavu";
            btn.Name = "btn";
            btn.Text = "Click click beep!";
            btn.FlatStyle = FlatStyle.Flat;
            btn.DefaultCellStyle.BackColor = Color.Red;
            //btn.UseColumnTextForButtonValue = true;
            dataGridViewPopisIspita.Columns.Add(btn);
            dataGridViewPopisIspita.Columns[7].Width = 160;

            dataGridViewPopisIspita.Width = 70 + 430 + 100 + 100 + 100 + 100 + 75 + 160 + 3;
            dataGridViewPopisIspita.Height = 200;
            dataGridViewPopisIspita.Font = new Font("Corbel", 11);

            // Pronađi potrebne informacije o ispitu
            List<Student> list_studenti = collection_studenti.AsQueryable().ToList<Student>();
            string ime_kolegija = "";

            // Pronađi odgovarajućeg studenta koji se ulogirao
            foreach (Student s in list_studenti)
            {
                if (s.Jmbag == JmbagStudenta)
                {
                    // Pronađi odabrani kolegij iz prethodne forme
                    List<Kolegij> list_kolegiji = collection_kolegiji.AsQueryable().ToList<Kolegij>();
                    foreach (Kolegij k_svi in list_kolegiji)
                    {
                        if (k_svi.Isvu_sifra.ToString() == Kolegij_isvu)
                        {
                            ime_kolegija = k_svi.Naziv;

                            if(k_svi.IspitiNaKolegiju.Count == 0)
                            {
                                dataGridViewPopisIspita.Visible = false;
                                label3.Visible = true;
                                label3.Text = "Ne postoji nijedan ispit u bazi za kolegij " + k_svi.Nastavni_sadrzaji;
                            }

                            // Sad pronađi sve ispite tog kolegija koji postoje, da bi ih ispisala
                            foreach (IspitNaKolegiju i_kolegija in k_svi.IspitiNaKolegiju)
                            {
                                broj_ispita++;
                                ispit_id = i_kolegija.Ispit_id.ToString();
                                sadrzaj = i_kolegija.Sadrzaj;
                                datum_odrzavanja = i_kolegija.Datum_odrzavanja;
                                rok_za_prijavu = i_kolegija.Prijava_do;
                                rok_za_odjavu = i_kolegija.Odjava_do;

                                // Sad pronađi taj isti ispit u kolekciji Studenti, da znamo za status i rezultat
                                // ... Prvo: pronađi odgovarajući kolegij
                                foreach (KolegijStudenta k_studenta in s.KolegijiStudenta)
                                {
                                    if (k_studenta.Isvu_sifra.ToString() == Kolegij_isvu)
                                    {
                                        // ... Drugo: pronađi odgovarajući ispit u tom kolegiju
                                        foreach (IspitStudenta i_studenta in k_studenta.IspitiStudenta)
                                        {
                                            if (i_kolegija.Ispit_id == i_studenta.Ispit_id)
                                            {
                                                status = i_studenta.Status;
                                                rezultat = i_studenta.Rezultat;
                                                break;
                                            }
                                        }

                                        // ... Treće: spremi trenutnu ocjenu za kolegij
                                        if (k_studenta.Ocjena != null)
                                            ocjena = k_studenta.Ocjena;
                                        else
                                            ocjena = "Ocjena još uvijek nije unesena.";
                                    }
                                }

                                // Napokon dodaj redak u tablicu
                                ArrayList row = new ArrayList();
                                row.Add(ispit_id);
                                row.Add(sadrzaj);
                                row.Add(datum_odrzavanja);
                                row.Add(status);
                                row.Add(rok_za_prijavu);
                                row.Add(rok_za_odjavu);
                                row.Add(rezultat);
                                dataGridViewPopisIspita.Rows.Add(row.ToArray());

                                // Namjesti odgovarajuci tekst gumba za taj redak, ovisno o statusu ispita
                                // - ako je ispit neprijavljen, moze prijaviti (ako nije prosao rok)
                                if (status == "neprijavljen")
                                {
                                    // Provjeri je li prosao rok za prijavu
                                    DateTime danasnjiDatum = DateTime.Now;
                                    DateTime prijavaDoDatuma = DateTime.ParseExact(rok_za_prijavu, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                                    // ... ako na vrijeme prijavljuje
                                    if (prijavaDoDatuma > danasnjiDatum)
                                    {
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Value = "Prijavi";
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Style.BackColor = Color.LightBlue;
                                    }

                                    // ... ako ne prijavljuje na vrijeme, neka ne bude gumba (tako da pretvoris tu celiju u text celiju)
                                    else
                                    {
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Value = false;
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7] = new DataGridViewTextBoxCell();
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Value = "Prošao je rok za prijavu ispita.";
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Style.BackColor = Color.LightGray;
                                    }
                                }

                                // - ako je ispit polozen, ne moze prijaviti nikako
                                else if (status == "obavljen")
                                {
                                    dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Value = false;
                                    dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7] = new DataGridViewTextBoxCell();
                                    dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Value = "Ispit je već obavljen.";
                                    dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Style.BackColor = Color.LightGray;
                                }

                                // - ako je ispit prijavljen, moze ga odjaviti (ako nije prosao rok)
                                else
                                {
                                    // Provjeri odjavljuje li na vrijeme
                                    DateTime danasnjiDatum = DateTime.Now;
                                    DateTime odjavaDoDatuma = DateTime.ParseExact(rok_za_odjavu, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                    int result = DateTime.Compare(odjavaDoDatuma, danasnjiDatum);

                                    // ... Ako odjavljuje na vrijeme
                                    if (result > 0)
                                    {
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Value = "Odjavi";
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Style.BackColor = Color.LightBlue;
                                    }

                                    // ... Ako ne odjavljuje na vrijeme, makni gumb
                                    else
                                    {
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Value = false;
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7] = new DataGridViewTextBoxCell();
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Value = "Prošao je rok za odjavu ispita.";
                                        dataGridViewPopisIspita.Rows[broj_ispita - 1].Cells[7].Style.BackColor = Color.LightGray;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // Sakrij zadnji, prazni redak:
            dataGridViewPopisIspita.AllowUserToAddRows = false;
            // Sakrij prvi, prazni stupac:
            dataGridViewPopisIspita.RowHeadersVisible = false;
            // Da se ne može ručno namještati veličina stupaca/redaka:
            dataGridViewPopisIspita.AllowUserToResizeColumns = false;
            dataGridViewPopisIspita.AllowUserToResizeRows = false;

            label2.Text = ime_kolegija;
            labelKonacnaOcjena.Text = "Konačna ocjena: " + ocjena;
        }

        private void dataGridViewPopisIspita_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewPopisIspita.ClearSelection();
        }

        private void buttonPocetna_Click(object sender, EventArgs e)
        {
            FormPocetna forma = new FormPocetna();
            forma.Show();
            this.Close();
        }

        private void buttonNatrag_Click(object sender, EventArgs e)
        {
            PrethodnaForma.Show();
            this.Close();
        }

        private void FormIspisIspitaZaStudenta_Load(object sender, EventArgs e)
        {
            dataGridViewPopisIspita.Visible = true;
            label3.Visible = false;
            labelUspjesno.Visible = false;

           dataGridViewPopisIspita.Rows.Clear();
            updateDataGridView();
        }

        private void dataGridViewPopisIspita_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ako je kliknut gumb
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                string odjaviIliPrijavi = dataGridViewPopisIspita.Rows[e.RowIndex].Cells[7].Value.ToString();

                // Ako nije gumb ("Prijavi" ili "Odjavi") u pitanju, nemoj raditi nikakve promjene
                if (odjaviIliPrijavi != "Prijavi" && odjaviIliPrijavi != "Odjavi")
                    return;

                // Ako je stisnuo gumb "Prijavi", promijeni stanje u kolekciji "studenti"
                if (odjaviIliPrijavi == "Prijavi")
                {
                    // Promijeni stanje u kolekciji studenti - promijeni status ispita u "prijavljen"
                    string ispit_id = dataGridViewPopisIspita.Rows[e.RowIndex].Cells[0].Value.ToString();

                    var updateDef = Builders<Student>.Update.Set("kolegiji.$[i].ispiti.$[j].status", "prijavljen");

                    var arrayFilters =
                        new List<ArrayFilterDefinition> {
                            new JsonArrayFilterDefinition<Student>(@"{'i.isvu_sifra':" + Kolegij_isvu + "}"),
                            new JsonArrayFilterDefinition<Student>(@"{'j.ispit_id':" + ispit_id + "}")
                        };

                    var updateOptions = new UpdateOptions { ArrayFilters = arrayFilters };

                    int Kolegij_isvu_temp = Int32.Parse(Kolegij_isvu);
                    int ispit_id_temp = Int32.Parse(ispit_id);

                    collection_studenti.UpdateOne(
                        s => s.Jmbag == JmbagStudenta &&
                            s.KolegijiStudenta.Any(k => k.Isvu_sifra == Kolegij_isvu_temp &&
                                                   k.IspitiStudenta.Any(i => i.Ispit_id == ispit_id_temp)),
                        updateDef,
                        updateOptions
                        );

                    // Updateaj ispis datagridviewa
                    dataGridViewPopisIspita.Rows.Clear();
                    updateDataGridView();

                    // Ispiši porukicu ispod datagridviewa da je (ne)uspješno obavljena prijava
                    labelUspjesno.Text = "Uspješno ste prijavili ispit!";
                    labelUspjesno.ForeColor = Color.Blue;
                    labelUspjesno.Font = new Font("Corbel", 14, FontStyle.Bold);
                    labelUspjesno.Visible = true;
                }

                // Inače, ako je stisnuo gumb "Odjavi" (treća opcija ne postoji jer je return na početku funkcije)
                else
                {
                    // Promijeni stanje u kolekciji studenti - promijeni ispit status u "neprijavljen"
                    string ispit_id = dataGridViewPopisIspita.Rows[e.RowIndex].Cells[0].Value.ToString();

                    var updateDef = Builders<Student>.Update.Set("kolegiji.$[i].ispiti.$[j].status", "neprijavljen");

                    var arrayFilters =
                        new List<ArrayFilterDefinition> {
                            new JsonArrayFilterDefinition<Student>(@"{'i.isvu_sifra':" + Kolegij_isvu + "}"),
                            new JsonArrayFilterDefinition<Student>(@"{'j.ispit_id':" + ispit_id + "}")
                        };

                    var updateOptions = new UpdateOptions { ArrayFilters = arrayFilters };

                    int Kolegij_isvu_temp = Int32.Parse(Kolegij_isvu);
                    int ispit_id_temp = Int32.Parse(ispit_id);

                    collection_studenti.UpdateOne(
                        s => s.Jmbag == JmbagStudenta &&
                            s.KolegijiStudenta.Any(k => k.Isvu_sifra == Kolegij_isvu_temp &&
                                                   k.IspitiStudenta.Any(i => i.Ispit_id == ispit_id_temp)),
                        updateDef,
                        updateOptions
                        );

                    // Updateaj ispis datagridviewa
                    dataGridViewPopisIspita.Rows.Clear();
                    updateDataGridView();

                    // Ispiši porukicu ispod datagridviewa da je (ne)uspješno obavljena odjava
                    labelUspjesno.Text = "Uspješno ste odjavili ispit!";
                    labelUspjesno.ForeColor = Color.Blue;
                    labelUspjesno.Font = new Font("Corbel", 14, FontStyle.Bold);
                    labelUspjesno.Visible = true;
                }
            }
        }

    }
}
