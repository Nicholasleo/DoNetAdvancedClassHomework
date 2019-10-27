﻿#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/Nicholasleo/DoNetAdvancedClassHomework
* 项目名称 ：NicholasLeo.Homework.Commond
* 项目描述 ：类-
* 类 名 称 ：CustomerAttributeHelper
* 类 描 述 ：
* 所在的域 ：NICHOLAS-LEO
* 命名空间 ：NicholasLeo.Homework.Commond
* 机器名称 ：NICHOLAS-LEO 
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2019-10-25 0:37:25
* 修 改 人 : NicholasLeo
* 更新时间 ：2019-10-25 0:37:25
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ NicholasLeo 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NicholasLeo.Homework.Commond
{
    public static class CustomerAttributeHelper
    {
        public static string GetTableName(Type type)
        {
            if (CacheHelper.IsExsits(type.Name))
            {
                return CacheHelper.Get<string>(type.Name);
            }
            string tableName = string.Empty;
            object[] objAttrs = type.GetCustomAttributes(typeof(CustomerAttribute), true);
            foreach (var item in objAttrs)
            {
                CustomerAttribute customerAttribute = item as CustomerAttribute;
                if (customerAttribute != null)
                {
                    tableName = customerAttribute.TableName;
                    break;
                }
            }
            CacheHelper.Add(type.Name, tableName);
            return tableName;
        }

        public static string GetColumnName(PropertyInfo prop)
        {
            string columnName = prop.Name;
            if (CacheHelper.IsExsits(prop.Name))
                return CacheHelper.Get<string>(prop.Name);
            object[] objAttrs = prop.GetCustomAttributes(typeof(CustomerAttribute), true);
            if (objAttrs.Length > 0)
            {
                CustomerAttribute attr = objAttrs[0] as CustomerAttribute;
                if (attr != null)
                {
                    columnName = attr.ColumnName;
                }
            }
            CacheHelper.Add(prop.Name, columnName);
            return columnName;
        }
    }
}
