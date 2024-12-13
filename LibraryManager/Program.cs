using System;
using System.ComponentModel;

namespace LibraryManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Book> library = new List<Book>();
            Services methods = new Services();

            while (true)
            {
                switch (methods.ShowMenu())
                {
                    case "1":
                        methods.AddBook(library);
                        break;
                    case "2":
                        methods.ShowLibrary(library);
                        break;
                    case "3":
                        methods.SearchBook(library);
                        break;
                    case "4":
                        methods.BorrowBook(library);
                        break;
                    case "5":
                        methods.ReturnBook(library);
                        break;
                    case "6":
                        methods.RemoveBook(library);
                        break;
                    case "7":
                        Console.WriteLine("A la prochaine");
                        return;
                    default:
                        break;
                }
            }
        }
    }
}