using Core.Domain;

namespace DataService.Interface
{
    public interface IUserService
    {
        User GetUserById(int id);
    }
}
