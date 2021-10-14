using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using MongoDB.Driver;
using MongoDB.Bson;
using Aardvark.Base;

namespace projet_rhinoceros
{
    public class Program
    {
        static void Main(string[] args)
        {

            var dbClient = new MongoClient("mongodb+srv://remi:basemongo@cluster0.bzwiy.mongodb.net/rhinoceros?retryWrites=true&w=majority");
            var dbList = dbClient.ListDatabases().ToList();


            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }

            var Database = dbClient.GetDatabase("Rhinoceros");

            var reader = new StreamReader(File.OpenRead("C:/Users/remim/Downloads/population_2018.csv"));
            IMongoCollection<BsonDocument> csvFile = Database.GetCollection<BsonDocument>("Departments");

            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                BsonDocument row = new BsonDocument
                        {
                            {"Code_Post", values[0]},
                            {"NomDept", values[1]},
                            {"Pop", values[2]},
                            {"GPS", values[3]}
                        };

                csvFile.InsertOne(row);
            }

            // tentative de récupération des données de la base mongodb
            /*Console.WriteLine("kjkreoiizjfoijzefjrioretoizutizutozujt---");
            MongoCollection collection = (MongoCollection)Database.GetCollection<departement>("departements");
            var blog = new departement()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Code_Postale = "First Blog"
            };
            collection.Insert(blog);

            MongoCursor<departement> cursor = collection.FindAllAs<departement>();
            cursor.SetLimit(5);

            var list = cursor.ToList();
            Console.WriteLine("kjkreoiizjfoijzefjrioretoizutizutozujt---");
            Console.WriteLine(list);*/


        }


    }
}


