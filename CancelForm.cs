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
    public partial class CancelForm : Form
    {
        public CancelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Railway reservation system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("validateTicId", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ticID", Convert.ToInt32(textBox1.Text.ToString())));
            SqlParameter myParam = cmd1.Parameters.Add("@@ok", SqlDbType.Int);
            myParam.Direction = ParameterDirection.Output;
            SqlDataReader read1 = cmd1.ExecuteReader();
            read1.Close();
            if (cmd1.Parameters["@@ok"].Value.ToString() == "0")
            {
                SqlCommand cmd = new SqlCommand("cancelation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TID", Convert.ToInt32(textBox1.Text)));
                SqlDataReader read = cmd.ExecuteReader();
                read.Close();
                label9.ForeColor = Color.White;
                label9.Text = "Ticket was successfully canceled.";
               
            }
            else
            {
                label9.ForeColor = Color.Red;
                label9.Text = "Ticket ID not found, please enter a valid ticket ID.";
            }
            con.Close();
            textBox1.Clear();
        } 

        private void Form6_Load(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(247, 151, 30);
            button6.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            this.Hide();
            f.ShowDialog();
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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewTicInfo vtic = new viewTicInfo();
            this.Hide();
            vtic.ShowDialog();
            this.Close();
        }

        private void button1_VisibleChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            label9.Text = "";
        }
    }
}
