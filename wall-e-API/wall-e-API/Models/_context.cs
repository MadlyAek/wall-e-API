using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace wall_e_API
{
    public class context : DbContext
    {
        public context() : base(ConfigData.ConnectionString()) {

        }

        public DbSet<walle_UserInfo> walle_UserInfos { get; set; }
        public DbSet<walle_AccountInfo> walle_AccountInfos { get; set; }

    }
}