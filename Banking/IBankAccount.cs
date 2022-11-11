using System;
using System.Collections.Generic;
using System.Text;

namespace Banking
{
    public interface IBankAccount
    {
        string FirstName { get; }

        string LastName { get; }

        decimal Balance { get; }
        void Withdraw(int amount);
        void Deposit(int amount);

        string CheckCustomersAndBalance();

    }
}
