using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online.Core
{
    public sealed class SystemFolder
    {
        #region private constants
        const string PathRoot = "~/SystemFolder/";
        const string PathDocuments = "~/SystemFolder/Documents/";
        const string PathImages = "~/SystemFolder/Images/";
        const string PathWebDocuments = "~/SystemFolder/Documents/WebDocuments/";
        const string PathWebImages = "~/SystemFolder/Images/WebImages/";
        const string PathUserDocuments = "~/SystemFolder/Documents/UserDocuments";
        const string PathUserImages = "~/SystemFolder/Images/UserImages/";
        const string PathLogoImages = "~/SystemFolder/Images/WebImages/LogoImages/";
        #endregion

        #region public static readonly members (these are the 'enum' equivalents)
        public static readonly SystemFolder RootDocsFolder = new SystemFolder(PathRoot);
        public static readonly SystemFolder Documents = new SystemFolder(PathDocuments);
        public static readonly SystemFolder Images = new SystemFolder(PathImages);
        public static readonly SystemFolder WebDocuments = new SystemFolder(PathWebDocuments);
        public static readonly SystemFolder WebImages = new SystemFolder(PathWebImages);
        public static readonly SystemFolder UserImages = new SystemFolder(PathUserImages);
        public static readonly SystemFolder UserDocuments = new SystemFolder(PathUserDocuments);
        public static readonly SystemFolder LogoImages = new SystemFolder(PathLogoImages);
        #endregion

        // Constructor intentionally hidden
        private SystemFolder(string relativePath)
        {
            if (relativePath == null) throw new ArgumentNullException("relativePath");

            this.RelativePath = relativePath;
        }

        #region public properties
        /// <summary>
        /// This is the full URL for this folder
        /// (e.g.
        /// </summary>
        //public string URL
        //{
        //    //get { return AspPathUtility.ConvertToAbsoluteUrl(this.RelativePath); }
        //}

        ///// <summary>
        ///// This is the local absolute physical path for this folder
        ///// (e.g. C:\DKI_Docs\Estimates)
        ///// </summary>
        //public string FilePath
        //{
        //    //get { return AspPathUtility.MapPath(this.RelativePath); }
        //}

        /// <summary>
        /// STRONGLY advise use of Path and URL where possible instead of this property, 
        /// or even better use the UserFile class when possible.
        /// 
        /// RelativePath gives the ASP.NET relative path for the folder (e.g. ~/Docs/Estimates)
        /// </summary>
        public string RelativePath { get; private set; }
        #endregion
    }
}
