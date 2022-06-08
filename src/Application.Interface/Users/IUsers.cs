using System.Threading.Tasks;

namespace Application.Interface.Users
{
    public interface IUsers
    {
        Task<bool> Register(Application.Model.Registration.Users model);
        Task<Application.Model.Registration.Users> Login(string ID);

        Task<Application.Model.Registration.Users> CheckIfIDExist(string IDNumber);
    }
}
