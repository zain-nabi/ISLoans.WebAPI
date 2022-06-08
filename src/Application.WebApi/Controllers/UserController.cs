using Application.Interface.Users;
using Application.Model.Registration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly  IUsers _users;

        public UserController(IUsers users)
        {
            _users = users;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<bool> Register(Users model)
        {
            return await _users.Register(model);
        }

        [Route("Login")]
        [HttpGet]
        public async Task<Users> Login(string ID)
        {
            return await _users.Login(ID);
        }

        [Route("CheckIfIDExist")]
        [HttpGet]
        public async Task<Users> CheckIfIDExist(string IDNumber)
        {
            return await _users.CheckIfIDExist(IDNumber);
        }
    }
}
