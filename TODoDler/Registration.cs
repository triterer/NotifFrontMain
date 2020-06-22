using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace TODoDler
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        string NN;
        string PP;
        string ConnectStr = "server=localhost;user=root;database=somesortoftestbd;"; // connect to db
        private void TB_Reg_Click(object sender, EventArgs e)
        {
            try// try connect server
            {
                test();
            }
            catch(Exception Ex)
            { MessageBox.Show(Ex.ToString()); }
            try// try connect local
            {
                MySqlConnection conn = new MySqlConnection(ConnectStr);
                conn.Open();
                string Sql = "INSERT INTO users VALUES('', '" + TB_Login.Text + "', '" + TB_Pass.Text + "', '0')";
                if (TB_Login.Text == "" || TB_Pass.Text == "")
                    MessageBox.Show("Field must be filled");
                else 
                { 
                MySqlCommand CommandSQL = new MySqlCommand(Sql, conn);
                string GetProjectName = CommandSQL.ExecuteScalar().ToString();
                conn.Close();
                }
            }
            catch (Exception EX) { /* MessageBox.Show(EX.ToString()); */}
        }
        public class Deadline
        {
            public string name { get; set; }
            public string password { get; set; }
        }
        private Deadline GetDeadline() //Test json package
        {
            var deadline = new Deadline
            {
                name = NN,
                password = PP
            };
            return deadline;
        }
        private void test()
        {
            try
            {
                NN = TB_Login.Text;
                PP = TB_Pass.Text;
                var deadline = GetDeadline();
                var jsonToWrite = JsonConvert.SerializeObject(deadline, Formatting.Indented);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.43.69:8000/descpath/registration/");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonToWrite);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd(); MessageBox.Show(result.ToString());
                    if (result.ToString() == "")
                    {
                    }
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show("WOW!: " + Ex.ToString());
            }
        }
            ///////////////////////////////////////////////////////////////////////////////////////////////
            private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login Log = new Login();
            Log.Show();
        }
    }
}
