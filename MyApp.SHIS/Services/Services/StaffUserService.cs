using Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class StaffUserService : BaseService<staff_user>, IStaffUserService
    {
        private readonly IStaffUserRepository _iStaffUserRepository;

        public StaffUserService(IStaffUserRepository iStaffUserRepository)
        {
            base._iBaseRepository = iStaffUserRepository;
            _iStaffUserRepository = iStaffUserRepository;
        }
    }
}