using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_POS
{
    internal class DBConnect

    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private string con;
        public string myConnection() 
        {
            con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\21361951\source\repos\E Commerce POS\E Commerce POS\DBPOSale.mdf; Integrated Security = True; Connect Timeout = 30";


            return con;
        }
        public DataTable getTable(string qury)
        {
            conn.ConnectionString = myConnection();
            cmd = new SqlCommand(qury,conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;


        }
    }
}
