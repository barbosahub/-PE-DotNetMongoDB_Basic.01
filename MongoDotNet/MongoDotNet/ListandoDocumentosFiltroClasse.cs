using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDotNet
{
    class ListandoDocumentosFiltroClasse
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
        
            Console.WriteLine("Listando Documentos Autor = George R R Martin");

            var Filtro = new BsonDocument
            {
            {"Autor", "George R R Martin"}
            };
            var listaLivros = await connectionBiblioteca.Livros.Find(Filtro).ToListAsync();

            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }


            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos Autor = Machado de Assis - Classe");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "Machado de Assis");
            listaLivros = await connectionBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }


            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos maior que 2013");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Gte(x => x.Ano, 2013);
            listaLivros = await connectionBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos ano de publicacao a partir de 2013 com mais de 100 paginas");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Gte(x => x.Ano, 2013) & construtor.Gte(x => x.Paginas, 100);
            listaLivros = await connectionBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos de Infantil");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.AnyEq(x => x.Assunto, "Infantil");
            listaLivros = await connectionBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }




        }
    }
}
