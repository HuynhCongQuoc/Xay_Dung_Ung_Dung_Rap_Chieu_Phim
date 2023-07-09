using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BaoCao.Control
{
    class ConnectSQL
    {
        public static string severName = @"MSI\SQLEXPRESS";
        public static string dataName = "QLY_RAPPHIM";

        public SqlConnection KetnoiCSDL()
        {
            string lenhketnoi = "Data Source=" + severName + ";Initial Catalog=" + dataName + ";Integrated Security=True";
            SqlConnection con = new SqlConnection(lenhketnoi);
            return con;
        }
    }

}
