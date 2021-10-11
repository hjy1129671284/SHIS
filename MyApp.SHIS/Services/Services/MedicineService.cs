using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class MedicineService : BaseService<medicine>, IMedicineService
    {
        private readonly IMedicineRepository _iMedicineRepository;

        public MedicineService(IMedicineRepository iMedicineRepository)
        {
            base._iBaseRepository = iMedicineRepository;
            _iMedicineRepository = iMedicineRepository;
        }
    }
}