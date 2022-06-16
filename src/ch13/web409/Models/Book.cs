using System;
using System.Collections.Generic;

namespace web409.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int Price { get; set; }
    }
}
