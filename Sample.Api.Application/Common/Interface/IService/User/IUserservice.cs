using Sample.Api.Application.Command;
using Sample.Api.Application.Query;
using System.Threading.Tasks;

namespace Sample.Api.Application.Common
{
   public interface IUserservice
    {
        Task<bool> RegisterUser(UserCreateDto createDto);
        Task<UserGetDto> Login(LoginRequsetDto createDto);
    }
}
