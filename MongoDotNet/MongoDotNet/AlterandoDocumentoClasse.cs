using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDotNet
{
    class AlterandoDocumentoClasse
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
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");

            var construtorAlteracao = Builders<Livro>.Update;
            var condicaoAlteracao = construtorAlteracao.Set(x => x.Ano , 2001);
                await connectionBiblioteca.Livros.UpdateOneAsync(condicao, condicaoAlteracao);
            Console.WriteLine("Registro alterado");


            Console.WriteLine("Listar o livro Guerra dos Tronos");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Titulo, "Game of Thrones");
            listaLivros = await connectionBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

        }
    }
}
