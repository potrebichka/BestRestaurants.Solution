using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
  public class ReviewsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public ReviewsController(BestRestaurantsContext db)
    {
        _db = db;
    }

    // public ActionResult Index()
    // {
    //     List<Restaurant> model = _db.Restaurants.Include(cuisines => cuisines.Cuisine).ToList();
    //     return View(model);
    // }
     public ActionResult Create(int id)
    {
        Restaurant currentRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
        ViewBag.currentRestaurant = currentRestaurant;
        return View();
    }
    [HttpPost]
    public ActionResult Create(Review review)
    {
        _db.Reviews.Add(review);
        _db.SaveChanges();
        return RedirectToAction("Details", "Restaurants", new {id = review.RestaurantId} );
    }
  }
}