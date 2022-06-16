using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using System.Linq;
using mauifunc.Models;
using System.Collections.Generic;

namespace mauifunc
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }


        /// <summary>
        /// 書籍リストを取得
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("books")]
        public static IActionResult GetBooks(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            init();
            log.LogInformation("C# HTTP trigger function processed a request in books.");

            foreach (var book in _books)
            {
                book.Author = _authors.FirstOrDefault(t => t.Id == book.AuthorId);
                book.Publisher = _publishers.FirstOrDefault(t => t.Id == book.PublisherId);
            }
            return new OkObjectResult(_books);
        }

        /// <summary>
        /// 指定IDで書籍データを取得
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("getbook")]
        public static IActionResult GetBook(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            init();
            log.LogInformation("C# HTTP trigger function processed a request in getbook.");
            int id = req.Query["id"] == "" ? 0 : int.Parse(req.Query["id"]);
            var book = _books.FirstOrDefault(t => t.Id == id);
            if (book != null)
            {
                book.Author = _authors.FirstOrDefault(t => t.Id == book.AuthorId);
                book.Publisher = _publishers.FirstOrDefault(t => t.Id == book.PublisherId);
            }
            else
            {
                book = new Book();
            }
            return new OkObjectResult(book);
        }


        /// <summary>
        /// 指定書籍の価格を更新
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("postbook")]
        public static async Task<IActionResult> PostBook(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            init();
            log.LogInformation("C# HTTP trigger function processed a request in postbook.");
            string requestBody =
              await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data =
              JsonConvert.DeserializeObject(requestBody);

            int id = data?.id;
            int price = data?.price;
            var book = _books.FirstOrDefault(t => t.Id == id);
            if (book != null)
            {
                book.Price = price;
                book.Author = _authors.FirstOrDefault(t => t.Id == book.AuthorId);
                book.Publisher = _publishers.FirstOrDefault(t => t.Id == book.PublisherId);
            }
            else
            {
                book = new Book();
            }
            return new OkObjectResult(book);
        }


        private static List<Book> _books;
        private static List<Author> _authors;
        private static List<Publisher> _publishers;


        /// <summary>
        /// データの初期化
        /// </summary>
        private static void init()
        {
            _books = new List<Book>()
            {
                new Book { Id = 1, Title = "テスト駆動開発入門", AuthorId = 6, PublisherId = 6, Price = 1000},
                new Book { Id = 2, Title = "コンサルタントの秘密", AuthorId = 3, PublisherId = 2, Price= 1000},
                new Book { Id = 3, Title = "ピープルウェア", AuthorId = 2, PublisherId = 2, Price= 1000},
                new Book { Id = 4, Title = ".NET6プログラミング入門", AuthorId = 1, PublisherId = 2, Price= 1000},
                new Book { Id = 5, Title = "逆引き大VB2022版(仮)", AuthorId = 1, PublisherId = 1, Price= 1000},
                new Book { Id = 6, Title = "逆引き大C#2022版", AuthorId = 1, PublisherId = 1, Price= 1000},
                new Book { Id = 7, Title = "F#入門", AuthorId = null, PublisherId = null, Price= 1000},
            };
            _authors = new List<Author>()
            {
                new Author { Id = 1, Name = "増田智明"},
                new Author { Id = 2, Name = "トム・デマルコ"},
                new Author { Id = 3, Name = "G.M.ワインバーグ"},
                new Author { Id = 4, Name = "ウンベルト・エーコ"},
                new Author { Id = 5, Name = "野中郁次郎"},
                new Author { Id = 6, Name = "ケント・ベック"},
                new Author { Id = 7, Name = "大物新人"},
                new Author { Id = 8, Name = "古参の新人"},
            };
            _publishers = new List<Publisher>()
            {
                new Publisher { Id = 1, Name = "秀和システム", Telephone = "03-6264-XXXX", Address = "東京都江東区"},
                new Publisher { Id = 2, Name = "日経BP", Telephone = "", Address = "東京都港区"},
                new Publisher { Id = 3, Name = "技術評論社", Telephone = "03-3513-XXXX", Address = "東京都新宿区"},
                new Publisher { Id = 4, Name = "共立出版", Telephone = "03-3947-XXXX", Address = "東京都文京区"},
                new Publisher { Id = 5, Name = "オーム社", Telephone = "03-3233-XXXX", Address = "東京都千代田区"},
                new Publisher { Id = 6, Name = "ピアソン・エデュケーション", Telephone = "03-3233-XXXX", Address = "東京都千代田区"},
            };
        }
    }
}
