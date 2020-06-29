using System;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Model;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace StoreApplication
{
    class Program
    {
        /** Using Logger later after reading more dof microsoft docs
         * 
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        **/

        private static bool resume = true;
        private static readonly DbContextOptions<StoreDatabaseContext> Options = new DbContextOptionsBuilder<StoreDatabaseContext>()
            //.UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome To Marshon's Store Application!\n");

                while (resume)
                {
                    DisplayMenu();
                }

                Console.WriteLine("Goodbye :)!");
            }
            catch(Exception)
            {
                // Handle Exception Here
            }
        }

        private static void DisplayMenu()
        {
            try
            {
                Console.WriteLine("1) Place an order.");
                Console.WriteLine("2) Add a new Customer.");
                Console.WriteLine("3) Search for customer.");
                Console.WriteLine("4) Display order details.");
                Console.WriteLine("5) Display order history of store.");
                Console.WriteLine("6) Display order history of customer.");
                Console.WriteLine("7) Exit application. \n");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PlaceOrder(); // place an order - unfinished
                        break;

                    case 2:
                        AddNewCustomer(); // add new customer - finished
                        break;

                    case 3:
                        SearchForCustomer(); // search for customer - functional
                        break;

                    case 4:
                        DisplayData(choice); // display order details - unfinished
                        break;

                    case 5:
                        DisplayData(choice); // display store's order history - unfinished
                        break;

                    case 6:
                        DisplayData(choice); // display customer's order history - unfinished
                        break;

                    case 7:
                        resume = false;
                        break;
                }
            }
            catch (Exception)
            {
                // Handle Exception Here
            }


            
        }

        private static void PlaceOrder()
        {
            try
            {
                
            }
            catch (Exception)
            {
                // Handle Exception Here
            }
        }

        private static void AddNewCustomer()
        {
            try
            {
                Console.WriteLine("Enter first name");
                var firstname = Console.ReadLine();
                Console.WriteLine("Enter last name");
                var lastname = Console.ReadLine();

                using var context = new StoreDatabaseContext(Options);

                var customer = new Customer { Firstname = firstname, Lastname = lastname };
                context.Customer.Add(customer);
                context.SaveChanges();
            }
            catch (Exception)
            {
                // Handle Exception Here
            }
        }


        private static void SearchForCustomer()
        {
            try
            {
                Console.WriteLine("1) Search by firstname.");
                Console.WriteLine("2) Search by lastname.");
                Console.WriteLine("3) Search by Id.");
                using var context = new StoreDatabaseContext(Options);
                List<Customer> customers = context.Customer.ToList();

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter first name: ");
                        string firstname = Console.ReadLine();

                        foreach (Customer x in customers)
                        {
                            if (x.Firstname == firstname)
                            {
                                Console.WriteLine($"Id: {x.CustomerId} / Firstname: {x.Firstname} / Lastname: {x.Lastname} \n");
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter last name: ");
                        string lastname = Console.ReadLine();

                        foreach (Customer x in customers)
                        {
                            if (x.Lastname == lastname)
                            {
                                Console.WriteLine($"Id: {x.CustomerId} / Firstname: {x.Firstname} / Lastname: {x.Lastname} \n");
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter customer Id: ");
                        int id = int.Parse(Console.ReadLine());

                        foreach (Customer x in customers)
                        {
                            if (x.CustomerId == id)
                            {
                                Console.WriteLine($"Id: {x.CustomerId} / Firstname: {x.Firstname} / Lastname: {x.Lastname} \n");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Choice \n");
                        break;
                }
            }
            catch (Exception)
            {
                // Handle Exception Here
            }

            /**
            Console.WriteLine("Enter last name: ");
            string lastname = Console.ReadLine();
            List<Customer> customers2 = context.Customer
                .Where(e => e.Lastname == lastname)
                .ToList();
            **/
        }


        private static void DisplayData(int choice)
        {
            try
            {
                using var context = new StoreDatabaseContext(Options);

                switch (choice)
                {
                    //display order details
                    case 4:
                        break;

                    // display store's order history
                    case 5:
                        break;

                    // display customer's order history
                    case 6:
                        break;
                }
            }
            catch (Exception)
            {
                // Handle Exception Here
            } 
        }
    }
}
