using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Functions
    {
        public static Lending firstLending = null;
        public static Lending lastLending = null;
        public static Hashtable LibraryBooks = new Hashtable();
        public static void AddNewBook(string newBookTitle, string newBookDescription, string newBookAuthor)
        {
            if (LibraryBooks.ContainsKey(newBookTitle))
            {
                book bookCopy = (book)LibraryBooks[newBookTitle];
                bookCopy.copies++;
                LibraryBooks[newBookTitle] = bookCopy;
            }
            else
            {
                book newBook = new book(newBookTitle, newBookAuthor, newBookDescription);
                LibraryBooks.Add(newBookTitle, newBook);
            }
        }

        public static string RemoveBook(string BookTitle)
        {
            if (LibraryBooks.ContainsKey(BookTitle))
            {
                book tmpBook = (book)LibraryBooks[BookTitle];
                if (tmpBook.copies != 0)
                {
                    tmpBook.copies--;
                    LibraryBooks[BookTitle] = tmpBook;
                }
                return BookTitle+" copy removd";
            }
            return "no book called " + BookTitle + " in the library";
        }

        public static string CheckForCopies(string BookTitle)
        {
            string status = null;
            if (LibraryBooks.ContainsKey(BookTitle))
            {
                book tmpBook = (book)LibraryBooks[BookTitle];
                if (tmpBook.copies == 0 || tmpBook.copies == tmpBook.rentedCopies)
                {
                    status = "no copies left";
                }
            }
            else
            {
                status = "no book called " + BookTitle + " in the library";
            }
            return status;
        }

        public static string lendBook(string BookTitle, string LenderId)
        {
            string status = CheckForCopies(BookTitle);
            if (status == null)
            {
                Lending r = new Lending(BookTitle, LenderId);
                if (firstLending==null)
                {
                    firstLending = r;
                    r.prev = null;
                    r.next = null;
                    lastLending = r;
                }
                else
                {
                    lastLending.next = r;
                    r.prev = lastLending;
                    r.next = null;
                    lastLending = r;
                }
                LendingSortDescription LSD = new LendingSortDescription(LenderId);
                book tmpBook = (book)LibraryBooks[BookTitle];
                LSD.fullData = r;
                if (tmpBook.head == null)
                {
                    tmpBook.head = LSD;
                    LSD.prev = null;
                    LSD.next = null;
                    tmpBook.tail = LSD;
                }
                else
                {
                    tmpBook.tail.next = LSD;
                    LSD.prev = tmpBook.tail;
                    LSD.next = null;
                    tmpBook.tail = LSD;
                }
                tmpBook.rentedCopies++;
                LibraryBooks[BookTitle] = tmpBook;
                return LenderId + " lent " + BookTitle;
            }
            return status;
        }

        public static string returnBook(string BookTitle, string LenderId)
        {
            int flag = 0;
            if (LibraryBooks.ContainsKey(BookTitle))
            {
                book tmpBook = (book)LibraryBooks[BookTitle];
                LendingSortDescription lsd = tmpBook.head;
                while (lsd != null && flag != 1)
                {
                    if (lsd.lenderId == LenderId)
                    {
                        flag = 1;
                        if (tmpBook.head == lsd && tmpBook.tail == lsd)
                        {
                            tmpBook.head = null;
                            tmpBook.tail = null;
                        }
                        else
                        {
                            if (tmpBook.head == lsd && tmpBook.tail != lsd)
                            {
                                tmpBook.head = lsd.next;
                                lsd.next.prev = lsd.prev;
                            }
                            else
                            {
                                if (tmpBook.tail == lsd && tmpBook.head != lsd)
                                {
                                    tmpBook.tail = lsd.prev;
                                    lsd.prev.next = lsd.next;
                                }
                                else
                                {
                                    lsd.next.prev = lsd.prev;
                                    lsd.prev.next = lsd.next;
                                }
                            }
                        }
                        if (firstLending == lsd.fullData && lastLending == lsd.fullData)
                        {
                            firstLending = null;
                            lastLending = null;
                        }
                        else
                        {
                            if (firstLending == lsd.fullData)
                            {
                                firstLending = lsd.fullData.next;
                                lsd.fullData.next.prev = lsd.fullData.prev;
                            }
                            else
                            {
                                if (lastLending == lsd.fullData)
                                {
                                    lastLending = lsd.fullData.prev;
                                    lsd.fullData.prev.next = lsd.fullData.next;
                                }
                                else
                                {
                                    lsd.fullData.next.prev = lsd.fullData.prev;
                                    lsd.fullData.prev.next = lsd.fullData.next;
                                }
                            }
                        }
                    }
                    lsd = lsd.next;
                }
                tmpBook.rentedCopies--;
                LibraryBooks[BookTitle] = tmpBook;
            }
            else
            {
                    return "no book called " + BookTitle + " in the library";
            }
            if (flag == 0)
            {
                return LenderId + " Did not borrow " + BookTitle;
            }
            return "The book was successfully returnd";
        }

        public static void returnDeladBooks()
        {
            int flag = 0;
            Lending l = firstLending;
            while (l != null && flag != 1)
            {
                if (l.lendingDate < DateTime.Today.AddDays(-7))
                {
                    Console.WriteLine(l.lenderId + " did no return " + l.bookTitle + " on time " + "The book was supposed to be returnd by " + l.lendingDate.AddDays(7));
                }
                else
                {
                    flag = 1;
                    Console.WriteLine("no books are delad");
                }
                l = l.next;
            }
        }
    }
}
