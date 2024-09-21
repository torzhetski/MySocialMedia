using MediatR;
using SocialMedia.Core.Models;

namespace SocialMedia.Application.CQRS.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserProfileDTO?>
    {
        public int Id { get; set; }
    }
}
