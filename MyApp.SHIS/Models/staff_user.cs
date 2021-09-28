using SqlSugar;

namespace MyApp.SHIS.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("staff_user")]
    public partial class staff_user
    {
           public staff_user(){


           }
           /// <summary>
           /// Desc:职工编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int StaffID {get;set;}

           /// <summary>
           /// Desc:FK1
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:职工姓名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string StafName {get;set;}

           /// <summary>
           /// Desc:职工类型    	3 医生    	4 药师   	5 挂号员    	6 收费员       	7 护士
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int StafType {get;set;}

           /// <summary>
           /// Desc:职工工作状态    	0 休息    	1 工作
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int StafWork {get;set;}

    }
}
