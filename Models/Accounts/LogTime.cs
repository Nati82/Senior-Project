using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.Accounts
{
    [Table("LogTimes")]
    public class LogTime
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string userRole { get; set; }
        public DateTime loginTime { get; set; }
        public DateTime logoutTime { get; set; }
    }
}
