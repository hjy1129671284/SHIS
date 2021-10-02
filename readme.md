# 简单HIS系统



## 数据库设计

暂定以**使用流程**写表

##### 账号登录

###### 帐号表  -- > user

| 序号 | 字段名   | 字段描述 | 数据类型 | 长度 | 是否能为空 | 注释                                                         | 默认值         |
| ---- | -------- | -------- | -------- | ---- | ---------- | ------------------------------------------------------------ | -------------- |
| 01   | UserName | 用户名   | varchar  | 20   | False      | PK                                                           |                |
| 02   | UserPwd  | 密码     | varchar  | 20   |            | 应当加密                                                     | 暂定默认123456 |
| 03   | UserType | 身份     | nvarchar | 20   | False      | 1 普通用户   <br/>2 病人    <br/>3 医生    <br/>4 药师   <br/>5 挂号员    <br/>6 收费员       <br/>7 护士 | 1              |

###### 普通用户表  -- >  Norm_User

| 序号 | 字段名          | 字段描述       | 数据类型 | 长度 | 是否能为空 | 注释                                                         | 默认值 |
| ---- | --------------- | -------------- | -------- | ---- | ---------- | ------------------------------------------------------------ | ------ |
| 01   | NormID          | 普通用户编码   | int      | 20   | False      | 普通用户的唯一标识，PK                                       |        |
| 02   | UserName        | 用户名         | varchar  | 20   | False      | FK;                                                          |        |
| 03   | IDCardTypeID    | 证件类型编码   | int      | 6    |            | 查看[证件编码](https://www.cnblogs.com/liuhongfeng/p/4981472.html) | NULL   |
| 04   | IDCardTypeName  | 证件类型名称   | nvarchar | 15   |            |                                                              | NULL   |
| 05   | IDCard          | 证件号         | int      | 20   |            |                                                              | NULL   |
| 06   | IDAuther        | 实名制认证状态 | int      | 1    |            | 未认证(0) / 已认证(1)                                        | 0      |
| 07   | IDAutherMethod  | 实名制认证方式 | nvarchar | 10   |            | 1    HIS 认证<br />2    医院挂号网站认证<br />3    12320认证<br />4     ICBC认证<br />5     APP认证<br />6     卫计委保健局认证 | NULL   |
| 08   | UserAuthName    | 用户姓名       | nvarchar | 50   |            |                                                              |        |
| 09   | SexID           | 性别编码       | int      | 1    |            | 0/ 1 / 2                                                     | 0      |
| 10   | SexName         | 性别名称       | nvarchar | 10   |            | NULL(0)/男(1) /女(2)                                         | NULL   |
| 11   | BirthDate       | 出生日期       | datetime |      |            | YYYY-MM-DD                                                   | NULL   |
| 12   | MobileNum       | 手机号码       | string   | 15   |            |                                                              | NULL   |
| 13   | PersonEmail     | 用户Email      | nvarchar | 50   |            |                                                              | NULL   |
| 14   | OccupationID    | 职业编码       | int      | 6    |            | 查看[职业编码国标]([职业编码国标 - 百度文库 (baidu.com)](https://wenku.baidu.com/view/411f46530975f46526d3e14f.html)) | NULL   |
| 15   | OccupationName  | 职业名称       | nvarchar | 50   |            |                                                              | NULL   |
| 16   | RegiLocID       | 户口所在地编码 | int      | 15   |            | 查看[户籍地编码](https://www.docin.com/p-1682420446.html)    | NULL   |
| 17   | RegiLocName     | 户口所在地名称 | nvarchar | 50   |            |                                                              | NULL   |
| 18   | MarriedID       | 婚姻状态编码   | int      | 2    |            | 查看[婚姻状态代码](http://c.gb688.cn/bzgk/gb/showGb?type=online&hcno=00C2855745344E94D01AB6ACE6CC62CE) | NULL   |
| 19   | CountryID       | 国籍编码       | int      | 5    |            | 查看[国家代码](https://blog.csdn.net/tcjy1000/article/details/48242359) | NULL   |
| 20   | CountryName     | 国籍名称       | nvarchar | 20   |            |                                                              | NULL   |
| 21   | NativePlaceID   | 籍贯地编码     | int      | 15   |            | 查看[户籍地编码](https://www.docin.com/p-1682420446.html)    | NULL   |
| 22   | NativePlaceName | 籍贯地名称     | nvarchar | 50   |            |                                                              | NULL   |
| 23   | NationalityID   | 民族编码       | int      | 2    |            | 查看[民族编码](https://www.supfree.net/search.asp?id=6226)   | NULL   |
| 24   | NationalityName | 民族名称       | nvarchar | 10   |            |                                                              | NULL   |
| 25   | RetireTypeID    | 职退状态编码   | int      |      |            | ***暂时没查到***                                             | NULL   |
| 26   | RegiLocPostCode | 户口所在地邮编 | int      | 6    |            | [邮编查找](https://www.ip138.com/post/)                      | NULL   |
| 27   | BloodType       | 血型           | nvarchar | 10   |            | NULL/ A / B / AB / O 型血                                    | NULL   |
| 28   | MedCardNum      | 就诊卡号       | int      | 20   |            |                                                              | NULL   |

###### 病人表  -- > Pati_User

| 序号 | 字段名        | 字段描述         | 数据类型 | 长度 | 是否能为空 | 注释                                | 默认值 |
| ---- | ------------- | ---------------- | -------- | ---- | ---------- | ----------------------------------- | ------ |
| 01   | PatiID        | 病人编码         | int      | 20   | False      | 病人的唯一标识，PK                  |        |
| 02   | UserName      | 用户名           | varchar  | 20   | False      | FK1                                 |        |
| 03   | PatiCateID    | 病人类型编码     | int      | 20   |            | Pati_Category  ***不知道意思***     |        |
| 04   | SecretGradeID | 病历保密级别编码 | int      | 1    |            | 绝密(3)、机密(2)、秘密(1)、无(NULL) | NULL   |
| 05   | MedCardNum    | 就诊卡号         | int      | 20   | False      |                                     | NULL   |



###### 职工用户表  -- > Staf_User

| 序号 | 字段名   | 字段描述     | 数据类型 | 长度 | 是否能为空 | 注释                                                         | 默认值 |
| ---- | -------- | ------------ | -------- | ---- | ---------- | ------------------------------------------------------------ | ------ |
| 01   | StafID   | 职工编码     | int      | 20   | False      | 职工的唯一标识，PK                                           |        |
| 02   | UserName | 用户名       | varchar  | 20   | False      | FK1                                                          |        |
| 03   | StafName | 职工姓名     | varchar  | 20   | False      |                                                              |        |
| 04   | StafType | 职工类型     | int      | 1    | False      | 3 医生    <br/>4 药师   <br/>5 挂号员    <br/>6 收费员       <br/>7 护士 | 2      |
| 05   | StafWork | 职工工作状态 | int      | 1    | False      | 0 休息<br />1 工作                                           | 0      |
|      |          |              |          |      |            |                                                              |        |



###### 医生用户表  -- >  Doct_User

| 序号 | 字段名   | 字段描述     | 数据类型 | 长度 | 是否能为空 | 注释                             | 默认值 |
| ---- | -------- | ------------ | -------- | ---- | ---------- | -------------------------------- | ------ |
| 01   | DoctID   | 医生编码     | int      | 20   | False      | 医生的唯一标识，PK，FK           |        |
| 04   | DoctDept | 医生科室     | nvarchar | 20   | False      |                                  |        |
| 05   | DoctPosn | 医生职位     | nvarchar | 20   | False      |                                  |        |
| 06   | DoctWork | 医生工作状态 | int      | 1    | False      | 0 休息<br />1 待诊<br />2 就诊中 | 0      |



##### 病人操作



###### 病人家庭信息表  -- > Pati_Info_Family

| 序号 | 字段名         | 字段描述     | 数据类型 | 长度 | 是否能为空 | 注释                                                      | 默认值 |
| ---- | -------------- | ------------ | -------- | ---- | ---------- | --------------------------------------------------------- | ------ |
| 01   | PatiID         | 病人编码     | int      | 20   | False      | PK，FK1                                                   |        |
| 02   | AreaID         | 家庭地区编码 | int      | 15   |            | 查看[户籍地编码](https://www.docin.com/p-1682420446.html) | NULL   |
| 03   | AreaName       | 家庭地区名称 | nvarchar | 50   |            |                                                           | NULL   |
| 04   | FamilyAddr     | 家庭地址     | nvarchar | 50   |            |                                                           | NULL   |
| 05   | FamilyPostCode | 邮编         | int      | 6    |            | [邮编查找](https://www.ip138.com/post/)                   | NULL   |
| 06   | FamilyTeleNum  | 家庭电话     | string   | 15   |            |                                                           | NULL   |
|      |                |              |          |      |            |                                                           |        |

###### 病人单位信息表  -- > Pati_Info_WorkUnit

| 序号 | 字段名      | 字段描述       | 数据类型 | 长度 | 是否能为空 | 注释                                                      | 默认值 |
| ---- | ----------- | -------------- | -------- | ---- | ---------- | --------------------------------------------------------- | ------ |
| 01   | PatiID      | 病人编码       | int      | 20   | False      | PK，FK1                                                   |        |
| 02   | EntAreaID   | 单位区域编码   | int      | 15   |            | 查看[户籍地编码](https://www.docin.com/p-1682420446.html) | NULL   |
| 03   | EntAreaName | 单位区域名称   | nvarchar | 50   |            |                                                           | NULL   |
| 04   | EntName     | 单位名称       | nvarchar | 50   |            |                                                           | NULL   |
| 05   | EntAddr     | 单位地址       | nvarchar | 255  |            |                                                           | NULL   |
| 06   | EntTeleNum  | 单位电话       | string   | 15   |            |                                                           | NULL   |
| 07   | Contactor   | 单位联系人姓名 | nvarchar | 50   |            |                                                           |        |
| 08   | EntPostCode | 单位邮编       | int      | 6    |            | [邮编查找](https://www.ip138.com/post/)                   | NULL   |
|      |             |                |          |      |            |                                                           |        |

###### 病人联系人信息表 --> Pati_Info_Contactor

| 序号 | 字段名        | 字段描述         | 数据类型 | 长度 | 是否能为空 | 注释     | 默认值 |
| ---- | ------------- | ---------------- | -------- | ---- | ---------- | -------- | ------ |
| 01   | ContID        | 联系人编码       | int      | 20   | False      | PK， FK1 |        |
| 02   | ContName      | 联系人姓名       | nvarchar | 50   | False      |          |        |
| 03   | ContRltn      | 联系人与病人关系 | nvarchar | 10   | False      |          |        |
| 04   | ContTeleNum   | 联系人电话       | string   | 15   |            |          | NULL   |
| 05   | ContAddr      | 联系人地址       | nvarchar | 255  |            |          | NULL   |
| 06   | ContEmailAddr | 联系人Email地址  | nvarchar | 50   |            |          | NULL   |
| 07   | PatiID        | 病人编码         | int      | 20   | False      | FK2      |        |
|      |               |                  |          |      |            |          |        |

##### 挂号操作

###### 门诊号源排班表  -- > Pati_Out_Resource





###### 病人门诊登记表  -- > Pati_Out_Visit

| 序号 | 字段名       | 字段描述   | 数据类型 | 长度 | 是否能为空 | 注释                   | 默认值 |
| ---- | ------------ | ---------- | -------- | ---- | ---------- | ---------------------- | ------ |
| 01   | SerialNumber | 门诊流水号 | int      | 50   | False      | PK                     |        |
| 02   | QueueNo      | 挂号序号   | int      | 5    |            |                        |        |
| 03   | PatiID       | 患者编码   | int      | 20   | False      | FK1                    |        |
| 04   | MedCardNum   | 就诊卡号   | int      | 20   | False      |                        |        |
| 05   | PatiName     | 患者姓名   | nvarchar | 50   | False      |                        |        |
| 06   | YBType       | 医保类型   | nvarchar | 50   |            |                        |        |
| 07   | RegDate      | 挂号日期   | datetime |      |            |                        |        |
| 08   | VaildDate    | 号源日期   | datetime |      |            |                        |        |
| 09   | VisitDate    | 就诊日期   | datetime |      |            |                        |        |
| 10   | OrgID        | 就诊科室号 | int      | 10   | False      |                        |        |
| 11   | DoctID       | 专家号     | int      | 10   | False      |                        |        |
| 12   | RegtID       | 挂号员工号 | int      | 10   | False      |                        |        |
| 13   | OutStatus    | 门诊状态   | int      | 1    | False      | 0 未就诊<br />1 已就诊 |        |
| 14   | TotalFee     | 总金额     | decimal  | 10   |            |                        |        |
| 15   | ReceiveFee   | 实付金额   | decimal  | 10   |            |                        |        |



##### 医生操作

诊断信息表



处方信息表





##### 收费操作

###### 门诊访问结算表  -- > Pati_Out_Visit_Settle

| 序号 | 字段名       | 字段描述   | 数据类型 | 长度 | 是否能为空 | 注释 | 默认值 |
| ---- | ------------ | ---------- | -------- | ---- | ---------- | ---- | ------ |
| 01   | SettleID     | 结算号     | int      | 50   | False      | PK   |        |
| 02   | SettleDate   | 结算日期   | datatime |      |            |      |        |
| 03   | SettleAmount | 结算金额   | decimal  | 6，2 | False      |      |        |
| 04   | EMPID        | 操作员     | nvarchar | 10   |            |      |        |
| 05   | SerialNumber | 门诊流水号 | int      |      | False      |      |        |



###### 病人门诊登记收据表  -- > Pati_Out_Visit_Invoice







## 使用流程

### 一、通用户使用流程

#### 1. (无账号)账号注册

在 **AccountRegister **中

输入  **(用户名  ----  密码  ----  确认密码)**  进行账号注册。若帐号已在数据库中，则注册失败，需重新输入信息注册(可弹窗提示“是否**忘记密码**”)； 若帐号不在数据库中， 则提示注册成功。

#### 2. 帐号登录

> 账号权限
>
> 1. 管理员
> 2. 普通用户
> 3. 医生
> 4. 药师
> 5. 挂号员
> 6. 收费员
> 7. 护士

在 **MainWindow** 中

输入 (用户名  ----  密码)、选择登陆的用户权限 进行帐号登录。若帐号不在数据库中，则提示"帐号不存在，是否前往**注册帐号**"；若帐号存在数据库中，密码错误，则提示"密码错误，是否**忘记密码**"；若帐号存在数据库中且与其密码对应，则提示"登陆成功，欢迎 \$UserName\$ "。其中，普通用户权限可以由所有用户登录，病人权限可以由除了普通用户之外的用户登录，其余权限均只能由各自对应的用户登录







# TODO

- [ ] 我的账号页面(MyAccountPage)  	IDCardButton_OnClick 方法  写一个 证件号验证是否填写正确的判断代码
- [ ] 实名认证页面(IDAutherView) 制作
- [ ] 我的账号页面(MyAccountPage)  户籍地修改、 国籍修改 、 籍贯地、 邮编  编码太多，没想好办法
- [ ] 仪表盘(DashBoardView) 左侧控件选择多个的聚焦优化
- [ ] 准备切换成MVVM架构
- [ ] MVVM架构下的问题
  1. 如何在将 view 的窗口传递到 vm 中，使切换页面能在 vm 中实现
  2. 尝试使用 vm 传递参数，使 dashboard 的构造函数变为一个(目前是登录后的构造函数需要用到用户名和用户类型的参数)





