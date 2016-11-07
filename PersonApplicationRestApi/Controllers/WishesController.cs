using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PersonApplicationDll;
using PersonApplicationDll.Entities;

namespace PersonApplicationRestApi.Controllers
{
    public class WishesController : ApiController
    {
        private IRepository<Wish> wr = new DllFacade().GetWishRepository();
        // GET: api/Wishes
        public List<Wish> GetWishes()
        {
            return wr.Read();
        }

        // GET: api/Wishes/5
        [ResponseType(typeof(Wish))]
        public IHttpActionResult GetWish(int id)
        {
            var wish = wr.Read(id);
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
                return BadRequest("Ids did not match");
            }

            wr.Update(wish);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// This is the great post request remember I like chokolate
        /// </summary>
        /// <param name="wish"></param>
        /// <returns></returns>
        // POST: api/Wishes
        [ResponseType(typeof(Wish))]
        public IHttpActionResult PostWish(Wish wish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            wr.Create(wish);

            return CreatedAtRoute("DefaultApi", new { id = wish.Id }, wish);
        }

        /// <summary>
        /// This is the Delete function
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Wishes/5
        [ResponseType(typeof(Wish))]
        [HttpDelete]
        public IHttpActionResult Wish(int id)
        {
            var wish = wr.Read(id);
            if (wish == null)
            {
                return NotFound();
            }

            wr.Delete(id);

            return Ok(wish);
        }
        
    }
}