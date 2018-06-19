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
    }
}