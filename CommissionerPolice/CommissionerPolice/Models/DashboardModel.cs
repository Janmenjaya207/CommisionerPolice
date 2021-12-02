using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommissionerPolice.Models
{
    public class DashboardModel
    {
        public int marriage { get; set; }
        public int funeral { get; set; }
        public int thread { get; set; }
        public int pending { get; set; }
        public int reject { get; set; }
    }
}