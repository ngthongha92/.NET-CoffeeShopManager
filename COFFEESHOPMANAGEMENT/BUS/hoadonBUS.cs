using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace COFFEESHOPMANAGEMENT
{
    class hoadonBUS
    {
        hoadonDAO hd = new hoadonDAO();

        public DataTable getallhoadon(string maban, string tinhtrang){
            return hd.getallinfo(maban, tinhtrang);
        }
        public string getsmahoadon(string maban, string tinhtrang) {
            string col = null;
            SqlDataReader rd = hd.getmahoadon(maban, tinhtrang);
            while (rd.Read())
            {
                col = rd["mahoadon"].ToString();
            }
            return col;
        }
        public Boolean laphoadon(string mahoadon, string maban) {
            return hd.inserthoadon(mahoadon, maban, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

    }
}
