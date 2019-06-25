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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Railway reservation system;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("get_time_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Date", textBox4.Text));
            cmd.Parameters.Add(new SqlParameter("@Time", textBox3.Text));
            SqlParameter myParam = cmd.Parameters.Add("@@tim_id", SqlDbType.Int);
            myParam.Direction = ParameterDirection.Output;
            SqlDataReader read = cmd.ExecuteReader();
            int z=-1;
            read.Close();
            if (cmd.Parameters["@@tim_id"].Value.ToString() == "")
            {
                SqlCommand cmd2 = new SqlCommand(@"insert into Timee (datee, timee) Values (@x,@x1) ", con);
                SqlParameter param1 = new SqlParameter("@x", textBox4.Text);
                SqlParameter param = new SqlParameter("@x1", textBox3.Text);
                cmd2.Parameters.Add(param1);
                cmd2.Parameters.Add(param);
                cmd2.ExecuteNonQuery();
                cmd = new SqlCommand("get_time_id", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Date", textBox4.Text));
                cmd.Parameters.Add(new SqlParameter("@Time", textBox3.Text));
                SqlParameter myParam1 = cmd.Parameters.Add("@@tim_id", SqlDbType.Int);
                myParam1.Direction = ParameterDirection.Output;
                SqlDataReader reader = cmd.ExecuteReader();
                z = Convert.ToInt32(cmd.Parameters["@@tim_id"].Value.ToString());
                reader.Close();
            }
            else
            {
                z = Convert.ToInt32(cmd.Parameters["@@tim_id"].Value.ToString());
            }
            SqlCommand cmd1 = new SqlCommand("get_des_id", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@Dest_from", textBox1.Text));
            cmd1.Parameters.Add(new SqlParameter("@Dest_to", textBox2.Text));
            myParam = cmd1.Parameters.Add("@@ID", SqlDbType.Int);
            myParam.Direction = ParameterDirection.Output;
            SqlDataReader read1 = cmd1.ExecuteReader();
            int y=-1;
            read1.Close();
            if (cmd1.Parameters["@@ID"].Value.ToString() == "")
            {
                SqlCommand cmd2 = new SqlCommand(@"insert into Distnation (from_des, to_des) Values (@x,@x1)", con);
                SqlParameter param = new SqlParameter("@x", textBox1.Text);
                SqlParameter param1 = new SqlParameter("@x1", textBox2.Text);
                cmd2.Parameters.Add(param);
                cmd2.Parameters.Add(param1);
                cmd2.ExecuteNonQuery();
                cmd1 = new SqlCommand("get_des_id", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@Dest_from", textBox1.Text));
                cmd1.Parameters.Add(new SqlParameter("@Dest_to", textBox2.Text));
                myParam = cmd1.Parameters.Add("@@ID", SqlDbType.Int);
                myParam.Direction = ParameterDirection.Output;
                SqlDataReader reader1 = cmd1.ExecuteReader();
                y = Convert.ToInt32(cmd1.Parameters["@@ID"].Value.ToString());
                reader1.Close();
            }
            else
            {
                y = Convert.ToInt32(cmd1.Parameters["@@ID"].Value.ToString());
            }


            SqlCommand cmdgt = new SqlCommand("get_train_id", con);
            cmdgt.CommandType = CommandType.StoredProcedure;
            SqlParameter mp1 = new SqlParameter("@d_ID", y);
            cmdgt.Parameters.Add(mp1); 
            mp1 = new SqlParameter("@t_ID", z);
            cmdgt.Parameters.Add(mp1);
            mp1 = new SqlParameter("@TrainID", Convert.ToInt32(textBox5.Text));
            cmdgt.Parameters.Add(mp1); 
            SqlParameter mP2 = cmdgt.Parameters.Add("@@tr_ID", SqlDbType.Int);
            mP2.Direction = ParameterDirection.Output;
            SqlDataReader reader2 = cmdgt.ExecuteReader();
            reader2.Close();
            if (cmdgt.Parameters["@@tr_ID"].Value.ToString() == "")
            {
                cmd1 = new SqlCommand(@"insert into T_info (Tim_ID, des_ID, Tr_ID) Values (@x, @x1, @x2)", con);
                SqlParameter myparam1 = new SqlParameter("@x", z);
                SqlParameter myparam2 = new SqlParameter("@x1", y);
                SqlParameter myparam3 = new SqlParameter("@x2", Convert.ToInt32(textBox5.Text));
                cmd1.Parameters.Add(myparam1);
                cmd1.Parameters.Add(myparam2);
                cmd1.Parameters.Add(myparam3);
                cmd1.ExecuteNonQuery();

                cmdgt = new SqlCommand("get_train_id", con);
                cmdgt.CommandType = CommandType.StoredProcedure;
                mp1 = new SqlParameter("@d_ID", y);
                cmdgt.Parameters.Add(mp1);
                mp1 = new SqlParameter("@t_ID", z);
                cmdgt.Parameters.Add(mp1);
                mp1 = new SqlParameter("@TrainID", Convert.ToInt32(textBox5.Text));
                cmdgt.Parameters.Add(mp1); 
                mP2 = cmdgt.Parameters.Add("@@tr_ID", SqlDbType.Int);
                mP2.Direction = ParameterDirection.Output;
                reader2 = cmdgt.ExecuteReader();
                reader2.Close();
                z = Convert.ToInt32(cmdgt.Parameters["@@tr_ID"].Value.ToString());


                cmd1 = new SqlCommand(@"insert into Ticket (TIn_ID, seat_num) Values (@x, @x1)", con);
                myparam1 = new SqlParameter("@x", z);
                cmd1.Parameters.Add(myparam1);
                myparam2 = new SqlParameter("@x1", 1);
                cmd1.Parameters.Add(myparam2);
                cmd1.ExecuteNonQuery();

                cmd1 = new SqlCommand(@"insert into Ticket (TIn_ID, seat_num) Values (@x, @x1)", con);
                myparam1 = new SqlParameter("@x", z);
                myparam2 = new SqlParameter("@x1", 2);
                cmd1.Parameters.Add(myparam1);
                cmd1.Parameters.Add(myparam2);
                cmd1.ExecuteNonQuery();

                cmd1 = new SqlCommand(@"insert into Ticket (TIn_ID, seat_num) Values (@x, @x1)", con);
                myparam1 = new SqlParameter("@x", z);
                myparam2 = new SqlParameter("@x1", 3);
                cmd1.Parameters.Add(myparam1);
                cmd1.Parameters.Add(myparam2);
                cmd1.ExecuteNonQuery();

                cmd1 = new SqlCommand(@"insert into Ticket (TIn_ID, seat_num) Values (@x, @x1)", con);
                myparam1 = new SqlParameter("@x", z);
                myparam2 = new SqlParameter("@x1", 4);
                cmd1.Parameters.Add(myparam1);
                cmd1.Parameters.Add(myparam2);
                cmd1.ExecuteNonQuery();

                cmd1 = new SqlCommand(@"insert into Ticket (TIn_ID, seat_num) Values (@x, @x1)", con);
                myparam1 = new SqlParameter("@x", z);
                myparam2 = new SqlParameter("@x1", 5);
                cmd1.Parameters.Add(myparam1);
                cmd1.Parameters.Add(myparam2);
                cmd1.ExecuteNonQuery();
                label9.ForeColor = Color.White;
                label9.Text = "Train was succefully added to the system.";
            }
            else
            {
                label9.ForeColor = Color.Red;
                label9.Text =  "ERROR: This train already exists.";
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label9.Text = "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
