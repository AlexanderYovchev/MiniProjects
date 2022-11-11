using System;
using System.Collections.Generic;
using System.Text;

namespace Banking
{
    public class BankAccount : IBankAccount
    {
        private string firstName;
        private string lastName;
        private decimal balance = 0;

        public BankAccount(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName 
        { 
            get => this.firstName; 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null or empty!");
                }
                this.firstName = value; 
            } 
        }

        public string LastName 
        { 
            get => this.lastName; 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty!");
                }
                this.lastName = value; 
            } 
        }

        public decimal Balance { get => this.balance; set { this.balance = value; } }

        public void Withdraw(int amount)
        {
            if (this.balance < amount)
            {
                throw new ArgumentException("There is not enough money in the account.");
            }
            else
            {
                this.balance -= amount;
            }
            
        }
        public void Deposit(int amount)
        {

            this.balance += amount;

        }

        public string CheckCustomersAndBalance()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FirstName} {LastName}: {Balance:f2} GBP.");
            return sb.ToString().TrimEnd();   
        }
        

    }
}
