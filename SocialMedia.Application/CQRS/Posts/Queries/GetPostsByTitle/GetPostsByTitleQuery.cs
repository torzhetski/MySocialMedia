using MediatR;

namespace SocialMedia.Application.CQRS.Posts.Queries.GetPostsByTitle
{
    public class GetPostsByTitleQuery : IRequest<List<PostSummaryDTO>>
    {
        public string Title { get; set; }
        public int PageSize { get; } = 15;
        public int PageNumber { get; set; }
    }
}
