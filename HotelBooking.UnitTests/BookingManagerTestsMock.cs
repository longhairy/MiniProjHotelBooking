using System;
using HotelBooking.Core;
using HotelBooking.UnitTests.Fakes;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace HotelBooking.UnitTests
{
    public class BookingManagerTestsMock
    {
        private IBookingManager bookingManager;

        public BookingManagerTestsMock(){
            DateTime start = DateTime.Today.AddDays(4);
            DateTime end = DateTime.Today.AddDays(18);
            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            var bookings = new List<Booking>
            {
                new Booking {Id=1, CustomerId=1, StartDate=start, EndDate=end, RoomId=1, IsActive = true},
                new Booking {Id=2, CustomerId=2, StartDate=start, EndDate=end, RoomId=2, IsActive = true}
            };
            bookingRepository.Setup(x => x.GetAll()).Returns(bookings);

            var rooms = new List<Room>
            {
                new Room { Id=1, Description="A" },
                new Room { Id=2, Description="B" },
            };
            roomRepository.Setup(x => x.GetAll()).Returns(rooms);


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

        [Fact]
        public void FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne()
        {
            // Arrange
            DateTime date = DateTime.Today.AddDays(1);
            // Act
            int roomId = bookingManager.FindAvailableRoom(date, date);
            // Assert
            Assert.NotEqual(-1, roomId);
        }
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
