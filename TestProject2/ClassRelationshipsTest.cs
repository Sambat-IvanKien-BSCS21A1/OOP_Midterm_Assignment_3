using ClassLibrary1;
namespace TestProject2;

public class ClassRelationshipsTest
{
    [TestMethod]
    public void AddBook_IncreasesBookCount()
    {
        // Arrange
        Library library = new Library();
        Book book = new Book("Title", "Author", "ISBN");

        // Act
        library.AddBook(book);

        // Assert
        Assert.AreEqual(1, library.GetBooks().Count());
    }

    [TestMethod]
    public void RemoveBook_DecreasesBookCount()
    {
        // Arrange
        Library library = new Library();
        Book book = new Book("Title", "Author", "ISBN");
        library.AddBook(book);

        // Act
        library.RemoveBook(book);

        // Assert
        Assert.AreEqual(0, library.GetBooks().Count());
    }

    [TestMethod]
    public void SearchBook_ReturnsCorrectBook()
    {
        // Arrange
        Library library = new Library();
        Book book = new Book("Title", "Author", "ISBN");
        library.AddBook(book);

        // Act
        Book foundBook = library.SearchBook("Title");

        // Assert
        Assert.AreEqual(book, foundBook);
    }

    [TestMethod]
    public void LibraryHasCompositionRelationshipWithBook()
    {
        // Arrange
        Library library = new Library();
        Book book = new Book("Title", "Author", "ISBN");

        // Act
        library.AddBook(book);

        // Assert
        Assert.IsTrue(library.GetBooks().Contains(book));
    }

    [TestMethod]
    public void CustomerHasAggregationRelationshipWithOrder()
    {
        // Arrange
        Customer customer = new Customer();
        Order order1 = new Order();
        Order order2 = new Order();

        // Act
        customer.AddOrder(order1);
        customer.AddOrder(order2);

        // Assert
        Assert.IsTrue(customer.GetOrders().Contains(order1));
        Assert.IsTrue(customer.GetOrders().Contains(order2));
    }

    public class OrderProcessorTests
    {
        [TestMethod]
        public void OrderProcessorHasDependencyRelationshipWithEmailSender()
        {
            // Arrange
            EmailSender emailSender = new EmailSender();
            OrderProcessor orderProcessor = new OrderProcessor(emailSender);

            // Act
            var emailSent = orderProcessor.ProcessOrder(new Order());

            // Assert
            Assert.IsNotNull(emailSent);
        }
    }
}
