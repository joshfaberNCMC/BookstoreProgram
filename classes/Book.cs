namespace BookstoreProgram.classes
{
    /// <summary>
    /// this class consists of the different properties of a book
    /// </summary>
    /// <param name="title">the name of the book</param>
    /// <param name="isbn">international Standard Book Number (real life unique identifier)</param>
    /// <param name="storeID">unique identifier for a book in the in-program bookstore</param>
    /// <param name="author">person who wrote the book</param>
    /// <param name="genre">the type or category of story being told in the book</param> <summary>
    /// 
    /// </summary>
    class Book(string title, string isbn, int storeID, string author, string genre)
    {
        public string Title { get; set; } = title;
        public string ISBN { get; set; } = isbn;
        public int StoreID { get; set; } = storeID;
        public string Author { get; set; } = author;
        public string Genre { get; set; } = genre;
    }
}