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
        
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        private static int currentCustomerId = 1; // changes when specified
        private static int currentStoreId = 1; // changes when specified
        private static bool resume = true;
        private static readonly DbContextOptions<StoreDatabaseContext> Options = new DbContextOptionsBuilder<StoreDatabaseContext>()
            .UseLoggerFactory(MyLoggerFactory)
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
            catch(Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e);
                DisplayMenu();
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

                while(choice < 1 || choice > 7) // validation
                {
                    Console.WriteLine("!!! Enter an appropriate choice !!!\n");

                    Console.WriteLine("1) Place an order.");
                    Console.WriteLine("2) Add a new Customer.");
                    Console.WriteLine("3) Search for customer.");
                    Console.WriteLine("4) Display order details.");
                    Console.WriteLine("5) Display order history of store.");
                    Console.WriteLine("6) Display order history of customer.");
                    Console.WriteLine("7) Exit application. \n");

                    choice = int.Parse(Console.ReadLine());
                }
                switch (choice)
                {
                    case 1:
                        PlaceOrder(); // place an order - finished
                        break;

                    case 2:
                        AddNewCustomer(); // add new customer - finished
                        break;

                    case 3:
                        SearchForCustomer(); // search for customer - finished
                        break;

                    case 4:
                        DisplayData(choice); // display order details - unfinished
                        break;

                    case 5:
                        DisplayData(choice); // display store's order history - finished
                        break;

                    case 6:
                        DisplayData(choice); // display customer's order history - finished
                        break;

                    case 7:
                        resume = false;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e);
                DisplayMenu();
            }


            
        }

        private static void PlaceOrder()
        {
            try
            {
                using var context = new StoreDatabaseContext(Options); // Get DBContext
                List<Products> products = context.Products.ToList(); //get list of products

                Console.WriteLine("Select product by id");

                foreach (Products x in products)
                { 
                    Console.WriteLine($"Id: {x.ProductId} / Product: {x.ProductName} / Price: ${String.Format("{0:C2}", x.ProductPrice)} \n");
                }


                int choice = int.Parse(Console.ReadLine());

                while (choice < 1 || choice > 3) //validation
                {
                    Console.WriteLine("!!! Enter an appropriate choice !!!\n");

                    foreach (Products x in products)
                    {
                        Console.WriteLine($"Id: {x.ProductId} / Product: {x.ProductName} / Price: ${String.Format("{0:C2}", x.ProductPrice)} \n");
                    }

                    choice = int.Parse(Console.ReadLine());
                }

                switch (choice)
                {
                    case 1:
                        var order = new Orders { CustomerId = currentCustomerId, OrderDate = DateTime.Now, Cost = 200, 
                        StoreId = currentStoreId, OrderInfo = "Phone"};
                        context.Orders.Add(order);
                        context.SaveChanges();
                        break;

                    case 2:
                        var order2 = new Orders { CustomerId = currentCustomerId, OrderDate = DateTime.Now, Cost = 2, 
                        StoreId = currentStoreId, OrderInfo = "Eraser"};
                        context.Orders.Add(order2);
                        context.SaveChanges();
                        break;

                    case 3:
                        var order3 = new Orders { CustomerId = currentCustomerId, OrderDate = DateTime.Now, Cost = 1, 
                        StoreId = currentStoreId, OrderInfo = "Pencil"};
                        context.Orders.Add(order3);
                        context.SaveChanges();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice \n");
                        break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e);
                DisplayMenu();
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
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e);
                DisplayMenu();
            }
        }


        private static void SearchForCustomer()
        {
            try
            {
                Console.WriteLine("1) Search by firstname.");
                Console.WriteLine("2) Search by lastname.");
                Console.WriteLine("3) Search by Id.");
                using var context = new StoreDatabaseContext(Options); // Get DBContext
                List<Customer> customers = context.Customer.ToList(); // Get a list of customers from the Customer DBSet within the DBContext

                int choice = int.Parse(Console.ReadLine());

                while (choice < 1 || choice > 3) //validation
                {
                    Console.WriteLine("!!! Enter an appropriate choice !!!\n");

                    Console.WriteLine("1) Search by firstname.");
                    Console.WriteLine("2) Search by lastname.");
                    Console.WriteLine("3) Search by Id.");

                    choice = int.Parse(Console.ReadLine());
                }

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
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e);
                DisplayMenu();
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
                        List<Orders> orders = context.Orders.ToList();
                        foreach (Orders x in orders)
                        {
                            if (x.StoreId == currentStoreId)
                            {
                                Console.WriteLine($"OrderId: {x.OrderId} / CustomerId: {x.CustomerId} / OrderDate: {x.OrderDate} / " +
                                    $"Cost: {String.Format("{0:C2}", x.Cost)} / StoreId: {x.StoreId}\n");
                            }
                        }
                        break;

                    // display customer's order history
                    case 6:
                        List<Orders> orders2 = context.Orders.ToList();
                        foreach (Orders x in orders2)
                        {
                            if (x.CustomerId == currentCustomerId)
                            {
                                Console.WriteLine($"OrderId: {x.OrderId} / CustomerId: {x.CustomerId} / OrderDate: {x.OrderDate} / " +
                                    $"Cost: {String.Format("{0:C2}", x.Cost)} / StoreId: {x.StoreId}\n");
                            }
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e);
                DisplayMenu();
            } 
        }
    }
}
