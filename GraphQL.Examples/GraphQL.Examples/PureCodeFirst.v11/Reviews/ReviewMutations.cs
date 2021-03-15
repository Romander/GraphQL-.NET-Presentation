﻿using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using PureCodeFirst.v11.Repositories;
using System.Threading.Tasks;

namespace PureCodeFirst.v11.Reviews
{
  [ExtendObjectType(Name = "Mutation")]
  public class ReviewMutations
  {
    /// <summary>
    /// Creates a review for a given Star Wars episode.
    /// </summary>
    public async Task<CreateReviewPayload> CreateReview(
        CreateReviewInput input,
        [Service] IReviewRepository repository,
        [Service] ITopicEventSender eventSender)
    {
      var review = new Review(input.Stars, input.Commentary);
      repository.AddReview(input.Episode, review);
      await eventSender.SendAsync(input.Episode, review);
      return new CreateReviewPayload(input.Episode, review);
    }
  }
}
