using System.Threading.Tasks;
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

        
        // 根据norm表创建pati表
        // public async Task<bool> CreateByNormAsynv(norm_user normUser, int medCardNum)
        // {
        //     pati_user patiUser = new pati_user
        //                         {
        //                             NormID = normUser.NormID,
        //                             UserName = normUser.UserName,
        //                             MedCardNum = medCardNum,
        //                             IDCardTypeID = normUser.IDCardTypeID,
        //                             IDCardTypeName = normUser.IDCardTypeName,
        //                             IDCard = normUser.IDCard,
        //                             IDAuther = normUser.IDAuther,
        //                             IDAutherMethod = normUser.IDAutherMethod,
        //                             UserAuthName = normUser.UserAuthName,
        //                             SexID = normUser.SexID,
        //                             SexName = normUser.SexName,
        //                             BirthDate = normUser.BirthDate,
        //                             MobileNum = normUser.MobileNum,
        //                             UserEmail = normUser.UserEmail,
        //                             OccupationID = normUser.OccupationID,
        //                             OccupationName = normUser.OccupationName,
        //                             RegiLocID = normUser.RegiLocID,
        //                             RegiLocName = normUser.RegiLocName,
        //                             MarriedID = normUser.MarriedID,
        //                             CountryID = normUser.MarriedID,
        //                             CountryName = normUser.CountryName,
        //                             NativePlaceID = normUser.NativePlaceID,
        //                             NativePlaceName = normUser.NativePlaceName,
        //                             NationalityID = normUser.NationalityID,
        //                             NationalityName = normUser.NationalityName,
        //                             RetireTypeID = normUser.RetireTypeID,
        //                             RegiLocPostCode = normUser.RegiLocPostCode,
        //                             BloodType = normUser.BloodType
        //                         };
        //     return await this.EditAsync(patiUser);
        // }
    }
}