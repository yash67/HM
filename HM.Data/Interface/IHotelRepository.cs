using HM.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Data.Interface
{
    public interface IHotelRepository
    {
        List<HM_Hotel> GetHotels();
        bool InsertHotel(HM_Hotel hotel);
    }
}