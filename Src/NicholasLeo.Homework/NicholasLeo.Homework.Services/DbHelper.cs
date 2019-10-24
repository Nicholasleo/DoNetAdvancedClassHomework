#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/nicholasleo
* 项目名称 ：NicholasLeo.Homework.Services
* 项目描述 ：类-
* 类 名 称 ：DbHelper
* 类 描 述 ：
* 所在的域 ：NICHOLAS-LEO
* 命名空间 ：NicholasLeo.Homework.Services
* 机器名称 ：NICHOLAS-LEO 
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2019-10-24 22:48:30
* 修 改 人 : NicholasLeo
* 更新时间 ：2019-10-24 22:48:30
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
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicholasLeo.Homework.Services
{
    public class DbHelper : IDbHelper
    {
        private readonly static string config = ConfigurationManager.ConnectionStrings["logisDb"].ConnectionString;
        public int ExecuteNonQuery(string sql, params SqlParameter[] par)
        {
            using (SqlConnection con = new SqlConnection(config))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    if (par != null && par.Length > 0)
                    {
                        com.Parameters.AddRange(par);
                    }
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    return com.ExecuteNonQuery();
                }
            }
        }

        public int ExecuteNonQueryProc(string sql, params SqlParameter[] par)
        {
            using (SqlConnection con = new SqlConnection(config))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandTimeout = 60;
                    com.CommandType = CommandType.StoredProcedure;
                    if (par != null && par.Length > 0)
                    {
                        com.Parameters.AddRange(par);
                    }
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    return com.ExecuteNonQuery();
                }
            }
        }

        public SqlDataReader ExecuteReader(string sql, params SqlParameter[] par)
        {
            SqlConnection con = new SqlConnection(config);

            using (SqlCommand com = new SqlCommand(sql, con))
            {

                if (par != null && par.Length > 0)
                {
                    com.Parameters.AddRange(par);
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return com.ExecuteReader(CommandBehavior.CloseConnection);

            }
        }

        public SqlDataReader ExecuteReaderProc(string procname, params SqlParameter[] par)
        {
            SqlConnection con = new SqlConnection(config);

            using (SqlCommand com = new SqlCommand(procname, con))
            {
                com.CommandType = CommandType.StoredProcedure;
                if (par != null && par.Length > 0)
                {
                    com.Parameters.AddRange(par);
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public object ExecuteScalar(string sql, params SqlParameter[] par)
        {
            using (SqlConnection con = new SqlConnection(config))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    if (par != null && par.Length > 0)
                    {
                        com.Parameters.AddRange(par);
                    }
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    return com.ExecuteScalar();
                }
            }
        }

        public DataTable ExecuteTable(string sql, params SqlParameter[] par)
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, config))
            {
                if (par != null && par.Length > 0)
                {
                    sda.SelectCommand.Parameters.AddRange(par);
                }
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }
    }
}
