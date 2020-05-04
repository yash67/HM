using HM.BusinessEntites.ViewModels;
using HM.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Data.Interface
{
    public interface IRoomRepository
    {
        bool InsertRoom(HM_Room room);
        List<RoomViewModel> GetRooms(int? hotelId, string city, int? pincode, double? price, string category);
    }
}
