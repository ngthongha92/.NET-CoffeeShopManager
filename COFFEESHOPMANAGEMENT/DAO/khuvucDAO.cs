using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace COFFEESHOPMANAGEMENT
{
    class khuvucDAO
    {
        public DbConnection con;

        public DataTable getallinfo()
        {
            string query = string.Format("SELECT * FROM khuvuc");
            try
            {
                con = new DbConnection();
                con.openConnection();
            }
            catch (SqlException e) { }
            return con.executeSelectQuery(query);
        }
    }
}
