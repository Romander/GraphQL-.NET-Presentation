using HotChocolate;
using HotChocolate.Types;
using PureCodeFirst.v11.Characters;

namespace PureCodeFirst.v11.Reviews
{
  [ExtendObjectType(Name = "Subscription")]
  public class ReviewSubscriptions
  {
    [Subscribe]
    public Review OnReview(
        [Topic] Episode episode,
        [EventMessage] Review message) => message;
  }
}
