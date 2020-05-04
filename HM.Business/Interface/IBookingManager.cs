using HM.BusinessEntites.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Business.Interface
{
    public interface IBookingManager
    {
        bool BookRoom(BookingViewModel bookingViewModel);
        bool UpdateBookingStatus(int bookingId, string status);
        bool GetRoomAvailability(int roomId, DateTime date);
        bool UpdateBookingDate(int bookingId, DateTime date);
        bool DeleteBooking(int bookingId);
    }
}
