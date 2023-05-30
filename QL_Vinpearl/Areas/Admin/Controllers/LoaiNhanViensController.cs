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
    public class LoaiNhanViensController : Controller
    {
        private QL_VinpearlEntities db = new QL_VinpearlEntities();

        // GET: Admin/LoaiNhanViens
        public ActionResult Index()
        {
            return View(db.LOAINV.ToList());
        }

        // GET: Admin/LoaiNhanViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAINV lOAINV = db.LOAINV.Find(id);
            if (lOAINV == null)
            {
                return HttpNotFound();
            }
            return View(lOAINV);
        }

        // GET: Admin/LoaiNhanViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiNhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maLoaiNV,tenLoai,luongCoBan")] LOAINV lOAINV)
        {
            if (ModelState.IsValid)
            {
                db.LOAINV.Add(lOAINV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAINV);
        }

        // GET: Admin/LoaiNhanViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAINV lOAINV = db.LOAINV.Find(id);
            if (lOAINV == null)
            {
                return HttpNotFound();
            }
            return View(lOAINV);
        }

        // POST: Admin/LoaiNhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maLoaiNV,tenLoai,luongCoBan")] LOAINV lOAINV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAINV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAINV);
        }

        // GET: Admin/LoaiNhanViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAINV lOAINV = db.LOAINV.Find(id);
            if (lOAINV == null)
            {
                return HttpNotFound();
            }
            return View(lOAINV);
        }

        // POST: Admin/LoaiNhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAINV lOAINV = db.LOAINV.Find(id);
            db.LOAINV.Remove(lOAINV);
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
