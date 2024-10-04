using MediatR;
using SocialMedia.Application.DTOs.PostDTOs;
using SocialMedia.Core.Models;

namespace SocialMedia.Application.CQRS.Posts.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequest<PostDTO>
    {
        public int Id { get; set; }
    }
}
