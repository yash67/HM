using HM.BusinessEntites.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Business.Interface
{
    public interface IHotelManager
    {
        List<HotelViewModel> GetHotels();
        bool InsertHotel(HotelViewModel hotelViewModel);
    }
}
