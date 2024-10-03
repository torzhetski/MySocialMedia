using MediatR;

namespace SocialMedia.Application.CQRS.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
