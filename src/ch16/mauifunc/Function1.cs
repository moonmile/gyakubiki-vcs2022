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
        /// ���Ѓ��X�g���擾
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
        /// �w��ID�ŏ��Ѓf�[�^���擾
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
        /// �w�菑�Ђ̉��i���X�V
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
        /// �f�[�^�̏�����
        /// </summary>
        private static void init()
        {
            _books = new List<Book>()
            {
                new Book { Id = 1, Title = "�e�X�g�쓮�J������", AuthorId = 6, PublisherId = 6, Price = 1000},
                new Book { Id = 2, Title = "�R���T���^���g�̔閧", AuthorId = 3, PublisherId = 2, Price= 1000},
                new Book { Id = 3, Title = "�s�[�v���E�F�A", AuthorId = 2, PublisherId = 2, Price= 1000},
                new Book { Id = 4, Title = ".NET6�v���O���~���O����", AuthorId = 1, PublisherId = 2, Price= 1000},
                new Book { Id = 5, Title = "�t������VB2022��(��)", AuthorId = 1, PublisherId = 1, Price= 1000},
                new Book { Id = 6, Title = "�t������C#2022��", AuthorId = 1, PublisherId = 1, Price= 1000},
                new Book { Id = 7, Title = "F#����", AuthorId = null, PublisherId = null, Price= 1000},
            };
            _authors = new List<Author>()
            {
                new Author { Id = 1, Name = "���c�q��"},
                new Author { Id = 2, Name = "�g���E�f�}���R"},
                new Author { Id = 3, Name = "G.M.���C���o�[�O"},
                new Author { Id = 4, Name = "�E���x���g�E�G�[�R"},
                new Author { Id = 5, Name = "�쒆�莟�Y"},
                new Author { Id = 6, Name = "�P���g�E�x�b�N"},
                new Author { Id = 7, Name = "�啨�V�l"},
                new Author { Id = 8, Name = "�ÎQ�̐V�l"},
            };
            _publishers = new List<Publisher>()
            {
                new Publisher { Id = 1, Name = "�G�a�V�X�e��", Telephone = "03-6264-XXXX", Address = "�����s�]����"},
                new Publisher { Id = 2, Name = "���oBP", Telephone = "", Address = "�����s�`��"},
                new Publisher { Id = 3, Name = "�Z�p�]�_��", Telephone = "03-3513-XXXX", Address = "�����s�V�h��"},
                new Publisher { Id = 4, Name = "�����o��", Telephone = "03-3947-XXXX", Address = "�����s������"},
                new Publisher { Id = 5, Name = "�I�[����", Telephone = "03-3233-XXXX", Address = "�����s���c��"},
                new Publisher { Id = 6, Name = "�s�A�\���E�G�f���P�[�V����", Telephone = "03-3233-XXXX", Address = "�����s���c��"},
            };
        }
    }
}
