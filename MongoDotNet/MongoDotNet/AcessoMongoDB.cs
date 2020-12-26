using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDotNet
{
    class AcessoMongoDB
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {

            var doc = new BsonDocument
            {
                {"Titulo","Game of Thrones" }
            };
            doc.Add("Autor", "George R R Martin");
            doc.Add("Ano", 1999);
            doc.Add("Paginas", 856);

            var assuntoArray = new BsonArray();
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Acao");

            doc.Add("Assunto", assuntoArray);
            Console.WriteLine(doc);

            // acesso ao servidor MongoDB
            string connection = "mongodb://localhost:27017";
            IMongoClient client = new MongoClient(connection);

            // acesso ao Database MongoDB
            IMongoDatabase database = client.GetDatabase("Biblioteca");

            // acesso a Collection MongoDB
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("livros");

            // Incluindo documento no MongoDB
            await collection.InsertOneAsync(doc);
            Console.WriteLine("Documento incluido");

        }

    }
}

