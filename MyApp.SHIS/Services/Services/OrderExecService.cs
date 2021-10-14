using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class OrderExecService : BaseService<order_exec>, IOrderExecService
    {
        private readonly IOrderExexRepository _iorderExecRepository;

        public OrderExecService(IOrderExexRepository iorderExecRepository)
        {
            base._iBaseRepository = iorderExecRepository;
            _iorderExecRepository = iorderExecRepository;
        }
    }
}