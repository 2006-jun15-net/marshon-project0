using System;
using Xunit;
using DataAccess.Model;

namespace StoreApplication.Test
{
    public class UnitTest1
    {
        Customer customer = new Customer();
        [Fact]
        public void TestCustomerName()
        {
            //arrange

            string testString1 = "Billy";
            string testString2 = "Bob";
            //act
            customer.Firstname = testString1;
            customer.Lastname = testString2;


            //assert
            Assert.Equal(testString1, customer.Firstname);
            Assert.Equal(testString2, customer.Lastname);

        }

    }
}
