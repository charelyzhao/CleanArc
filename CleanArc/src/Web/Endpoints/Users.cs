using CleanArc.Application.Common.Interfaces;
using CleanArc.Infrastructure.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CleanArc.Application.Common.Models;

namespace CleanArc.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this)
            .WithTags("Authentication")
            .AllowAnonymous();

        // 注册端点
        group.MapPost("/register", async Task<Results<Ok, ProblemHttpResult>>
            ([FromBody] RegisterRequest request,
            [FromServices] UserManager<ApplicationUser> userManager) =>
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email
            };

            var result = await userManager.CreateAsync(user, request.Password);

            return result.Succeeded ?
                TypedResults.Ok() :
                TypedResults.Problem(result.Errors.First().Description);
        });

        // 登录端点
        group.MapPost("/login", async Task<Results<Ok<AuthResponse>, UnauthorizedHttpResult>>
            ([FromBody] LoginRequest request,
            [FromServices] IIdentityService identityService) =>
        {
            var result = await identityService.CheckLogin(
               request.Email,
               request.Password);

            return result ?
                TypedResults.Ok(await identityService.GenerateToken(request.Email)) :
                TypedResults.Unauthorized();

        });
    }
    // DTO定义
    public record RegisterRequest(string Email, string Password);
    public record LoginRequest(string Email, string Password);

}
