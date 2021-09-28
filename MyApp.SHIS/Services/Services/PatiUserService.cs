using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class PatiUserService : BaseService<pati_user>, IPatiUserService
    {
        private readonly IPatiUserRepository _iPatiUserRepository;
        public PatiUserService(IPatiUserRepository iPatiUserRepository)
        {
            base._iBaseRepository = iPatiUserRepository;
            _iPatiUserRepository = iPatiUserRepository;
        }
    }
}