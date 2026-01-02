using eCommers.Core.DTO;
using eCommers.Core.Entities;
using eCommers.Core.RepositoryContracts;
using eCommers.Core.ServiceContracts;

namespace eCommers.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email,loginRequest.Password);
            if (user == null)
            {
                return null;
            }

            return new AuthenticationResponse(user.UserId,user.Email,user.PersonName,user.Gender,"Token",true);

        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            ApplicationUser newUser = new ApplicationUser()
            {
                Email = registerRequest.Email,
                Gender = registerRequest.Gender.ToString(),
                Password = registerRequest.Password,
                PersonName = registerRequest.PersonName
            };
            
            ApplicationUser? user = await _userRepository.AddUser(newUser);

            if (user == null)
            {
                return null;
            }
            return new AuthenticationResponse(user.UserId,user.Email,user.PersonName,user.Gender,"Token",true);

        }
    }
}