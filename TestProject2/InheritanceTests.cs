using ClassLibrary1;

namespace TestProject2;

public class InheritanceTests
{
    [TestMethod]
    public void CalculateInterest_AppliesHigherRate()
    {
        // Arrange
        BankAccount account = new SavingsAccount(12345, 1000, 0.05);

        // Act
        account.CalculateInterest();

        // Assert
        Assert.AreEqual(1075, account.GetBalance()); // Adjusted for higher rate
    }

    [TestMethod]
    public void InheritsFromBankAccount()
    {
        // Arrange
        SavingsAccount account = new SavingsAccount(12345, 1000, 0.05);

        // Assert
        Assert.IsTrue(account is BankAccount);
    }
}
