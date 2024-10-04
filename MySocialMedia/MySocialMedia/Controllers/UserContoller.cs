using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.CQRS.Users.Commands.CreateUser;
using SocialMedia.Application.CQRS.Users.Commands.UpdateUser;
using SocialMedia.Application.CQRS.Users.Queries.GetUserById;
using SocialMedia.Application.CQRS.Users.Queries.GetUsersByUserName;
using SocialMedia.Application.DTOs.UserDTOs;

namespace MySocialMedia.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserProfileDTO>> GetById([FromRoute] int id)
        {
            var query = new GetUserByIdQuery
            {
                Id = id
            };
            var profile = await Mediator.Send(query);

            if (profile == null) 
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpGet("users/{username}/{pageNumber}")]
        public async Task<ActionResult<List<UserSummaryDTO>>> Find([FromRoute] string username, [FromRoute] int pageNumber)
        {
            var query = new GetUsersByUserNameQuery
            {
                PageNumber = pageNumber,
                UserName = username
            };
            var list = await Mediator.Send(query);
            
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserCommand command)
        {
            var userId = await Mediator.Send(command);
            if (userId == 0)
                return BadRequest();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            var userId = await Mediator.Send(command);
            if(userId == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
