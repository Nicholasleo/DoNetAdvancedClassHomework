#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/nicholasleo
* 项目名称 ：NicholasLeo.Homework.Factory
* 项目描述 ：类-
* 类 名 称 ：DBContextFactory
* 类 描 述 ：
* 所在的域 ：NICHOLAS-LEO
* 命名空间 ：NicholasLeo.Homework.Factory
* 机器名称 ：NICHOLAS-LEO 
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2019-10-25 23:04:27
* 修 改 人 : NicholasLeo
* 更新时间 ：2019-10-25 23:04:27
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ NicholasLeo 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using NicholasLeo.Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NicholasLeo.Homework.Factory
{
    public static class DBContextFactory
    {
        private static readonly string _config = ConfigurationManager.AppSettings["DbType"];
        public static IDbContext CreateDbContext()
        {
            string _fullName = _config.Split(',')[1];
            string _typeName = _config.Split(',')[0];
            Assembly assembly = Assembly.Load(_fullName);
            Type type = assembly.GetType(_typeName);
            return (IDbContext)Activator.CreateInstance(type);
        }
    }
}
