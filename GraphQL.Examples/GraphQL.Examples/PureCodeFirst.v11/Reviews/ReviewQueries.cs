using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;
using PureCodeFirst.v11.Characters;
using PureCodeFirst.v11.Repositories;

namespace PureCodeFirst.v11.Reviews
{
    [ExtendObjectType(Name = "Query")]
    public class ReviewQueries
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Review> GetReviews(
            Episode episode,
            [Service]IReviewRepository repository) =>
            repository.GetReviews(episode);
    }
}
