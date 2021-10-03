using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class PatiOutVisitService : BaseService<pati_out_visit>, IPatiOutVisitService
    {
        private readonly IPatiOutVisitRepository _ipatiOutVisitRepository;

        public PatiOutVisitService(IPatiOutVisitRepository iPatiOutVisitRepository)
        {
            base._iBaseRepository = iPatiOutVisitRepository;
            _ipatiOutVisitRepository = iPatiOutVisitRepository;
        }

    }
}