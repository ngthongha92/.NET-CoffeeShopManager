using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace COFFEESHOPMANAGEMENT
{
    class BUSban
    {
        banDAO tab = new banDAO();
        khuvucDAO kv = new khuvucDAO();
        
        public DataTable alltable() {
            return tab.getallinfo();
        }

        public DataTable allkv()
        {
            return kv.getallinfo();
        }

        public DataTable getallfilterkv(string _condition) {
            return tab.getfilterinfo("khuvuc="+_condition);
        }

        public int check_ban(string _maban) {
            string col = null;
            SqlDataReader rd = tab.getinfoban(_maban);
            while (rd.Read())
            {
                col = rd["tinhtrang"].ToString();
            }
            int a = Convert.ToInt32(col);
            return a;
        }

        public Boolean capnhattinhtrangban(string _tinhtrang, string _maban) {
            return tab.updatetinhtranban(_tinhtrang, _maban);
        }
    }
}
