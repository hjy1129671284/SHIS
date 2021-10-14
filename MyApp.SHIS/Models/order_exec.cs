using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MyApp.SHIS.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("order_exec")]
    public partial class order_exec
    {
           public order_exec(){


           }
           /// <summary>
           /// Desc:执行编号, PK
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int ExecID {get;set;}

           /// <summary>
           /// Desc:医嘱编号, FK， 引用Order表的OrderID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int OrderID {get;set;}

           /// <summary>
           /// Desc:药师编号, FK， 引用staff表的StaffId
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int StaffID {get;set;}

           /// <summary>
           /// Desc:执行时间, 当前时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime ExecTime {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Note {get;set;}

    }
}
