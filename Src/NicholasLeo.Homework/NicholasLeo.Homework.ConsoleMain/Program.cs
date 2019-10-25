using NicholasLeo.Homework.Interfaces;
using NicholasLeo.Homework.Models;
using NicholasLeo.Homework.Services;
using System;
using System.Collections.Generic;

namespace NicholasLeo.Homework.ConsoleMain
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbContext _IDbContext = new SqlDbContext();
            List<CompanyModel> list = _IDbContext.GetLists<CompanyModel>();
            Console.WriteLine(list.Count);
            CompanyModel model = new CompanyModel { Name = "腾讯科技", CreateTime = DateTime.Now.Date, CreatorId = 1 ,LastModifierId=1,LastModifyTime=DateTime.Now.Date};
            ResultMsg msg = _IDbContext.Add<CompanyModel>(model);
            Console.WriteLine(msg.Status);
            Console.WriteLine(msg.Message);
            model = _IDbContext.GetEntity<CompanyModel>(1);
            model.Name = "测试";
            msg = _IDbContext.Update<CompanyModel>(model);
            Console.WriteLine(msg.Status);
            Console.WriteLine(msg.Message);
            Console.ReadKey();
        }
    }
}
