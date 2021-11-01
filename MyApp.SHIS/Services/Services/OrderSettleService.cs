using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class OrderSettleService : BaseService<order_settle>, IOrderSettleService
    {
        private readonly IOrderSettleRepository _iOrderSettleRepository;

        public OrderSettleService(IOrderSettleRepository iOrderSettleRepository)
        {
            base._iBaseRepository = iOrderSettleRepository;
            _iOrderSettleRepository = iOrderSettleRepository;
        }
    }
}