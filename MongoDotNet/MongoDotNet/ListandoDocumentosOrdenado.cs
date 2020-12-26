using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


namespace MongoDotNet
{
    class ListandoDocumentosOrdenado
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



            Console.WriteLine("Listando Documentos maior que 100 paginas ordenado e limitado a 2");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Gt(x => x.Paginas, 100);
            var listaLivros = await connectionBiblioteca.Livros.Find(condicao).SortBy(x => x.Titulo).Limit(2).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }


            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");



        }
    }
}
