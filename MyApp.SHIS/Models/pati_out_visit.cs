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
           /// Desc:PK  门诊流水号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int SerialNumber {get;set;}

           /// <summary>
           /// Desc:挂号序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? QueueNo {get;set;}

           /// <summary>
           /// Desc:FK，引用pati表的PatiID  患者编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int PatiID {get;set;}

           /// <summary>
           /// Desc:FK，引用pati表的MedCardNum  就诊卡号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MedCardNum {get;set;}

           /// <summary>
           /// Desc:FK，引用pati表的PatiName  患者姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PatiName {get;set;}

           /// <summary>
           /// Desc:医保类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string YBType {get;set;}

           /// <summary>
           /// Desc:挂号日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RegDate {get;set;}

           /// <summary>
           /// Desc:号源日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime VaildDate {get;set;}

           /// <summary>
           /// Desc:就诊日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? VisitDate {get;set;}

           /// <summary>
           /// Desc:FK，引用doct表的DoctDept  就诊科室号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DoctDept {get;set;}

           /// <summary>
           /// Desc:FK，引用doct表的DoctID  医生编号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int DoctID {get;set;}

           /// <summary>
           /// Desc:FK，引用staff表的staffID  挂号员工号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RegtID {get;set;}

           /// <summary>
           /// Desc:0 未就诊    	1 已就诊    	门诊状态
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int OutStatus {get;set;}

           /// <summary>
           /// Desc:应付金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? PayAmount {get;set;}

           /// <summary>
           /// Desc:实付金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? PaidAmount {get;set;}

           /// <summary>
           /// Desc:支付方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PayType {get;set;}

    }
}
