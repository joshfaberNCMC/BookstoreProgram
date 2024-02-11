namespace BookstoreProgram.classes
{
    /// <summary>
    /// this class contains the properties related to a customer of the in-program bookstore
    /// </summary>
    /// <param name="firstName">the customer's first name</param>
    /// <param name="lastName">the customer's last name</param>
    /// <param name="age"></param>the customer's age<summary>
    /// UserInventory is a list of books that the customer is purchasing/did purchase
    /// </summary>
    class User(string firstName, string lastName, int age)
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public int Age { get; set; } = age;
        public List<Book> UserInventory { get; set; } = [];
    }
}

