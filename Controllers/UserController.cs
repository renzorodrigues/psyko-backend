using System.Collections.Generic;
using System.Threading.Tasks;
using CCAU.Domain.DTOs;
using CCAU.Domain.Entities;
using CCAU.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CCAU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(List<User>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await this.userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(List<User>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var result = await this.userService.GetUserById(id);
            this.Response.StatusCode = (int)result.StatusCode;
            return new JsonResult(result.Data);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostUser(UserForRequest user)
        {
            var newUserId = await this.userService.PostUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = newUserId }, newUserId);
        }
    }
}