using AutoMapper;
using HM.Business.Interface;
using HM.BusinessEntites.ViewModels;
using HM.Data.Database;
using HM.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Business.Manager
{
    public class BookingManager : IBookingManager
    {
        private IBookingRepository _bookingRepository; 

        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public bool BookRoom(BookingViewModel bookingViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookingViewModel, HM_Booking>();
            });
            IMapper mapper = config.CreateMapper();
            var booking = mapper.Map<BookingViewModel, HM_Booking>(bookingViewModel);
            return _bookingRepository.BookRoom(booking);
        }

        public bool DeleteBooking(int bookingId)
        {
            bool result = _bookingRepository.DeleteBooking(bookingId);
            return result;
       
        }

        public bool GetRoomAvailability(int roomId, DateTime date)
        {
            bool result = _bookingRepository.GetRoomAvailability(roomId, date);
            return result;
        }

        public bool UpdateBookingDate(int bookingId, DateTime date)
        {
            bool result = _bookingRepository.UpdateBookingDate(bookingId, date);
            return result;
        }

        public bool UpdateBookingStatus(int bookingId, string status)
        {
            bool result = _bookingRepository.UpdateBookingStatus(bookingId, status);
            return result;
        }

        
    }
}
