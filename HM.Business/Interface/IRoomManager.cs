using HM.BusinessEntites.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Business.Interface
{
    public interface IRoomManager
    {
        bool InsertRoom(RoomViewModel roomViewModel);
        List<RoomViewModel> GetRooms(int? hotelId, string city, int? pincode, double? price, string category);

    }
}
