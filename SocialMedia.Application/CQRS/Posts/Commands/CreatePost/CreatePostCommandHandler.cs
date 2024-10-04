using MediatR;
using SocialMedia.Application.Interfaces;
using SocialMedia.Core.Models;

namespace SocialMedia.Application.CQRS.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IDbContext _context;

        public CreatePostCommandHandler(IDbContext context ) 
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post()
            {
                Title = request.Title,
                Content = request.Content,
                Description = request.Description ?? "",
                UserId = request.UserId,
            };

            _context.Posts.Add( post );
            await _context.SaveChangesAsync();

            return post.Id;
        }
    }
}
