using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace En_Tur_på_bibloteket
{
    class Book
    {
        private string name;
        private string genre;
        private string author;
        private int pages;
        private float price;
        private bool fiction;

        public Book()
        {
            // Empty constructor
        }
        public void GenerateBook()
        {
            Random rand = new Random();

            // Setting up for generating random author and book name
            string[] firstNames = new string[20] { "John", "Tom", "Michael", "Harrison", "Russell", "Isaac", "Jordan", "Alexander", "Ewan", "Gabriel", "Mia", "Jasmine", "Chelsea", "Madison", "Esme", "Olive", "Sierra", "Kali", "Cara", "Sofie" };
            string[] lastNames = new string[20] { "Chambers", "Parker", "Burton", "Gordon", "Simpson", "Walsh", "Bennett", "Abbott", "Cameron", "Brady", "Rogers", "Spencer", "May", "Wilkinson", "Thompson", "Malone", "Short", "Beach", "Moon", "Doyle" };
            string[] genreList = new string[7] { "Crime", "Fantasy", "Sci-Fi", "Mystery", "Horror", "Autobiography", "Learning Book" };
            string[] bookNamePrefix = new string[20] { "Savior", "Goddess", "Swindlers", "Trees", "Pirates", "Humans", "Completion", "Luck", "Angel", "Defender", "Spiders", "Knights", "Docters", "Giants", "Anger", "Shield", "Traces", "Parrot", "Phantom", "Rebels" };
            string[] bookNameMiddle = new string[5] { "of", "of the", "with", "without", "and" };
            string[] bookNameSuffix = new string[20] { "Reality", "Tomorrow", "Time", "Water", "Earth", "Ocean", "Mountain", "Prison", "Forest", "End", "Money", "Vigor", "Wings", "Sins", "Pride", "A Home", "Fear", "Time", "Desire", "Sins" };
            string bookName = "";
            int prefixTemp = 0;
            int middleTemp = 0;
            int suffixTemp = 0;
            prefixTemp = rand.Next(0, bookNamePrefix.Length);
            middleTemp = rand.Next(0, bookNameMiddle.Length);

            switch (middleTemp)
            {
                case 0:
                    suffixTemp = rand.Next(0, 4);
                    break;
                case 1:
                    suffixTemp = rand.Next(5, 9);
                    break;
                case 2:
                    suffixTemp = rand.Next(10, 14);
                    break;
                case 3:
                    suffixTemp = rand.Next(15, 19);
                    break;
            }
            bookName = String.Concat(bookNamePrefix[prefixTemp], " ", bookNameMiddle[middleTemp]);
            if (suffixTemp == 4)
            {
                bookName = String.Concat(bookName, " ", bookNamePrefix[rand.Next(0, bookNamePrefix.Length)]);
            }
            else
            {
                bookName = String.Concat(bookName, " ", bookNameSuffix[suffixTemp]);
            }
            this.Name = bookName;

            // Setting author name
            this.Author = String.Concat(firstNames[rand.Next(0, firstNames.Length)], " ", lastNames[rand.Next(0, lastNames.Length)]);
            // Book genre
            this.Genre = genreList[rand.Next(0, genreList.Length)];
            this.Pages = rand.Next(80, 750);
            this.Price = 9.99f + (5 * rand.Next(1, 8));
            if (rand.Next(1, 100) < 50)
            {
                this.Fiction = true;
            }
            else
            {
                this.Fiction = false;
            }

        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                this.genre = value;
            }
        }
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                this.author = value;
            }
        }
        public int Pages
        {
            get
            {
                return pages;
            }
            set
            {
                this.pages = value;
            }
        }
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                this.price = value;
            }
        }
        public bool Fiction
        {
            get
            {
                return fiction;
            }
            set
            {
                this.fiction = value;
            }
        }
    }
}
