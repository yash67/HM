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
    public class RoomManager : IRoomManager
    {
        private IRoomRepository _roomRepository;
        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<RoomViewModel> GetRooms(int? hotelId, string city, int? pincode, double? price, string category)
        {
            List<RoomViewModel> rooms = _roomRepository.GetRooms(hotelId, city, pincode, price, category);
            return rooms;
        }

        public bool InsertRoom(RoomViewModel roomViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomViewModel, HM_Room>();
            });
            IMapper mapper = config.CreateMapper();
            var room = mapper.Map<RoomViewModel, HM_Room>(roomViewModel);
            return _roomRepository.InsertRoom(room);
        }
    }
}
