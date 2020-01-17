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
    public ActionResult Edit(int id)
    {
      Review thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == thisReview.RestaurantId);
      ViewBag.restaurantName = thisRestaurant.Name;
      ViewBag.restaurantId = thisRestaurant.RestaurantId;
      return View(thisReview);
    }
    [HttpPost]
    public ActionResult Edit(Review review)
    {
      _db.Entry(review).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", "Restaurants", new {id = review.RestaurantId});
    }
    public ActionResult Delete(int id)
    {
      Review thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == thisReview.RestaurantId);
      ViewBag.restaurantName = thisRestaurant.Name;
      ViewBag.restaurantId = thisRestaurant.RestaurantId;
      return View(thisReview);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisReview = _db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
      _db.Reviews.Remove(thisReview);
      _db.SaveChanges();
      return RedirectToAction("Details", "Restaurants", new {id = thisReview.RestaurantId});
    }
  }
}