using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDotNet
{
    class UsandoValoresLivros
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {

            Livro livro = new Livro();
            livro.Titulo = "It a coisa";
            livro.Autor = "Sthepen King";
            livro.Ano = 2012;
            livro.Paginas = 679;
            List<string> listaAssuntos = new List<string>();
            listaAssuntos.Add("Ficcao Cientifica");
            listaAssuntos.Add("Acao");
            listaAssuntos.Add("Terror");
            livro.Assunto = listaAssuntos;
            
            //acessando atráves da classe de connector
            var connectionBiblioteca = new Connection();


            Livro Livro = new Livro();
            Livro = valoresLivro.incluiValoresLivro("Dom Casmurro", "Machado de Assis", 1923, 188, "Romance, Literatura  Brasileira");
            await connectionBiblioteca.Livros.InsertOneAsync(Livro);
            Console.WriteLine("Documento incluido");

            Livro Livro2 = new Livro();
            Livro2 = valoresLivro.incluiValoresLivro("A Arte da Ficção", "David Lodge", 2002, 230, "Didático, Auto Ajuda");
            await connectionBiblioteca.Livros.InsertOneAsync(Livro);

            Console.WriteLine("Documento Incluido");


        }
    }
}
