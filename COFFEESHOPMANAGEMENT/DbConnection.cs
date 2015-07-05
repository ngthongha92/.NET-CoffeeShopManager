using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace COFFEESHOPMANAGEMENT
{
    class DbConnection{
        public static SqlConnection conn = null;

        /// <method>
        /// Open Database Connection if Closed or Broken
        /// </method>
        public void openConnection(){
            try
            {
                conn = new SqlConnection(@"Data Source=NGTHONG-PC\SQLEXPRESS;Initial Catalog=coffee;Integrated Security=True");
                conn.Open();
            }
            catch (SqlException e) { }
        }

        public void closeConnection() {
            try {
                conn.Close();
            }
            catch (SqlException e){
            }
        }

        /// <method>
        /// Select Query
        /// </method>
        public DataTable executeSelectQuery(String _query){
            SqlCommand myCommand = new SqlCommand(_query, conn);
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        /// <method>
        /// None Query
        /// </method>
        public static void executeQuery(String _query){
            SqlCommand myCommand = new SqlCommand(_query, conn);
            try{
                myCommand.CommandText = _query;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e){
            }
        }
    }
}
