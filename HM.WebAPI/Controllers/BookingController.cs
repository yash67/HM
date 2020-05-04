using HM.Business.Interface;
using HM.BusinessEntites.ViewModels;
using HotelManagement.WebAPI.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HM.WebAPI.Controllers
{
    [BasicAuth]
    [RoutePrefix("api/Booking")]
    public class BookingController : ApiController
    {
        private IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [Route("BookRooms")]
        [HttpPost]
        public IHttpActionResult BookRoom(BookingViewModel bookingViewModel)
        {
            try
            {
                bool status = _bookingManager.BookRoom(bookingViewModel);
                return Json(new { message = "Room booked for date " + bookingViewModel.BookingDate });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        [Route("UpdateBookingStatus")]
        [HttpPut]
        public IHttpActionResult UpdateBookingStatus(BookingViewModel booking)
        {
            try
            {
                bool updated = _bookingManager.UpdateBookingStatus(booking.BookingId, booking.Status);
                return Json(new { message = "Booking status updated successfully" });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        [Route("CheckAvailability")]
        [HttpGet]
        public IHttpActionResult GetRoomAvailability(int roomId, string date)
        {
            DateTime dateTime = Convert.ToDateTime(date);
            try
            {
                bool status = _bookingManager.GetRoomAvailability(roomId, dateTime);
                return Json(status);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        [Route("UpdateBookingDate")]
        [HttpPut]
        public IHttpActionResult UpdateBookingDate(int bookingId, string date)
        {
            DateTime dateTime = Convert.ToDateTime(date);
            try
            {
                bool status = _bookingManager.UpdateBookingDate(bookingId, dateTime);
                return Json(new { message = "Booking date updated successfully" });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        [Route("DeleteBooking")]
        [HttpDelete]
        public IHttpActionResult DeleteBooking(int bookingId)
        {
            try
            {
                bool status = _bookingManager.DeleteBooking(bookingId);
                return Json(new { message = "Booking details deleted successfully" });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }
    }
}

