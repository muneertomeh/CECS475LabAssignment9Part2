using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CECS475LabAssignment9Part2.Tests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void BankTestingMethod()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;


            BankAccount theBankAccount = new BankAccount("Muneer Tomeh", beginningBalance);
            theBankAccount.Debit(debitAmount);

            Assert.AreEqual(expected, theBankAccount.Balance);
        }


        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDebitOverArgumentException()
        {
            double beginningBalance = 11.99;
            double debitAmount = 20.99;
            BankAccount theBank = new BankAccount("Muneer Tomeh", beginningBalance);


            try
            {
                theBank.Debit(debitAmount);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The exception has not been triggered");

        }

        [TestMethod]
        public void TestDebitUnderArgumentException()
        {

            double beginningBalance = 11.99;
            double debitAmount = -1;
            BankAccount bankAccount = new BankAccount("Muneer Tomeh", beginningBalance);


            try
            {
                bankAccount.Debit(debitAmount);
            }
            catch(ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown");
            
        }
    }
}
