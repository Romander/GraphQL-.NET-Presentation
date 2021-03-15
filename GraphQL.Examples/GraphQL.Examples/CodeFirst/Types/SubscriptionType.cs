using HotChocolate.Types;

namespace PureCodeFirst.v10.Types
{
    public class SubscriptionType
        : ObjectType<Subscription>
    {
        protected override void Configure(IObjectTypeDescriptor<Subscription> descriptor)
        {
            descriptor.Field(t => t.OnReview(default, default))
                .Type<NonNullType<ReviewType>>()
                .Argument("episode", arg => arg.Type<NonNullType<EpisodeType>>());
        }
    }
}
