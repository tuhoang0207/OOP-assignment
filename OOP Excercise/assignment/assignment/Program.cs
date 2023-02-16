using System.Globalization;
using System;
using System.Net;

class Book
{
    int bookId;
    string name;
    string author;
    string genre;
    int quantity;

    public Book()
    {
    }

    public Book(int bookId, string name, string author, string genre, int quantity)
    {
        this.bookId = bookId;
        this.name = name;
        this.author = author;
        this.genre = genre;
        this.quantity = quantity;
    }
    class libraryCard
    {
        int cardId;
        string name;
        string cmndId;
        DateOnly dateCreated;

        public libraryCard() { }
        public libraryCard(int cardId, string name, string cmndId, DateOnly dateCreated)
        {
            this.cardId = cardId;
            this.name = name;
            this.cmndId = cmndId;
            this.dateCreated = dateCreated;
        }

        class LoanCard
        {
            string loanCardId;
            string libraryCardId;

            string cardOwner;
            string bookName;
            string bookId;
            DateOnly loanDate;
            DateOnly giveBackDate;

            class main
            {
                static List<Book> list = new List<Book>();

                static List<LoanCard> loanCardList = new List<LoanCard>();

                static List<libraryCard> libraryCardList = new List<libraryCard>();
                public static void mainMenu()
                {
                    Console.WriteLine("---Welcome to VTCA library---");
                    Console.WriteLine("=============================");
                    Console.WriteLine("1. Manage book");
                    Console.WriteLine("2. Manage library card");
                    Console.WriteLine("3. Manage book loan card");
                }

                public static void bookMenu()
                {
                    Console.WriteLine("Manage book");
                    Console.WriteLine("1. Add new book");
                    Console.WriteLine("2. Show list book");
                    Console.WriteLine("3. Update book");
                    Console.WriteLine("4. Search by name");
                    Console.WriteLine("5. Sort by name");
                    Console.WriteLine("6. Delete by name");
                }

                static int bookId = 1;
                static int id = 1;
                public static void addBook()
                {
                    Book b = new Book();

                    b.bookId = bookId;
                    b.bookId = id;

                    Console.WriteLine("enter book name ");
                    b.name = Console.ReadLine();

                    Console.WriteLine("enter author name ");
                    b.author = Console.ReadLine();

                    Console.WriteLine("enter quantity ");
                    b.quantity = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("enter genre ");
                    b.genre = Console.ReadLine();
                    list.Add(b);

                    SaveToTxt();
                    writeToFile("books",b.name);

                    bookId++;

                    id++;
                }

                public static void SaveToTxt()
                {
                    using (TextWriter tw = new StreamWriter("Book.txt"))
                    {
                        foreach (var item in list)
                        {
                            tw.WriteLine(string.Format("Id:{0} Book: {1} - Genre: {2} written by: {3} quantity {4}",item.bookId, item.name,item.genre,item.author,item.quantity.ToString()));
                        }
                    }
                }

                public static void printBook()
                {
                    foreach (Book book in list)
                    {
                        Console.WriteLine(book.bookId);
                        Console.WriteLine("Book name: " + book.name);
                        Console.WriteLine("Book author " + book.author);
                        Console.WriteLine("Book quantity " + book.quantity);
                        Console.WriteLine("Book genre " + book.genre);
                        Console.WriteLine("==========================");
                    }
                }

                public static void updateBook()
                {
                    string name;
                    Console.WriteLine("enter book name you want to update ");
                    name = Console.ReadLine();
                    foreach (Book b in list)
                    {
                        if (b.name.Equals(name))
                        {
                            Console.WriteLine("enter book name ");
                            b.name = Console.ReadLine();

                            Console.WriteLine("enter author name ");
                            b.author = Console.ReadLine();

                            Console.WriteLine("enter quantity ");
                            b.quantity = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("enter genre ");
                            b.genre = Console.ReadLine();

                            Console.WriteLine("update successful");
                        }
                    }
                }

                public static void searchBook()
                {
                    string name;
                    Console.WriteLine("enter book name you want to search ");
                    name = Console.ReadLine();

                    foreach (Book b in list)
                    {
                        if (b.name.Equals(name))
                        {
                            Console.WriteLine("Found the book you want to search ");
                            Console.WriteLine(b.name + " of " + b.author);
                        }
                        else
                        {
                            Console.WriteLine("The book you want to search is not found ");
                        }
                    }
                }

                public static void sortBookByName()
                {
                    list.Sort((x, y) => string.Compare(x.name, y.name));
                }

                public static void deleteByName()
                {
                    string name;
                    Console.WriteLine("enter book name you want to delete ");
                    name = Console.ReadLine();
                    foreach (Book b in list)
                    {
                        if (b.name.Equals(name))
                        {
                            list.Remove(b);
                        }
                        else
                        {
                            Console.WriteLine("The book you want to delete is not found ");
                        }
                    }
                }

                public static void loanCardMenu()
                {
                    Console.WriteLine("Manage library card");
                    Console.WriteLine("1. Add new card");
                    Console.WriteLine("2. Show list loan card");
                    Console.WriteLine("3. Update card information");
                }

                public static void addNewLoanBookCard()
                {
                    LoanCard card = new LoanCard();

                    Console.WriteLine("enter loan card id ");
                    card.libraryCardId = Console.ReadLine();

                    Console.WriteLine("enter library card id ");
                    card.libraryCardId = Console.ReadLine();

                    Console.WriteLine("enter owner name ");
                    card.cardOwner = Console.ReadLine();

                    Console.WriteLine("enter loan date ");
                    card.loanDate = DateOnly.Parse(Console.ReadLine());

                    Console.WriteLine("enter give back date ");
                    card.giveBackDate = DateOnly.Parse(Console.ReadLine());

                    Console.WriteLine("enter book name");
                    card.bookName = Console.ReadLine();

                    Console.WriteLine("enter book id ");
                    card.bookId = Console.ReadLine();

                    loanCardList.Add(card);
                }

                public static void showListLoanCard()
                {
                    foreach (LoanCard c in loanCardList)
                    {
                        Console.WriteLine("book name " + c.bookName);
                        Console.WriteLine("owner by " + c.cardOwner);
                        Console.WriteLine("loan date " + c.loanDate.ToString("d", new CultureInfo("es-ES")));
                        Console.WriteLine("give back date " + c.giveBackDate.ToString("d", new CultureInfo("es-ES")));
                        Console.WriteLine("==========================");
                    }
                }





                public static void updateLoanCard()
                {
                    string name;
                    Console.WriteLine("enter loan card owner you want to update ");
                    name = Console.ReadLine();
                    foreach (LoanCard c in loanCardList)
                    {
                        if (c.cardOwner.Equals(name))
                        {
                            Console.WriteLine("enter owner name ");
                            c.cardOwner = Console.ReadLine();

                            Console.WriteLine("enter book name ");
                            c.bookName = Console.ReadLine();

                            Console.WriteLine("enter loan date ");
                            c.loanDate = DateOnly.Parse(Console.ReadLine());

                            Console.WriteLine("enter give back date ");
                            c.giveBackDate = DateOnly.Parse(Console.ReadLine());

                            Console.WriteLine("update successful");
                        }
                    }
                }

                public static void libraryCardMenu()
                {
                    Console.WriteLine("1. Add new card ");
                    Console.WriteLine("2. Update card information ");
                    Console.WriteLine("3. Show list");
                }

                public static void addLibraryCard()
                {
                    libraryCard lcard = new libraryCard();

                    Console.WriteLine("enter library card id ");
                    lcard.cardId = int.Parse(Console.ReadLine());

                    Console.WriteLine("enter owner name");
                    lcard.name = Console.ReadLine();

                    Console.WriteLine("enter cmnd id ");
                    lcard.cmndId = Console.ReadLine();

                    Console.WriteLine("enter date created ");
                    lcard.dateCreated = DateOnly.Parse(Console.ReadLine());

                    libraryCardList.Add(lcard);
                }

                public static void showListLibraryCard()
                {
                    foreach (libraryCard lc in libraryCardList)
                    {
                        Console.WriteLine("owner by " + lc.name);
                        Console.WriteLine("cmnd id " + lc.cmndId);
                        Console.WriteLine("create date " + lc.dateCreated.ToString("d", new CultureInfo("es-ES")));
                        Console.WriteLine("==========================");
                    }
                }

                public static void updateLibraryCard()
                {
                    string name;
                    Console.WriteLine("enter loan card owner you want to update ");
                    name = Console.ReadLine();

                    foreach (libraryCard c in libraryCardList)
                    {
                        if (c.name.Equals(name))
                        {
                            Console.WriteLine("enter owner name ");
                            c.name = Console.ReadLine();

                            Console.WriteLine("enter cmnd id ");
                            c.cmndId = Console.ReadLine();

                            Console.WriteLine("enter created date");
                            c.dateCreated = DateOnly.Parse(Console.ReadLine());


                            Console.WriteLine("update successful");
                        }
                    }
                }

                public static void writeToFile(string fileName,string content)
                {
                    File.WriteAllText(fileName + ".txt", content);  // Create a file and write the content of writeText to it
                    Console.WriteLine("write to file successful");

                    string readText = File.ReadAllText(fileName + ".txt");  // Read the contents of the file
                    Console.WriteLine(readText);  // Output the content
                }

                public static void Main(string[] args)
                {

                    int option;
                    do
                    {
                        mainMenu();

                        Console.WriteLine("enter your option ");
                        option = Convert.ToInt32(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                bookMenu();
                                Console.WriteLine("enter your option ");
                                option = Convert.ToInt32(Console.ReadLine());
                                switch (option)
                                {
                                    case 1:
                                        addBook();
                                        printBook();
                                        break;
                                    case 2:
                                        printBook();
                                        break;
                                    case 3:
                                        updateBook();
                                        printBook();
                                        break;
                                    case 4:
                                        searchBook();
                                        break;
                                    case 5:
                                        sortBookByName();
                                        printBook();
                                        break;
                                    case 6:
                                        deleteByName();
                                        break;
                                }

                                break;
                            case 2:
                                loanCardMenu();

                                Console.WriteLine("enter your option");
                                option = Convert.ToInt32(Console.ReadLine());

                                switch (option)
                                {
                                    case 1:
                                        addNewLoanBookCard();
                                        break;
                                    case 2:
                                        showListLoanCard();
                                        break;
                                    case 3:
                                        updateLoanCard();
                                        break;
                                }
                                break;
                            case 3:
                                libraryCardMenu();

                                Console.WriteLine("enter your option");
                                option = Convert.ToInt32(Console.ReadLine());

                                switch (option)
                                {
                                    case 1:
                                        addLibraryCard();
                                        break;
                                    case 2:
                                        showListLibraryCard();
                                        break;
                                    case 3:
                                        updateLibraryCard();
                                        break;
                                }
                                break;
                            default:
                                System.Environment.Exit(0);
                                break;

                        }
                    } while (option != null);
                }
            }
        }
    }
}