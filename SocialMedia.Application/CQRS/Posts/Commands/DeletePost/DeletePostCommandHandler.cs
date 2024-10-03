using MediatR;
using SocialMedia.Application.Exeptions;
using SocialMedia.Application.Interfaces;

namespace SocialMedia.Application.CQRS.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IDbContext _context;

        public DeletePostCommandHandler(IDbContext context) 
        {
            _context = context;
        }

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FindAsync(request.Id);
            if(post == null || post.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(post), request.Id);
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
