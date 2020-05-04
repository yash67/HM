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
    [RoutePrefix("api/Rooms")]
    public class RoomController : ApiController
    {
        private IRoomManager _roomManager;
        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [Route("GetRooms")]
        [HttpGet]
        public IHttpActionResult GetRooms(string city = null, int? pincode = null, string category = null, double? hotelId = null, double? price = null)
        {
            int? hid;
            if (hotelId == null)
            {
                hid = null;
            }
            else
            {
                hid = Convert.ToInt32(hotelId);
            }
            try
            {
                List<RoomViewModel> rooms = _roomManager.GetRooms(hid, city, pincode, price, category);
                if (rooms.Count == 0 || rooms == null)
                {
                    return Json("No Records Found");
                }
                return Json(rooms);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }

        [Route("AddRooms")]
        [HttpPost]
        public IHttpActionResult InsertRoom(RoomViewModel roomViewModel)
        {
            try
            {
                bool status = _roomManager.InsertRoom(roomViewModel);
                return Content(HttpStatusCode.Created, new { message = "Room details inserted successfully" });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = e.Message });
            }
        }
    }
}
