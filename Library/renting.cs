using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Lending
    {
        public string bookTitle { get; set; }
        public string lenderId { get; set; }
        public DateTime lendingDate { get; set; }
        public Lending prev { get; set; }
        public Lending next { get; set; }

        public Lending(string bookTitle,string lenderId)
        {
            this.bookTitle = bookTitle;
            this.lenderId = lenderId;
            this.lendingDate = DateTime.Today.Date;
            prev = null;
            next = null;

        }
    }

    public class LendingSortDescription
    {
        public string lenderId { get; set; }
        public LendingSortDescription prev { get; set; }
        public LendingSortDescription next { get; set; }
        public Lending fullData { get; set; }

        public LendingSortDescription(string lenderId)
        {
            this.lenderId = lenderId;
            prev = null;
            next = null;
            fullData = null;

        }

    }
}
