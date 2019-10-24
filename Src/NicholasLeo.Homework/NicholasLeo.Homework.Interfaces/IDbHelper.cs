#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/nicholasleo
* 项目名称 ：NicholasLeo.Homework.Interfaces
* 项目描述 ：接口-
* 类 名 称 ：IDbHelper
* 类 描 述 ：
* 所在的域 ：NICHOLAS-LEO
* 命名空间 ：NicholasLeo.Homework.Interfaces
* 机器名称 ：NICHOLAS-LEO 
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2019-10-24 22:48:14
* 修 改 人 : NicholasLeo
* 更新时间 ：2019-10-24 22:48:14
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ NicholasLeo 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicholasLeo.Homework.Interfaces
{
    public interface IDbHelper
    {
        int ExecuteNonQuery(string sql, params SqlParameter[] par);
        int ExecuteNonQueryProc(string sql, params SqlParameter[] par);
        SqlDataReader ExecuteReader(string procname, params SqlParameter[] par);
        SqlDataReader ExecuteReaderProc(string procname, params SqlParameter[] par);
        object ExecuteScalar(string sql, params SqlParameter[] par);
        DataTable ExecuteTable(string sql, params SqlParameter[] par);
    }
}
