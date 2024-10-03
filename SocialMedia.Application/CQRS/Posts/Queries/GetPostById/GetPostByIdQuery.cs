using MediatR;
using SocialMedia.Core.Models;

namespace SocialMedia.Application.CQRS.Posts.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequest<Post>
    {
        public int Id { get; set; }
    }
}
