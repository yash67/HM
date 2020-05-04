using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.BusinessEntites.ViewModels
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public System.DateTime BookingDate { get; set; }
        public string Status { get; set; }

    }
}
