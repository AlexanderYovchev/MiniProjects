using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IPCustomers
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private string ipRegex;
        private string mobileNumber;
        

        public string FirstName { get => this.firstName ; set { this.firstName = value; } }

        public string LastName { get => this.lastName; set { this.lastName = value; } }

        public string IpRegex { get => this.ipRegex; set { this.ipRegex = value; } }

        public string MobileNumber { get => this.mobileNumber; set { this.mobileNumber = value; } }


    }
}
