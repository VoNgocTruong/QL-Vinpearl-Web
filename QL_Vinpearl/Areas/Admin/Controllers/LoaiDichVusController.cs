using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QL_Vinpearl.Models;

namespace QL_Vinpearl.Areas.Admin.Controllers
{
    public class LoaiDichVusController : Controller
    {
        private QL_VinpearlEntities db = new QL_VinpearlEntities();

        // GET: Admin/LoaiDichVus
        public ActionResult Index()
        {
            return View(db.LOAIDV.ToList());
        }

        // GET: Admin/LoaiDichVus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIDV lOAIDV = db.LOAIDV.Find(id);
            if (lOAIDV == null)
            {
                return HttpNotFound();
            }
            return View(lOAIDV);
        }

        // GET: Admin/LoaiDichVus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiDichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maLoaiDV,tenLoai")] LOAIDV lOAIDV)
        {
            if (ModelState.IsValid)
            {
                db.LOAIDV.Add(lOAIDV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAIDV);
        }

        // GET: Admin/LoaiDichVus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIDV lOAIDV = db.LOAIDV.Find(id);
            if (lOAIDV == null)
            {
                return HttpNotFound();
            }
            return View(lOAIDV);
        }

        // POST: Admin/LoaiDichVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maLoaiDV,tenLoai")] LOAIDV lOAIDV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAIDV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAIDV);
        }

        // GET: Admin/LoaiDichVus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIDV lOAIDV = db.LOAIDV.Find(id);
            if (lOAIDV == null)
            {
                return HttpNotFound();
            }
            return View(lOAIDV);
        }

        // POST: Admin/LoaiDichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAIDV lOAIDV = db.LOAIDV.Find(id);
            db.LOAIDV.Remove(lOAIDV);
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
