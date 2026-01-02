using eCommers.Core.Entities;
namespace eCommers.Core.RepositoryContracts
{
    /// <summary>
    /// This contract to be implemented by User Repository that contains data access logic of user data.
    /// </summary>
    public interface IUserRepository
    {
        Task<ApplicationUser?> AddUser(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email,string? password);
    }
}