using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online.Security
{
    public static class Security
    {
        #region Private Members
        private string UserRoles;
        private static const string AdminRole = "1";
        private static const string UserRole = "2";
        private static const string MemberRole = "3";
        private static const string AgentRole = "4";
        private static const string AdminRoleKey = "Admin";
        private static const string UserRoleKey = "User";
        private static const string MemberRoleKey = "Member";
        private static const string AgentRoleKey = "Agent";
        #endregion

        #region Private Properties
        private string RequestUserRoles
        {
            get
            {
                return UserRole;
            }
            set
            {
                switch (value)
                {
                    case AdminRole:
                        UserRoles = AdminRoleKey;
                        break;
                    case UserRole:
                        UserRoles = UserRoleKey;
                        break;
                    case MemberRole:
                        UserRoles = MemberRoleKey;
                        break;
                    case AgentRole:
                        UserRoles = AgentRoleKey;
                        break;
                }
            }
        }
        #endregion

        #region Public Methods
        public string GetUserRoleKey(int userRoleID)
        {
            RequestUserRoles = userRoleID.ToString();
            ASCIIEncoding encryptUserRole = new ASCIIEncoding();
            byte[] userRoleKey = encryptUserRole.GetBytes(RequestUserRoles);
            return userRoleKey.ToString();
        }
        #endregion
    }
}
