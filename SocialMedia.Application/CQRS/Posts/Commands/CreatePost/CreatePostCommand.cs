using MediatR;

namespace SocialMedia.Application.CQRS.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
