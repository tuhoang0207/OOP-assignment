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

    class Member
    {
        int memberId;
        string name;
        string cmndId;

        public Member(int memberId, string name, string cmndId)
        {
            this.memberId = memberId;
            this.name = name;
            this.cmndId = cmndId;
        }


    }

    class main
    {
        static List<Book> list = new List<Book>();
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
            Console.WriteLine("4. Sort by name");
        }

        public static void addBook()
        {
            Book b = new Book();

            Console.WriteLine("enter book id ");
            b.bookId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter book name ");
            b.name = Console.ReadLine();

            Console.WriteLine("enter author name ");
            b.author = Console.ReadLine();

            Console.WriteLine("enter quantity ");
            b.quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter genre ");
            b.genre = Console.ReadLine();

            list.Add(b);

        }

        public static void printBook()
        {
            foreach (Book book in list)
            {
                Console.WriteLine("Book name: " + book.name);
                Console.WriteLine("Book author " + book.author);
                Console.WriteLine("Book quantity " + book.quantity);
                Console.WriteLine("Book genre " + book.genre);
            }
        }

        public static void updateBook()
        {
            string name;
            Console.WriteLine("enter book name you want to update ");
            name = Console.ReadLine();
            foreach(Book b in list)
            {
                if(b.name.Equals(name))
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

            foreach (Book b in list) { 
                if(b.name.Equals(name))
                {
                    Console.WriteLine("Found the book you want to search ");
                    Console.WriteLine(b.name + " of " + b.author);
                } else
                {
                    Console.WriteLine("The book you want to search is not found ");
                }
            }
        }

        public static void sortBookByName()
        {
            
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
                }
            } while (true);
        }
    }

}




