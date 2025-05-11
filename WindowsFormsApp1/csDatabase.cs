using System;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    internal class csDatabase
    {
        const string kullaniciAdi = "yakup";
        const string sifre = "1246";
        const string hostName = "localhost";
        const string port = "1521";
        const string dbName = "TEST1";
        public OracleConnection conn;
        static string connect;
       public csDatabase()
        {
            connect = $"User Id={kullaniciAdi};Password={sifre};Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={hostName})(PORT={port}))(CONNECT_DATA=(SID={dbName})));";
            conn = new OracleConnection(connect);
        }
        

        public void dbOpen()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        public void dbClose()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
