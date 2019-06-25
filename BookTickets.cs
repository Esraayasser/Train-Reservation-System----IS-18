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
    public partial class BookTickets : Form
    {
        public BookTickets()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(247, 151, 30);
            button5.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Railway reservation system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                con.Open();
                SqlCommand cmd1 = new SqlCommand("validateTripID", con);
                SqlParameter mp = new SqlParameter("@tr", Convert.ToInt32(textBox1.Text));
                cmd1.Parameters.Add(mp);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter myParam2 = cmd1.Parameters.Add("@@ok", SqlDbType.Int);
                myParam2.Direction = ParameterDirection.Output;
                SqlDataReader reader2 = cmd1.ExecuteReader();
                reader2.Close();
                if (cmd1.Parameters["@@ok"].Value.ToString() == "")
                {
                    label8.Text = "Invalid Trip ID.";
                }
            }
            else
            {
                label8.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            viewTrains vt = new viewTrains();
            this.Hide();
            vt.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Railway reservation system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            con.Open();
            SqlCommand cmd4 = new SqlCommand("findseat", con);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.Add(new SqlParameter("@trID", Convert.ToInt32(textBox1.Text)));
            SqlParameter myParam = cmd4.Parameters.Add("@@ID", SqlDbType.Int);
            myParam.Direction = ParameterDirection.Output;
            SqlDataReader read4 = cmd4.ExecuteReader();
            read4.Close();
            int h = -1;
            if (cmd4.Parameters["@@ID"].Value.ToString() == "")
            {
                label9.Text = "Sorry all tickets in this trip has been booked try chooseing another";
            }
            else
            {
                h = Convert.ToInt32(cmd4.Parameters["@@ID"].Value.ToString());
                SqlCommand cmd3 = new SqlCommand(@"update Ticket set state = 1  where Tic_Id = @Id", con);
                SqlParameter param5 = new SqlParameter("@Id", h);
                cmd3.Parameters.Add(param5);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("insertpIn", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pname", textBox4.Text));
                cmd.Parameters.Add(new SqlParameter("@padd", textBox3.Text));
                cmd.Parameters.Add(new SqlParameter("@phone", textBox2.Text));
                cmd.Parameters.Add(new SqlParameter("@tic", h));
                SqlDataReader read = cmd.ExecuteReader();
                read.Close();
                con.Close();
                variables.x = h;
                TicketDisplay f = new TicketDisplay();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CancelForm f6 = new CancelForm();
            this.Hide();
            f6.ShowDialog();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            viewTicInfo vtic = new viewTicInfo();
            this.Hide();
            vtic.ShowDialog();
            this.ShowDialog();
        }

        private void Form3_VisibleChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            label9.Text = "";
        }
    }
}
