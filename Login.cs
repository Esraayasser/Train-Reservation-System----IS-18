using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Railway reservation system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("validateID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            int y = Convert.ToInt32(textBox2.Text);
            cmd.Parameters.Add(new SqlParameter("@ID", y));
            cmd.Parameters.Add(new SqlParameter("@nm", textBox1.Text));
            SqlParameter myParam = cmd.Parameters.Add("@@ok", SqlDbType.Int);
            myParam.Direction = ParameterDirection.Output;
            SqlDataReader read = cmd.ExecuteReader();
            read.Close();
            if (cmd.Parameters["@@ok"].Value.ToString() == "")
            {
                label9.Text = "The username or ID is invalide please enter a valid one.";
            }
            else
            {
                Form8 f = new Form8();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            label9.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CancelForm f6 = new CancelForm();
            this.Hide();
            f6.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            viewTrains vt = new viewTrains();
            this.Hide();
            vt.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BookTickets f = new BookTickets();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewTicInfo vtic = new viewTicInfo();
            this.Hide();
            vtic.ShowDialog();
            this.ShowDialog();
        }
    }
}
