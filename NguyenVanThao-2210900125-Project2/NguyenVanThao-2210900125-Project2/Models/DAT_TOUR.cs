//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NguyenVanThao_2210900125_Project2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DAT_TOUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DAT_TOUR()
        {
            this.HOA_DON = new HashSet<HOA_DON>();
        }
    
        public int Ma_dat_tour { get; set; }
        public Nullable<int> Ma_tour { get; set; }
        public Nullable<int> Ma_KH { get; set; }
        public Nullable<int> So_luong { get; set; }
        public Nullable<System.DateTime> Ngay_dat { get; set; }
        public Nullable<byte> Trang_thai { get; set; }
    
        public virtual KHACH_HANG KHACH_HANG { get; set; }
        public virtual TOUR TOUR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOA_DON> HOA_DON { get; set; }
    }
}