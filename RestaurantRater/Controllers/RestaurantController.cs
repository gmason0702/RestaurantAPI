using RestaurantRater.Models;
using System;
using System.Collections.Generic;
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
        //POST
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid && restaurant!=null)//ModelState is property from APIController
            {
                _context.Restaurants.Add(restaurant);             //restaurants is the name of the database table we're adding the local _context to, passing in THE restaurant to add it
                await _context.SaveChangesAsync();//returns int of how many items were changed
                return Ok();//returning http protocol response, assuming it's 200 level 
            }
            return BadRequest(ModelState);
        }
    }
}
