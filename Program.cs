// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akash Kumar Singh"/>
// --------------------------------------------------------------------------------------------------------------------
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace Day_21_Assignment_Address_Book
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Lenovo\source\repos\Day_21_Assignment_Address_Book\Day_21_Assignment_Address_Book\export.csv";
            int choice = 0;
            //Creating a method of class AddressBook
            AddressBook addbook = new AddressBook();
            // Using Do-While Loop to iterate the options give to user.
            do
            {
                //Asking the user choice
                Console.WriteLine("Enter your choice :");
                Console.WriteLine("1. Add Contact.");
                Console.WriteLine("2. View all Contacts.");
                Console.WriteLine("3.Edit existing contacts.");
                Console.WriteLine("4.Remove a contact.");
                Console.WriteLine("5.View AddressBook fora key name.");
                Console.WriteLine("6.Search person by city/state name.");
                Console.WriteLine("7.View persons by city.");
                Console.WriteLine("8.View persons by state");
                Console.WriteLine("9.Print all contacts from text file.");
                Console.WriteLine("10.Exit.");
                choice = Convert.ToInt32(Console.ReadLine());
                //Checking the choice entered by the user and iterating using for loop
                if (choice == 1)
                {
                    //asking for the name of the user
                    Console.WriteLine("Enter your Name : ");
                    string name = Console.ReadLine();
                    //Regex for checking name
                    Regex reg4 = new Regex(@"(^[a-z A-Z]*$)");
                    //if regex is not matching then asking for valid name
                    while (!reg4.IsMatch(name))
                    {
                        Console.WriteLine("Enter a valid name : ");
                        name = Console.ReadLine();
                    }
                    //checking for duplicate entry
                    while (addbook.UC7_CheckForDuplicateEntry(name))
                    {
                        Console.WriteLine("This name already exists in the address book.");
                        Console.WriteLine("Please enter a new name : ");
                        name = Console.ReadLine();
                        while (!reg4.IsMatch(name))
                        {
                            Console.WriteLine("Enter a valid name : ");
                            name = Console.ReadLine();
                        }
                    }
                    //asking for address of the user
                    Console.WriteLine("Enter your address : ");
                    string address = Console.ReadLine();
                    //regex for checking the address field
                    Regex reg5 = new Regex(@"(^[a-z A-Z]*$)");
                    //if regex is not matching then asking for valid address
                    while (!reg5.IsMatch(address))
                    {
                        Console.WriteLine("Enter a valid address : ");
                        address = Console.ReadLine();
                    }
                    //asking to enter city name by the user
                    Console.WriteLine("Enter your city : ");
                    string city = Console.ReadLine();
                    //regex to match city name
                    Regex reg6 = new Regex(@"(^[a-z A-Z]*$)");
                    //if regex is not matching then asking for valid city name
                    while (!reg6.IsMatch(city))
                    {
                        Console.WriteLine("Enter a valid city name : ");
                        city = Console.ReadLine();
                    }
                    //asking to enter state name of the user
                    Console.WriteLine("Enter your state : ");
                    string state = Console.ReadLine();
                    //regex to check the correct state name
                    Regex reg7 = new Regex(@"(^[a-z A-Z]*$)");
                    //if regex is not matching then asking for the correct state name
                    while (!reg7.IsMatch(state))
                    {
                        Console.WriteLine("Enter a valid state name : ");
                        state = Console.ReadLine();
                    }
                    //asking for the Zip code of the user
                    Console.WriteLine("Enter your zip : ");
                    string zip = Console.ReadLine();
                    //regex to match the correct zip code format
                    Regex reg = new Regex(@"(^[0-9]{6}$)");
                    //if zip code is not matching then asking for valid zip code
                    while (!reg.IsMatch(zip))
                    {
                        Console.WriteLine("Enter a valid zip code : ");
                        zip = Console.ReadLine();
                    }
                    //asking for the contact number of the user
                    Console.WriteLine("Enter your contact no. : ");
                    string contactNo = Console.ReadLine();
                    //regex code to match the correct contact number format
                    Regex reg1 = new Regex(@"(^[7-9]{1}[0-9]{9}$)");
                    //if phone number doesn't matches then asking for valid number
                    while (!reg1.IsMatch(contactNo))
                    {
                        Console.WriteLine("Enter a a valid mobile number : ");
                        contactNo = Console.ReadLine();
                    }
                    //asking for the email id of the user
                    Console.WriteLine("Enter your email : ");
                    string mailID = Console.ReadLine();
                    //regex code to match the email id 
                    Regex reg2 = new Regex("^[0-9A-Za-z]+([+-_.][a-zA-Z]+)*[@][0-9A-Za-z]+[.][0-9A-Za-z]{2,3}$");
                    //if the email id not matches with the regex pattern then asking for valid email id
                    while (!reg2.IsMatch(mailID))
                    {
                        Console.WriteLine("Enter a a valid emailID : ");
                        mailID = Console.ReadLine();
                    }
                    //asking for the keyname to be saved in the address book
                    Console.WriteLine("Enter the key name to be saved in the address book : ");
                    string keyname = Console.ReadLine();
                    //regex pattern to match the keyname
                    Regex reg3 = new Regex("^[A-Z a-z]*$");
                    //if keyname doesn't matches then asking for a valid keyname
                    while (!reg3.IsMatch(keyname))
                    {
                        Console.WriteLine("Enter a valid name : ");
                        keyname = Console.ReadLine();
                    }
                    //storing all the data entered by the user in the constructor

                    Contact contact = new Contact(name.ToUpper(), address.ToUpper(), city.ToUpper(), state.ToUpper(), zip, contactNo, mailID);
                    //passing the details into the method AddAddress
                    addbook.AddAddress(keyname, contact);                                                    
                }
                //second choice iteration of view all contacts
                else if (choice == 2)
                {
                    Console.WriteLine("1.Sort by Name");
                    Console.WriteLine("2.Sort by City");
                    Console.WriteLine("3.Sort by State");
                    Console.WriteLine("4.Sort by Zip");
                    int input = Convert.ToInt32(Console.ReadLine());
                    //creating an object of ViewAddressBook and storing in list li
                    List<Contact> li = addbook.ViewAddressBook(input);
                    //checking if the list is empty or not
                    if (li.Count == 0)
                    {
                        Console.WriteLine("The address book is empty.");
                    }
                    else
                    {
                        //iterating each data of the contact list using foreach loop
                        foreach (Contact cl in li)
                        {
                            Console.WriteLine("Name : " + cl.name);
                            Console.WriteLine("Address : " + cl.address);
                            Console.WriteLine("City : " + cl.city);
                            Console.WriteLine("State : " + cl.state);
                            Console.WriteLine("zip : " + cl.zip);
                            Console.WriteLine("Contact No. : " + cl.phoneNo);
                            Console.WriteLine("Email ID : " + cl.email);
                        }
                    }
                }
                //iterating third choice to edit existing contact
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the name :");
                    string ename = Console.ReadLine();
                    Console.WriteLine("Enter the new number for " + ename);
                    string newnumber = Console.ReadLine();
                    addbook.EditNumber(ename, newnumber);
                }
                //iterating fourth choice to delete contact
                else if (choice == 4)
                {
                    Console.WriteLine("Enter the name :");
                    string rname = Console.ReadLine();
                    addbook.RemoveContact(rname);
                }
                //iterating fifth choice to view address book by a key name
                else if (choice == 5)
                {
                    Console.WriteLine("Enter the key name : ");
                    string kname = Console.ReadLine();
                    //adding the keyname 
                    Contact cc = addbook.ViewByKeyName(kname);
                    if (cc == null)
                    {
                        Console.WriteLine("No such key name found!!!");
                    }
                    else
                    {
                        Console.WriteLine("Name : " + cc.name);
                        Console.WriteLine("Address : " + cc.address);
                        Console.WriteLine("City : " + cc.city);
                        Console.WriteLine("State : " + cc.state);
                        Console.WriteLine("zip : " + cc.zip);
                        Console.WriteLine("Contact No. : " + cc.phoneNo);
                        Console.WriteLine("Email ID : " + cc.email);
                    }
                }
                //iterating sixth choice to search people by city or state
                else if (choice == 6)
                {
                    Console.WriteLine("Enter the name of the city/state : ");
                    string location = Console.ReadLine();
                    //calling the method UC8_SearchPeopleByCityOrState() and adding the location into the list li
                    List<Contact> li = addbook.UC8_SearchPeopleByCityOrState(location);
                    //iterating the list to fetch the contact details when the list count is not empty
                    if (li.Count != 0)
                    {
                        Console.WriteLine("There are " + li.Count + " contacts with location " + location);
                        foreach (Contact cc in li)
                        {
                            Console.WriteLine("Name : " + cc.name + "  Address : " + cc.address + "  ZIP : " + cc.zip + "  Contact No : " + cc.phoneNo + "  EmailID : " + cc.email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No contact found!!!");
                    }
                }
                //UC9- View persons by city or state
                else if (choice == 7)
                {
                    addbook.AddressByCity();
                }
                else if (choice == 8)
                {
                    addbook.AddressByState();
                }
               // Ability to Read / Write the address book with person's contact as CSV file
                else if (choice == 9)
                {
                    if (File.Exists(path))
                        
                    {
                        List<Contact> li = addbook.ViewAddressBook(1);
                        // Writing into CSV file
                        using (var writer = new StreamWriter(path))
                        using (var csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csvwriter.WriteRecords(li);
                        }
                    }
                    // Reading all text from the file
                    addbook.ReadAllText();
                }
                else
                {
                    break;
                }
            } while (choice != 10);
        }
    }
}