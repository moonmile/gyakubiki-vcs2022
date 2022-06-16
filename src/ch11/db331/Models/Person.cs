using System;
using System.Collections.Generic;

namespace db331.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Address { get; set; } = null!;
    }
}
