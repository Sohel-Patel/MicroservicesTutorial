using eCommers.Core.DTO.Enums;
using eCommers.Core.Entities;
using eCommers.Core.RepositoryContracts;

namespace eCommers.InfraStructure.Repositories
{
    internal class UserRepository : IUserRepository
    {

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            return user;
        }
        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            return new ApplicationUser()
            {
                UserId = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName = "Person Name",
                Gender = GenderOptions.Male.ToString()
            };
        }
    }
}