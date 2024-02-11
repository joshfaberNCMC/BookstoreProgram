namespace BookstoreProgram.classes
{
    /// <summary>
    /// this class contains the properties and singular method of an in-program bookstore
    /// </summary>
    /// <param name="name">name of the bookstore</param>
    /// <param name="address">address of the bookstore</param>
    /// <summary>
    /// the StoreInventory is a list of books that the bookstore has in stock
    /// </summary>
    class Bookstore(string name, string address)
    {
        public string Name { get; set; } = name;
        public string Address { get; set; } = address;
        public List<Book> StoreInventory { get; set; } = [];

        public int SetInventory()
        {
            /// <summary>
            /// this method fills the StoreInventory list with some books
            /// </summary>
            int storeID = 1; // storeID starts the first books unique ID to 1 and it iterates for every new book
            StoreInventory.AddRange( 
        [
            new Book("A Game of Thrones", "0-553-10354-7", storeID++, "George R. R. Martin", "Fantasy"),
            new Book("A Clash of Kings", "0-00-224585-X", storeID++, "George R. R. Martin", "Fantasy"),
            new Book("A Feast for Crows", "0-00-224743-7", storeID++, "George R. R. Martin", "Fantasy"),
            new Book("A Dance with Dragons", "978-0553801477", storeID++, "George R. R. Martin", "Fantasy"),
            new Book("The Hitchhiker's Guide to the Galaxy", "0-330-25864-8", storeID++, "Douglas Adams", "Science Fiction"),
            new Book("The Restaurant at the End of the Universe", "0-345-39181-0", storeID++, "Douglas Adams", "Science Fiction"),
            new Book("Life, the Universe and Everything", "0-330-26738-8", storeID++, "Douglas Adams", "Science Fiction"),
            new Book("So Long, and Thanks for All the Fish", "0-330-28700-1", storeID++, "Douglas Adams", "Science Fiction"),
            new Book("Mostly Harmless", "0-330-32311-3", storeID++, "Douglas Adams", "Science Fiction"),
        ]);

            return storeID; // returns the iterated ID after adding all of the books to the list
        }
    }
}
