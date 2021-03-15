using HotChocolate;
using HotChocolate.Types;
using PureCodeFirst.v11.Characters;

namespace PureCodeFirst.v11.Reviews
{
  public class OnReviewMessage
  {
    [Subscribe]
    public Review OnReview(
      [Topic] Episode episode,
      [EventMessage] Review message) => message;
  }
}
