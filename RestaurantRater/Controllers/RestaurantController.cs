using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        [HttpPost]
        //POST
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid && restaurant != null)//ModelState is property from APIController
            {
                _context.Restaurants.Add(restaurant);             //restaurants is the name of the database table we're adding the local _context to, passing in THE restaurant to add it
                await _context.SaveChangesAsync();//returns int of how many items were changed
                return Ok();//returning http protocol response, assuming it's 200 level 
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        // GET ALL
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        // GET ID
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        // PUT (update)
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri]int id, [FromBody]Restaurant model)//getting id from URL, getting model from Body
        {
            if (ModelState.IsValid && model != null)
            {
                Restaurant restaurant = await _context.Restaurants.FindAsync(id);//restaurant is our entity within the database

                if (restaurant != null)
                {
                    restaurant.Name = model.Name;
                    restaurant.Rating = model.Rating;
                    restaurant.Style = model.Style;
                    restaurant.DollarSigns = model.DollarSigns;

                    await _context.SaveChangesAsync();

                    return Ok();
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        // DELETE BY ID
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurantByID(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                if (await _context.SaveChangesAsync() == 1)
                {
                    return Ok();
                }
                return InternalServerError();
            }
            return BadRequest();
        }
    }
}
