using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables.Medicine;

namespace WebApplication4.Controllers.TablesControllers
{
    public class MedicineController : Controller
    {
        // GET: Medicine
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            Session["u_id"] = 1;
            var Product_count = db.tbl_product.Count();
            if (TempData["cart"] != null)
            {
                float x = 0;
                List<cart> li2 = TempData["cart"] as List<cart>;
                foreach (var item in li2)
                {
                    x += item.bill;

                }

                TempData["total"] = x;
               
            }
            TempData["NbMed"] = Product_count;
            TempData.Keep();
            return View(db.tbl_product.OrderByDescending(x => x.pro_id).ToList());
        }
            public ActionResult AddToCart(int? Id)
            {

                tbl_product p = db.tbl_product.Where(x => x.pro_id == Id).SingleOrDefault();
                return View(p);
            }

            List<cart> li = new List<cart>();
        [HttpPost]
        public ActionResult AddToCart(tbl_product pi, string qty, int Id)
        {
            tbl_product p = db.tbl_product.Where(x => x.pro_id == Id).SingleOrDefault();
            var ConsultationID = (int)Session["ConsultationID"];
            cart c = new cart();
            c.productid = p.pro_id;
            //c.price = (float)p.pro_price;
            c.qty = Convert.ToInt32(qty);
            c.bill = c.qty;
            c.productname = p.pro_name;
            c.ConsultationID = ConsultationID;
            if (TempData["cart"] == null)
            {
                li.Add(c);
                TempData["cart"] = li;

            }
            else
            {
                List<cart> li2 = TempData["cart"] as List<cart>;
                //li2.Add(c);
                //TempData["cart"] = li2;
                int flag = 0;
                foreach(var item in li2)
                {
                    if(item.productid==c.productid)
                    {
                        item.qty += c.qty;
                        item.bill += c.bill;
                        flag = 1;
                    }
                }
                if(flag == 0)
                {
                    li2.Add(c);
                }
                TempData["cart"] = li2;
            }

            TempData.Keep();

            return RedirectToAction("Index");
        }

        public ActionResult checkout()
        {
            TempData.Keep();


            return View();
        }

        public ActionResult check()
        {
            List<cart> li = TempData["cart"] as List<cart>;
            TempData.Keep();
            ViewBag.Message = "Your Contact Message";
            return View();
        }
        [HttpPost] 
        public ActionResult checkout(tbl_order order)
        {
            List<cart> li = TempData["cart"] as List<cart>;
            var ConsultationID = (int)Session["ConsultationID"];
            tbl_invoice iv = new tbl_invoice();
            //iv.in_fk_user = Convert.ToInt32["u_id"].toString();
            iv.in_date = System.DateTime.Now;
            iv.in_totalbill = Convert.ToInt32(TempData["total"]);
            iv.ConsultationID = ConsultationID;
            db.tbl_invoice.Add(iv);

            db.SaveChanges();
            foreach (var item in li)
            {
                tbl_order od = new tbl_order();
                od.o_fk_pro = item.productid;
                od.o_fk_invoice = iv.in_id;
                od.o_date = System.DateTime.Now;
                od.o_qty = item.qty;
                od.o_unitprice = (int)item.price;
                od.o_bill = item.bill;
                od.ConsultationID = ConsultationID;
                db.tbl_order.Add(od);
                db.SaveChanges();
            }

            TempData.Remove("total");
            TempData.Remove("cart");

            TempData["msg"] = "Translation Completed";
            TempData.Keep();
            return RedirectToAction("Index");
        }

      public ActionResult remove(int? id)
        {
            List<cart> li2 = TempData["cart"] as List<cart>;
            cart c = li2.Where(x => x.productid == id).SingleOrDefault();
            li2.Remove(c);
            float h = 0;
            foreach(var item in li2)
            {
                h += item.bill;
            }
            TempData["total"] = h;
            return RedirectToAction("checkout");
        }

       

        
    }
}