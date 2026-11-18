using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PRAKTIKUM1_DESKTOP_XII_242507105_WIKABIMASANTOSO
{
    public partial class frmregister : Form
    {
        string kongigurasi = "server=localhost,username=root,database=db_apotek_petugas";
        public frmregister()
        {
            InitializeComponent();
            txtpassword.PasswordChar = '*';
            txtkonfirpw.PasswordChar = '*';
            
        }

        private void frmregister_Load(object sender, EventArgs e)
        {

        }

        private void btnmasuk_Click(object sender, EventArgs e)
        {
            
            MySqlConnection koneksi = new MySqlConnection(kongigurasi);
            try
            {
                koneksi.Open();
                string query = "INSERT INTO tb_apoteker (username, password, role) VALUES (@username, @password, @role)";
                MySqlCommand cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@role", comboBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registrasi Berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }
           
            if (txtpassword.Text != txtkonfirpw.Text)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak sama");
                return;
            }
            else
            {
                MessageBox.Show("Registrasi Berhasil");
                frmlogin login = new frmlogin();
                login.Show();
                this.Hide();
            }


            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmlogin login = new frmlogin();
            login.Show();
            this.Hide();
           
        }
    }
}
 