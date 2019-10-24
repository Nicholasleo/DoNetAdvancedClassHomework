#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/nicholasleo
* 项目名称 ：NicholasLeo.Homework.Interfaces
* 项目描述 ：接口-
* 类 名 称 ：IDbContext
* 类 描 述 ：
* 所在的域 ：NICHOLAS-LEO
* 命名空间 ：NicholasLeo.Homework.Interfaces
* 机器名称 ：NICHOLAS-LEO 
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2019-10-24 23:05:20
* 修 改 人 : NicholasLeo
* 更新时间 ：2019-10-24 23:05:20
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ NicholasLeo 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using NicholasLeo.Homework.Models;
using System.Collections.Generic;

namespace NicholasLeo.Homework.Interfaces
{
    public interface IDbContext
    {
        ResultMsg Add<T>(T t) where T : BaseModel;
        ResultMsg Update<T>(T t) where T : BaseModel;
        ResultMsg Delete<T>(T t) where T : BaseModel;
        ResultMsg Delete<T>(int id) where T : BaseModel;
        T GetEntity<T>(int id) where T : BaseModel;
        List<T> GetLists<T>() where T : BaseModel;
    }
}
