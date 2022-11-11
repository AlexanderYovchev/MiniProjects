using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking
{
    public class Repository<BankAccount>
    {
        private List<IBankAccount> bankAccounts;

        public Repository()
        {
            bankAccounts = new List<IBankAccount>();
        }

        public IReadOnlyCollection<IBankAccount> BankAccounts { get => bankAccounts;}

        public IBankAccount FindByName(string firstName, string lastName)
        {
            return this.bankAccounts.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
        public void AddAccount(IBankAccount givenAccount)
        {
            bankAccounts.Add(givenAccount);
        }
        public bool RemoveAccount(IBankAccount givenAccount)
        {
            if (bankAccounts.Contains(givenAccount))
            {
                bankAccounts.Remove(givenAccount);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
    }
}
