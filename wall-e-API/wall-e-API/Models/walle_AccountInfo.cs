using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wall_e_API
{
    public class walle_AccountInfo
    {
        [Key, Column(Order = 0)]
        public string No { get; set; }
        public double Balance { get; set; }
        
        [ForeignKey("walle_UserInfo_ref")]
        public string walle_UserInfo { get; set; }

        public walle_UserInfo walle_UserInfo_ref { get; set; }
    }
}