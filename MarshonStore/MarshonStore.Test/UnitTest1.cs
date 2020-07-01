using System;
using Xunit;
using MarshonStore.Library.Model;

namespace MarshonStore.Test
{
    public class UnitTest1
    {
        Customer customer = new Customer();
        [Fact]
        public void ProperNameStorage()
        {
            //arrange

            string testString = "Billy";
            string testString2 = "Bob";
            //act
            customer.Firstname = testString;
            customer.Lastname = testString;


            //assert
            Assert.Equal(testString, customer.Firstname);
            Assert.Equal(testString, customer.Lastname);

        }
    }
}
