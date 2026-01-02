using eCommers.Core.DTO.Enums;
namespace eCommers.Core.DTO
{
    public record RegisterRequest(string? Email,string? Password,string? PersonName,GenderOptions Gender);    
}