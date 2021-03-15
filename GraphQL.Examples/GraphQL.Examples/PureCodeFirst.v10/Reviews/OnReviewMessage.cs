using HotChocolate.Language;
using HotChocolate.Subscriptions;
using PureCodeFirst.v10.Characters;

namespace PureCodeFirst.v10.Reviews
{
  public class OnReviewMessage
        : EventMessage
  {
    public OnReviewMessage(Episode episode, Review review)
        : base(CreateEventDescription(episode), review)
    {
    }

    private static EventDescription CreateEventDescription(Episode episode)
    {
      return new EventDescription("onReview",
          new ArgumentNode("episode",
              new EnumValueNode(
                  episode.ToString().ToUpperInvariant())));
    }
  }
}
