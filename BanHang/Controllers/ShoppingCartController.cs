using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHang.Models;

namespace BanHang.Controllers
{
    public class ShoppingCartController : Controller
    {
        ConnectDB db = new ConnectDB();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddtoCart(int id)
        {
            var pro = db.Products.SingleOrDefault(m => m.IdProduct == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        //Hiển thị giỏ hàng
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("ShowCart", "ShoppingCart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        //
        public ActionResult Update_Qt_Cart (FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["Id_product"]);
            //lấy số lượng hiện tại trên form
            int _qt = int.Parse(form["quantity"]);
            cart.Update_Qt_sp(id_pro, _qt);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        // xóa
        public ActionResult RemoveCart( int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_p(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        //
        //Giỏ hàng menu
        public PartialViewResult BagCart()
        {
            //hiển thị tổng số lượng mua
            int _t_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                _t_item = cart.Total_Qt();
            }
            ViewBag.infoCart = _t_item;
            return PartialView("BagCart");
        }

        public ActionResult Shopping_Success()
        {
            return View();
        }
        //checkout
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order _or = new Order();
                _or.OrderDate = DateTime.Now;
                _or.IdUser = int.Parse(form["username"]);
                _or.Note = form["address"];
                db.Orders.Add(_or); //Lưu thông tin
                foreach (var item in cart.Items)
                {
                    OrderDetail _od = new OrderDetail();
                    _od.IdOrder = _or.IdOrder;
                    _od.Product_id = item._sp_product.IdProduct;
                    _od.UnitPrice = item._sp_product.UnitPrice;
                    _od.Quantity = item._sp_quantity;
                    db.OrderDetails.Add(_od);
                }
                db.SaveChanges();
                cart.Clear();
                return RedirectToAction("Shopping_Success", "ShoppingCart");
            }
            catch 
            {

                return Content("Error Checkout.");
            }
        }
    }
}