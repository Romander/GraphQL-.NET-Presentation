using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using PureCodeFirst.v10.Characters;
using PureCodeFirst.v10.Repositories;
using System.Collections.Generic;

namespace PureCodeFirst.v10.Reviews
{
  [ExtendObjectType(Name = "Query")]
  public class ReviewQueries
  {
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IEnumerable<Review> GetReviews(
        Episode episode,
        [Service] IReviewRepository repository) =>
        repository.GetReviews(episode);
  }
}
