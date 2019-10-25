using NicholasLeo.Homework.Commond;
using NicholasLeo.Homework.Factory;
using NicholasLeo.Homework.Interfaces;
using NicholasLeo.Homework.Models;
using NicholasLeo.Homework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace NicholasLeo.Homework.ConsoleMain
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbContext _IDbContext = DBContextFactory.CreateDbContext();
            List<CompanyModel> list = _IDbContext.GetLists<CompanyModel>();
            Console.WriteLine(list.Count);

            //CompanyModel model = new CompanyModel { Name = "腾讯科技", CreateTime = DateTime.Now.Date, CreatorId = 1 ,LastModifierId=1,LastModifyTime=DateTime.Now.Date};
            //ResultMsg msg = _IDbContext.Add<CompanyModel>(model);
            //Console.WriteLine(msg.Status);
            //Console.WriteLine(msg.Message);
             CompanyModel model = _IDbContext.GetEntity<CompanyModel>(1);
            foreach (var item in GetFieldInfo<CompanyModel>(model))
            {
                Console.WriteLine(item);
            }
            //model.Name = "测试";
            //msg = _IDbContext.Update<CompanyModel>(model);
            //Console.WriteLine(msg.Status);
            //Console.WriteLine(msg.Message);
            UserModel user = new UserModel();
            user.Email = "hhhhh.com";
            user.Mobile = "123";
            string res = user.Validate();
            Console.WriteLine(res);


            Console.ReadKey();
        }

        private static List<string> GetFieldInfo<T>(T t) where T : BaseModel
        {
            List<string> list = new List<string>();
            Type type = t.GetType();
            foreach (PropertyInfo prop in type.GetProperties().Where(s=>!s.Name.Equals("Id")))
            {
                object[] attr = prop.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attr != null && attr.Length > 0)
                    list.Add($"{((DescriptionAttribute)attr[0]).Description}:{prop.GetValue(t, null)}");
            }
            return list;
        }
    }
}
