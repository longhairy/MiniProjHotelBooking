using HotelBooking.Core;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Events;

namespace SpecFlowProject1.StepDefinitions
{
  


    [Binding]
public class CreateBookingStepDefinitions
    {
        private readonly BookingManager bookingManager;
        
        DateTime startDate, endDate;
        bool actual;
       // public BookingManager BookingManager { get; set; } = new BookingManager(HotelBooking.Core.IRepository < Booking > bookingRepository, IRepository < Room > roomRepository);

        [Given("the start date is (.*)")]
        public void GivenTheStartDateIs(string  startdate)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

             startDate = DateTime.Parse(startdate);
        }

        [Given("the end date is (.*)")]
        public void GivenTheEndDateIs(string enddate)
        {
            //TODO: implement arrange (precondition) logic

            endDate = DateTime.Parse(enddate);
        }

        [When("the booking created")]
        public void WhenTheBookingCreated()
        {
            //TODO: implement act (action) logic
          
            Booking booking = new Booking();
            booking.StartDate = startDate;
            booking.EndDate = endDate;
            actual= bookingManager.CreateBooking( booking);
           
         
        }

        [Then(@"the result shold be (.*)")]
        public void ThenTheResultShouldBe(bool True)
        {
            //TODO: implement assert (verification) logic

            Assert.Equals(True,actual);
        }




    }
}
