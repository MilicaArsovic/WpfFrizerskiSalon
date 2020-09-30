using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFrizerskiSalon
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder();

            ccnSb.DataSource = @"BOOORKOO\SQLEXPRESS";
            ccnSb.InitialCatalog = @"FrizerskiSalon";
            ccnSb.IntegratedSecurity = true;

            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);

            return konekcija;
        }
    }
}
