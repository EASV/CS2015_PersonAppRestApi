using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PersonApplicationDll.Context;
using PersonApplicationDll.Entities;

namespace PersonApplicationRestApi.Controllers
{
    public class WishesController : ApiController
    {
        private PersonAppContext db = new PersonAppContext();

        // GET: api/Wishes
        public IQueryable<Wish> GetWishes()
        {
            return db.Wishes;
        }

        // GET: api/Wishes/5
        [ResponseType(typeof(Wish))]
        public IHttpActionResult GetWish(int id)
        {
            Wish wish = db.Wishes.Find(id);
            if (wish == null)
            {
                return NotFound();
            }

            return Ok(wish);
        }

        // PUT: api/Wishes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWish(int id, Wish wish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wish.Id)
            {
                return BadRequest();
            }

            db.Entry(wish).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Wishes
        [ResponseType(typeof(Wish))]
        public IHttpActionResult PostWish(Wish wish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wishes.Add(wish);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wish.Id }, wish);
        }

        // DELETE: api/Wishes/5
        [ResponseType(typeof(Wish))]
        public IHttpActionResult DeleteWish(int id)
        {
            Wish wish = db.Wishes.Find(id);
            if (wish == null)
            {
                return NotFound();
            }

            db.Wishes.Remove(wish);
            db.SaveChanges();

            return Ok(wish);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WishExists(int id)
        {
            return db.Wishes.Count(e => e.Id == id) > 0;
        }
    }
}