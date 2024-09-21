using MediatR;

namespace SocialMedia.Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Email { get; set; } 
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
