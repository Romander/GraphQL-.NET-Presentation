using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using PureCodeFirst.v10.Data;
using PureCodeFirst.v10.Models;

namespace PureCodeFirst.v10
{
    public class Mutation
    {
        private readonly ReviewRepository _repository;

        public Mutation(ReviewRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Creates a review for a given Star Wars episode.
        /// </summary>
        /// <param name="episode">The episode to review.</param>
        /// <param name="review">The review.</param>
        /// <param name="eventSender">The event sending service.</param>
        /// <returns>The created review.</returns>
        public async Task<Review> CreateReview(
            Episode episode, Review review,
            [Service]ITopicEventSender eventSender)
        {
            _repository.AddReview(episode, review);
            await eventSender.SendAsync(episode, review);
            return review;
        }
    }
}
