using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmOgrEkle : Form
    {
        csDatabase db = new csDatabase();
        public frmOgrEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                db.dbOpen();
                OracleCommand updateCmd = new OracleCommand();
                updateCmd.Connection = db.conn;
                updateCmd.CommandText = "INSERT INTO kullanicilar (tc, ad, soyad) VALUES (:tc, :ad, :soyad)";
                updateCmd.Parameters.Add("ad", txtAd.Text);
                updateCmd.Parameters.Add("soyad", txtSoyad.Text);
                updateCmd.Parameters.Add("tc", txtTc.Text);
                int result = updateCmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Öğrenci eklendi");
                }
                else
                {
                    MessageBox.Show("Öğrenci eklenemedi");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
