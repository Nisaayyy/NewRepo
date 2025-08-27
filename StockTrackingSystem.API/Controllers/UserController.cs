using MediatR;    
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingSystem.Business.User.Models;
using StockTrackingSystem.Business.User.Requests;

namespace StockTrackingSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]  
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)  
    {
        _mediator = mediator;
    }

    [HttpPost("add")] 

    public async Task<ActionResult<AddUserModel>> AddUser([FromBody] AddUserRequest request) 
    {                                                                                              
        
        var users = await _mediator.Send(request); 
        return Ok(users);
    }

    [HttpPost("login")] 

    public async Task<ActionResult<LoginModel>> Login([FromBody] LoginRequest request) 
    {                                                                                                                                                                              

        var users = await _mediator.Send(request); 
        return Ok(users);
    }

    [HttpPut("Update")] 

    public async Task<ActionResult<UpdateModel>> Update([FromBody] UpdateRequest request) 
    {                                                                                        

        var users = await _mediator.Send(request);
        return Ok(users);
    }


}