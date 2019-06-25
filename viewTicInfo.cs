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
    public partial class viewTicInfo : Form
    {
        public viewTicInfo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Railway reservation system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("validateTicId", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@ticID", Convert.ToInt32(textBox1.Text)));
            SqlParameter myParam = cmd1.Parameters.Add("@@ok", SqlDbType.Int);
            myParam.Direction = ParameterDirection.Output;
            SqlDataReader read1 = cmd1.ExecuteReader();
            read1.Close();
            int ok = Convert.ToInt32(cmd1.Parameters["@@ok"].Value.ToString());
            if (ok == 0)
            {
                variables.x = Convert.ToInt32(textBox1.Text);
                TicketDisplay f5 = new TicketDisplay();
                this.Hide();
                f5.ShowDialog();
                this.Close();
            }
            else
            {
                label9.Text = "Ticket ID not found, please enter a valid ticket ID.";
            }
            con.Close();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            this.Hide();
            f.ShowDialog();
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
            CancelForm fr = new CancelForm();
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            viewTrains f = new viewTrains();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void viewTicInfo_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(247, 151, 30);
            button1.Enabled = false;
        }

        private void label9_VisibleChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            label9.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
