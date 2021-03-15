using System.Collections.Generic;
using PureCodeFirst.v11.Characters;
using PureCodeFirst.v11.Reviews;

namespace PureCodeFirst.v11.Repositories
{
    public interface IReviewRepository
    {
        void AddReview(Episode episode, Review review);
        IEnumerable<Review> GetReviews(Episode episode);
    }
}
