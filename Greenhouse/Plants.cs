using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Greenhouse.classes;
using MySql.Data.MySqlClient;

namespace Greenhouse
{
    public partial class Plants : Form
    {
        public Plants()
        {
            InitializeComponent();
            conecting_to_sql();
            //Plant[] plants = new Plant();
        }

        private void Plants_Load(object sender, EventArgs e)
        {

        }

        private void conecting_to_sql()
        {
            label11.Text="Getting Connection ...";
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                label11.Text=("Openning Connection ...");

                conn.Open();

                label11.Text=("Connection successful!");
            }
            catch (Exception e)
            {
                label11.Text=("Error: " + e.Message);
            }

            Console.Read();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
