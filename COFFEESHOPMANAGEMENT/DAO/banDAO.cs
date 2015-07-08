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

        public SqlDataReader getsingleban(string _id) {
            string query = string.Format("SELECT * FROM ban WHERE maban='"+_id+"'");
            try
            {
                con = new DbConnection();
                con.openConnection();
            }
            catch (SqlException e) { }
            return con.MyReader(query);
        }

        public Boolean setban(string _tenban, string _tinhtrang, string _khuvuc) {
            string query = string.Format("INSERT INTO ban (tenban, tinhtrang, khuvuc) VALUES ('"+_tenban+"', "+_tinhtrang+", "+_khuvuc+")");
            try{
                con = new DbConnection();
                con.openConnection();
            }
            catch (SqlException e) { }
            return con.executeQuery(query);
        }


    }
}
