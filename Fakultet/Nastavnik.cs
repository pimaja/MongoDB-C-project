using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet
{
    class Nastavnik
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("oib")]
        public Int64 Oib { get; set; }

        [BsonElement("ime")]
        public String Ime { get; set; }

        [BsonElement("prezime")]
        public String Prezime { get; set; }

        [BsonElement("kolegiji")]
        public List<KolegijNastavnika> KolegijiNastavnika { get; set; }
    }

    class KolegijNastavnika
    {
        [BsonElement("isvu_sifra")]
        public int Isvu_sifra { get; set; }

        [BsonElement("naziv")]
        public String Naziv { get; set; }

        public KolegijNastavnika(int isvu_sifra, string naziv)
        {
            Isvu_sifra = isvu_sifra;
            Naziv = naziv;
        }
    }
}
