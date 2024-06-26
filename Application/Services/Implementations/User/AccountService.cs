﻿using Application.DtoModels.Models.Authorization;
using Application.DtoModels.Response.Authorization;
using Application.Services.Interfaces.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Persistance;


namespace Application.Services.Implementations.User
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtService _jwtService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<Users> userManager, SignInManager<Users> signInManager, 
            RoleManager<IdentityRole> roleManager, IMapper mapper, JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtService = jwtService;
            _roleManager = roleManager;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new Exception($"Email {model.Email} not found");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid password");
            }

            var token = await _jwtService.GenerateTokenAsync(user);

            var loginResponse = _mapper.Map<LoginResponseDto>(user);
            loginResponse.Token = token;

            return loginResponse;
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterDto model)
        {
            var user = _mapper.Map<Users>(model);

            var emailAlreadyExists = await _userManager.FindByEmailAsync(model.Email);
            if(emailAlreadyExists != null)
            {
                throw new Exception($"User with this {model.Email} email already exists");
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var role = new IdentityRole("User");
                await _roleManager.CreateAsync(role);
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded || user == null)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Error creating account: {errors}");
            }

            await _userManager.AddToRoleAsync(user, "User");
            await _signInManager.SignInAsync(user, true);

            var token = await _jwtService.GenerateTokenAsync(user);

            var registerResponse = _mapper.Map<RegisterResponseDto>(user);
            registerResponse.Token = token;

            return registerResponse;
        }

        public async Task<LogoutResponseDto> LogoutAsync(HttpContext httpContext)
        {
            var user = await _userManager.GetUserAsync(httpContext.User);

            await _signInManager.SignOutAsync();

            return _mapper.Map<LogoutResponseDto>(user);
        }
    }
}
