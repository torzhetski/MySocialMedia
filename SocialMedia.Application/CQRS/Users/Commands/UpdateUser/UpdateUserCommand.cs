using MediatR;

namespace SocialMedia.Application.CQRS.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Avatar { get; set; }
    }
}
