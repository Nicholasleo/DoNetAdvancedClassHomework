#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/nicholasleo
* 项目名称 ：NicholasLeo.Homework.Commond
* 项目描述 ：类-
* 类 名 称 ：ValidateExtend
* 类 描 述 ：
* 所在的域 ：NICHOLAS-LEO
* 命名空间 ：NicholasLeo.Homework.Commond
* 机器名称 ：NICHOLAS-LEO 
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2019-10-26 0:35:47
* 修 改 人 : NicholasLeo
* 更新时间 ：2019-10-26 0:35:47
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
    public static class ValidateExtend
    {
        public static string Validate<T>(this T t)
        {
            Type type = t.GetType();

            //获取所有属性
            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            List<string> errorList = new List<string>();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.IsDefined(typeof(ValidateAttribute)))//如果属性上有定义该属性,此步没有构造出实例
                {
                    foreach (ValidateAttribute attribute in propertyInfo.GetCustomAttributes(typeof(ValidateAttribute)))
                    {
                        if (!attribute.Validate(propertyInfo.GetValue(t, null)))
                        {
                            errorList.Add($"[{propertyInfo.Name}]" + attribute.ErrorMessage);
                        }
                    }

                }
            }
            return string.Join(",", errorList);
        }
    }
}
