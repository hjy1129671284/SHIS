using System;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using MyApp.SHIS.Repository.Repository;
using MyApp.SHIS.Services.Services;
using MyApp.SHIS.View.Windows;

namespace MyApp.SHIS.View.Pages
{
    public partial class MyAccountPage : Page
    {
        private string _userName;
        private DashBoardView _context;
        public MyAccountPage(string userName, DashBoardView context)
        {
            _userName = userName;
            _context = context;
            InitializeComponent();

            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == userName).Result;
            // 个人信息根据查 norm_user 表初始化
            if (result != null && result.Count > 0)
            {
                var user = result[0];
                HintAssist.SetHint(UserSexTextComboBox, user.SexName);
                HintAssist.SetHint(IDCardTypeTextComboBox, user.IDCardTypeName);
                HintAssist.SetHint(UserAuthNameTextBox, user.UserAuthName);
                HintAssist.SetHint(MobileNumTextBox, user.MobileNum);
                HintAssist.SetHint(PersonEmailTextBox, user.UserEmail);
                HintAssist.SetHint(OccupationComboBox, user.OccupationName);
                HintAssist.SetHint(RegiLocTextBox, user.RegiLocName);
                HintAssist.SetHint(CountryTextBox, user.CountryName);
                HintAssist.SetHint(NationalityComboBox, user.NationalityName);
                HintAssist.SetHint(NativePlaceTextBox, user.NativePlaceName);
                HintAssist.SetHint(RegiLocPostCodeTextBox, user.RegiLocPostCode);
                HintAssist.SetHint(BloodTypeTextBlock, user.BloodType);
                if (user.IDCard != null) HintAssist.SetHint(IDCardTextBox, user.IDCard);
                if (user.BirthDate != null) HintAssist.SetHint(BirthDatePicker, user.BirthDate);
                if (user.RetireTypeID != null) HintAssist.SetHint(RetireTypeComboBox, user.RetireTypeID);
                if (user.MedCardNum != null) HintAssist.SetHint(MedCardNumTextBox, user.MedCardNum);
                if (user.BirthDate != null) 
                    HintAssist.SetHint(UserAgeTextBox, DateTime.Now.Year - user.BirthDate.Value.Year);
                if (user.IDAuther != null)
                {
                    if (user.IDAuther == 0)
                    {
                        HintAssist.SetHint(IDAutherTextBox, "未认证");
                        IDAutherButton.Content = "去认证";
                    }
                    else
                    {
                        HintAssist.SetHint(IDAutherTextBox, "已认证");
                        IDAutherButton.Content = "取消认证";
                    }

                }
                if (user.IDAutherMethod != null)
                {
                    HintAssist.SetHint(IDAutherMethodComboBox, user.IDAutherMethod);
                    IDAutherMethodComboBox.IsEnabled = true;
                    IDAutherMethodButton.IsEnabled = true;
                    UserAuthNameButton.IsEnabled = true;
                }
                else
                {
                    IDAutherMethodComboBox.Text = "未认证";
                }
                if (user.MarriedID != null)
                {
                    switch (user.MarriedID)
                    {
                        case 10: HintAssist.SetHint(MarriedComboBox, "未婚"); break;
                        case 20: HintAssist.SetHint(MarriedComboBox, "已婚"); break;
                        case 21: HintAssist.SetHint(MarriedComboBox, "已婚-初婚"); break;
                        case 22: HintAssist.SetHint(MarriedComboBox, "已婚-再婚"); break;
                        case 23: HintAssist.SetHint(MarriedComboBox, "已婚-复婚"); break;
                        case 30: HintAssist.SetHint(MarriedComboBox, "丧偶"); break;
                        case 40: HintAssist.SetHint(MarriedComboBox, "离婚");; break;
                        default:HintAssist.SetHint(MarriedComboBox, "");; break;
                    }
                }
            }

            if (IDCardTypeTextComboBox.SelectionBoxItem.ToString() == "其他证件类型")
            {
                IDCardTypeTextComboBox.Visibility = Visibility.Collapsed;
                QTZJLXTextBox.Visibility = Visibility.Visible;
            }
        }
        

        private async void UserAgeButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            int age = Convert.ToInt32(UserAgeTextBox.Text);
            DateTime now = DateTime.Now;
            int birthYear = now.Year - age;
            DateTime birthDate = new DateTime(birthYear, now.Month, now.Day);

            user.BirthDate = birthDate;
            BirthDatePicker.SelectedDate = birthDate;

            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        private async void UserSexButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            string sex = UserSexTextComboBox.SelectionBoxItem.ToString();
            user.SexName = sex;
            if (sex == "  ") user.SexID = 0;
            else if (sex == "男") user.SexID = 1;
            else if (sex == "女") user.SexID = 2;
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        private async void IDCardTypeButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];
            
            user.IDCardTypeName = IDCardTypeTextComboBox.SelectionBoxItem.ToString() == 
                                  "其他证件类型" ? QTZJLXTextBox.Text : IDCardTypeTextComboBox.SelectionBoxItem.ToString();
            switch (user.IDCardTypeName)
            {
                case "身份证": user.IDCardTypeID = 100001; break;
                case "军人证": user.IDCardTypeID = 100002; break;
                case "护照": user.IDCardTypeID = 100003; break;
                case "户口本": user.IDCardTypeID = 100004; break;
                case "外国人永久居留证": user.IDCardTypeID = 100005; break;
                case "武警证": user.IDCardTypeID = 100006; break;
                case "公章": user.IDCardTypeID = 100007; break;
                case "工商营业执照": user.IDCardTypeID = 100008; break;
                case "法人代码证": user.IDCardTypeID = 100009; break;
                case "学生证": user.IDCardTypeID = 100010; break;
                case "士兵证": user.IDCardTypeID = 100011; break;
                case "港澳居民来往内地通行证": user.IDCardTypeID = 100016; break;
                case "台湾居民来往大陆通行证": user.IDCardTypeID = 100017; break;
                default: user.IDCardTypeID = 10018; break;
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        private async void IDCardButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            if(int.TryParse(IDCardTextBox.Text, out int num))
                user.IDCard = num;
            else
            {
                MessageBox.Show("请填写正确的证件号");
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
        }

        private async void IDAutherButton_OnClick(object sender, RoutedEventArgs e)
        {
            if ((string) IDAutherButton.Content == "去认证")
            {
                _context.ContentControl.Content = new Frame()
                {
                    Content = new VerifiedPage()
                };
            }
            else
            {
                NormUserService normUserService = new NormUserService(new NormUserRepository());
                var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
                var user = result[0];

                user.IDAuther = 0;
                user.IDAutherMethod = null;

                bool isEdit = await normUserService.EditAsync(user);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
            
        }
        
        private async void IDAutherMethodButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            user.IDAuther = 0;
            user.IDAutherMethod = null;
            user.UserAuthName = null;

            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
            _context.ContentControl.Content = new Frame()
            {
                Content = new VerifiedPage()
            };
        }
        
        
        private async void UserAuthNameButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            user.IDAuther = 0;
            user.IDAutherMethod = null;
            user.UserAuthName = null;

            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
            _context.ContentControl.Content = new Frame()
            {
                Content = new VerifiedPage()
            };
        }
        
        private async void BirthDateButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];


            if (BirthDatePicker.SelectedDate != null)
            {
                user.BirthDate = BirthDatePicker.SelectedDate.Value;
                
                bool isEdit = await normUserService.EditAsync(user);
                MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            }
        }
        
        private async void MobileNumButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            user.MobileNum = MobileNumTextBox.Text;
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
        }
        
        private async void PersonEmailButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            user.UserEmail = PersonEmailTextBox.Text;
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
        }
        
        private async void OccupationButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            user.OccupationName = OccupationComboBox.SelectionBoxItem.ToString();

            switch (OccupationComboBox.SelectionBoxItem.ToString())
            {
                case "国家机关、党群组织、企业、事业单位负责人": user.OccupationID = 10000; break;
                case "专业技术人员": user.OccupationID = 20000; break;
                case "办事人员和有关人员": user.OccupationID = 30000; break;
                case "商业、服务业人员": user.OccupationID = 40000; break;
                case "农、林、牧、渔、水利业生产人员": user.OccupationID = 50000; break;
                case "生产、运输设备操作人员及有关人员": user.OccupationID = 60000; break;
                case "军人": user.OccupationID = 70000; break;
                case "无职业者分类及代码": user.OccupationID = 80000; break;
                case "不便分类的其他人群": user.OccupationID = 90000; break;
                case "不知道": user.OccupationID = -1; break;
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
        }
        
        private async void MarriedButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            string marriedType = MarriedComboBox.SelectionBoxItem.ToString();

            switch (marriedType)
            {
                case "未婚": user.MarriedID = 10; break;
                case "已婚": user.MarriedID = 10; break;
                case "已婚-初婚": user.MarriedID = 10; break;
                case "已婚-再婚": user.MarriedID = 10; break;
                case "已婚-复婚": user.MarriedID = 10; break;
                case "丧偶": user.MarriedID = 10; break;
                case "离婚": user.MarriedID = 10; break;
                default: user.MarriedID = 0; break;
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
        }
        
        private async void RetireTypeButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            switch (RetireTypeComboBox.SelectionBoxItem.ToString())
            {
                case "退休": user.RetireTypeID = 0; break;
                case "在职": user.RetireTypeID = 1; break;
                default: user.RetireTypeID = null; break;
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
        }
        
        private async void CountryButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            // TODO
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
        }
        
        private async void NationalityButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            switch (NationalityComboBox.SelectionBoxItem.ToString())
            {
                case "汉族": user.NationalityID = 01; break;
                case "蒙古族": user.NationalityID = 02; break;
                case "回族": user.NationalityID = 03; break;
                case "藏族": user.NationalityID = 04; break;
                case "维吾尔族": user.NationalityID = 05; break;
                case "苗族": user.NationalityID = 06; break;
                case "彝族": user.NationalityID = 07; break;
                case "壮族": user.NationalityID = 08; break;
                case "布依族": user.NationalityID = 09; break;
                case "朝鲜族": user.NationalityID = 10; break;
                case "满族": user.NationalityID = 11; break;
                case "侗族": user.NationalityID = 12; break;
                case "瑶族": user.NationalityID = 13; break;
                case "白族": user.NationalityID = 14; break;
                case "土家族": user.NationalityID = 15; break;
                case "哈尼族": user.NationalityID = 16; break;
                case "哈萨克族": user.NationalityID = 17; break;
                case "傣族": user.NationalityID = 18; break;
                case "黎族": user.NationalityID = 19; break;
                case "傈僳族": user.NationalityID = 20; break;
                case "佤族": user.NationalityID = 21; break;
                case "畲族": user.NationalityID = 22; break;
                case "高山族": user.NationalityID = 23; break;
                case "拉祜族": user.NationalityID = 24; break;
                case "水族": user.NationalityID = 25; break;
                case "东乡族": user.NationalityID = 26; break;
                case "纳西族": user.NationalityID = 27; break;
                case "景颇族": user.NationalityID = 28; break;
                case "柯尔克孜族": user.NationalityID = 29; break;
                case "土族": user.NationalityID = 30; break;
                case "达斡尔族": user.NationalityID = 31; break;
                case "仫佬族": user.NationalityID = 32; break;
                case "羌族": user.NationalityID = 33; break;
                case "布朗族": user.NationalityID = 34; break;
                case "撒拉族": user.NationalityID = 35; break;
                case "毛难族": user.NationalityID = 36; break;
                case "仡佬族": user.NationalityID = 37; break;
                case "锡伯族": user.NationalityID = 38; break;
                case "阿昌族": user.NationalityID = 39; break;
                case "普米族": user.NationalityID = 40; break;
                case "塔吉克族": user.NationalityID = 41; break;
                case "怒族": user.NationalityID = 42; break;
                case "乌孜别克族": user.NationalityID = 43; break;
                case "俄罗斯族": user.NationalityID = 44; break;
                case "鄂温克族": user.NationalityID = 45; break;
                case "崩龙族": user.NationalityID = 46; break;
                case "保安族": user.NationalityID = 47; break;
                case "裕固族": user.NationalityID = 48; break;
                case "京族": user.NationalityID = 49; break;
                case "塔塔尔族": user.NationalityID = 50; break;
                case "独龙族": user.NationalityID = 51; break;
                case "鄂伦春族": user.NationalityID = 52; break;
                case "赫哲族": user.NationalityID = 53; break;
                case "门巴族": user.NationalityID = 54; break;
                case "珞巴族": user.NationalityID = 55; break;
                case "基诺族": user.NationalityID = 56; break;
                case "其他": user.NationalityID = 97; break;
                case "外国血统": user.NationalityID = 98; break;
                default: user.NationalityID = null; break;
            }
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
        }
        
        private async void NativePlaceButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
        }
        
        private async void RegiLocPostCodeButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
        }
        
        private async void BloodTypeButton_OnClick(object sender, RoutedEventArgs e)
        {
            NormUserService normUserService = new NormUserService(new NormUserRepository());
            var result = normUserService.QueryAsync(it => it.UserName == _userName).Result;
            var user = result[0];

            user.BloodType = BloodTypeComboBox.SelectionBoxItem.ToString();
            
            bool isEdit = await normUserService.EditAsync(user);
            MessageBox.Show(isEdit ? "修改成功" : "修改失败");
            
        }
        
    }
}