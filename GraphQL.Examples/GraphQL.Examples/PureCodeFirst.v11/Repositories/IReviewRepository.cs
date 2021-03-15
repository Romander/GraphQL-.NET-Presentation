using PureCodeFirst.v11.Characters;
using PureCodeFirst.v11.Reviews;
using System.Collections.Generic;

namespace PureCodeFirst.v11.Repositories
{
  public interface IReviewRepository
  {
    void AddReview(Episode episode, Review review);
    IEnumerable<Review> GetReviews(Episode episode);
  }
}
