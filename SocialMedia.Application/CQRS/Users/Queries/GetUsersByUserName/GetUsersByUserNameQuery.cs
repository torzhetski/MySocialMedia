using MediatR;

namespace SocialMedia.Application.CQRS.Users.Queries.GetUsersByUserName
{
    public class GetUsersByUserNameQuery : IRequest<List<UserSummaryDTO>>
    {
        public string? UserName { get; set; }
    }
}
