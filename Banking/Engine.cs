using System;
using System.Collections.Generic;
using System.Text;

namespace Banking
{
    public class Engine
    {
        
        
        public void Run()
        {
            Console.WriteLine("|---------- Test Bank ----------|");
            Console.WriteLine("1.Open New Account.");
            Console.WriteLine("2.Withdraw Money.");
            Console.WriteLine("3.Deposit Money.");
            Console.WriteLine("4.Check customers and balance.");
            Console.WriteLine("5.Exit.");

            Repository<BankAccount> BankAccountRepository = new Repository<BankAccount>();

            char input = char.Parse(Console.ReadLine());
            while (input != '5')
            {
                try
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (input == '1')
                {
                    string[] inputNames = Console.ReadLine().Split(" ");
                    BankAccount account = new BankAccount(inputNames[0], inputNames[1]);
                    BankAccountRepository.AddAccount(account);
                }
                else if (input == '2')
                {
                    Console.WriteLine("Enter your account name.");
                    string[] inputAccountName = Console.ReadLine().Split();
                    if (BankAccountRepository.FindByName(inputAccountName[0], inputAccountName[1]) == null)
                    {
                        Console.WriteLine("The account name doesn't exist!");
                    }
                    else
                    {
                        Console.WriteLine("Enter the amount of money you want to withdraw.");
                        int amount = int.Parse(Console.ReadLine());
                        IBankAccount account = BankAccountRepository.FindByName(inputAccountName[0], inputAccountName[1]);
                        account.Withdraw(amount);
                    }
                }
                else if (input == '3')
                {
                    Console.WriteLine("Enter your account name.");
                    string[] inputAccountName = Console.ReadLine().Split();
                    if (BankAccountRepository.FindByName(inputAccountName[0], inputAccountName[1]) == null)
                    {
                        Console.WriteLine("The account name doesn't exist!");
                    }
                    else
                    {
                        Console.WriteLine("Enter the amount of money you want to deposit.");
                        int amount = int.Parse(Console.ReadLine());
                        IBankAccount account = BankAccountRepository.FindByName(inputAccountName[0], inputAccountName[1]);
                        account.Deposit(amount);
                    }
                }
                else if (input == '4')
                {
                    foreach (IBankAccount account in BankAccountRepository.BankAccounts)
                    {
                        Console.WriteLine(account.CheckCustomersAndBalance());
                    }
                }
                input = char.Parse(Console.ReadLine());
            }
        }
    }
}
