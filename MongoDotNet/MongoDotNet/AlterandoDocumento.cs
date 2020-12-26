using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDotNet
{
    class AlterandoDocumento
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



            Console.WriteLine("Listar o livro Guerra dos Tronos");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Titulo, "Game of Thrones");
            var listaLivros = await connectionBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
                doc.Ano = 2000;
                doc.Paginas = 900;
                await connectionBiblioteca.Livros.ReplaceOneAsync(condicao, doc);
            }
            
            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");

        }
    }
}
