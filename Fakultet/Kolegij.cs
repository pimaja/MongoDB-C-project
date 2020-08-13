using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet
{
    class Kolegij
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("isvu_sifra")]
        public int Isvu_sifra { get; set; }

        [BsonElement("naziv")]
        public String Naziv { get; set; }

        [BsonElement("semestar")]
        public String Semestar { get; set; }

        [BsonElement("ects_bodovi")]
        public double Ects_bodovi { get; set; }

        [BsonElement("izborna_grupa")]
        public String Izborna_grupa { get; set; }

        [BsonElement("nositelj")]
        public String Nositelj { get; set; }

        [BsonElement("nositelj_oib")]
        public Int64 Nositelj_oib { get; set; }

        [BsonElement("nastavni_sadrzaji")]
        public String Nastavni_sadrzaji { get; set; }

        [BsonElement("ispiti")]
        public List<IspitNaKolegiju> IspitiNaKolegiju { get; set; }

    }

    class IspitNaKolegiju
    {
        [BsonElement("ispit_id")]
        public int Ispit_id { get; set; }

        [BsonElement("datum_odrzavanja")]
        public String Datum_odrzavanja { get; set; }

        [BsonElement("vrijeme_odrzavanja")]
        public String Vrijeme_odrzavanja { get; set; }

        [BsonElement("prijava_do")]
        public String Prijava_do { get; set; }

        [BsonElement("odjava_do")]
        public String Odjava_do { get; set; }

        [BsonElement("nacin_polaganja")]
        public String Nacin_polaganja { get; set; }

        [BsonElement("sadrzaj")]
        public String Sadrzaj { get; set; }

        [BsonElement("trajanje")]
        public double Trajanje { get; set; }

        [BsonElement("predavaonica")]
        public String Predavaonica { get; set; }

        public IspitNaKolegiju(int ispit_id, string datum_odrzavanja, string vrijeme_odrzavanja, string prijava_do, string odjava_do, string nacin_polaganja, string sadrzaj, double trajanje, string predavaonica)
        {
            Ispit_id = ispit_id;
            Datum_odrzavanja = datum_odrzavanja;
            Vrijeme_odrzavanja = vrijeme_odrzavanja;
            Prijava_do = prijava_do;
            Odjava_do = odjava_do;
            Nacin_polaganja = nacin_polaganja;
            Sadrzaj = sadrzaj;
            Trajanje = trajanje;
            Predavaonica = predavaonica;
        }
    }
}
