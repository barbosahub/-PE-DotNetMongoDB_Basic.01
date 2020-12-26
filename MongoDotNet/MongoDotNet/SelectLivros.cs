using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDotNet
{
    class SelectLivros
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {
            //acessando atráves da classe de connector
            var connectionBiblioteca = new Connection();
            Console.WriteLine("Listando Documentos");

            var listaLivros = await connectionBiblioteca.Livros.Find(new BsonDocument()).ToListAsync();

            
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }


        }
    }
}
