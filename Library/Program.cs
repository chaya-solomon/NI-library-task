using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions.AddNewBook("Harry Potter and the Philosopher's Stone", "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J. K. Rowling.", "J.K. Rowling");
            Functions.AddNewBook("Harry Potter and the Philosopher's Stone", "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J. K. Rowling.", "J.K. Rowling");
            Console.WriteLine(Functions.RemoveBook("Harry Potter and the Philosopher's Stone"));
            Console.WriteLine(Functions.RemoveBook("Harry Potter and the Chamber of Secrets"));
            Functions.AddNewBook("Harry Potter and the Chamber of Secrets", "Harry Potter and the Chamber of Secrets is a fantasy novel written by British author J. K. Rowling and the second novel in the Harry Potter series", "J.K. Rowling");
            Functions.AddNewBook("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Prisoner of Azkaban is a fantasy novel written by British author J. K. Rowling and is the third in the Harry Potter series. The book follows Harry Potter, a young wizard, in his third year at Hogwarts School of Witchcraft and Wizardry.", "J.K. Rowling");
            Functions.AddNewBook("Harry Potter and the Prisoner of Azkaban", "Harry Potter and the Prisoner of Azkaban is a fantasy novel written by British author J. K. Rowling and is the third in the Harry Potter series. The book follows Harry Potter, a young wizard, in his third year at Hogwarts School of Witchcraft and Wizardry.", "J.K. Rowling");
            Functions.AddNewBook("Harry Potter and the Goblet of Fire", "Harry Potter and the Goblet of Fire is a fantasy novel written by British author J. K. Rowling and the fourth novel in the Harry Potter series", "J.K. Rowling");
            Functions.AddNewBook("Harry Potter and the Order of the Phoenix", "Harry Potter and the Order of the Phoenix is a fantasy novel written by British author J. K. Rowling and the fifth novel in the Harry Potter series.", "J.K. Rowling");
            Functions.AddNewBook("Harry Potter and the Order of the Phoenix", "Harry Potter and the Order of the Phoenix is a fantasy novel written by British author J. K. Rowling and the fifth novel in the Harry Potter series.", "J.K. Rowling");
            Functions.AddNewBook("Harry Potter and the Order of the Phoenix", "Harry Potter and the Order of the Phoenix is a fantasy novel written by British author J. K. Rowling and the fifth novel in the Harry Potter series.", "J.K. Rowling");
            Functions.AddNewBook("Harry Potter and the Order of the Phoenix", "Harry Potter and the Order of the Phoenix is a fantasy novel written by British author J. K. Rowling and the fifth novel in the Harry Potter series.", "J.K. Rowling");
            Console.WriteLine(Functions.CheckForCopies("Harry Potter and the Half-Blood Prince"));
            Console.WriteLine(Functions.CheckForCopies("Harry Potter and the Order of the Phoenix"));
            Console.WriteLine(Functions.lendBook("Harry Potter and the Order of the Phoenix", "098747732"));
            Console.WriteLine(Functions.lendBook("Harry Potter and the Deathly Hallows", "55838424"));
            Console.WriteLine(Functions.lendBook("Harry Potter and the Philosopher's Stone", "55838424"));
            Console.WriteLine(Functions.CheckForCopies("Harry Potter and the Philosopher's Stone"));
            Console.WriteLine(Functions.returnBook("Harry Potter and the Philosopher's Stone", "55838424"));
            Console.WriteLine(Functions.returnBook("Harry Potter and the Philosopher's Stone", "55838424"));

            Functions.returnDeladBooks();
        }
    }
}
