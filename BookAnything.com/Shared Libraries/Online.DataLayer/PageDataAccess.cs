using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Online.DataLayer
{
   public class PageDataAccess
    {
       public static DataTable GetAllPages(int moduleID)
       {
           return DataAccess.DataAccessLayer.FillDataTable("security.sp_GetAllPagesByModuleID", CommandType.StoredProcedure,
                    new SqlParameter("@ModuleID",moduleID));
       }
    }
}
