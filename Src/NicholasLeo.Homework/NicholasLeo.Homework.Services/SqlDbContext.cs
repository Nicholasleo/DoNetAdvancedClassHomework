#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/nicholasleo
* 项目名称 ：NicholasLeo.Homework.Services
* 项目描述 ：类-
* 类 名 称 ：SqlDbContext
* 类 描 述 ：
* 所在的域 ：NICHOLAS-LEO
* 命名空间 ：NicholasLeo.Homework.Services
* 机器名称 ：NICHOLAS-LEO 
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2019-10-24 23:10:56
* 修 改 人 : NicholasLeo
* 更新时间 ：2019-10-24 23:10:56
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ NicholasLeo 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using NicholasLeo.Homework.Interfaces;
using NicholasLeo.Homework.Models;

namespace NicholasLeo.Homework.Services
{
    public class SqlDbContext : IDbContext
    {
        private ResultMsg resultMsg = null;
        #region private
        private static readonly IDbHelper _IDbHelper = new DbHelper();
        #endregion
        public ResultMsg Add<T>(T t) where T : BaseModel
        {// resultMsg.Status = 202;
            resultMsg = new ResultMsg { Status = 202, Message="新增失败！"};
            try
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                string fields = string.Join(",", type.GetProperties().Where(p => p.Name.Equals("Id")).Select(s => $"[{s.Name}]"));
                string values = string.Join(",", type.GetProperties().Where(p => !p.Name.Equals("Id")).Select(s => $"@[{s.Name}]"));
                string sql = $"Insert [{type.Name}] ({fields}) values({values})";
                var parameters = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Select(item => new SqlParameter()
                    {
                        ParameterName = $"@{item.Name}",
                        SqlValue = $"{item.GetValue(t)}"
                    });
                if (_IDbHelper.ExecuteNonQuery(sql, parameters.ToArray()) > 0)
                {
                    resultMsg.Status = 200;
                    resultMsg.Message = "添加成功！";
                }
            }
            catch (Exception ex)
            {
                resultMsg.Status = 400;
                resultMsg.Message = ex.Message;
            }
            return resultMsg;
        }

        public ResultMsg Update<T>(T t) where T : BaseModel
        {
            resultMsg = new ResultMsg { Status = 202, Message = "修改失败！" };
            try
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                string sql = $"update [{type.Name}]  set {string.Join(",", type.GetProperties().Where(f => !f.Name.Equals("Id")).Select(f => $"[{f.Name}]=@ {f.Name}"))}  where Id =@Id";
                var parameters = type.GetProperties().Select(item => new SqlParameter()
                {
                    ParameterName = $"@{item.Name}",
                    SqlValue = $"{item.GetValue(t)}"
                });
                if (_IDbHelper.ExecuteNonQuery(sql, parameters.ToArray()) > 0)
                {
                    resultMsg.Status = 200;
                    resultMsg.Message = "更新成功！";
                }
            }
            catch (Exception ex)
            {
                resultMsg.Status = 400;
                resultMsg.Message = ex.Message;
            }
            return resultMsg;
        }

        public ResultMsg Delete<T>(T t) where T : BaseModel
        {
            resultMsg = new ResultMsg { Status = 202, Message = "删除失败！" };
            try
            {
                Type type = t.GetType();
                string sql = $"Delete from [{type.Name}] where Id=@Id";
                if (_IDbHelper.ExecuteNonQuery(sql, new SqlParameter("@Id", t.Id)) > 0)
                {
                    resultMsg.Status = 200;
                    resultMsg.Message = "删除成功！";
                }
            }
            catch (Exception ex)
            {
                resultMsg.Status = 400;
                resultMsg.Message = ex.Message;
            }
            return resultMsg;

        }

        public ResultMsg Delete<T>(int id) where T : BaseModel
        {
            resultMsg = new ResultMsg { Status = 202, Message = "删除失败！" };
            try
            {
                Type type = typeof(T);
                string sql = $"Delete from [{type.Name}] where Id=@Id";
                if (_IDbHelper.ExecuteNonQuery(sql, new SqlParameter("@Id", id)) > 0)
                {
                    resultMsg.Status = 200;
                    resultMsg.Message = "删除成功！";
                }
            }
            catch (Exception ex)
            {
                resultMsg.Status = 400;
                resultMsg.Message = ex.Message;
            }
            return resultMsg;
        }

        public T GetEntity<T>(int id) where T : BaseModel
        {
            try
            {
                Type type = typeof(T);
                object data = Activator.CreateInstance(type); 
                string sql = $"SELECT {string.Join(",", type.GetProperties().Select(f => $"[{f.Name}]")) } FROM [{type.Name}] where Id=@Id";
                SqlDataReader dataReader = _IDbHelper.ExecuteReader(sql, new SqlParameter("@Id", id));
                if (dataReader.Read())
                {
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(data, dataReader[prop.Name] is DBNull ? null : dataReader[prop.Name]);
                    }
                    return (T)data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public List<T> GetLists<T>() where T : BaseModel
        {
            try
            {
                List<T> result = new List<T>();
                Type type = typeof(T);
                string sql = $"SELECT {string.Join(",", type.GetProperties().Select(a => $"[{a.Name}]")) } FROM [{type.Name}]";
                SqlDataReader dataReader = _IDbHelper.ExecuteReader(sql);
                while (dataReader.Read())
                {
                    object data = Activator.CreateInstance(type); 
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(data, dataReader[prop.Name] is DBNull ? null : dataReader[prop.Name]);
                    }
                    result.Add((T)data);
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
