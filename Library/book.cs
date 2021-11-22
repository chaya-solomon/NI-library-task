using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class book
    {
        public string title { get; set; }
        public string author{ get; set; }
        public string Description { get; set; }
        public int copies { get; set; }
        public int rentedCopies { get; set; }
        public LendingSortDescription head { get; set; }
        public LendingSortDescription tail { get; set; }


        public book(string title, string author, string Description)
        {
            this.title = title;
            this.author = author;
            this.Description = Description;
            this.copies = 1;
            this.rentedCopies = 0;
            this.head = null;
            this.tail = null;
        }
    }
}
