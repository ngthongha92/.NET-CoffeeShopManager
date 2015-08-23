using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace COFFEESHOPMANAGEMENT
{
    class hoadonDAO
    {
        public DbConnection con;
        public DataTable getallinfo(string a, string b)
        {
            string query = string.Format("select hoadon.mahoadon,thucdon.tenmon,chitiethoadon.soluong,chitiethoadon.thanhtien, hoadon.ngaylap FROM hoadon inner join chitiethoadon ON hoadon.mahoadon = chitiethoadon.mahoadon inner join thucdon ON chitiethoadon.mamon = thucdon.mamon WHERE hoadon.maban = "+a+" and hoadon.tinhtrang = "+b);
            try
            {
                con = new DbConnection();
                con.openConnection();
            }
            catch (SqlException e) { }
            return con.executeSelectQuery(query);
        }
        public SqlDataReader getmahoadon(string maban, string tinhtrang)
        {
            string query = string.Format("SELECT * FROM hoadon WHERE maban=" + maban + " and tinhtrang="+tinhtrang);
            try
            {
                con = new DbConnection();
                con.openConnection();
            }
            catch (SqlException e) { }
            return con.MyReader(query);
        }
        public Boolean inserthoadon(string _mahoadon,string _maban, string _tinhtrang, string _ngaylap) {
            string query = string.Format("INSERT INTO hoadon (mahoadon, maban, tinhtrang, ngaylap) VALUES ('"+_mahoadon+"', "+_maban+", "+_tinhtrang+", '"+_ngaylap+"')");
            try
            {
                con = new DbConnection();
                con.openConnection();
            }
            catch (SqlException e) { }
            return con.executeQuery(query);
        }

        public Boolean deletehoadon(string _id) {
            string query = string.Format("delete from hoadon where mahoadon = "+_id);
            try
            {
                con = new DbConnection();
                con.openConnection();
            }
            catch (SqlException e) { }
            return con.executeQuery(query);
        }
        public Boolean deletecthoadon(string _id)
        {
            string query = string.Format("delete from chitiethoadon where mahoadon = " + _id);
            try
            {
                con = new DbConnection();
                con.openConnection();
            }
            catch (SqlException e) { }
            return con.executeQuery(query);
        }
    }
}
