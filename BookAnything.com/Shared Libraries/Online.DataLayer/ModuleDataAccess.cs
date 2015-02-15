using System.Data;

namespace Online.DataLayer
{
    public class ModuleDataAccess
    {
        public static DataTable GetAllModules()
        {
            return DataAccess.DataAccessLayer.FillDataTable("security.sp_GetAllModules", CommandType.StoredProcedure);
        }
    }
}
