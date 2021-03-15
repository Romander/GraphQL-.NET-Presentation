using CodeFirst.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CodeFirst
{
  public class Subscription
  {
    [Subscribe]
    public Review OnReview(
        [Topic] Episode episode,
        [EventMessage] Review message) =>
        message;
  }
}
