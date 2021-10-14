using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projet_rhinoceros
{
    //[BsonIgnoreExtraElements]
    public class departement
    {
        [BsonId]
        //BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("Code_Post")]
        public string Code_Postale { get; set; }

        //[BsonElement("NomDept")]
        public string DepartmentNom { get; set; }

        //[BsonElement("Pop")]
        public int Population { get; set; }
    }
}