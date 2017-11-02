using System.Collections.Generic;

namespace BankSimulation
{
    /// <summary>
    /// models a bank (naive implementation, not thread-safe)
    /// </summary>
    public class Bank : LoggingServiceBase
    {
        /// <summary>
        /// poor man's implementation of the database of accounts
        /// </summary>
        public Dictionary<string, int> Accounts { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger">the logger instance to be used (optional, can be null)</param>
        public Bank(ILogger logger = null) : base(logger)
        {
        }

        /// <summary>
        /// adds the given amount of money to the given account.
        /// if no account exists with that nr, a new one is 
        /// created.
        /// </summary>
        /// <param name="accountNr"></param>
        /// <param name="amount"></param>
        public void Deposit(string accountNr, int amount)
        {
            Logger?.Log($"Deposit of {amount} to {accountNr}: STARTED");
            if (!Accounts.ContainsKey(accountNr))
            {
                Logger?.Log($"- Account {accountNr} does not exist, creating");
                Accounts.Add(accountNr, amount);
            }
            else
            {
                Accounts[accountNr] += amount;
            }
            Logger?.Log($"Deposit of {amount} to {accountNr}: ENDED.");
        }

        /// <summary>
        /// subtracts the given amount of money from the given account.
        /// if the account does not exist or contains not enough money,
        /// the withdrawal fails.
        /// </summary>
        /// <param name="accountNr"></param>
        /// <param name="amount"></param>
        /// <returns>true if the money could successfully be withdrawn, false otherwise</returns>
        public bool Withdraw(string accountNr, int amount)
        {
            Logger?.Log($"Withdrawal of {amount} from {accountNr}: STARTED");
            if (!Accounts.ContainsKey(accountNr))
            {
                Logger?.Log($"- Account {accountNr} does not exist");
                Logger?.Log($"Withdrawal of {amount} from {accountNr}: ABORTED");

                return false;
            }

            if (Accounts[accountNr] < amount)
            {
                Logger?.Log($"- Account {accountNr} does not exist");
                Logger?.Log($"Withdrawal of {amount} from {accountNr}: ABORTED");

                return false;
            }

            Accounts[accountNr] -= amount;
            Logger?.Log($"Withdrawal of {amount} from {accountNr}: ENDED");
            return true;
        }
    }

}