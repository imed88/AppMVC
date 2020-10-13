using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;

namespace WebApplication4.Controllers.TablesControllers
{
    public class CheckOutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CheckOut
        public ActionResult Index()
        {
          
                ViewBag.Cart = db.MedShoppingCartDatas.ToList<MedShoppingCartData>();
                return View();
           
        }

        public JsonResult QuanityChange(int type, int pId)
        {
           
            MedShoppingCartData product = db.MedShoppingCartDatas.FirstOrDefault(p => p.PID == pId);
            if (product == null)
            {
                return Json(new { d = "0" });
            }

            Medicament actualProduct = db.Medicaments.FirstOrDefault(p => p.PID == pId);
            int quantity;
            // if type 0, decrease quantity
            // if type 1, increase quanity
            switch (type)
            {
                case 0:
                    product.Quantity--;
                    actualProduct.UnitsInStock++;
                    break;
                case 1:
                    product.Quantity++;
                    actualProduct.UnitsInStock--;
                    break;
                case -1:
                    actualProduct.UnitsInStock += product.Quantity;
                    product.Quantity = 0;
                    break;
                default:
                    return Json(new { d = "0" });
            }

            if (product.Quantity == 0)
            {
                db.MedShoppingCartDatas.Remove(product);
                quantity = 0;
            }
            else
            {
                quantity = product.Quantity;
            }

            db.SaveChanges();
            return Json(new { d = quantity });
        }

        [HttpGet]
        public JsonResult UpdateTotal()
        {
            decimal total;
            try
            {

                total = db.MedShoppingCartDatas.Select(p => p.UnitPrice * p.Quantity).Sum();
            }
            catch (Exception) { total = 0; }

            return Json(new { d = String.Format("{0:c}", total) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Clear()
        {
            try
            {
                List<MedShoppingCartData> carts = db.MedShoppingCartDatas.ToList();
                carts.ForEach(a => {
                    Medicament product = db.Medicaments.FirstOrDefault(p => p.PID == a.PID);
                    product.UnitsInStock += a.Quantity;
                });
                db.MedShoppingCartDatas.RemoveRange(carts);
                db.SaveChanges();
            }
            catch (Exception) { }
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Purchase()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Purchase(Patients patients)
        {
          
            if (ModelState.IsValid)
            {
                

                if (ModelState.IsValid)
                {
                    Patients c = new Patients
                    {
                        PrenomPatient = patients.PrenomPatient,
                        NomPatient = patients.NomPatient,
                        MatriculePatients = patients.MatriculePatients,
                        
                                  };

                    MedicamentOrder o = new MedicamentOrder
                    {
                        OrderDate = DateTime.Now,
                        DeliveryDate = DateTime.Now.AddDays(5),
                        idPatients = c.IdPatients
                    };

                    db.Patients.Add(c);
                    db.MedicamentOrders.Add(o);

                    foreach (var i in db.MedShoppingCartDatas.ToList<MedShoppingCartData>())
                    {
                        db.Med.Add(new MedOrder_Products
                        {
                            OrderID = o.OrderID,
                            PID = i.PID,
                            Qty = i.Quantity,
                            TotalSale = i.Quantity * i.UnitPrice
                        });
                        db.MedShoppingCartDatas.Remove(i);
                    }

                    db.SaveChanges();

                    return RedirectToAction("PurchasedSuccess");

                }
            }

            List<ModelError> errors = new List<ModelError>();
            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errors.Add(error);
                }
            }
            return View(patients);
        }

        public ActionResult PurchasedSuccess()
        {
            return View();
        }
    }
}