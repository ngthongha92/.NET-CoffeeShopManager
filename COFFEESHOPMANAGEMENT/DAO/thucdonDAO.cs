using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace COFFEESHOPMANAGEMENT
{
    class thucdonDAO
    {
        public DbConnection con;

        public DataTable getallloaithucdon()
        {
            string query = string.Format("SELECT * FROM loaithucdon");
            try
            {
                con = new DbConnection();
                con.openConnection();
            }
            catch (SqlException e) { }
            return con.executeSelectQuery(query);
        }

        public DataTable getallthucdon()
        {
            string query = string.Format("SELECT thucdon.mamon, thucdon.tenmon, thucdon.gia, loaithucdon.tenloai, thucdon.donvi, thucdon.tinhtrang, thucdon.mota FROM thucdon INNER JOIN loaithucdon ON thucdon.maloai = loaithucdon.maloai");
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
