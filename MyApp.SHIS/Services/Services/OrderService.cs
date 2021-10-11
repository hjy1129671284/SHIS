using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class OrderService : BaseService<order>, IOrderService
    {
        private readonly IOrderRepository _iOrderRepository;

        public OrderService(IOrderRepository iOrderRepository)
        {
            base._iBaseRepository = iOrderRepository;
            _iOrderRepository = iOrderRepository;
        }
    }
}