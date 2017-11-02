using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankSimulation.Test
{
    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void SimpleDepositTest()
        {
            // 1. arrange 
            var logger = new ConsoleLogger();
            var bank = new Bank(logger);

            // 2. act
            bank.Deposit("123", 100);

            // 3. assert
            Assert.AreEqual(bank.Accounts.Count, 1);
            Assert.IsTrue(bank.Accounts.ContainsKey("123"));
            Assert.AreEqual(bank.Accounts["123"], 100);
        }
    }
}
