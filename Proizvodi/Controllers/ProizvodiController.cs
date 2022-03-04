using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proizvodi.Controllers
{
    public class ProizvodiController : ApiController
    {
        private ProizvodiEntities _proizvodiEntities;
        public ProizvodiController()
        {
            _proizvodiEntities = new ProizvodiEntities();
        }

        // GET/api/proizvodi
        public IHttpActionResult GetCustomers(string query = null)
        {
            var proizvodi = _proizvodiEntities.Proizvods.ToList();

            return Ok(proizvodi);
        }

        // GET/proizvod/1
        public IHttpActionResult GetCustomer(int id)
        {
            var proizvod = _proizvodiEntities.Proizvods.SingleOrDefault(c => c.ProizvodId == id);

            if (proizvod == null)
                return NotFound();

            return Ok(proizvod);
        }

        // POST/api/proizvodi
        [HttpPost]
        public IHttpActionResult CreateProizvod(Proizvod proizvod)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _proizvodiEntities.Proizvods.Add(proizvod);
            _proizvodiEntities.SaveChanges();

            return Ok(proizvod);
        }

        // PUT/api/proizvodi
        public void UpdateCustomer(int id, Proizvod proizvod)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var proizvodDb = _proizvodiEntities.Proizvods.SingleOrDefault(c => c.ProizvodId == id);

            if (proizvodDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _proizvodiEntities.SaveChanges();
        }

        // DELETE/api/proizvod/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var proizvodDb = _proizvodiEntities.Proizvods.SingleOrDefault(c => c.ProizvodId == id);

            if (proizvodDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _proizvodiEntities.Proizvods.Remove(proizvodDb);
            _proizvodiEntities.SaveChanges();
        }
    }
}
