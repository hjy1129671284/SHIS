using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("rgst_user")]
    public partial class rgst_user
    {
           public rgst_user(){


           }
           /// <summary>
           /// Desc:挂号员编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int RgstID {get;set;}

           /// <summary>
           /// Desc:用户名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:挂号员姓名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RgstName {get;set;}

           /// <summary>
           /// Desc:挂号员工作状态
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RgstWork {get;set;}

    }
}
