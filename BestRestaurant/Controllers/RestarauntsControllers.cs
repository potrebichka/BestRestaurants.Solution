using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public RestaurantsController(BestRestaurantsContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Restaurant> model = _db.Restaurants.Include(cuisines => cuisines.Cuisine).ToList();
        return View(model);
    }
     public ActionResult Create()
    {
        ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
        return View();
    }
    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
        _db.Restaurants.Add(restaurant);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
        Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
        Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == thisRestaurant.CuisineId);
        ViewBag.CuisineName = thisCuisine.Name;
        return View(thisRestaurant);
    }
  }
}