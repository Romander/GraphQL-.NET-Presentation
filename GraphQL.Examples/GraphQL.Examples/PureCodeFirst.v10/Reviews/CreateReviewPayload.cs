using PureCodeFirst.v10.Characters;

namespace PureCodeFirst.v10.Reviews
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
