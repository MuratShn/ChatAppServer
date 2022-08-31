﻿using Business.Features.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(CreateUserCommandRequest user)
        {
            var result = await _mediator.Send(user);
            return Ok(result);
        }
    }
}
