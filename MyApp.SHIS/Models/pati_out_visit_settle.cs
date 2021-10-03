using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MyApp.SHIS.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("pati_out_visit_settle")]
    public partial class pati_out_visit_settle
    {
           public pati_out_visit_settle(){


           }
           /// <summary>
           /// Desc:PK
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int SettleID {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime SettleDate {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal SettleAmount {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int StaffID {get;set;}

           /// <summary>
           /// Desc:FK，引用Pati_Out_Visit表的SerialNumber
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int SerialNumber {get;set;}

    }
}
