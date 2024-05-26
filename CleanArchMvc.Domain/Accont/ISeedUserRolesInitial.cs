using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Accont
{
    public interface ISeedUserRolesInitial
    {
        void SeedUsers();
        void SeedRoles();
    }
}