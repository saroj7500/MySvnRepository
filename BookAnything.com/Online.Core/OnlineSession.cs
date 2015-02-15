using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online.Core
{
    public static class OnlineSession
    {
        #region Static Members
        static ISessionStateProvider sessionState;
        #endregion

        #region Public Methods
        public static void RecordLoginDetails(LoginInfo loginInformation)
        {
            MemberID = loginInformation.MemberID;
            EnrollmentID = loginInformation.EnrollmentID;
            UserName = loginInformation.UserName;
            UserRoleID = loginInformation.UserRoleID;
            UserRoleKey = loginInformation.UserRoleKey;
            UserImageGUID = loginInformation.UserImageGUID;
            IsUserLoggegin = loginInformation.IsUserLoggedIn;
            LoginTime = loginInformation.LoginTime;
            LoginIP = loginInformation.LoginIP;
            PreviousPageUrl = loginInformation.PreviousPageUrl;
            StartPageUrl = loginInformation.StartPageUrl;
        }
        #endregion

        #region Public Properties
        public static int MemberID
        {
            get{ return sessionState.MemberID;}
            set{ sessionState.MemberID = value;}
        }

        public static int EnrollmentID
        {
            get { return sessionState.EnrollmentID; }
            set { sessionState.EnrollmentID = value; }
        }

        public static string UserName
        {
            get { return sessionState.UserName; }
            set { sessionState.UserName = value; }
        }

        public static int UserRoleID
        {
            get { return sessionState.UserRoleID; }
            set { sessionState.UserRoleID = value; }
        }

        public static string UserRoleKey
        {
            get { return sessionState.UserRoleKey; }
            set { sessionState.UserRoleKey = value; }
        }

        public static string UserImageGUID
        {
            get { return sessionState.UserImageGUID; }
            set { sessionState.UserImageGUID = value; }
        }

        public static bool IsUserLoggegin
        {
            get { return sessionState.IsUserLoggedIn; }
            set { sessionState.IsUserLoggedIn = value; }
        }

        public static DateTime LoginTime
        {
            get { return sessionState.LoginTime; }
            set { sessionState.LoginTime = value; }
        }

        public static long? LoginIP
        {
            get { return sessionState.LoginIP; }
            set { sessionState.LoginIP = value; }
        }

        public static string PreviousPageUrl
        {
            get { return sessionState.PreviousPageUrl; }
            set { sessionState.PreviousPageUrl = value; }
        }

        public static string StartPageUrl
        {
            get { return sessionState.StartPageUrl; }
            set { sessionState.StartPageUrl = value; }
        }
        #endregion
    }
}
