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
    public partial class viewTrains : Form
    {
        public viewTrains()
        {
            InitializeComponent();
        }

        private void viewTrains_Load(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(247, 151, 30);
            button7.Enabled = false;
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Railway reservation system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("ShowavailableTrains", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = reader["TIn_ID"];
                dataGridView1.Rows[n].Cells[1].Value = reader["Tr_ID"];
                dataGridView1.Rows[n].Cells[2].Value = reader["from_des"];
                dataGridView1.Rows[n].Cells[3].Value = reader["to_des"];
                dataGridView1.Rows[n].Cells[4].Value = reader["datee"];
                dataGridView1.Rows[n].Cells[5].Value = reader["timee"];
            }
            reader.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookTickets f = new BookTickets();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            viewTicInfo vtic = new viewTicInfo();
            this.Hide();
            vtic.ShowDialog();
            this.ShowDialog();
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
    }
}
