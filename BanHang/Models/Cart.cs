using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class item_Cart
    {
        public Product _sp_product { get; set; }
        public int _sp_quantity { get; set; }
    }
    //giỏ hàng
    public class Cart
    {
        List<item_Cart> items = new List<item_Cart>();
        //get danh sách item_Cart
        public IEnumerable<item_Cart> Items
        {
            get { return items; }
        }
        //Thêm item vào Cart
        public void Add(Product pr, int quantity = 1)
        {
            var item = items.FirstOrDefault(m => m._sp_product.IdProduct == pr.IdProduct);
            if (item == null)
            {
                items.Add(new item_Cart
                {
                    _sp_product = pr,
                    _sp_quantity = quantity
                });
            }
            else
            {
                item._sp_quantity += quantity;
            }
        }
        //hàm update số lượng sản phẩm
        public void Update_Qt_sp(int id, int quantity)
        {
            var item = items.Find(m => m._sp_product.IdProduct == id);
            if (item != null) //kiểm tra sản phẩm tồn tại
            {
                item._sp_quantity = quantity;
            }
        }
        //tổng đơn hàng
        public double Total_Money()
        {
            var total = items.Sum(m => m._sp_product.UnitPrice * m._sp_quantity);
            return (double)total;
        }
        //Delete sản phẩm odder
        public void Remove_p(int id)
        {
            items.RemoveAll(m => m._sp_product.IdProduct == id);
        }
        //
        //tổng số lượng sp
        public int Total_Qt()
        {
            return items.Sum(m => m._sp_quantity);
        }
        //
        public void Clear()
        {
            items.Clear();//xóa giỏ hàng để thực hiện đơn hàng mới
        }
    }
}