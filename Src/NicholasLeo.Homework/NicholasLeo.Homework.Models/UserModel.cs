#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/Nicholasleo/DoNetAdvancedClassHomework
* 项目名称 ：NicholasLeo.Homework.Models
* 项目描述 ：类-
* 类 名 称 ：UserModel
* 类 描 述 ：
* 所在的域 ：NICHOLAS-LEO
* 命名空间 ：NicholasLeo.Homework.Models
* 机器名称 ：NICHOLAS-LEO 
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2019-10-24 22:34:15
* 修 改 人 : NicholasLeo
* 更新时间 ：2019-10-24 22:34:15
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ NicholasLeo 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using NicholasLeo.Homework.Commond;
using System;
using System.ComponentModel;

namespace NicholasLeo.Homework.Models
{
    [CustomerAttribute(TableName = "User")]
    public class UserModel : BaseInfoModel
    {
        [Required(ErrorMessage = "请输入用户账号")]
        [Description("用户账号")]
        public string Account { get; set; }
        [Description("密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }
        [Required(ErrorMessage ="请输入正确的email")]
        [Regex(RegexText = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        [Description("E-Mail")]
        public string Email { get; set; }
        [Description("手机")]
        public string Mobile { get; set; }
        [Description("公司NO")]
        public int CompanyId { get; set; }
        [Description("公司名称")]
        public string CompanyName { get; set; }
        [Description("状态")]
        public int State { get; set; }
        [Description("用户类型")]
        public int UserType { get; set; }
        [Description("最近登录时间")]
        public DateTime? LastLoginTime { get; set; }
    }
}
