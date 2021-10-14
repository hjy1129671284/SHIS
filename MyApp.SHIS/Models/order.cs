using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MyApp.SHIS.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("order")]
    public partial class order
    {
           public order(){


           }
           /// <summary>
           /// Desc:医嘱编号 ，PK
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int OrderID {get;set;}

           /// <summary>
           /// Desc:流水号， FK，引用Pati_Out_Visit表的SerialNumber
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int SerialNumber {get;set;}

           /// <summary>
           /// Desc:患者编号， FK，引用Pati_Out_Visit表的PatiID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int PatiID {get;set;}

           /// <summary>
           /// Desc:医生编号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int DoctID {get;set;}

           /// <summary>
           /// Desc:医嘱时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime OrderTime {get;set;}

           /// <summary>
           /// Desc:药品编号， FK，引用Medicine表的MedicineID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MedicineID {get;set;}

           /// <summary>
           /// Desc:药品数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MedicineAmount {get;set;}

           /// <summary>
           /// Desc:总金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TotalPay {get;set;}

           /// <summary>
           /// Desc:医嘱状态， 0：未执行 1：已执行
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int OrderType {get;set;}

    }
}
