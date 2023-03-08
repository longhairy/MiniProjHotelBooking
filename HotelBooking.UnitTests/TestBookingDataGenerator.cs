using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.UnitTests
{
    public class TestBookingDataGenerator : IEnumerable<object[]>
    {
        static DateTime BeforeToday = DateTime.Today.AddDays(-1);
        static DateTime AfterTodayBeforeFullyBooked = DateTime.Today.AddDays(3);
        static DateTime DateWhenFullyBooked=DateTime.Today.AddDays(10);
        static DateTime AfterFullyBooked = DateTime.Today.AddDays(21);

        private readonly List<object[]> _data = new List<object[]>();
        //{
        //    new object[] { BeforeToday,BeforeToday,-1},//case 1
        //    new object[] { BeforeToday,AfterTodayBeforeFullyBooked,-1},//case 2
        //    new object[] { AfterTodayBeforeFullyBooked, AfterTodayBeforeFullyBooked, 1},//case 3
        //    new object[] { AfterTodayBeforeFullyBooked,AfterFullyBooked,-1},//case 4
        //    new object[] { AfterFullyBooked, AfterFullyBooked, 1},//case 5
        //    new object[] { AfterTodayBeforeFullyBooked, DateWhenFullyBooked, -1},//case 6
        //    new object[] { DateWhenFullyBooked, DateWhenFullyBooked, -1},//case 7
        //    new object[] { DateWhenFullyBooked, AfterFullyBooked, -1}//case 8

        //};

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static IEnumerable<object[]> GetSuccessData()
        {
            var data = new List<object[]>
            {
                new object[] { AfterTodayBeforeFullyBooked, AfterTodayBeforeFullyBooked},//case 3
                new object[] { AfterFullyBooked, AfterFullyBooked},//case 5
               
            };
            return data;
        }
        public static IEnumerable<object[]> GetFailureData()
        {
            var data = new List<object[]>
            {
                new object[] { AfterTodayBeforeFullyBooked,AfterFullyBooked},//case 4
                new object[] { AfterTodayBeforeFullyBooked, DateWhenFullyBooked},//case 6
                new object[] { DateWhenFullyBooked, DateWhenFullyBooked},//case 7
                new object[] { DateWhenFullyBooked, AfterFullyBooked}//case 8

            };
            return data;
        }
        public static IEnumerable<object[]> GetExceptionData()
        {
            var data = new List<object[]>
            {
                new object[] { BeforeToday,BeforeToday},//case 1
                new object[] { BeforeToday,AfterTodayBeforeFullyBooked}//case 2

            };
            return data;
        }
    }
}
