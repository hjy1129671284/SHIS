using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MyApp.SHIS.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("diagnosis")]
    public partial class diagnosis
    {
           public diagnosis(){


           }
           /// <summary>
           /// Desc:诊断编号
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int DiagID {get;set;}

           /// <summary>
           /// Desc:流水号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int SerialNumber {get;set;}

           /// <summary>
           /// Desc:患者编号
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
           /// Desc:诊断信息
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Diagnosis {get;set;}

           /// <summary>
           /// Desc:病历信息
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Record {get;set;}

           /// <summary>
           /// Desc:诊断时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime DiagTime {get;set;}

    }
}
