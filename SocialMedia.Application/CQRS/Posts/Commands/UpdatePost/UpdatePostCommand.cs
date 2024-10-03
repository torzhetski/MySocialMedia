using MediatR;

namespace SocialMedia.Application.CQRS.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
    }
}
