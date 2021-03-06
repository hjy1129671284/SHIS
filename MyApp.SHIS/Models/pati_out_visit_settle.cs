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
           /// Desc:付款日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime SettleDate {get;set;}

           /// <summary>
           /// Desc:支付方式
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PayType {get;set;}

           /// <summary>
           /// Desc:应付金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal PayAmount {get;set;}

           /// <summary>
           /// Desc:实付金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal PaidAmount {get;set;}

           /// <summary>
           /// Desc:找零
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal ChangeAmount {get;set;}

           /// <summary>
           /// Desc:职工编号 FK， 引用 Staff 表的 staffID
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
