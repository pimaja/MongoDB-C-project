using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet
{
    class Student
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("jmbag")]
        public int Jmbag { get; set; }

        [BsonElement("ime")]
        public String Ime { get; set; }

        [BsonElement("prezime")]
        public String Prezime { get; set; }

        [BsonElement("razina")]
        public String Razina { get; set; }

        [BsonElement("smjer")]
        public String Smjer { get; set; }

        [BsonElement("kolegiji")]
        public List<KolegijStudenta> KolegijiStudenta { get; set; }

    }

    class KolegijStudenta
    {
        [BsonElement("isvu_sifra")]
        public int Isvu_sifra { get; set; }

        [BsonElement("naziv")]
        public String Naziv { get; set; }

        [BsonElement("ects_bodovi")]
        public int Ects_bodovi { get; set; }

        [BsonElement("ispiti")]
        public List<IspitStudenta> IspitiStudenta { get; set; }

        [BsonElement("ocjena")]
        public String Ocjena { get; set; }

        public KolegijStudenta(int isvu_sifra, string naziv, int ects_bodovi, List<IspitStudenta> ispitiStudenta, string ocjena)
        {
            Isvu_sifra = isvu_sifra;
            Naziv = naziv;
            Ects_bodovi = ects_bodovi;
            IspitiStudenta = ispitiStudenta;
            Ocjena = ocjena;
        }

        //konstruktor

    }

    class IspitStudenta
    {
        [BsonElement("ispit_id")]
        public int Ispit_id { get; set; }

        [BsonElement("status")]
        public String Status { get; set; }

        [BsonElement("rezultat")]
        public String Rezultat { get; set; }

        public IspitStudenta(int ispit_id, string status, string rezultat)
        {
            Ispit_id = ispit_id;
            Status = status;
            Rezultat = rezultat;
        }

        //konstruktor

    }
}
