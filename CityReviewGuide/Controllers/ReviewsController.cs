using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CityReviewGuide.Repositories;
using CityReviewGuide.Repositories.Domain;
using Newtonsoft.Json.Linq;


namespace CityReviewGuide.Controllers
{
    [Route("api/Reviews")]
    public class ReviewsController : Controller
    {
        private readonly ILogger _logger;

        public ReviewsController(ILogger<ReviewsController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<CityReview> Get()
        {

            ReviewsRepository repo = new ReviewsRepository(_logger);
            return repo.returnReviews("Events").ToList();

            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]JToken value)
        {
            var a = value.ToString();

            CityReview review = new CityReview();
            review.ReviewCategory = (string)value["ReviewCategory"];
            review.ReviewItemID = (int)value["reviewItemID"];
            review.ReviewRating = (string)value["reviewRating"];
            review.ReviewText = (string)value["reviewText"];

            ReviewsRepository repo = new ReviewsRepository(_logger);
            repo.addReview(review);


            _logger.LogInformation("Value added");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
