using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace En_Tur_på_bibloteket
{
    class Program
    {
        static void Main(string[] args)
        {
            // List and stack we are using for the rental system
            List<Book> booksForRental = new List<Book>();
            Stack<Book> bookStack = new Stack<Book>();
            Queue<Book> rentedBooks = new Queue<Book>();
            // Used for while loops to stay in menu
            bool looper = true;


            // Adding books to the rental stack
            void AddBookToStack()
            {
                while (looper)
                {

                    // First displaying available books
                    Console.WriteLine("Currently available books\n");
                    int counter = 1;
                    foreach (Book hardBacks in booksForRental)
                    {
                        Console.WriteLine($"{counter}.");
                        Console.WriteLine($"Name: {hardBacks.Name}");
                        Console.WriteLine($"Author: {hardBacks.Author}");
                        Console.WriteLine($"Genre: {hardBacks.Genre}");
                        Console.WriteLine($"Pages: {hardBacks.Pages}");
                        Console.WriteLine($"Price: {hardBacks.Price}$");
                        if (hardBacks.Fiction)
                        {
                            Console.WriteLine("Fiction: Yes");
                        }
                        else
                        {
                            Console.WriteLine("Fiction: No");
                        }
                        Console.WriteLine();
                        counter++;
                    }
                    //User chooses a book
                    Console.WriteLine("Write the number on the book you want to rent. (0) to return to main menu");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                    {
                        break;
                    }

                    // Adds the book from the available books to the rent stack and removes it from the original list
                    bookStack.Push(booksForRental[input - 1]);
                    booksForRental.RemoveAt(input - 1);
                    Console.WriteLine("\nBook added");
                    Console.ReadKey();
                    Console.Clear();

                }

            }
            void RentBook()
            {
                // loops this to mimic sub menu
                while (looper)
                {
                    //  Show the next book in the stack and ask if the user wants to rent it and removes it if not
                    Console.Clear();
                    Console.WriteLine("Rent this book?\n");
                    Book topBook = bookStack.Peek();
                    Console.WriteLine($"Name: {topBook.Name}");
                    Console.WriteLine($"Author: {topBook.Author}");
                    Console.WriteLine($"Genre: {topBook.Genre}");
                    Console.WriteLine($"Pages: {topBook.Pages}");
                    Console.WriteLine($"Price: {topBook.Price}$");
                    Console.WriteLine();
                    Console.WriteLine("0. Exit\n1. Yes\n2. No");
                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 0:
                            return;
                        case 1:
                            rentedBooks.Enqueue(bookStack.Pop());
                            Console.WriteLine("\nBook rented.");
                            Console.ReadKey();
                            break;
                        case 2:
                            booksForRental.Add(bookStack.Pop());
                            Console.WriteLine("\nBook removed.");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            void ShowBooks()
            {
                if (bookStack.Count() == 0)
                {
                    Console.WriteLine("Book Stack empty");
                }
                foreach (Book hardBacks in bookStack)
                {
                    Console.WriteLine($"Name: {hardBacks.Name}");
                    Console.WriteLine($"Author: {hardBacks.Author}");
                    Console.WriteLine($"Genre: {hardBacks.Genre}");
                    Console.WriteLine($"Pages: {hardBacks.Pages}");
                    Console.WriteLine($"Price: {hardBacks.Price}$");
                    if (hardBacks.Fiction)
                    {
                        Console.WriteLine("Fiction: Yes");
                    }
                    else
                    {
                        Console.WriteLine("Fiction: No");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();

            }
            void RentedBooks()
            {

            }
            // Generating random books
            for (int i = 0; i < 10; i++)
            {
                Book book = new Book();
                book.GenerateBook();
                // Pauses on each interation to give program time to generate the book. Experiences a problem with the book being added before it was generated.
                System.Threading.Thread.Sleep(50);
                booksForRental.Add(book);
            }

            // Menu System
            while (looper)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("            H1 Queue Operations Menu");
                Console.WriteLine("==================================================");
                Console.WriteLine();
                Console.WriteLine("1. Add book to rent stack");
                Console.WriteLine("2. Rent books in stack");
                Console.WriteLine("3. Show currunt book stack");
                Console.WriteLine("4. Show current rented books");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.WriteLine("Enter your choice");
                Console.WriteLine();
                int menuChoice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (menuChoice)
                {
                    case 1:
                        AddBookToStack();
                        break;
                    case 2:
                        RentBook();
                        break;
                    case 3:
                        ShowBooks();
                        break;
                    case 4:
                        RentedBooks();
                        break;
                    case 5:
                        looper = false;
                        break;
                    default:
                        Console.WriteLine("Input not recognise. Please try igen");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}
