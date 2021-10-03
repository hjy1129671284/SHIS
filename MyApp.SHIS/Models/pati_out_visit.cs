using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MyApp.SHIS.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("pati_out_visit")]
    public partial class pati_out_visit
    {
           public pati_out_visit(){


           }
           /// <summary>
           /// Desc:PK
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int SerialNumber {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? QueueNo {get;set;}

           /// <summary>
           /// Desc:FK，引用pati表的PatiID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int PatiID {get;set;}

           /// <summary>
           /// Desc:FK，引用pati表的MedCardNum
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MedCardNum {get;set;}

           /// <summary>
           /// Desc:FK，引用pati表的PatiName
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PatiName {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string YBType {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RegDate {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? VaildDate {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? VisitDate {get;set;}

           /// <summary>
           /// Desc:FK，引用doct表的DoctDept
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DoctDept {get;set;}

           /// <summary>
           /// Desc:FK，引用doct表的DoctID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int DoctID {get;set;}

           /// <summary>
           /// Desc:FK，引用staff表的staffID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RegtID {get;set;}

           /// <summary>
           /// Desc:0 未就诊    	1 已就诊
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int OutStatus {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TotalFee {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ReceiveFee {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PayType {get;set;}

    }
}
