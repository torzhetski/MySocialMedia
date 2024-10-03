using MediatR;
using SocialMedia.Application.Exeptions;
using SocialMedia.Application.Interfaces;

namespace SocialMedia.Application.CQRS.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, int>
    {
        private readonly IDbContext _context;

        public UpdatePostCommandHandler(IDbContext context) 
        {
            _context = context;
        }

        public async Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FindAsync(request.Id);
            if (post == null) 
            {
                throw new NotFoundException(nameof(post), request.Id);
            }
            post.Title = request.Title ?? post.Title;
            post.Content = request.Content ?? post.Content;
            post.Description = request.Description ?? post.Description;
            
            await _context.SaveChangesAsync();
            return post.Id;
        }
    }
}
