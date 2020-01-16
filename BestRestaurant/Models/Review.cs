namespace BestRestaurants.Models
{
    public class Review
    {
        public int ReviewId {get;set;}
        public string Name {get;set;}
        public int Rating {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        public int RestaurantId {get;set;}
        public Restaurant Restaurant {get;set;}
    }
}