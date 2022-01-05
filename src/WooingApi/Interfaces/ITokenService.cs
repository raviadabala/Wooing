using WooingApi.Models;

namespace WooingApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}