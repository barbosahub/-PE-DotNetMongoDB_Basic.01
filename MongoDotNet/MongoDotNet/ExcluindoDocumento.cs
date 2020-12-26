using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDotNet
{
    class ExcluindoDocumento
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



            Console.WriteLine("Listar o livro de Sthepen King");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "Sthepen King");
            var listaLivros = await connectionBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Excluindo o livro de Sthepen King");
            await connectionBiblioteca.Livros.DeleteManyAsync(condicao);
            

            Console.WriteLine("Listar o livro de Sthepen King");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Autor, "Sthepen King");
            listaLivros = await connectionBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

        }
    }
}
