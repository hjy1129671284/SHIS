using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
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
           /// Desc:用户名
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserName {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserPwd {get;set;}

           /// <summary>
           /// Desc:身份     	1 普通用户   	2 病人    	2 医生    	3 挂号员    	4 收费员    
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public string UserType {get;set;}

    }
}
