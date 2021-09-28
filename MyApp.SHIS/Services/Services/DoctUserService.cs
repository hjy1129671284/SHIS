using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class DoctUserService : BaseService<doct_user>, IDoctUserService
    {
        private readonly IDoctUserRepository _iDoctUserRepository;

        public DoctUserService(IDoctUserRepository iDoctUserRepository)
        {
            base._iBaseRepository = iDoctUserRepository;
            _iDoctUserRepository = iDoctUserRepository;
        }
    }
}