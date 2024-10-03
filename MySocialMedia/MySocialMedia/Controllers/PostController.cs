using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.CQRS.Posts.Commands.CreatePost;
using SocialMedia.Application.CQRS.Posts.Commands.DeletePost;
using SocialMedia.Application.CQRS.Posts.Commands.UpdatePost;
using SocialMedia.Application.CQRS.Posts.Queries;
using SocialMedia.Application.CQRS.Posts.Queries.GetPostById;
using SocialMedia.Application.CQRS.Posts.Queries.GetPostsByTitle;
using SocialMedia.Application.CQRS.Posts.Queries.GetRecentPosts;
using SocialMedia.Core.Models;

namespace MySocialMedia.Controllers
{
    [Route("api/[controller]")]
    public class PostController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById([FromRoute] int id)
        {
            var query = new GetPostByIdQuery
            {
                Id = id
            };
            var post = await Mediator.Send(query);
            if (post != null) 
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet("{title}/{pageNumber}")]
        public async Task<ActionResult<List<PostSummaryDTO>>> GetByTitle([FromRoute] string title, [FromRoute] int pageNumber)
        {
            var query = new GetPostsByTitleQuery
            {
                Title = title,
                PageNumber = pageNumber
            };
            var posts = await Mediator.Send(query);
            return Ok(posts);
        }

        [HttpGet("{pageNumber}")]
        public async Task<ActionResult<List<PostSummaryDTO>>> GetRecent([FromRoute] int pageNumber)
        {
            var query = new GetRecentPostsQuery
            {
                PageNumber = pageNumber
            };
            var posts = await Mediator.Send(query);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePostCommand command)
        {
            var PostId = await Mediator.Send(command);
            if (PostId == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update ([FromRoute] int id, [FromBody] UpdatePostCommand command)
        {
            command.Id = id;
            var postId = await Mediator.Send(command);
            if (postId == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{userId}/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int userId,[FromRoute] int id) 
        {
            var command = new DeletePostCommand 
            {
                UserId = userId,
                Id = id 
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }

}
