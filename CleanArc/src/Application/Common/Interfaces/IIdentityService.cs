﻿using CleanArc.Application.Common.Models;

namespace CleanArc.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);

    Task<AuthResponse> GenerateToken(string email);

    Task<bool> CheckLogin(string userName, string password);
}
