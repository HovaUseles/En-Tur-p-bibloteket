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
                        Console.WriteLine(String.Format("{0} by {1}.", hardBacks.Name, hardBacks.Author));
                        Console.WriteLine(String.Format("{0}. {1} pages. No-return fine {2}$", hardBacks.Genre, hardBacks.Pages, hardBacks.Price));

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
                    Console.WriteLine("Write the number on the book you want to add to stack. (0) to return to main menu");
                    int input;
                    // Catch un-accepted input and take user back
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("Please write in accepted format.");
                        Console.ReadKey();
                        continue;
                    }
                    if (input == 0)
                    {
                        break;
                    }
                    else if (input > booksForRental.Count || input < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("PLease choose select a book within the range.");
                        Console.ReadKey();
                        continue;
                    }

                    // Adds the book from the available books to the rent stack and removes it from the original list
                    Console.Clear();
                    Console.WriteLine("\nBook added\n");
                    Console.WriteLine(String.Format("{0} by {1}.", booksForRental[input -1].Name, booksForRental[input -1].Author));
                    Console.WriteLine(String.Format("{0}. {1} pages. No-return fine {2}$", booksForRental[input -1].Genre, booksForRental[input -1].Pages, booksForRental[input -1].Price));
                    bookStack.Push(booksForRental[input - 1]);
                    booksForRental.RemoveAt(input - 1);
                    Console.ReadKey();
                    Console.Clear();


                }

            }
            void RentBook()
            {
                // loops this to mimic sub menu
                while (looper)
                {
                    // Checks for empty stack
                    if (bookStack.Count() == 0)
                    {
                        Console.WriteLine("Book Stack empty");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Books in stack: {bookStack.Count}\n");
                        //  Show the next book in the stack and ask if the user wants to rent it and removes it if not
                        Console.Clear();
                        Console.WriteLine("Rent this book?\n");
                        Book topBook = bookStack.Peek();
                        Console.WriteLine(String.Format("{0} by {1}.", topBook.Name, topBook.Author));
                        Console.WriteLine(String.Format("{0}. {1} pages. No-return fine {2}$", topBook.Genre, topBook.Pages, topBook.Price));
                        Console.WriteLine();
                        Console.WriteLine("0. Exit\n1. Yes\n2. No");
                        int input;
                        try
                        {
                            input = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (System.FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine("Please write in accepted format.");
                            Console.ReadKey();
                            continue;
                        }
                        switch (input)
                        {
                            case 0:
                                return;
                            case 1:
                                rentedBooks.Enqueue(bookStack.Pop());
                                Console.WriteLine("\nBook rented.");
                                break;
                            case 2:
                                booksForRental.Add(bookStack.Pop());
                                Console.WriteLine("\nBook removed.");
                                break;
                            default:
                                Console.WriteLine("\nPlease choose one of the options");
                                break;
                        }
                        Console.ReadKey();

                    }
                }
            }
            void ShowBooks()
            {
                Console.Clear();
                // Checks for empty stack
                if (bookStack.Count() == 0)
                {
                    Console.WriteLine("Book Stack empty");
                }
                else
                {
                    Console.WriteLine($"Books in stack: {bookStack.Count}\n");
                }

                // Displays all books in the stack
                foreach (Book hardBacks in bookStack)
                {
                    Console.WriteLine(String.Format("{0} by {1}.", hardBacks.Name, hardBacks.Author));
                    Console.WriteLine(String.Format("{0}. {1} pages. No-return fine {2}$", hardBacks.Genre, hardBacks.Pages, hardBacks.Price));
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
                Console.Clear();
                // Checks for empty queue
                float priceSum = 0;

                if (rentedBooks.Count() == 0)
                {
                    Console.WriteLine("No rented books");
                }
                else
                {
                    Console.WriteLine($"Books rented: {rentedBooks.Count}\n");

                    // Displays all books in the queue
                    foreach (Book hardBacks in rentedBooks)
                    {
                        priceSum += hardBacks.Price;
                        Console.WriteLine(String.Format("{0} by {1}.", hardBacks.Name, hardBacks.Author));
                        Console.WriteLine(String.Format("{0}. {1} pages. No-return fine {2}$", hardBacks.Genre, hardBacks.Pages, hardBacks.Price));
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
                    Console.WriteLine($"Penalty for not returning the books: {priceSum}$");
                    Book firstRented = rentedBooks.Peek();
                    Console.WriteLine("Book to be returned first:\n");
                    Console.WriteLine($"Name: {firstRented.Name}");
                    Console.WriteLine($"Author: {firstRented.Author}");
                    Console.WriteLine($"Genre: {firstRented.Genre}");
                    Console.WriteLine($"Pages: {firstRented.Pages}");
                    Console.WriteLine($"Price: {firstRented.Price}$");
                    Console.WriteLine();
                }
                Console.ReadKey();
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
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add book to stack");
                Console.WriteLine("2. Rent books in stack");
                Console.WriteLine("3. Show currunt book stack");
                Console.WriteLine("4. Show current rented books");
                Console.WriteLine();
                Console.WriteLine("Enter your choice");
                Console.WriteLine();
                int menuChoice;

                // Tries to catch exceptions, if the user writes not accepted inputs.
                try
                {
                    menuChoice = Convert.ToInt32(Console.ReadLine());

                }
                catch (System.FormatException)
                {
                    menuChoice = 5;
                }
                Console.Clear();
                switch (menuChoice)
                {
                    case 0:
                        looper = false;
                        break;
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
                    default:
                        Console.WriteLine("Input not recognise. Please try igen");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}
