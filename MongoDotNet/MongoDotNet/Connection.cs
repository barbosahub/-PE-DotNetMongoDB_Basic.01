using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDotNet
{
    class Connection
    {
        public const string StringConnection = "mongodb://localhost:27017";
        public const string Database = "Biblioteca";
        public const string Collection = "livros";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static Connection(){
            _client = new MongoClient(StringConnection);
            _database = _client.GetDatabase(Database);
        }

        public IMongoClient Cliente
        {
            get { return _client; }
        }

        public IMongoCollection<Livro> Livros
        {
            get { return _database.GetCollection<Livro>(Collection); }
        }

    }
}
