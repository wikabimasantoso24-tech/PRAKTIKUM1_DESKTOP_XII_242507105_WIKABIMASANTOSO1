using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PRAKTIKUM1_DESKTOP_XII_242507105_WIKABIMASANTOSO
{
    public partial class frmlogin : Form
    {
        string kongigurasi = "server=localhost;username=root;database=db_apotek_petugas";
        public frmlogin()
        {
            InitializeComponent();
            txtpassword.PasswordChar = '*';


        }

        private void btnmasuk_Click(object sender, EventArgs e)
        {

            frmdasboard anu = new frmdasboard();
            anu.Show();
            this.Hide();



            MySqlConnection koneksi = new MySqlConnection(kongigurasi);
            try
            {
                koneksi.Open();
                string query = "SELECT * FROM tb_apoteker WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                MySqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    MessageBox.Show("Login Berhasil");
                    frmdasboard dashboard = new frmdasboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau Password Salah");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                koneksi.Close();

            }


            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong");
                return;
            }
            else
            {
                MessageBox.Show("Login Berhasil");
                frmdasboard dashboard = new frmdasboard();
                dashboard.Show();
                this.Hide();
            }

            if (txtusername.Text == "" && txtpassword.Text == "")
            {
                MessageBox.Show("Login Berhasil");
                frmdasboard dashboard = new frmdasboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password Salah");
            }

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            frmregister register = new frmregister();
            register.Show();
            this.Hide();
        }
    }
}
