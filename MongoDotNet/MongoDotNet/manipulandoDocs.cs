using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDotNet
{
    class manipulandoDocs
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
            doc.Add("Autor","George R R Martin");
            doc.Add("Ano", 1999);
            doc.Add("Paginas", 856);

            var assuntoArray = new BsonArray();
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Acao");

            doc.Add("Assunto", assuntoArray);
            Console.WriteLine(doc);
        }

    }
}
