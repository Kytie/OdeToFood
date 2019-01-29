using OdeToFood.Models;
using System.Data;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        //
        // GET: /Reviews/

        public ActionResult Index([Bind(Prefix="id")] int restaurantId)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if(restaurant != null) { return View(restaurant); }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (!ModelState.IsValid) { return View(review); }
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = review.RestaurantId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "ReviewerName")]RestaurantReview review)
        {
            if (!ModelState.IsValid) { return View(review); }
            _db.Entry(review).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = review.RestaurantId });
        }
        /* or you could create a view model to stop reviewer name from being edited.
        public class ReviewEditViewModel
        {
            public int Id { get; set; }
            public int RestaurantId { get; set; }
            public string Body { get; set; }
            public string Rating { get; set; }
        }*/

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
