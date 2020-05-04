using AutoMapper;
using HM.BusinessEntites.ViewModels;
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
    public class RoomRepository : IRoomRepository
    {
        private HMEntities HMEntities;

        public RoomRepository()
        {
            HMEntities = new HMEntities();
        }

        public List<RoomViewModel> GetRooms(int? hotelId, string city, int? pincode, double? price, string category)
        {
            List<HM_Room> rooms = new List<HM_Room>();
            using (HMEntities)
            {
                var query = from r in HMEntities.HM_Room select r;
                if (hotelId != null)
                {
                    query = query.Where(x => x.HotelId == hotelId);
                }
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(x => x.HM_Hotel.City == city);
                }
                if (pincode!=null)
                {
                    query = query.Where(x => x.HM_Hotel.Pincode == pincode);
                }
                if (!string.IsNullOrEmpty(category))
                {
                    query = query.Where(x => x.HM_RoomCategoryMaster.RoomCategoryType==category);
                }
                if (price != null)
                {
                    query = query.Where(x => x.RoomPrice == price);
                }
                query = query.Include(x => x.HM_Hotel).Include(x => x.HM_RoomCategoryMaster).OrderBy(x => x.RoomPrice);
                rooms = query.ToList();
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HM_Room, RoomViewModel>().ForMember(d => d.HM_Hotel, o => o.MapFrom(s => s.HM_Hotel)).ForMember(d => d.HM_RoomCategoryMaster, o => o.MapFrom(s => s.HM_RoomCategoryMaster));
                cfg.CreateMap<HM_Hotel, HotelViewModel>();
                cfg.CreateMap<HM_RoomCategoryMaster, CategoryViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            List<RoomViewModel> roomViewModels = mapper.Map<List<HM_Room>, List<RoomViewModel>>(rooms);
            return roomViewModels;
        }

        public bool InsertRoom(HM_Room room)
        {
            bool status = false;
            room.CreatedDate = DateTime.Now;
            HMEntities.HM_Room.Add(room);
            if (HMEntities.SaveChanges() > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
