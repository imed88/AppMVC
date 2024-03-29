﻿using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables;
using WebApplication4.Models.Tables.ShopCart;

namespace WebApplication4.Controllers.TablesControllers
{
    [Authorize(Roles = "Administrateur")]
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private string strCart = "Cart"; 
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if(Session[strCart] ==null)
            {
                List<Cart> lsCart = new List<Cart> {
                    new Cart(db.Products.Find(id),1)
    
                };
                Session[strCart] = lsCart;
            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session[strCart];
                int check = IsExistingCheck(id);
                if(check==-1)
                {
                    lsCart.Add(new Cart(db.Products.Find(id),1));
                }
               
                //lsCart.Add(new Cart(db.Products.Find(id), 1));
                Session[strCart] = lsCart;
            }
            return View("Index");
        }

        public int IsExistingCheck(int? id)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for(int i=0; i<lsCart.Count; i++)
            {
                if(lsCart[i].Product.ProductID==id)
                {
                    return i;
                }
                
            }
            return -1;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int check = IsExistingCheck(id);
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            lsCart.RemoveAt(check);
            return View("Index");
        }


        public ActionResult UpdateCart(FormCollection frc)
        {
            string[] quantities = frc.GetValues("quantity");
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for(int i=0; i<lsCart.Count; i++)
            {
                lsCart[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[strCart] = lsCart;
            return View("Index");
        }


        public ActionResult Checkout()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ProcessOrder(FormCollection frc, int? id)
        {
            List<Cart> lstCart = (List<Cart>)Session[strCart];
            var ConsultationID = Convert.ToInt32(frc["NConsultation"]);
            var MatriculePatients = frc["MatriculePatient"];
            var Indication = frc["Comment"];
            //Save to order
            if (ModelState.IsValid)
            {

                Order order = new Order()
                {

                    OrderDate = DateTime.Now,
                    ConsultationID = ConsultationID,
                    MatriculePatients = MatriculePatients
                };
                db.Orders.Add(order);
                db.SaveChanges();
                //save to order detail
                foreach (Cart cart in lstCart)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderID = order.OrderID,
                        ProductID = cart.Product.ProductID,
                        Quantity = cart.Quantity,
                        Comments = Indication

                    };

                    db.OrderDetails.Add(orderDetail);
                    db.SaveChanges();



                    var OneBlog = (from e in db.Orders
                                   join p in db.Consultations
                                   on e.ConsultationID equals p.ConsultationID
                                   join s in db.OrderDetails
                                   on e.OrderID equals s.OrderID
                                   join t in db.Products
                                   on s.ProductID equals t.ProductID

                                   select new
                                   {

                                       t.ProductID,
                                       t.NameProduct,
                                       p.ConsultationID,
                                       p.Patient.MatriculePatients,
                                       p.Patient.NomPatient,
                                       p.Patient.PrenomPatient,
                                       p.DateCreated,
                                       e.OrderDate,
                                       s.Quantity,
                                       e.OrderID,
                                       s.Comments

                                   }).ToList();


                        //var item = OneBlog.ToList();
                        ReportDocument rd = new ReportDocument();
                        rd.Load(Path.Combine(Server.MapPath("~/Report"), "Ordonnance.rpt"));
                        rd.SetDataSource(OneBlog);

                        Response.Buffer = false;
                        Response.ClearContent();
                        Response.ClearHeaders();

                        Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        stream.Seek(0, SeekOrigin.Begin);
                        return File(stream, "application/pdf", "Ordonnance.pdf");

                    

                }
            }
            else
            {
                Session.Remove(strCart);
            }
            return RedirectToAction("Index","Order");
          
          

            //Remove shopping session
          
            //return View("OrderSuccess");
        }
        

    }
    
}