using System.Threading.Tasks;
using MyApp.SHIS.Models;
using MyApp.SHIS.Repository.IRepository;
using MyApp.SHIS.Services.IServices;

namespace MyApp.SHIS.Services.Services
{
    public class NormUserService : BaseService<norm_user>, INromUserService
    {
        private readonly INormUserRepository _iNormUserRepository;
        public NormUserService(INormUserRepository iNormUserRepository)
        {
            base._iBaseRepository = iNormUserRepository;
            _iNormUserRepository = iNormUserRepository;
        }

        #region 修改证件类型

        public async Task<bool> EditIDCardAsync(norm_user user, int? IDCardtype, string qtzklx)
        {
            switch (IDCardtype)
            {
                case 100001: user.IDCardTypeID = 100001; user.IDCardTypeName = "身份证"; break;
                case 100002: user.IDCardTypeID = 100002; user.IDCardTypeName = "军人证"; break;
                case 100003: user.IDCardTypeID = 100003; user.IDCardTypeName = "护照"; break;
                case 100004: user.IDCardTypeID = 100004; user.IDCardTypeName = "户口本"; break;
                case 100005: user.IDCardTypeID = 100005; user.IDCardTypeName = "外国人永久居留证"; break;
                case 100006: user.IDCardTypeID = 100006; user.IDCardTypeName = "武警证"; break;
                case 100007: user.IDCardTypeID = 100007; user.IDCardTypeName = "公章"; break;
                case 100008: user.IDCardTypeID = 100008; user.IDCardTypeName = "工商营业执照"; break;
                case 100009: user.IDCardTypeID = 100009; user.IDCardTypeName = "法人代码证"; break;
                case 100010: user.IDCardTypeID = 100010; user.IDCardTypeName = "学生证"; break;
                case 100011: user.IDCardTypeID = 100011; user.IDCardTypeName = "士兵证"; break;
                case 100016: user.IDCardTypeID = 100016; user.IDCardTypeName = "港澳居民来往内地通行证"; break;
                case 100017: user.IDCardTypeID = 100017; user.IDCardTypeName = "台湾居民来往大陆通行证"; break;
                case 100018: user.IDCardTypeID = 100018; user.IDCardTypeName = qtzklx; break;
                default: user.IDCardTypeID = null; user.IDCardTypeName = null; break;
            }
            
            return await this.EditAsync(user);
        }
        
        public async Task<bool> EditIDCardAsync(norm_user user, string IDCardtype, string qtzjlx)
        {
            switch (IDCardtype)
            {
                case "身份证": user.IDCardTypeID = 100001; user.IDCardTypeName = "身份证"; break;
                case "军人证": user.IDCardTypeID = 100002; user.IDCardTypeName = "军人证"; break;
                case "护照": user.IDCardTypeID = 100003; user.IDCardTypeName = "护照"; break;
                case "户口本": user.IDCardTypeID = 100004; user.IDCardTypeName = "户口本"; break;
                case "外国人永久居留证": user.IDCardTypeID = 100005; user.IDCardTypeName = "外国人永久居留证"; break;
                case "武警证": user.IDCardTypeID = 100006; user.IDCardTypeName = "武警证"; break;
                case "公章": user.IDCardTypeID = 100007; user.IDCardTypeName = "公章"; break;
                case "工商营业执照": user.IDCardTypeID = 100008; user.IDCardTypeName = "工商营业执照"; break;
                case "法人代码证": user.IDCardTypeID = 100009; user.IDCardTypeName = "法人代码证"; break;
                case "学生证": user.IDCardTypeID = 100010; user.IDCardTypeName = "学生证"; break;
                case "士兵证": user.IDCardTypeID = 100011; user.IDCardTypeName = "士兵证"; break;
                case "港澳居民来往内地通行证": user.IDCardTypeID = 100016; user.IDCardTypeName = "港澳居民来往内地通行证"; break;
                case "台湾居民来往大陆通行证": user.IDCardTypeID = 100017; user.IDCardTypeName = "台湾居民来往大陆通行证"; break;
                case "其他证件类型": user.IDCardTypeID = 100018; user.IDCardTypeName = qtzjlx; break;
                default: user.IDCardTypeID = null; user.IDCardTypeName = null; break;
            }
            
            return await this.EditAsync(user);
        }

        #endregion

        #region 修改性别

        public async Task<bool> EditGenderAsync(norm_user user, string genderName)
        {
            switch (genderName)
            {
                case "男": user.SexID = 1; user.SexName = "男"; break;
                case "女": user.SexID = 2; user.SexName = "女"; break;
                default: user.SexID = null; user.SexName = null; break;
            }
            return await this.EditAsync(user);
        }

        #endregion

        #region 修改职业

        public async Task<bool> EditOccupationAsync(norm_user user, int? occupationID)
        {
            user.OccupationID = occupationID;
            switch (occupationID)
            {
                case 10000: user.OccupationName = "国家机关、党群组织、企业、事业单位负责人"; break;
                case 20000: user.OccupationName = "专业技术人员"; break;
                case 30000: user.OccupationName = "办事人员和有关人员"; break;
                case 40000: user.OccupationName = "商业、服务业人员"; break;
                case 50000: user.OccupationName = "农、林、牧、渔、水利业生产人员"; break;
                case 60000: user.OccupationName = "生产、运输设备操作人员及有关人员"; break;
                case 70000: user.OccupationName = "军人"; break;
                case 80000: user.OccupationName = "无职业者分类及代码"; break;
                case 90000: user.OccupationName = "不便分类的其他人群"; break;
                case -1: user.OccupationName = "不知道"; break;
                default: user.OccupationName = null; user.OccupationName = null; break;
            }
            return await this.EditAsync(user);
        }
        
        public async Task<bool> EditOccupation(norm_user user, string occupationName)
        {
            user.OccupationName = occupationName;
            switch (occupationName)
            {
                case "国家机关、党群组织、企业、事业单位负责人": user.OccupationID = 10000; break;
                case "专业技术人员": user.OccupationID = 20000; break;
                case "办事人员和有关人员": user.OccupationID = 30000; break;
                case "商业、服务业人员": user.OccupationID = 40000; break;
                case "农、林、牧、渔、水利业生产人员": user.OccupationID = 50000; break;
                case "生产、运输设备操作人员及有关人员": user.OccupationID = 60000; break;
                case "军人": user.OccupationID = 70000; break;
                case "无职业者分类及代码": user.OccupationID = 80000; break;
                case "不便分类的其他人群": user.OccupationID = 90000; break;
                case "不知道": user.OccupationID = -1; break;
                default: user.OccupationID = null; user.OccupationName = null; break;
            }
            return await this.EditAsync(user);
        }


        #endregion

        #region 修改国籍(还没写)
        
        public async Task<bool> EditCountryAsync(norm_user user, string countryName)
        {
            user.CountryName = countryName;
            return await this.EditAsync(user);
        }

        #endregion

        #region 修改民族
        
        public async Task<bool> EditNationalityAsync(norm_user user, string nationalityName)
        {
            user.NationalityName = nationalityName;
            switch (nationalityName)
            {
                case "汉族": user.NationalityID = 01; break;
                case "蒙古族": user.NationalityID = 02; break;
                case "回族": user.NationalityID = 03; break;
                case "藏族": user.NationalityID = 04; break;
                case "维吾尔族": user.NationalityID = 05; break;
                case "苗族": user.NationalityID = 06; break;
                case "彝族": user.NationalityID = 07; break;
                case "壮族": user.NationalityID = 08; break;
                case "布依族": user.NationalityID = 09; break;
                case "朝鲜族": user.NationalityID = 10; break;
                case "满族": user.NationalityID = 11; break;
                case "侗族": user.NationalityID = 12; break;
                case "瑶族": user.NationalityID = 13; break;
                case "白族": user.NationalityID = 14; break;
                case "土家族": user.NationalityID = 15; break;
                case "哈尼族": user.NationalityID = 16; break;
                case "哈萨克族": user.NationalityID = 17; break;
                case "傣族": user.NationalityID = 18; break;
                case "黎族": user.NationalityID = 19; break;
                case "傈僳族": user.NationalityID = 20; break;
                case "佤族": user.NationalityID = 21; break;
                case "畲族": user.NationalityID = 22; break;
                case "高山族": user.NationalityID = 23; break;
                case "拉祜族": user.NationalityID = 24; break;
                case "水族": user.NationalityID = 25; break;
                case "东乡族": user.NationalityID = 26; break;
                case "纳西族": user.NationalityID = 27; break;
                case "景颇族": user.NationalityID = 28; break;
                case "柯尔克孜族": user.NationalityID = 29; break;
                case "土族": user.NationalityID = 30; break;
                case "达斡尔族": user.NationalityID = 31; break;
                case "仫佬族": user.NationalityID = 32; break;
                case "羌族": user.NationalityID = 33; break;
                case "布朗族": user.NationalityID = 34; break;
                case "撒拉族": user.NationalityID = 35; break;
                case "毛难族": user.NationalityID = 36; break;
                case "仡佬族": user.NationalityID = 37; break;
                case "锡伯族": user.NationalityID = 38; break;
                case "阿昌族": user.NationalityID = 39; break;
                case "普米族": user.NationalityID = 40; break;
                case "塔吉克族": user.NationalityID = 41; break;
                case "怒族": user.NationalityID = 42; break;
                case "乌孜别克族": user.NationalityID = 43; break;
                case "俄罗斯族": user.NationalityID = 44; break;
                case "鄂温克族": user.NationalityID = 45; break;
                case "崩龙族": user.NationalityID = 46; break;
                case "保安族": user.NationalityID = 47; break;
                case "裕固族": user.NationalityID = 48; break;
                case "京族": user.NationalityID = 49; break;
                case "塔塔尔族": user.NationalityID = 50; break;
                case "独龙族": user.NationalityID = 51; break;
                case "鄂伦春族": user.NationalityID = 52; break;
                case "赫哲族": user.NationalityID = 53; break;
                case "门巴族": user.NationalityID = 54; break;
                case "珞巴族": user.NationalityID = 55; break;
                case "基诺族": user.NationalityID = 56; break;
                case "其他": user.NationalityID = 97; break;
                case "外国血统": user.NationalityID = 98; break;
                default: user.NationalityID = null; user.NationalityName = null; break;
            }
            
            return await this.EditAsync(user);
        }

        #endregion

        #region 修改籍贯地(还没写)
        
        public async Task<bool> EditNativePlaceAsync(norm_user user, string nativePlaceName)
        {
            user.NativePlaceName = nativePlaceName;
            return await this.EditAsync(user);
        }

        #endregion
    }
}