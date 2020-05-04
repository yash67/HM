using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.BusinessEntites.ViewModels
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string RoomName { get; set; }
        public int RoomCategoryId { get; set; }
        public double RoomPrice { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdateBy { get; set; }
        public HotelViewModel HM_Hotel { get; set; }
        public virtual CategoryViewModel HM_RoomCategoryMaster { get; set; }
    }
}
