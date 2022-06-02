using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_POS
{
    internal class DBConnect
    {
        private string con;
        public string myConnection() 
        {
            con = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\21361951\source\repos\E Commerce POS\E Commerce POS\DBPOSale.mdf; Integrated Security = True; Connect Timeout = 30";


            return con;
        }
    }
}
