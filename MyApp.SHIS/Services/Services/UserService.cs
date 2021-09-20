using Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class UserService : BaseService<user>, IUserService
    {
        private readonly IUserRepository _iUserRepository;
        public UserService(IUserRepository iUserRepository)
        {
            base._iBaseRepository = iUserRepository;
            _iUserRepository = iUserRepository;
        }
    }
}