// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akash Kumar Singh"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Day_21_Assignment_Address_Book
{
    class Contact
    {
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }
        public Contact()
        {

        }
        //creating a constructor
        public Contact(string name, string address, string city, string state, string zip, string phoneNo, string email)
        {
            this.name = name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNo = phoneNo;
            this.email = email;
        }             
    }
}
