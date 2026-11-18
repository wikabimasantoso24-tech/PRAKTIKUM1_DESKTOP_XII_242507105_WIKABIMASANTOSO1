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
        string kongigurasi = "server=localhost,username=root,database=db_apotek_petugas";   
        public frmlogin()
        {
            InitializeComponent();
            
        }

        private void btnmasuk_Click(object sender, EventArgs e)
        {
            frmdasboard anu = new frmdasboard();
            anu.Show();


            
           
        }
    }
}
