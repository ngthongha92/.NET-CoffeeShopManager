using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace COFFEESHOPMANAGEMENT
{
    class banDAO
    {
        public DbConnection con;

        public DataTable getallban() {
            string query = string.Format("SELECT * FROM ban");
            try {
                con = new DbConnection();
                con.openConnection();
            }
            catch (SqlException e) { }
            return con.executeSelectQuery(query);
        }

    }
}
