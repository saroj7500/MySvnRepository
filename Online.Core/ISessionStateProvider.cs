using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online.Core
{
    public interface ISessionStateProvider
    {
        int UserID { get; set; }
        string UserCode { get; set; }
        int EnrollmentID { get; set; }
        string UserName { get; set; }
        string UserImageGUID { get; set; }
        int UserRoleID { get; set; }
        string UserRoleKey { get; set; }
        bool IsUserLoggedIn { get; set; }
        DateTime LoginTime { get; set; }
        long? LoginIP { get; set; }
        string PreviousPageUrl { get; set; }
        string StartPageUrl { get; set; }
        string MobileNo { get; set; }
    }
}
