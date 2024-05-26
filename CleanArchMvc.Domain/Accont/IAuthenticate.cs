using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Accont
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateUser(string email, string password);
        Task<bool> RegistreUser(string email, string password);
        Task Logout();
    }
}