// Kieran Burns
// Last edit: 23/03/2018
//
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Build_A_Bike_Program;

namespace Class_unit_tests
{
    [TestClass]
    public class UnitTestClass
    {
        Customer testCustomer = new Customer(); 

        [TestMethod]
        public void findBike_Test()
        {
            //Create and add some bikes with different internal values to be searched.
            bool testResult = false;
            Bike testBike1 = new Bike();
            testBike1.Bike_No = 1;
            testBike1.ExtendedWarranty = true;
            

            Bike testBike2 = new Bike();
            testBike2.Bike_No = 2;
            testBike2.ExtendedWarranty = false;

            //Save the test bikes to the test customer.
            testCustomer.Bikes.Add(testBike1);
            testCustomer.Bikes.Add(testBike2);

            //Load in the different bikes using the findBike method.
            Bike callBike1 = testCustomer.findBike(1);
            Bike callBike2 = testCustomer.findBike(2);

            //If the correct bikes are loaded into the class variables they are being attempted to be loaded in to
            //the pass the test, otherwise the test will automatically fail.
            if (callBike1.ExtendedWarranty && !callBike2.ExtendedWarranty)
            {
                testResult = true;
            }


            Assert.IsTrue(testResult);
        }
    }
}
