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
    [RoutePrefix("api/Hotels")]
    public class HotelController : ApiController
    {
        private IHotelManager _hotelManager;
        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        [Route("GetHotels")]
        [HttpGet]
        public IHttpActionResult GetHotels()
        {
            try
            {
                List<HotelViewModel> hotels = _hotelManager.GetHotels();
                if (hotels.Count == 0 || hotels == null)
                {
                    return Json("No records found");
                }
                return Json(hotels);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        [Route("AddHotels")]
        [HttpPost]
        public IHttpActionResult InsertHotel(HotelViewModel hotelViewModel)
        {
            try
            {
                bool status = _hotelManager.InsertHotel(hotelViewModel);
                return Content(HttpStatusCode.Created, new { message = "Hotel details inserted successfully" });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }
    }
}
