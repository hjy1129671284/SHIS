using Models;
using MyApp.SHIS.Repository.IRepository;

namespace MyApp.SHIS.Repository.Repository
{
    public class UserRepository : BaseRepository<user>, IUserRepository
    {
        public UserRepository()
        {
            
        }
    }
}