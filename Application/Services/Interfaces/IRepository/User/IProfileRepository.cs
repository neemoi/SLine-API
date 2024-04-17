using Application.DtoModels.Models.User.Profile;
using Persistance;

namespace Application.Services.Interfaces.IRepository.User
{
    public interface IProfileRepository
    {
        Task<Users> EditProfileAsync(EditProfileDto model, string userId);

        Task<Users> GetAllInfoAsync(string userId);
    }
}
