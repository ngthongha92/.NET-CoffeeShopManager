using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace COFFEESHOPMANAGEMENT
{
    class thucdonBUS
    {
        thucdonDAO td = new thucdonDAO();
        public DataTable getallthucdon() {
            return td.getallthucdon();
        }
        public DataTable getallloaithucdon()
        {
            return td.getallloaithucdon();
        }
    }
}
