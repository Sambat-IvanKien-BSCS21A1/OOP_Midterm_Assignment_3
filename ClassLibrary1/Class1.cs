namespace ClassLibrary1
{

    public class Library
    {
        private readonly List<Book> _books = new List<Book>();



        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }

        public List<Book> GetBooks()
        {
            return _books;
        }

        public Book SearchBook(string title)
        {
            return _books.Find(b => b.title == title);
        }
    }

    public class Book
    {
        public string title;
        public string author;
        public string isbn;

        public Book(string title, string author, string isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
        }
    }

    public class Customer
    {
        private readonly List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }
    }

    public class Order
    {
        // Define properties for Order as needed
    }

    public class EmailSender
    {
        public string SendEmail(Order order)
        {
            // Logic to send an email
            return "Email Sent"; // Placeholder return value
        }
    }

    public class OrderProcessor
    {
        private readonly EmailSender _emailSender;

        public OrderProcessor(EmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public string ProcessOrder(Order order)
        {
            // Logic to process the order
            return _emailSender.SendEmail(order);
        }
    }
    public class BankAccount
    {
        public decimal balance;
        private int accNumber;
        private double interestRate;

        public BankAccount(int accNumber, decimal Balance, double interestRate = 0)
        {
            this.accNumber = accNumber;
            this.balance = Balance;
            this.interestRate = interestRate;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                Console.WriteLine("Deposit must be positive");
            balance += amount;
        }

        public void Withdraw(decimal amount, bool isOtherBank = false)
        {
            if (amount <= 0)
                Console.WriteLine("Withdrawal amount must be positive.");

            decimal penalty = isOtherBank ? 20 : 0;
            if (amount + penalty > balance)
                Console.WriteLine("Insufficient funds.");

            balance -= (amount + penalty);
        }

        public virtual void CalculateInterest()
        {
            decimal interest = balance * (decimal)interestRate;
            balance += interest;
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }
    public class SavingsAccount : BankAccount
    {
        private double interestRate;

        public SavingsAccount(int accountNumber, decimal initialBalance, double interestRate)
            : base(accountNumber, initialBalance)
        {
            this.interestRate = interestRate;
        }

        public override void CalculateInterest()
        {
            decimal interest = balance * (decimal)interestRate;
            balance += interest;
        }
    }
}
