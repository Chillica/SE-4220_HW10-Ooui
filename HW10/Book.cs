using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Book
    {
        public Book()
        {
            Title = "";
            Author = "";
            Pages = 0;
            Words = 0;
            Characters = 0;
            Locations = 0;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int Words { get; set; }
        public int Characters { get; set; }
        public int Locations { get; set; }
    }
}
