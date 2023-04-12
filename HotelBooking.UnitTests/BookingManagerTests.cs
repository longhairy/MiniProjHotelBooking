using System;
using HotelBooking.Core;
using HotelBooking.Infrastructure.Repositories;
using HotelBooking.UnitTests.Fakes;
using Xunit;

namespace HotelBooking.UnitTests
{
    public class BookingManagerTests
    {
        private IBookingManager bookingManager;
        private readonly IRepository<Booking> bookingRepository;
        public BookingManagerTests(){
            DateTime start = DateTime.Today.AddDays(4);
            DateTime end = DateTime.Today.AddDays(18);
            IRepository<Booking> bookingRepository = new FakeBookingRepository(start, end);
            IRepository<Room> roomRepository = new FakeRoomRepository();
            bookingManager = new BookingManager(bookingRepository, roomRepository);
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
        //[Fact]
        //public void CreateBooking_ReturnBoolean()
        //{
        //    // Arrange
        //    Booking booking = new Booking();

        //    int roomId = bookingManager.FindAvailableRoom(booking.StartDate, booking.EndDate);


        //    // Act 
        //    booking.RoomId = roomId;
        //    booking.IsActive = true;
        //    bookingRepository.Add(booking);
        //    //Test af commit
        //    //test
        //    // Assert
        //    Assert.NotEqual(-1,booking.RoomId);

        //}
    }
}
