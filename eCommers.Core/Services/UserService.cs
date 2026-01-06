using AutoMapper;
using eCommers.Core.DTO;
using eCommers.Core.Entities;
using eCommers.Core.RepositoryContracts;
using eCommers.Core.ServiceContracts;

namespace eCommers.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email,loginRequest.Password);
            if (user == null)
            {
                return null;
            }

            //return new AuthenticationResponse(user.UserId,user.Email,user.PersonName,user.Gender,"Token",true);
            return _mapper.Map<AuthenticationResponse>(user) with { Success = true,Token = "Token"};
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            // ApplicationUser newUser = new ApplicationUser()
            // {
            //     Email = registerRequest.Email,
            //     Gender = registerRequest.Gender.ToString(),
            //     Password = registerRequest.Password,
            //     PersonName = registerRequest.PersonName
            // };
           
            ApplicationUser newUser = _mapper.Map<RegisterRequest,ApplicationUser>(registerRequest);

            ApplicationUser? user = await _userRepository.AddUser(newUser);

            if (user == null)
            {
                return null;
            }
            //return new AuthenticationResponse(user.UserId,user.Email,user.PersonName,user.Gender,"Token",true);
            return _mapper.Map<AuthenticationResponse>(user) with { Success = true,Token = "Token"};
        }
    }
}