namespace BookstoreProgram.classes
{
    class BookManagerService
    {
        /// <summary>
        /// this class contains all of the methods related to searching/handling/maintaining the books in the
        /// in-program bookstore.
        /// </summary>
    
        public BookManagerService()
        {
            Bookstore badassTown = new("Badass Town Bookstore", "Badass Town, USA"); // instantiates a a new bookstore object
            Console.WriteLine($"You walk into {badassTown.Name}, located in {badassTown.Address}");
            int storeID = badassTown.SetInventory(); // calls the method to fill the bookstore with books
            User joshf = new("Josh", "Faber", 29); // instantiates a user object

            Console.WriteLine($"Hello {joshf.FirstName} {joshf.LastName}, welcome to {badassTown.Name}!");
            Console.WriteLine("Please browse our small collection of books.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            DisplayInventory(badassTown.StoreInventory); // shows the stock of books in the bookstore
            SearchStoreInventory(badassTown.StoreInventory, storeID); // facilitates searching through the books in the bookstore
            RequestStoreInventory(badassTown.StoreInventory, storeID); // allows a user to add books that are not in the bookstore

            int storeStock = TotalStock(badassTown.StoreInventory); // keeps count of the total number of books in the bookstore

            DisplayInventory(badassTown.StoreInventory);
            InventoryManager(joshf.UserInventory, badassTown.StoreInventory, storeStock); // adds/removes books between the StoreInventory and UserInventory

            int userStock = TotalStock(joshf.UserInventory);

            Checkout(joshf.UserInventory, userStock, storeID); // allows the user to remove selected books before purchasing
        }

        public static void DisplayInventory(List<Book> Inventory)
        {
        /// <summary>
        /// writes all books and book properties in a provided inventory to the console
        /// </summary>
            foreach(Book book in Inventory)
            {
                Console.WriteLine($"\nTitle: {book.Title}\nISBN: {book.ISBN}\nStore ID: {book.StoreID}\nAuthor: {book.Author}\nGenre: {book.Genre}");
            }            
        }

        public static int TotalStock(List<Book> Inventory)
        {
        /// <summary>
        /// counts how many books are in a provided inventory
        /// </summary>
            int count = 0;

            foreach(Book book in Inventory)
            {
                count++;
            }

            return count;
        }

        public static int SearchInput()
        {
        /// <summary>
        /// prompts the user for an int and returns that int for use in SearchStoreInventory()
        /// </summary>
            Console.Write("\nEnter the Store ID to search for a specific book: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            return userInput;                         
        }

        public static void SearchLoop(int userInput, List<Book> StoreInventory, int storeID)
        {
        /// <summary>
        /// loops through StoreInventory searching for books with a storeID that match the userInput provided as an argument
        /// </summary>
            foreach (Book book in StoreInventory)
            {
                if (book.StoreID == userInput)
                {
                    Console.WriteLine($"\nTitle: {book.Title}\nISBN: {book.ISBN}\nStore ID: {book.StoreID}\nAuthor: {book.Author}\nGenre: {book.Genre}");
                }
                else if (book.StoreID != userInput && userInput >= 1 && userInput <= storeID)
                { // runs if the storeID of a book doesn't match userInput, and the user input is within the appropriate ranges within StoreInventory
                    continue; // continue here as no code needs to run
                }
                else
                {
                    Console.WriteLine("\nInvalid entry. No book exists with that Store ID.");
                    break;
                }
            }            
        }

        public static void SearchStoreInventory(List<Book> StoreInventory, int storeID)
        {
            /// <summary>
            /// facilitates the search of StoreInventory
            /// </summary>
            Console.Write("\nWould you like to search for a specific book? (Y for yes, N for no): ");
            string? answer = Console.ReadLine();

            bool conditional = true;

            while(conditional == true) // will keep prompting user for input until they are finished searching or they enter the correct prompt
            {
                if(answer == "Y" || answer == "y")
                {
                    int userInput = SearchInput(); // userInput returned from SearchInput()
                    SearchLoop(userInput, StoreInventory, storeID); 
                    Console.Write("\nWould you like to continue searching? (Y for yes, N for no): ");
                    answer = Console.ReadLine(); // prompts the user again to determine what path to take                                      
                }
                else if(answer == "N" || answer == "n")
                {
                    break;
                }
                else
                {
                    Console.Write("\nInvalid entry. Please, try again.\n");
                    Console.Write("\nWould you like to search for a specific book? (Y for yes, N for no): ");
                    answer = Console.ReadLine(); // stays in the while loop unless N or n are entered                
                }
            }
        }

        public static void RequestStoreInventory(List<Book> StoreInventory, int storeID)
        {
            /// <summary>
            /// allows a user to add books to the bookstore's stock
            /// </summary>
            bool conditional = true;

            Console.Write("\nIf there is a book you want that we don't have in stock, request it below and we can add it to the store inventory.\n\n");
            Console.Write("Would you Like to request a book? (Y for yes, N for no): ");
            string? answer = Console.ReadLine();

            while(conditional == true)
            {
                if(answer == "Y" || answer == "y")
                {
                    Console.Write("\nTitle: "); // prompts the user to enter all of the properties listed in Book.cs
                    string inputTitle = Console.ReadLine()!;
                    Console.Write("ISBN: ");
                    string inputISBN = Console.ReadLine()!;
                    Console.Write("Author: ");
                    string inputAuthor = Console.ReadLine()!;
                    Console.Write("Genre: ");
                    string inputGenre = Console.ReadLine()!;

                    Book newBook = new(inputTitle, inputISBN, storeID++, inputAuthor, inputGenre);
                    StoreInventory.Add(newBook);  // adds the book to StoreInventory with a unique incremented storeID

                    Console.Write("\nWould you like to request another book? (Y for yes, N for no): ");
                    answer = Console.ReadLine();
                }
                else if(answer == "N" || answer == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid entry. Please, try again.");
                    Console.Write("\nWould you Like to request a book? (Y for yes, N for no): ");
                    answer = Console.ReadLine();
                }
            }
        }
        
        public static void InventoryManager(List<Book> UserInventory, List<Book> StoreInventory, int stock)
        {
            /// <summary>
            /// allows the user to remove books from StoreInventory and add them to their UserInventory
            /// </summary>
            Console.Write("\nWould you like to purchase a book? (Y for yes, N for no): ");
            string? answer = Console.ReadLine();

            int buyCounter = 0; // counter to keep track of the number of transactions
            bool conditional = true;

            while(conditional == true)
            {
                if(answer == "Y" || answer == "y")
                {
                    Console.Write("\nEnter the Store ID of a book that you would like to purchase: ");
                    int inputStoreID = Convert.ToInt32(Console.ReadLine());

                    for(int step = 0; step < stock; step++) // loop iterates from 0 to the total amount of books in StoreInventory
                    {
                        if(inputStoreID == StoreInventory[step].StoreID) // checks if user input is == to the storeID of each book in StoreInventory
                        {
                            Console.WriteLine("\n" + StoreInventory[step].Title); // if true, write the books name to console
                            UserInventory.Add(StoreInventory[step]); // adds it to UserInventory
                            StoreInventory.Remove(StoreInventory[step]); // removes it from StoreInventory
                            stock = TotalStock(StoreInventory); // runs TotalSock() to count the updated number of books in StoreInventory
                            buyCounter++; // iterates buy counter for every add
                        }
                        else if(inputStoreID < 0 || inputStoreID > stock + buyCounter)  // tests for out-of-bounds input
                        {                                                              // update stock + total buy amount is always == to the initial stock
                            Console.WriteLine("\nInvalid entry. Please, try again."); // before any changes were made
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.Write("\nWould you like to purchase another book? (Y for yes, N for no): ");
                    answer = Console.ReadLine();
                }
                else if(answer == "N" || answer =="n")
                {
                    break;
                }
                else
                {
                    Console.Write("\nInvalid entry. Please, try again.\n");
                    Console.Write("\nWould you like to purchase a book? (Y for yes, N for no): ");
                    answer = Console.ReadLine();
                }
            }  
        }

        public static void Checkout(List<Book> UserInventory, int stock, int storeID)
        {
        /// <summary>
        /// allows the user to remove books from his inventory before purchase
        /// </summary>            
            Console.WriteLine("\nHere are the items you added to your inventory.");
            DisplayInventory(UserInventory); // calls DisplayInventory() to output the contents of UserInventory to the console

            Console.Write("\nWould you like to make any changes before purchasing? (Y for yes, N for no): ");
            string? answer = Console.ReadLine();

            bool conditional = true;

            while(conditional == true)
            {
                if (answer == "Y" || answer == "y")
                {
                    Console.Write("\nEnter the Store ID of a book that you would like to remove from your inventory: ");
                    int inputStoreID = Convert.ToInt32(Console.ReadLine());

                    for(int step = 0; step < stock; step++) 
                    {
                        if (inputStoreID == UserInventory[step].StoreID) // same technique used here as in InventoryManager()
                        {
                            Console.WriteLine("\n" + UserInventory[step].Title);
                            UserInventory.Remove(UserInventory[step]); // removes book from UserInventory
                            stock = TotalStock(UserInventory); // calls TotalStock to update the number of books in UserInventory before next iteration
                        }
                        else if(inputStoreID < 0 || inputStoreID > storeID) // tests for out-of-bounds input, if < 0 and > highest storeID given out
                        {                                                  // then input is invalid
                            Console.WriteLine("\nInvalid entry. Please, try again.\n");
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.Write("\nWould you like to remove another book? (Y for yes, N for no): ");
                    answer = Console.ReadLine();
                }
                else if(answer == "N" || answer =="n")
                {
                    break;
                }
                else
                {
                    Console.Write("\nInvalid entry. Please, try again.\n"); // this is to catch incorrect input and prompt to retry
                    Console.Write("\nWould you like to make any changes before purchasing? (Y for yes, N for no): ");
                    answer = Console.ReadLine();                  
                }
            }
            Console.WriteLine("\nThe following items have been purchased: ");
            DisplayInventory(UserInventory);
            Console.WriteLine("\nThanks for shopping at Badass Town Bookstore!\n"); // thank god we're finally done! -_-              
        }
    }
}