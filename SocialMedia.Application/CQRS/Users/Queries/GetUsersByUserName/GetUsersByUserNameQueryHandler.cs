using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Mappers;
using SocialMedia.Application.Interfaces;
using SocialMedia.Application.DTOs.UserDTOs;

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
                                        .Skip((request.PageNumber - 1) * request.PageSize)
                                        .Take(request.PageSize)
                                        .Select(user => user.FromUserToSummaryDTO())
                                        .ToListAsync();

        }
    }
}
