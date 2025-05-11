using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmOgrListele : Form
    {
        public frmOgrListele()
        {
            InitializeComponent();
        }
        csDatabase db = new csDatabase();
        void searchPeople(TextBox tc,TextBox ad,TextBox soyad)
        {
            string query = "SELECT * FROM kullanicilar where 1=1";

            if (ad.Text.Trim() != "")
            {
                query += $" and LOWER(ad) LIKE '%{ad.Text.ToLower()}%' ";
            }
            if (soyad.Text.Trim() != "")
            {
                query += $" and LOWER(soyad) LIKE '%{soyad.Text.ToLower()}%' ";
            }
            if (tc.Text.Trim() != "")
            {
                query += $" and tc LIKE '%{tc.Text}%' ";
            }


            OracleDataAdapter da = new OracleDataAdapter(query, db.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frmOgrListele_Load(object sender, EventArgs e)
        {
            try
            {
               
                string query = "SELECT * FROM kullanicilar"; // Tablo adını değiştir

                OracleDataAdapter da = new OracleDataAdapter(query, db.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Application.Exit();
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string kolon1 = dataGridView1.SelectedCells[0].Value.ToString();
                    string kolon2 = dataGridView1.SelectedCells[1].Value.ToString();
                    string kolon3 = dataGridView1.SelectedCells[2].Value.ToString();
                    //MessageBox.Show($"{kolon1} {kolon2} {kolon3}");

                    txtTcNo.Text = kolon1.ToString();
                    txtOgrAd.Text = kolon2.ToString();
                    txtOgrSoyad.Text = kolon3.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            searchPeople(txtTcNo, txtOgrAd, txtOgrSoyad);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string kolon1 = dataGridView1.SelectedCells[0].Value.ToString();
            string kolon2 = dataGridView1.SelectedCells[1].Value.ToString();
            string kolon3 = dataGridView1.SelectedCells[2].Value.ToString();
            frmOgrGuncelle frmOgrGuncelle = new frmOgrGuncelle(kolon1, kolon2, kolon3);
            frmOgrGuncelle.ShowDialog();

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtOgrAd.Text = "";
            txtTcNo.Text = "";
            txtOgrSoyad.Text = "";

        }
    }
}
