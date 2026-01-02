using eCommers.Core.DTO;
namespace eCommers.Core.ServiceContracts
{
    public interface IUserService
    {
        /// <summary>
        /// Method to handle user login use case and returns an AuthenticationResponse object that contains status of login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

        /// <summary>
        /// Method to handle user registration use case and returns an object That represents status of registration.
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}