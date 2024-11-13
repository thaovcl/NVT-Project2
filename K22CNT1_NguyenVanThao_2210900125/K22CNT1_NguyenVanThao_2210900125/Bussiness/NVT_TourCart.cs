using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using K22CNT1_NguyenVanThao_2210900125.Models;

namespace K22CNT1_NguyenVanThao_2210900125.Bussiness
{
    public class NVT_TourCart
    {
        public List<NVTCartItem> Items { get; set; }
        public NVT_TourCart()
        {
            Items = new List<NVTCartItem>();
        }

        //Chức năng thêm tour vào giỏ hàng
        public void AddToCart(NVTCartItem item)
        {
            var existingItem = Items.FirstOrDefault(x => x.ID == item.ID);
            if(existingItem != null){
                existingItem.SoNguoiMua += item.SoNguoiMua;
            }
            else
            {
                Items.Add(item);
            }
        }

        //Xoa tour trong giỏ hàng
        public void RemoveCartItem(int id)
        {
            var itemToRemove = Items.FirstOrDefault(x => x.ID == id);
            if(itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        //tính tổng trị giá hóa đơn
        public float GetTongThanhTien()
        {
            return Items.Sum(x => x.SoNguoiMua * x.DonGiaMua);
        }

        //Cập nhật Tour Cart
        public void UpdateFromCart(int id, int qty)
        {
            var exsitingItem = Items.FirstOrDefault(x => x.ID == id);
            if(exsitingItem != null)
            {
                exsitingItem.SoNguoiMua = qty;
            }
        }

    }
}