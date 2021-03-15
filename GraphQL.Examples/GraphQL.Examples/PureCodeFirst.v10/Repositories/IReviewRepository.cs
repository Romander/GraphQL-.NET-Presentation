using System.Collections.Generic;
using PureCodeFirst.v10.Characters;
using PureCodeFirst.v10.Reviews;

namespace PureCodeFirst.v10.Repositories
{
    public interface IReviewRepository
    {
        void AddReview(Episode episode, Review review);
        IEnumerable<Review> GetReviews(Episode episode);
    }
}
