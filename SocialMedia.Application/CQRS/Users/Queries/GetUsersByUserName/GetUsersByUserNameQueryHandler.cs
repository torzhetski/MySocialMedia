using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Extentions;
using SocialMedia.Application.Interfaces;

namespace SocialMedia.Application.CQRS.Users.Queries.GetUsersByUserName
{
    public class GetUsersByUserNameQueryHandler : IRequestHandler<GetUsersByUserNameQuery, List<UserSummaryDTO>>
    {
        private readonly IDbContext _context;

        public GetUsersByUserNameQueryHandler(IDbContext context) 
        {
            _context = context;
        }


        public async Task<List<UserSummaryDTO>> Handle(GetUsersByUserNameQuery request, CancellationToken cancellationToken)
        {
           return await _context.Users
                               .Where(user => user.UserName.Contains(request.UserName))
                               .Select(user => user.FromUserToSummaryDTO())
                               .ToListAsync();
            
        }
    }
}
