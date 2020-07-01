using System;
using MarshonStore.DataAccess.Model;
using MarshonStore.DataAccess.Repositories;
using MarshonStore.Library.Model;
using MarshonStore.Library.RepositoryInterfaces;
using System.Collections.Generic;

namespace MarshonStore
{
    class Program
    {

        //static CustomerRepository cr = new CustomerRepository();
        private static bool resume = true;
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
            catch (Exception)
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
                        //PlaceOrder(); // place an order - unfinished
                        break;

                    case 2:
                        //AddNewCustomer(); // add new customer - finished
                        break;

                    case 3:
                        //SearchForCustomer(); // search for customer - functional
                        break;

                    case 4:
                        //DisplayData(choice); // display order details - unfinished
                        break;

                    case 5:
                        //DisplayData(choice); // display store's order history - unfinished
                        break;

                    case 6:
                        //DisplayData(choice); // display customer's order history - unfinished
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


        /**
        private static void SearchForCustomer()
        {
            string input;
            Console.WriteLine("Enter first name: ");
            input = Console.ReadLine();
            List<Customer> custList = (List<Customer>)custRepository.GetCustomerByFirstName(input);

            foreach(Customer x in custList)
            {
                Console.WriteLine($"Id: {x.CustomerId} / Firstname: {x.Firstname} / Lastname: {x.Lastname} \n");
            }
        }
        **/


    }
}
