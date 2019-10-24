#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 作    者 ：Nicholas Leo 
*  E-Mail : nicholasleo1030@163.com
*  GitHub : https://github.com/nicholasleo
* 项目名称 ：NicholasLeo.Homework.Models
* 项目描述 ：类-
* 类 名 称 ：BaseInfoModel
* 类 描 述 ：
* 所在的域 ：NICHOLAS-LEO
* 命名空间 ：NicholasLeo.Homework.Models
* 机器名称 ：NICHOLAS-LEO 
* CLR 版本 ：4.0.30319.42000
* 创建时间 ：2019-10-24 22:35:40
* 修 改 人 : NicholasLeo
* 更新时间 ：2019-10-24 22:35:40
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

namespace NicholasLeo.Homework.Models
{
    public abstract class BaseInfoModel : BaseModel
    {
        public virtual string Name { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual int CreatorId { get; set; }
        public virtual int? LastModifierId { get; set; }
        public virtual DateTime? LastModifyTime { get; set; }
    }
}
