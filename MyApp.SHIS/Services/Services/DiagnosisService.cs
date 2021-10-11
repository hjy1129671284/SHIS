using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class DiagnosisService : BaseService<diagnosis>, IDiagnosisService
    {
        private readonly IDiagnosisRepository _idiagnosisRepository;

        public DiagnosisService(IDiagnosisRepository idiagnosisRepository)
        {
            base._iBaseRepository = idiagnosisRepository;
            _idiagnosisRepository = idiagnosisRepository;
        }
    }
}