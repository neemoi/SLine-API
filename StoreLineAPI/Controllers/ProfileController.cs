﻿using Application.DtoModels.Models.User.Profile;
using Application.Services.Implementations.User;
using Application.Services.Interfaces.IServices.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreLineAPI.Controllers
{
    [Route("/Profile")]
    [ApiController]
    //[Authorize]
    public class ProfileController : ControllerBase
    {
       
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("GetAllInfo")]
        public async Task<IActionResult> GetAllInfoAsync(string userId)
        {
            try
            {
                return Ok(await _profileService.GetAllInfoAsync(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditProfileAsync(EditProfileDto model, string userId)
        {
            try
            {
                return Ok(await _profileService.EditProfileAsync(model, userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
