using HotChocolate;
using HotChocolate.Types;
using PureCodeFirst.v10.Models;

namespace PureCodeFirst.v10
{
    public class Subscription
    {
        [Subscribe]
        public Review OnReview(
            [Topic]Episode episode, 
            [EventMessage]Review message) =>
            message;
    }
}
