using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceRecognition
{
    public partial class Form : System.Windows.Forms.Form
    {
        //SqlConnection sqlConnection = new SqlConnection("Data Source=(local);Initial Catalog=MySQL57;Integrated Security=SSPI");
        //SqlConnection sqlConnection = new SqlConnection("Data Source=(local);USER ID=root;Password=rlgus5125");
        MySqlConnection sqlConnection = new MySqlConnection("server=127.0.0.1; uid=root; pwd=rlgus5125; database=seungseung;");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        public Form()
        {
            InitializeComponent();

        }

        private void Form_Load(object sender, EventArgs e)
        {
            comboBoxPoint.SelectedIndex = 0;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error! \n\n" + ee);
            }

            cmd = new MySqlCommand("SELECT EXISTS " +
                "(SELECT 1 FROM Information_schema.tables WHERE table_name = 'scores')" +
                " AS FLAG", sqlConnection);

            reader = cmd.ExecuteReader();
            reader.Read();

            if(reader["FLAG"].ToString() != "1")
            {
                reader.Close();
                //MessageBox.Show("!");

                cmd = new MySqlCommand("CREATE TABLE scores (" +
                    "number INT(10) AUTO_INCREMENT PRIMARY KEY," +
                    "user varchar(20) NOT NULL," +
                    "date datetime," +
                    "score INT(5)," +
                    "script_name varchar(20) NOT NULL," +
                    "script mediumtext );", sqlConnection);

                cmd.ExecuteNonQuery();
            }
            else { reader.Close(); }

            cmd = new MySqlCommand("SELECT EXISTS " +
                "(SELECT 1 FROM Information_schema.tables WHERE table_name = 'scripts')" +
                " AS FLAG", sqlConnection);

            reader = cmd.ExecuteReader();
            reader.Read();

            if (reader["FLAG"].ToString() != "1")
            {
                reader.Close();

                cmd = new MySqlCommand("CREATE TABLE scripts (" +
                    "script_name varchar(20) PRIMARY KEY," +
                    "script mediumtext );", sqlConnection);

                cmd.ExecuteNonQuery();
                MessageBox.Show("WARNING : TABLE 'scripts' is EMPTY!");
            }
            else
            {
                reader.Close();
                cmd = new MySqlCommand("SELECT EXISTS (SELECT * FROM scripts) AS FLAG", sqlConnection);
                reader = cmd.ExecuteReader();
                reader.Read();
                
                if(reader["FLAG"].ToString() != "1")
                {
                    MessageBox.Show("WARNING : TABLE 'scripts' is EMPTY!");
                }
                reader.Close();
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("프로그램을 정말 종료합니까?", "프로그램 종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sqlConnection.Close();
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
