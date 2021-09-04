using CadInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //Creating Instance of Invoice Generator  For Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            //Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            //Asserting Values
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            //Creating Instance of Invoice Generator  For Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Generating Summary for Rides
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            //Asserting Values
            Assert.AreEqual(expectedSummary, invoiceSummary);
        }
        [Test]
        public void GivenRidesShouldReturnPartsOfInvoiceSummary()
        {
            //Creating Instance of Invoice Generator  For Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Generating Summary for Rides
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);

            //Asserting Values
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenUserIdUsingInvoivceServiceShouldReturnInvoiceSummary()
        {
            //Creating Instance of Invoice Generator  For Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Generating Summary for Rides For Particular UserId
            invoiceGenerator.AddRides("2000", rides);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("2000");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, "2000");

            //Asserting Values
            Assert.AreEqual(expectedSummary, summary);
        }
    }
}