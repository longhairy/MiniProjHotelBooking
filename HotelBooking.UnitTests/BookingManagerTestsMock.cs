using System;
using HotelBooking.Core;
using HotelBooking.UnitTests.Fakes;
using Xunit;
using Moq;

namespace HotelBooking.UnitTests
{
    public class BookingManagerTestsMock
    {
        private IBookingManager bookingManager;

        public BookingManagerTestsMock(){
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);
            Mock<IRepository<Booking>> bookingRepository = new Mock< IRepository < Booking >>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();
            bookingManager = new BookingManager(bookingRepository.Object, roomRepository.Object);
        }

        [Fact]
        public void FindAvailableRoom_StartDateNotInTheFuture_ThrowsArgumentException()
        {
            // Arrange
            DateTime date = DateTime.Today;

            // Act
            Action act = () => bookingManager.FindAvailableRoom(date, date);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        //[Fact]
        //public void FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne()
        //{
        //    // Arrange
        //    DateTime date = DateTime.Today.AddDays(1);
        //    // Act
        //    int roomId = bookingManager.FindAvailableRoom(date, date);
        //    // Assert
        //    Assert.NotEqual(-1, roomId);
        //}
        [Fact]
        public void FindAvailableRoom_RoomNotAvailable_RoomIdMinusOne()//testcase 7
        {
            // Arrange
            DateTime startDate = DateTime.Today.AddDays(10); 
            DateTime endDate = DateTime.Today.AddDays(12); 


            // Act 
            int roomId1 = bookingManager.FindAvailableRoom(startDate, endDate);
            //Test af commit
            //test
            // Assert
            Assert.Equal(-1, roomId1);

        }
    }
}
