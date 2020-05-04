using HM.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Data.Interface
{
    public interface IBookingRepository
    {
        bool GetRoomAvailability(int roomId, DateTime date);
        bool BookRoom(HM_Booking booking);
        bool UpdateBookingDate(int bookingId, DateTime date);
        bool UpdateBookingStatus(int bookingId, string status);
        bool DeleteBooking(int bookingId);
    }
}
