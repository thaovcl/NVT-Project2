using K22CNT1_NguyenVanThao_2210900125.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K22CNT1_NguyenVanThao_2210900125.ViewModel
{
    public class OrderHistoryViewModel
    {
        public HOA_DON HoaDon { get; set; }
        public List<CT_HOA_DON> ChiTietHoaDon { get; set; }
    }
}