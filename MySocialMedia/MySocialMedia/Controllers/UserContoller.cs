using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.CQRS.Users.Commands.LoginUser;
using SocialMedia.Application.CQRS.Users.Commands.RegisterUser;
using SocialMedia.Application.CQRS.Users.Commands.UpdateUser;
using SocialMedia.Application.CQRS.Users.Queries.GetUserById;
using SocialMedia.Application.CQRS.Users.Queries.GetUsersByUserName;
using SocialMedia.Application.DTOs.UserDTOs;
using SocialMedia.Application.Exeptions;

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

        [HttpPost("Registration")]
        public async Task<ActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var userId = await Mediator.Send(command);
            if (userId == 0)
                return BadRequest();

            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var token = await Mediator.Send(command);
                return Ok(token);
            }
            catch (InvalidUserException ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateUserCommand command)
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
