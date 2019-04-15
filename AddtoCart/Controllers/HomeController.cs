using AddtoCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddtoCart.Controllers
{
    public class HomeController : Controller
    {
        ecommerceEntities db = new ecommerceEntities();
        public ActionResult Index()
        {
            Session["u_id"] = 1;
            if (TempData["cart"] != null)
            {
                float x = 0;
                List<cart> adcart2 = TempData["cart"] as List<cart>;
                foreach (var item in adcart2)
                {
                    x += item.bill;
                }
                TempData["total"] = x;

            }
          
            TempData.Keep();
            return View(db.TBL_PRODUCT.OrderByDescending(x=>x.PROD_ID).ToList());
        }

         [HttpGet]
        public ActionResult addToCart1(int? id)
        {
            TBL_PRODUCT p = db.TBL_PRODUCT.Where(x => x.PROD_ID == id).SingleOrDefault();
            return View(p);
        }

        List<cart> adcart = new List<cart>();
        [HttpPost]
        public ActionResult addToCart1(TBL_PRODUCT pl,string qty,int id)
        {
            TBL_PRODUCT p = db.TBL_PRODUCT.Where(x => x.PROD_ID == id).SingleOrDefault();
            cart c = new cart();
            c.productid = p.PROD_ID;
            c.productname = p.PROD_NAME;
            c.price = (float)p.PROD_PRICE;
            c.qty = Convert.ToInt32(qty);
            c.bill = c.price * c.qty;


            if (TempData["cart"] == null)
            {
                adcart.Add(c);
                TempData["cart"] = adcart;
            }

            else {

                List<cart> adcart2 = TempData["cart"] as List<cart>;
                int flag = 0;
                foreach (var item in adcart2)
                {
                     if (item.productid == c.productid)
                     {
                        item.qty += c.qty;
                        item.bill += c.bill;
                        flag = 1;
                     }
                }

                if (flag == 0)
                    {
                        adcart2.Add(c);
                        //here item is new it will append to list   
                    }

                TempData["cart"] = adcart2;
           }

            TempData.Keep();
            return RedirectToAction("Index");

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult checkOut()
        {
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public ActionResult checkOut(TBL_ORDER O)
        {
            List<cart> adcart = TempData["cart"] as List<cart>;
            TBL_INVOICE i = new TBL_INVOICE();
            i.INV_FK_USR = Convert.ToInt32(Session["u_id"].ToString());
            i.INV_DATE = System.DateTime.Now;
            i.INV_TOTALIBILL = (float)TempData["total"];
            db.TBL_INVOICE.Add(i);
            db.SaveChanges();

            foreach (var item in adcart)
            {
                TBL_ORDER od = new TBL_ORDER();
                od.O_FK_PROD = item.productid;
                od.O_FK_INV = i.INV_ID;
                od.O_DATE = System.DateTime.Now;
                od.O_QTY = item.qty;
                od.O_UNITPRICE = (int)item.price;
                od.O_BILL = item.bill;

                db.TBL_ORDER.Add(od);
                db.SaveChanges();
                
            }
            TempData.Remove("total");
            TempData.Remove("cart");

            TempData["msg"] = "Transaction completed...";
            TempData.Keep();
            return RedirectToAction("Index");
        }

        public ActionResult remove(int? id)
        {
            List<cart> adcart2 = TempData["cart"] as List<cart>;
            cart c = adcart2.Where(x => x.productid == id).SingleOrDefault();
            adcart2.Remove(c);
            float h = 0;
            foreach (var item in adcart2)
            {
                h += item.bill;
            }

            TempData["total"] = h;

            return RedirectToAction("checkOut");
        }

    }
}