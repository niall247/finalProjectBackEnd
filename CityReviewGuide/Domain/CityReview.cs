using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityReviewGuide.Repositories.Domain
{
    public class CityReview
    {

        public int ReviewID { get; set; }
        public string ReviewCategory { get; set; }
        public int ReviewItemID { get; set; }
        public string ReviewRating { get; set; }
        public string ReviewText { get; set; }
    }
}
