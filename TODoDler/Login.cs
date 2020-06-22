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
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }
        string NN;
        string PP;
        public static string AccLogin;
        public static string AccPassword;
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
        private void BT_Enter_Click(object sender, EventArgs e)
        {
            string Ans = "";
            try
            {
                NN = TB_Login.Text;
                PP = TB_Pass.Text;
                AccLogin = TB_Login.Text;
                AccPassword = TB_Pass.Text;
                var deadline = GetDeadline();
                var jsonToWrite = JsonConvert.SerializeObject(deadline, Formatting.Indented);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.43.69:8000/descpath/login/");
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
                { var result = streamReader.ReadToEnd(); Ans = result.ToString();
                    if (Ans != "not registred")
                    { //MessageBox.Show("You in list, move along");
                        this.Hide();
                        MainForm Main = new MainForm();
                        Main.Show();
                    }
                    else { MessageBox.Show(Ans); }
                }
            }

            catch(Exception Ex)
            {
                MessageBox.Show("Server error. Now it offlain mod. Error: " + Ex.ToString());
            
            ///////////////////////////////////////////////////////////////////////////////////////////////
            string ConnectStr = "server=localhost;user=root;database=somesortoftestbd;"; // connect to db
                try
                {

                MySqlConnection conn = new MySqlConnection(ConnectStr);
                    conn.Open();
                    string Sql = "SELECT UserName,UserPassword FROM `users` WHERE UserName = '" + TB_Login.Text+"' AND UserPassword = '"+TB_Pass.Text+"'";
                    MySqlCommand CommandSQL = new MySqlCommand(Sql, conn);
                    MySqlDataReader UserNamePass = CommandSQL.ExecuteReader();
               
                List<string[]> userData = new List<string[]>();
                while (UserNamePass.Read())
                {
                    userData.Add(new string[2]);
                    userData[userData.Count - 1][0] = UserNamePass[0].ToString();
                    userData[userData.Count - 1][1] = UserNamePass[1].ToString();
                }
                UserNamePass.Close();
                conn.Close();
                string UserName="", UserPassword="";

                foreach (string[] s in userData)
                {
                    UserName = s[0];
                    UserPassword = s[1];
                }
                if (UserName == TB_Login.Text && UserPassword == TB_Pass.Text)
                {
                    this.Hide();
                    MainForm Main = new MainForm();
                    Main.Show();
                }
                else { MessageBox.Show("Wrong Login or Password"); }
            }
                catch (Exception EX) {  MessageBox.Show(EX.ToString()); }
            }
        }

        private void BT_Reg_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration Reg = new Registration();
            Reg.ShowDialog();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
