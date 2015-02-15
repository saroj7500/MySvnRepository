using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online.Core
{
    public class LoginInfo:ISessionStateProvider
    {
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public int EnrollmentID { get; set; }
        public string UserName { get; set; }
        public string UserImageGUID { get; set; }
        public int UserRoleID { get; set; }
        public string UserRoleKey { get; set; }
        public bool IsUserLoggedIn { get; set; }
        public DateTime LoginTime { get; set; }
        public long? LoginIP { get; set; }
        public string PreviousPageUrl { get; set; }
        public string StartPageUrl { get; set; }
        public string MobileNo { get; set; }
    }
}
