#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/nicholasleo
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

namespace NicholasLeo.Homework.Models
{
    [CustomerAttribute(TableName = "User")]
    public class UserModel : BaseInfoModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int State { get; set; }
        public int UserType { get; set; }
        public DateTime? LastLoginTime { get; set; }
    }
}
