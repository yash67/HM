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
    public class HotelManager : IHotelManager
    {
        private IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public List<HotelViewModel> GetHotels()
        {
            var hotels = _hotelRepository.GetHotels();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HM_Hotel, HotelViewModel>();
            });

            IMapper mapper = config.CreateMapper();         
            var hotelViewModel = mapper.Map<List<HM_Hotel>, List<HotelViewModel>>(hotels);
            return hotelViewModel;
        }

        public bool InsertHotel(HotelViewModel hotelViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HotelViewModel, HM_Hotel>();
            });
            IMapper mapper = config.CreateMapper();
            var hotel = mapper.Map<HotelViewModel, HM_Hotel>(hotelViewModel);
            return _hotelRepository.InsertHotel(hotel);
        }
    }
}
