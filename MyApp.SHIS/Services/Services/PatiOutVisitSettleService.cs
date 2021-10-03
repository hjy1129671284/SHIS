using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class PatiOutVisitSettleService : BaseService<pati_out_visit_settle>, IPatiOutVisitSettleService
    {
        private readonly IPatiOutVisitSettleRepository _iPatiOutVisitSettleRepository;

        public PatiOutVisitSettleService(IPatiOutVisitSettleRepository iPatiOutVisitSettleRepository)
        {
            base._iBaseRepository = iPatiOutVisitSettleRepository;
            _iPatiOutVisitSettleRepository = iPatiOutVisitSettleRepository;
        }
    }
}