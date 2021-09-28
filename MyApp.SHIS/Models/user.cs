using SqlSugar;

namespace MyApp.SHIS.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("user")]
    public partial class user
    {
           public user(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int UserID {get;set;}

           /// <summary>
           /// Desc:用户名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:123456
           /// Nullable:True
           /// </summary>           
           public string UserPwd {get;set;}

           /// <summary>
           /// Desc:身份     	0 管理员    	1 普通用户   	2 病人    	3 医生    	4 药师   	5 挂号员    	6 收费员       	7 护士
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int UserType {get;set;}

    }
}
