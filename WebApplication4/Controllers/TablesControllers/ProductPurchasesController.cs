using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.Tables.Medicine;

namespace WebApplication4.Controllers.TablesControllers
{
    public class ProductPurchasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductPurchases
        public ActionResult Index()
        {
            var productPurchase = db.productPurchase.Include(p => p.product);
            return View(productPurchase.ToList());
        }

        // GET: ProductPurchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPurchase productPurchase = db.productPurchase.Find(id);
            if (productPurchase == null)
            {
                return HttpNotFound();
            }
            return View(productPurchase);
        }

        // GET: ProductPurchases/Create
        public ActionResult Create()
        {
            ViewBag.pro_id = new SelectList(db.tbl_product, "pro_id", "pro_name");
            return View();
        }

        // POST: ProductPurchases/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseID,PurchaseProd,PurchaseQuantity,PurchaseDate,pro_id")] ProductPurchase productPurchase)
        {
            if (ModelState.IsValid)
            {
                db.productPurchase.Add(productPurchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pro_id = new SelectList(db.tbl_product, "pro_id", "pro_name", productPurchase.pro_id);
            return View(productPurchase);
        }

        // GET: ProductPurchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPurchase productPurchase = db.productPurchase.Find(id);
            if (productPurchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.pro_id = new SelectList(db.tbl_product, "pro_id", "pro_name", productPurchase.pro_id);
            return View(productPurchase);
        }

        // POST: ProductPurchases/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseID,PurchaseProd,PurchaseQuantity,PurchaseDate,pro_id")] ProductPurchase productPurchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productPurchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pro_id = new SelectList(db.tbl_product, "pro_id", "pro_name", productPurchase.pro_id);
            return View(productPurchase);
        }

        // GET: ProductPurchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPurchase productPurchase = db.productPurchase.Find(id);
            if (productPurchase == null)
            {
                return HttpNotFound();
            }
            return View(productPurchase);
        }

        // POST: ProductPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductPurchase productPurchase = db.productPurchase.Find(id);
            db.productPurchase.Remove(productPurchase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




    }
}
