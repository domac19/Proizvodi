using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proizvodi;

namespace Proizvodi.Controllers
{
    public class KatalogProizvodasController : Controller
    {
        private ProizvodiEntities db = new ProizvodiEntities();

        // GET: KatalogProizvodas
        public ActionResult Index()
        {
            var katalogProizvodas = db.KatalogProizvodas.Include(k => k.Proizvod1);
            return View(katalogProizvodas.ToList());
        }

        // GET: KatalogProizvodas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KatalogProizvoda katalogProizvoda = db.KatalogProizvodas.Find(id);
            if (katalogProizvoda == null)
            {
                return HttpNotFound();
            }
            return View(katalogProizvoda);
        }

        // GET: KatalogProizvodas/Create
        public ActionResult Create()
        {
            ViewBag.ProizvodId = new SelectList(db.Proizvods, "ProizvodId", "Naziv");
            return View();
        }

        // POST: KatalogProizvodas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KatalogId,Proizvod,ProizvodId")] KatalogProizvoda katalogProizvoda)
        {
            if (ModelState.IsValid)
            {
                db.KatalogProizvodas.Add(katalogProizvoda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProizvodId = new SelectList(db.Proizvods, "ProizvodId", "Naziv", katalogProizvoda.ProizvodId);
            return View(katalogProizvoda);
        }

        // GET: KatalogProizvodas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KatalogProizvoda katalogProizvoda = db.KatalogProizvodas.Find(id);
            if (katalogProizvoda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProizvodId = new SelectList(db.Proizvods, "ProizvodId", "Naziv", katalogProizvoda.ProizvodId);
            return View(katalogProizvoda);
        }

        // POST: KatalogProizvodas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KatalogId,Proizvod,ProizvodId")] KatalogProizvoda katalogProizvoda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(katalogProizvoda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProizvodId = new SelectList(db.Proizvods, "ProizvodId", "Naziv", katalogProizvoda.ProizvodId);
            return View(katalogProizvoda);
        }

        // GET: KatalogProizvodas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KatalogProizvoda katalogProizvoda = db.KatalogProizvodas.Find(id);
            if (katalogProizvoda == null)
            {
                return HttpNotFound();
            }
            return View(katalogProizvoda);
        }

        // POST: KatalogProizvodas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KatalogProizvoda katalogProizvoda = db.KatalogProizvodas.Find(id);
            db.KatalogProizvodas.Remove(katalogProizvoda);
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
