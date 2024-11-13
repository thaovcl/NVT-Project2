using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K22CNT1_NguyenVanThao_2210900125.Models
{
    public class NVTCartItem
    {
        public int ID { get; set; }
        public String TenTour { get; set; }
        public string HinhAnh { get; set; }
        public int SoNguoiMua { get; set; }
        public float DonGiaMua { get; set; }
        public float ThanhTien { get; set; }

    }
}