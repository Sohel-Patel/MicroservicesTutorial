using Dapper;
using eCommers.Core.DTO.Enums;
using eCommers.Core.Entities;
using eCommers.Core.RepositoryContracts;
using eCommers.Infrastructure.DbContext;

namespace eCommers.InfraStructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;
        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();

            //sql query to insert data into Users table
            string query = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserId, @Email, @PersonName, @Gender, @Password)";
             
            int numberOfRowsAffected = await _dbContext.DbConnection.ExecuteAsync(query,user);
            if (numberOfRowsAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = "Select * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
            var Parameters = new { Email = email, Password = password};
            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,Parameters);
            return user;

        }
    }
}