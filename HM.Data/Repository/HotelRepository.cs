using HM.Data.Database;
using HM.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Data.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private HMEntities HMEntities;

        public HotelRepository()
        {
            HMEntities = new HMEntities();
        }

        public List<HM_Hotel> GetHotels()
        {
            return HMEntities.HM_Hotel.OrderBy(x=>x.HotelName).ToList();
        }

        public bool InsertHotel(HM_Hotel hotel)
        {
            bool status = false;
            hotel.CreatedDate = DateTime.Now;
            HMEntities.HM_Hotel.Add(hotel);
            if (HMEntities.SaveChanges() > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
