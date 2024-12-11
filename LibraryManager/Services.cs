using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    public class Services
    {
        public string ShowMenu()
        {
            Console.WriteLine("\n--- Gestionnaire de Bibliothèque ---");
            Console.WriteLine("1. Ajouter un livre");
            Console.WriteLine("2. Afficher les livres");
            Console.WriteLine("3. Rechercher un livre par titre");
            Console.WriteLine("4. Emprunter un livre");
            Console.WriteLine("5. Retourner un livre");
            Console.WriteLine("6. Quitter");
            Console.Write("Choisissez une option : ");
            string choice = Console.ReadLine()?.Trim();

            // Validation basique de l'entrée utilisateur
            if (string.IsNullOrEmpty(choice) || !"123456".Contains(choice))
            {
                Console.WriteLine("Veuillez entrer un numéro valide (1-6).");
                return ShowMenu(); // Relancer le menu si l'entrée est invalide
            }

            return choice;
        }

        // Ajouter un nouveau livre.
        public void AddBook(List<Book> books)
        {
            // Introduire les spécifications du livre
            Console.Write("Saisir le titre du livre               : ");
            string titleBook = Console.ReadLine();

            Console.Write("Saisir l'auteur du livre               : ");
            string authorBook = Console.ReadLine();

            Console.Write("Saisir l'année de publication du livre : ");
            int pubYearBook = Console.Read();

            // Vérification de l'existance du livre dans la bibliothèque
            var book = books.FirstOrDefault(b => b.title == titleBook);

            if (book == null)
            {
                books.Add(
                    new Book()
                    { 
                        title = titleBook,
                        author = authorBook,
                        publicationYear = pubYearBook
                    });
                Console.Write("Le livre est ajouté avec succées.");
            }
            else
            {
                Console.Write("Le livre existe dans la bibliothèque !");
            }
        }

        // Afficher tous les livres.
        public void ShowLibrary(List<Book> books)
        {
            // Vérifier que la liste n'est pas nulle
            if(books.Count > 0)
            {
                Console.WriteLine($"La bibliothèque contient les livres suivantes :");
                // Affichage
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {books[i].title}");
                }
            }
            else
                Console.WriteLine($"La bibliothèque ne contient aucun livre !");
        }

        // Rechercher un livre par titre.
        public void SearchBook(List<Book> books)
        {
            // Saisir un nom à chercher
            Console.Write("Saisir un titre à chercher : ");
            string titleBook = Console.ReadLine();
            // Vérification de l'existance du livre dans la bibliothèque
            var book = books.FirstOrDefault(b => b.title == titleBook);
            if (book != null)
            {
                Console.WriteLine($"Titre : {book.title}");
                Console.WriteLine($"Auteur : {book.author}");
                Console.WriteLine($"Année de publication : {book.publicationYear}");
                Console.WriteLine($"Disponible : {book.isAvailable}");
            }
            else
                Console.Write("Le livre recherché n'est pas trouvé !");

        }

        // Emprunter un livre.
        public void BorrowBook(List<Book> books)
        {
            Console.Write("Quel livre voulez-vous emprunter ? ");
            string bookTitle = Console.ReadLine();

            var book = books.FirstOrDefault(c => c.title == bookTitle);
            if (book != null)
            {
                book.isAvailable = false;
                Console.Write("Dès maintenant, le livre est le votre.");
            }
            else
                Console.Write("Le livre existe dans la bibliothèque !");
        }

        // Retourner un livre.
        public void ReturnBook(List<Book> books)
        {
            Console.Write("Quel livre voulez avez emprunter ? ");
            string bookTitle = Console.ReadLine();

            var book = books.FirstOrDefault(c => c.title == bookTitle);
            if (book != null)
            {
                book.isAvailable = true;
                Console.Write("Vous avez bien retourné le livre, Merci.");
            }
            else
                Console.Write("Le livre existe dans la bibliothèque !");
        }
    }
}
