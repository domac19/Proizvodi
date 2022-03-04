using Proizvodi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proizvodi.Controllers
{
    public class ProizvodController : Controller
    {
        private ProizvodiEntities _proizvodiEntities;
        public ProizvodController()
        {
            _proizvodiEntities = new ProizvodiEntities();
        }
        protected override void Dispose(bool disposing)
        {
            _proizvodiEntities.Dispose();
        }

        public ActionResult Add()
        {
            var viewModel = new ProizvodViewModel
            {
                Proizvod = new Proizvod()
            };
            return View("Add", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProizvodViewModel
                {
                    Proizvod = proizvod
                };
                return View("Add", viewModel);
            }

            if (proizvod.ProizvodId == 0)
                _proizvodiEntities.Proizvods.Add(proizvod);
            else
            {
                var proizvodDb = _proizvodiEntities.Proizvods.Single(c => c.ProizvodId == proizvod.ProizvodId);

                proizvodDb.Naziv = proizvod.Naziv;
                proizvodDb.Tip = proizvod.Tip;
                proizvodDb.Cijena = proizvod.Cijena;
            }
            _proizvodiEntities.SaveChanges();

            return RedirectToAction("Index", "Proizvod");
        }
        public ActionResult Edit(int id)
        {
            var proizvod = _proizvodiEntities.Proizvods.SingleOrDefault(c => c.ProizvodId == id);
            if (proizvod == null)
                return HttpNotFound();

            var viewModel = new ProizvodViewModel
            {
                Proizvod = proizvod
            };

            return View("Add", viewModel);
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var proizvod = _proizvodiEntities.Proizvods.SingleOrDefault(c => c.ProizvodId == id);

            if (proizvod == null)
                return HttpNotFound();

            return View(proizvod);
        }
    }
}