using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MyApp.SHIS.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("pati_user")]
    public partial class pati_user
    {
           public pati_user(){


           }
           /// <summary>
           /// Desc:病人编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int PatiID {get;set;}

           /// <summary>
           /// Desc:普通用户编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int NormID {get;set;}

           /// <summary>
           /// Desc:用户名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:用户姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserAuthName {get;set;}

           /// <summary>
           /// Desc:就诊卡号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MedCardNum {get;set;}

           /// <summary>
           /// Desc:病历保密级别编码，绝密(3)、机密(2)、秘密(1)、无(0)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int SecretGradeID {get;set;}

           /// <summary>
           /// Desc:病人类型编码
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int PatiCateID {get;set;}

    }
}
