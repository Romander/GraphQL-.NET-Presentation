using PureCodeFirst.v11.Characters;

namespace PureCodeFirst.v11.Reviews
{
  public class CreateReviewPayload
  {
    public CreateReviewPayload(Episode episode, Review review)
    {
      Episode = episode;
      Review = review;
    }

    public Episode Episode { get; }

    public Review Review { get; }
  }
}
