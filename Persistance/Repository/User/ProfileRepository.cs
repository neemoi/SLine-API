using Application.DtoModels.Models.User.Profile;
using Application.Services.Interfaces.IRepository.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Persistance.Repository.User
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Users> _userManager;

        public ProfileRepository(IMapper mapper, UserManager<Users> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Users> EditProfileAsync(EditProfileDto model, string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    if (!string.IsNullOrEmpty(model.CurrentPassword))
                    {
                        var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                        if (!changePasswordResult.Succeeded)
                        {
                            throw new InvalidOperationException($"Error changing password: {string.Join(", ", changePasswordResult.Errors.Select(e => e.Description))}");
                        }
                    }

                    _mapper.Map(model, user);

                    var updateResult = await _userManager.UpdateAsync(user);

                    if (updateResult.Succeeded)
                    {
                        return user;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Error updating user profile: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    throw new ArgumentNullException($"User with id {userId} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ProfileRepository -> EditProfileAsync: {ex.Message}");
            }
        }

        public async Task<Users> SetAddres(string userId, string address)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    _mapper.Map(address, user);

                    var updateResult = await _userManager.UpdateAsync(user);

                    if (updateResult.Succeeded)
                    {
                        return user;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Error updating user address: {string.Join(", ", updateResult.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    throw new ArgumentNullException($"User with id {userId} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ProfileRepository -> SetAddres: {ex.Message}");
            }
        }

        public async Task<Users> GetAllInfoAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException($"User with id {userId} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ProfileRepository -> GetAllInfoAsync: {ex.Message}");
            }
        }
    }
}
