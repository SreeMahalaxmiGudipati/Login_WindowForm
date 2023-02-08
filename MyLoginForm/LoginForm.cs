using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyLoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        //for establishing connection 
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

      
        private void button1_Click(object sender, EventArgs e)
        {
            //creating database connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //creating SQL DataAdapter 
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from LoginForm where Username='"+textBox1.Text+ "' and Password='"+textBox2.Text+"'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()=="1")
            {
                this.Hide();
                Main ss = new Main();
                ss.Show();

            }
            else
            {
                MessageBox.Show("Please enter valid Username and Password");
                Clear();
            }

        }
            public void Clear()
            {
            textBox1.Text = "";
            textBox2.Text = "";
            
             }
    }
}
