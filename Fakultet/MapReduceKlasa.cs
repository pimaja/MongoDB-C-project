using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacijaZaIspite
{
    class MapReduceKlasa
    {
        [BsonElement("_id")]
        public int Id { get; set; }

        [BsonElement("value")]
        public Value Value { get; set; }
    }

    class Value
    {
        [BsonElement("count")]
        public int Count { get; set; }

        [BsonElement("rezultat")]
        public double Rezultat { get; set; }

        [BsonElement("avg")]
        public double Avg { get; set; }

        public Value(int count, double rezultat, double avg)
        {
            Count = count;
            Rezultat = rezultat;
            Avg = avg;
        }
    }
}
