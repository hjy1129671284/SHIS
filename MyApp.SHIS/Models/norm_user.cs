using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace MyApp.SHIS.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("norm_user")]
    public partial class norm_user
    {
           public norm_user(){


           }
           /// <summary>
           /// Desc:普通用户编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int NormID {get;set;}

           /// <summary>
           /// Desc:用户名 FK
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:证件类型编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IDCardTypeID {get;set;}

           /// <summary>
           /// Desc:证件类型名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IDCardTypeName {get;set;}

           /// <summary>
           /// Desc:证件号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IDCard {get;set;}

           /// <summary>
           /// Desc:实名制认证状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IDAuther {get;set;}

           /// <summary>
           /// Desc:实名制认证方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IDAutherMethod {get;set;}

           /// <summary>
           /// Desc:用户真实姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserAuthName {get;set;}

           /// <summary>
           /// Desc:性别编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? SexID {get;set;}

           /// <summary>
           /// Desc:性别名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SexName {get;set;}

           /// <summary>
           /// Desc:出生日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? BirthDate {get;set;}

           /// <summary>
           /// Desc:手机号码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MobileNum {get;set;}

           /// <summary>
           /// Desc:用户Email
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UserEmail {get;set;}

           /// <summary>
           /// Desc:职业编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? OccupationID {get;set;}

           /// <summary>
           /// Desc:职业名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OccupationName {get;set;}

           /// <summary>
           /// Desc:户口所在地编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? RegiLocID {get;set;}

           /// <summary>
           /// Desc:户口所在地名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RegiLocName {get;set;}

           /// <summary>
           /// Desc:婚姻状态编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MarriedID {get;set;}

           /// <summary>
           /// Desc:国籍编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? CountryID {get;set;}

           /// <summary>
           /// Desc:国籍名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CountryName {get;set;}

           /// <summary>
           /// Desc:籍贯地编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? NativePlaceID {get;set;}

           /// <summary>
           /// Desc:籍贯地名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NativePlaceName {get;set;}

           /// <summary>
           /// Desc:民族编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? NationalityID {get;set;}

           /// <summary>
           /// Desc:民族名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NationalityName {get;set;}

           /// <summary>
           /// Desc:职退状态编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? RetireTypeID {get;set;}

           /// <summary>
           /// Desc:户口所在地邮编
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RegiLocPostCode {get;set;}

           /// <summary>
           /// Desc:血型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BloodType {get;set;}

           /// <summary>
           /// Desc:医疗卡号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MedCardNum {get;set;}

           /// <summary>
           /// Desc:余额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? Gold {get;set;}

    }
}
