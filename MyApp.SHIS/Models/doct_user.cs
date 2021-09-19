using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("doct_user")]
    public partial class doct_user
    {
           public doct_user(){


           }
           /// <summary>
           /// Desc:医生编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int DoctID {get;set;}

           /// <summary>
           /// Desc:用户名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:医生姓名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DoctName {get;set;}

           /// <summary>
           /// Desc:医生科室
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DoctDept {get;set;}

           /// <summary>
           /// Desc:医生职位
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DoctPosn {get;set;}

           /// <summary>
           /// Desc:医生工作状态    	0 休息    	1 工作
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int DoctWork {get;set;}

    }
}
