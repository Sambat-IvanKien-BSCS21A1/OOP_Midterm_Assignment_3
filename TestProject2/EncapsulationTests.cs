using ClassLibrary1;
namespace TestProject2;

using System;

public class EncapsulationTests
{
    [TestMethod]
    public void Deposit_IncreasesBalance()
    {
        // Arrange
        BankAccount account = new BankAccount(12345, 1000, 0.05);

        // Act
        account.Deposit(500);

        // Assert
        Assert.AreEqual(1500, account.GetBalance());
    }

    [TestMethod]
    public void Withdraw_DecreasesBalance()
    {
        // Arrange
        BankAccount account = new BankAccount(12345, 1000, 0.05);

        // Act
        account.Withdraw(200);

        // Assert
        Assert.AreEqual(800, account.GetBalance());
    }

    [TestMethod]
    public void CalculateInterest_IncreasesBalance()
    {
        // Arrange
        var accountNumber = 12345;
        BankAccount account = new BankAccount(accountNumber, 1000, 0.05);

        // Act
        account.CalculateInterest();

        // Assert
        Assert.AreEqual(1050, account.GetBalance());
    }

    [DataTestMethod]
    [DataRow(1000, true)]
    [DataRow(1000, false)]
    [DataRow(9000, false)]
    public void Withdraw_OtherBanksShouldHaveChargeOfTwentyPesos(int amount, bool isOtherBank)
    {
        // Arrange
        var initialBalance = 9000;
        var accountNumber = 12345;
        var penalty = isOtherBank ? 20 : 0;
        BankAccount account = new BankAccount(accountNumber, initialBalance);

        // Act
        account.Withdraw(amount, isOtherBank);

        // Assert
        Assert.AreEqual(1000 - amount - penalty, account.GetBalance());
    }
}
