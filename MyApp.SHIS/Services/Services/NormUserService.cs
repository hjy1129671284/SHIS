using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class NormUserService : BaseService<norm_user>, INromUserService
    {
        private readonly INormUserRepository _iNormUserRepository;
        public NormUserService(INormUserRepository iNormUserRepository)
        {
            base._iBaseRepository = iNormUserRepository;
            _iNormUserRepository = iNormUserRepository;
        }
    }
}