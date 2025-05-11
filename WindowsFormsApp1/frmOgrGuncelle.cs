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
    public partial class frmOgrGuncelle : Form
    {
        csDatabase db = new csDatabase();
        string eskiTc;
        public frmOgrGuncelle(string tc,string ad,string soyad)
        {
            InitializeComponent();
            eskiTc = tc;
            txtTc.Text = tc;
            txtAd.Text = ad;
            txtSoyad.Text = soyad;
        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                db.dbOpen();
                OracleCommand updateCmd = new OracleCommand();
                updateCmd.Connection = db.conn;
                updateCmd.CommandText = $"UPDATE kullanicilar SET ad = :ad ,soyad = :soyad, tc = :tc WHERE tc = :eskiTc";
                updateCmd.Parameters.Add("ad",txtAd.Text);
                updateCmd.Parameters.Add("soyad", txtSoyad.Text);
                updateCmd.Parameters.Add("tc", txtTc.Text);
                updateCmd.Parameters.Add("eskiTc", eskiTc);
                int result = updateCmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Güncelleme başarılı");
                }
                else
                {
                    MessageBox.Show("Güncelleme başarısız");
                }
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n"+ ex.StackTrace);
            }

        }
    }
}
