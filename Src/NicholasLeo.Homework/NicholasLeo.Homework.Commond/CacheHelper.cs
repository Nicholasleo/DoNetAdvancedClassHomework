#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/nicholasleo
* 项目名称 ：NicholasLeo.Homework.Commond
* 项目描述 ：类-
* 类 名 称 ：CacheHelper
* 类 描 述 ：
* 所在的域 ：NICHOLAS-LEO
* 命名空间 ：NicholasLeo.Homework.Commond
* 机器名称 ：NICHOLAS-LEO 
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2019-10-27 15:42:31
* 修 改 人 : NicholasLeo
* 更新时间 ：2019-10-27 15:42:31
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ NicholasLeo 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicholasLeo.Homework.Commond
{
    public static class CacheHelper
    {
        private static Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();

        public static void Add(string key, object obj)
        {
            CacheDictionary.Add(key, obj);
        }

        public static void Remove(string key)
        {
            CacheDictionary.Remove(key);
        }

        public static T Get<T>(string key)
        {
            return (T)CacheDictionary[key];
        }

        public static bool IsExsits(string key)
        {
            return CacheDictionary.ContainsKey(key);
        }
    }
}
