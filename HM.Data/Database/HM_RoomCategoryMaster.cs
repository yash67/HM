//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HM.Data.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class HM_RoomCategoryMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HM_RoomCategoryMaster()
        {
            this.HM_Room = new HashSet<HM_Room>();
        }
    
        public int RoomCategoryId { get; set; }
        public string RoomCategoryType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HM_Room> HM_Room { get; set; }
    }
}
