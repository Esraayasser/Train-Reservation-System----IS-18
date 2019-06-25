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
    public partial class TicketDisplay : Form
    {
        public TicketDisplay()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Railway reservation system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("ShowTicketInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@TID", variables.x));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label16.Text = reader["Tic_ID"].ToString();
                label14.Text = reader["name"].ToString();
                label12.Text = reader["seat_num"].ToString();
                label10.Text = reader["Tr_ID"].ToString();
                label5.Text = reader["from_des"].ToString();
                label6.Text = reader["to_des"].ToString();
                label7.Text = reader["datee"].ToString();
                label8.Text = reader["timee"].ToString();
            }
            reader.Close();
            con.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewTicInfo vtic = new viewTicInfo();
            this.Hide();
            vtic.ShowDialog();
            this.Close();
        }

        private void Form5_VisibleChanged(object sender, EventArgs e)
        {
        }
    }
}
