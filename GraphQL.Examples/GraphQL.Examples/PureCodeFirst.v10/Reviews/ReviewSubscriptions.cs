using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using PureCodeFirst.v10.Characters;
using PureCodeFirst.v10.Repositories;

namespace PureCodeFirst.v10.Reviews
{
  [ExtendObjectType(Name = "Subscription")]
  public class ReviewSubscriptions
  {
    public Review OnReview(
        Episode episode,
        IEventMessage message,
        [Service] IReviewRepository _repository)
    {
      return (Review)message.Payload;
    }
  }
}
