using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDotNet
{
    class SelectLivrosComFiltro
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

            var Filtro = new BsonDocument();
            var listaLivros = await connectionBiblioteca.Livros.Find(Filtro).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Listando Documentos Autor = Machado de Assis");

            Filtro = new BsonDocument
            {
            {"Autor", "George R R Martin"}
            };
            listaLivros = await connectionBiblioteca.Livros.Find(Filtro).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }


            Console.WriteLine("Fim da Lista");


        }
    }
}
