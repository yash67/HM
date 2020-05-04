using HM.Data.Database;
using HM.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private HMEntities HMEntities;
        public BookingRepository(HMEntities hMEntities)
        {
            HMEntities = hMEntities;
        }

        public bool BookRoom(HM_Booking booking)
        {
            bool status = false;
            booking.Status = "Optional";
            HMEntities.HM_Booking.Add(booking);
            if (HMEntities.SaveChanges() > 0)
            {
                status = true;
            }
            return status;
        }

        public bool GetRoomAvailability(int roomId, DateTime date)
        {
            bool status = false;
            
            List<HM_Booking> bookings = HMEntities.HM_Booking.Where(x => x.RoomId == roomId && x.BookingDate.Equals(date) && (x.Status == "Optional" || x.Status == "Definitive")).ToList();
            if (bookings.Count > 0)
            {
                status = true;
            }           
            return status;
        }
        public bool UpdateBookingStatus(int bookingId, string status)
        {
            bool updated = false;
           
                HM_Booking booking = HMEntities.HM_Booking.Where(x => x.BookingId == bookingId).FirstOrDefault();
                booking.Status = status;
                HMEntities.Entry(booking).State = EntityState.Modified;
                if (HMEntities.SaveChanges() > 0)
                {
                    updated = true;
                }         
            return updated;
        }

        public bool UpdateBookingDate(int bookingId, DateTime date)
        {
            bool status = false;
            
                HM_Booking booking = HMEntities.HM_Booking.Where(x => x.BookingId == bookingId).FirstOrDefault();
                booking.BookingDate = date;
                HMEntities.Entry(booking).State = EntityState.Modified;
            if (HMEntities.SaveChanges() > 0)
                {
                    status = true;
                }
            
            return status;
        }


        public bool DeleteBooking(int bookingId)
        {
                bool status = false;            
                HM_Booking booking = HMEntities.HM_Booking.Where(x => x.BookingId == bookingId).AsNoTracking().FirstOrDefault();
                booking.Status = "Deleted";
                HMEntities.Entry(booking).State = EntityState.Modified;
                if (HMEntities.SaveChanges() > 0)
                {
                    status = true;
                }
            
            return status;
        }
    }
}
