using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proizvodi.Controllers
{
    public class KatalogController : ApiController
    {
        private ProizvodiEntities _proizvodiEntities;
        public KatalogController()
        {
            _proizvodiEntities = new ProizvodiEntities();
        }

        // GET/api/katalog
        public IHttpActionResult GetKatalog(string query = null)
        {
            var proizvodKatalog = _proizvodiEntities.KatalogProizvodas.ToList();

            return Ok(proizvodKatalog);
        }

        // GET/katalog/1
        public IHttpActionResult GetCustomer(int id)
        {
            var katalog = _proizvodiEntities.KatalogProizvodas.SingleOrDefault(c => c.KatalogId == id);

            if (katalog == null)
                return NotFound();

            return Ok(katalog);
        }

        // POST/api/katalog
        [HttpPost]
        public IHttpActionResult CreateProizvod(KatalogProizvoda katalogProizvoda)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _proizvodiEntities.KatalogProizvodas.Add(katalogProizvoda);
            _proizvodiEntities.SaveChanges();

            return Ok(katalogProizvoda);
        }

        // PUT/api/proizvodi
        public void UpdateCustomer(int id, KatalogProizvoda katalogProizvoda)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var katalogDb = _proizvodiEntities.KatalogProizvodas.SingleOrDefault(c => c.KatalogId == id);

            if (katalogDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _proizvodiEntities.SaveChanges();
        }

        // DELETE/api/proizvod/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var katalogDb = _proizvodiEntities.KatalogProizvodas.SingleOrDefault(c => c.KatalogId == id);

            if (katalogDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _proizvodiEntities.KatalogProizvodas.Remove(katalogDb);
            _proizvodiEntities.SaveChanges();
        }
    }
}
