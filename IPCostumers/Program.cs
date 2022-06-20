using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IPCostumers
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Costumer> costumers = new List<Costumer>();
            Regex fName = new Regex(@"[A-Z][a-z]+");
            Regex lName = new Regex(@"[A-Z][a-z]+");

            Regex classAIp = new Regex (@"^([0-9]|[1-9][0-9]|1[0-1][0-9]|12[0-7])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]?)){3}$"); // 0.0.0.0 - 127.255.255.255 (no leading zeros)
            Regex classBIp = new Regex (@"^(12[8-9]|1[3-8][0-9]|19[0-1])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]?)){3}$"); // 128.0.0.0 - 191.255.255.255 (no leading zeros)
            Regex classCIp = new Regex (@"^(19[2-9]|2[0-1][0-9]|22[0-3])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]?)){3}$"); // 192.0.0.0 - 223.255.255.255 (no leading zeros)

            Regex mNumber = new Regex (@"^(\+359)([0-9]){9}$"); // 10 digits

            int classAcount = 0;
            int classBcount = 0;
            int classCcount = 0;

            List<string> classASold = new List<string>();
            List<string> classBSold = new List<string>();
            List<string> classCSold = new List<string>();

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] tokens = input.Split();
                Costumer currCostumer = new Costumer();
                // First name check!
                try
                {
                    
                    if (fName.IsMatch(tokens[0]))
                    {
                        currCostumer.FirstName = tokens[0];
                        
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid first name!");

                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                // Last name check!
                try
                {
                    
                    if (lName.IsMatch(tokens[1]))
                    {
                        currCostumer.LastName = tokens[1];
                        
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid last name!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                // IP address check!
                
                try
                {
                    
                    if (classAIp.IsMatch(tokens[2]))
                    {
                        currCostumer.IpRegex = tokens[2];
                        classAcount++;
                        classASold.Add(currCostumer.IpRegex);
                    }
                    else if (classBIp.IsMatch(tokens[2]))
                    {
                        currCostumer.IpRegex = tokens[2];
                        classBcount++;
                        classBSold.Add(currCostumer.IpRegex);
                    }
                    else if (classCIp.IsMatch(tokens[2]))
                    {
                        currCostumer.IpRegex = tokens[2];
                        classCcount++;
                        classCSold.Add(currCostumer.IpRegex);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid IP input!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                // Mobile number check!
                try
                {
                    if (mNumber.IsMatch(tokens[3]))
                    {
                        currCostumer.MobileNumber = tokens[3];
                        

                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid mobile number!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }

                costumers.Add(currCostumer);

                input = Console.ReadLine();
            }

            string infoCommand = Console.ReadLine();
            while (infoCommand != "Stop")
            {
                try
                {
                    if (infoCommand == "Show IPs")
                    {
                        Console.WriteLine("IPV4 Class A Sold List:");
                        classASold.ForEach(a => Console.WriteLine(a));
                        Console.WriteLine("---------------");
                        Console.WriteLine("IPV4 Class B Sold List:");
                        classBSold.ForEach(b => Console.WriteLine(b));
                        Console.WriteLine("---------------");
                        Console.WriteLine("IPV4 Class C Sold List:");
                        classCSold.ForEach(c => Console.WriteLine(c));
                        Console.WriteLine("***************");


                    }
                    else if (infoCommand == "Show IPs count")
                    {
                        Console.WriteLine($"Class A count - {classAcount} \nClass B count - {classBcount} \nClass C count - {classCcount}");
                    }
                    else if (infoCommand == "Show database")
                    {
                        foreach (var c in costumers)
                        {
                            Console.WriteLine($"{c.FirstName} {c.LastName} {c.MobileNumber} - {c.IpRegex}");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid command input!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
                infoCommand = Console.ReadLine();
            }
            
            

        }
    }
}
