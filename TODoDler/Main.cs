using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tulpep.NotificationWindow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using System.Net;
using System.Text.RegularExpressions;

namespace TODoDler
{
    public partial class MainForm : Form
    {
        //Global var
        string MessBodyText = "You have new notification"; //notification msg 
        string MessTitleText = "You have new notification";//msg. project name
        string DATATIME = ""; //deadline timer(date)
        string JsonPath = Directory.GetCurrentDirectory().ToString()+ @"\Package.json"; //create json path
        string ConnectStr = "server=localhost;user=root;database=somesortoftestbd;"; // connect to db

        string NN = Login.AccLogin;//"Log";
        string PP = Login.AccPassword;//"Pass";
        string NT = "";
        string NTD = "";

        List<DateTime> times = new List<DateTime>();


        public MainForm()
        {
            InitializeComponent();
        }
        /// <SendingNew>  
        public class SendDead
        {
            public string toUser { get; set; }
            public string text { get; set; }
            public string toDate { get; set; }
        }
        private SendDead SendNewNotif()
        {
            var sendDead = new SendDead
            {
                toUser = NN,
                text = NT,
                toDate = NTD
            };
            return sendDead; 
        }
        /// </SendingNew>
        /// <getListOfNotif>
        public class Deadline2
        {
            public string name { get; set; }
            public string password { get; set; }
        }
        private Deadline2 GetDeadline2() //Test json package
        {
            var deadline2 = new Deadline2
            {
                name = NN,
                password = PP
            };
            return deadline2;
        }
        /// </getListOfNotif>

        public class Deadline
        {
            public string EndDate { get; set; }
            public string ProjectName { get; set; }
            public string Note { get; set; }
        }
        private Deadline GetDeadline() //Test json package
        {
            var deadline = new Deadline
            {
                ProjectName = "IDK",
                Note = "I think this ist working",
                EndDate = "66.99.6969"
            };
            return deadline;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                /*
                CreateJsonFile();//create json
                MessageBox.Show("First done");
                ReadJsonFile();//read json, 
                MessageBox.Show("Second done");
                AddDeadToDB();//write to db
                MessageBox.Show("Third done");
                GETnotiff();//get notification
                MessageBox.Show("Fourth done");
                //SendToServ();//send to Sever
                //MessageBox.Show("Fifth done");
                */
                GetAllNotif();
                dateTimePicker1_ValueChanged(null,null);
                //todo - pop up 

            } catch (Exception EX) { MessageBox.Show(EX.ToString()); };
        }
        private void GetAllNotif()
        {
            dataGridView1.Rows.Clear();
            string Ans = "";
            try
            {

                var deadline = GetDeadline2();
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
                {
                    var result = streamReader.ReadToEnd(); Ans = result.ToString();
                    if (Ans == "{}") {}
                    else
                    {
                        Match match0 = Regex.Match(Ans, @"\u0022count\u0022: \u0022.*?(\w.*)\s*\u0022, \u0022text0\u0022", RegexOptions.Singleline);
                        string Counter = match0.Success ? match0.Groups[1].Value : "Не найдено";
                        int i = 0;
                        int ii = 1;
                        times.Clear();

                        while (i < Convert.ToInt32(Counter)-1)

                        {
                            //Match match1 = Regex.Match(Ans, "\u0022text"+i+"\u0022: \u0022"+".*?(\\w.*)\\s*" + "\u0022, \u0022todate" + i + "\u0022:", RegexOptions.Singleline);
                            Match match1 = Regex.Match(Ans, "\u0022text" + i + "\u0022: \u0022" + ".*?(\\w.*)\\s*" + "\u0022, \u0022todate" + i + "\u0022:", RegexOptions.Singleline);
                            string result1 = match1.Success ? match1.Groups[1].Value : "Не найдено";

                           // Match match2 = Regex.Match(Ans, "\u0022todate"+i+"\u0022: \u0022"+@".*?(\w.*)\s*\u0022,", RegexOptions.Singleline);
                            Match match2 = Regex.Match(Ans, "\u0022todate" + i + "\u0022: \u0022" + @".*?([0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]) ", RegexOptions.Singleline);
                            string result2 = match2.Success ? match2.Groups[1].Value : "Не найдено";

                            Match match3 = Regex.Match(Ans, @".*?([0-9][0-9]:[0-9][0-9]:[0-9][0-9]\W"+"[0-9][0-9]:[0-9][0-9])\u0022, \u0022text" + ii, RegexOptions.Singleline);
                            string result3 = match3.Success ? match3.Groups[1].Value : "Не найдено";

                            string wow = result2 +" "+ result3;
                            times.Add(Convert.ToDateTime(wow.Remove(19)));

                            //MessageBox.Show(wow.Remove(19));

                            dataGridView1.Rows.Add(result1, result2, result3);
                            
                            i++;ii++;

                        }
                        Match matchLast = Regex.Match(Ans, "\u0022text" + (Convert.ToString(Convert.ToInt64(Counter)-1)) + "\u0022: \u0022" + ".*?(\\w.*)\\s*" + "\u0022, \u0022todate" + (Convert.ToString(Convert.ToInt64(Counter) - 1)) + "\u0022:", RegexOptions.Singleline);
                        string resultLast1 = matchLast.Success ? matchLast.Groups[1].Value : "Не найдено";

                        //Match match = Regex.Match(Ans, "\u0022todate" + (Convert.ToString(Convert.ToInt64(Counter) - 1)) + "\u0022: \u0022" + @".*?(\w.*)\s*\u0022}", RegexOptions.Singleline);
                        Match matchLast1 = Regex.Match(Ans, "\u0022todate" + (Convert.ToString(Convert.ToInt64(Counter) - 1)) + "\u0022: \u0022" + @".*?([0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]) ", RegexOptions.Singleline);
                        string resultLast2 = matchLast1.Success ? matchLast1.Groups[1].Value : "Не найдено";

                        Match matchLast3 = Regex.Match(Ans, @".*?([0-9][0-9]:[0-9][0-9]:[0-9][0-9]\W" + "[0-9][0-9]:[0-9][0-9])\u0022}", RegexOptions.Singleline);
                        string resultLast3 = matchLast3.Success ? matchLast3.Groups[1].Value : "Не найдено";

                        string wowe = resultLast2 + " " + resultLast3;
                        times.Add(Convert.ToDateTime(wowe.Remove(19)));

                        dataGridView1.Rows.Add(resultLast1, resultLast2, resultLast3);
                        //try sync with db


                    }
                }
            }

            catch (Exception Ex)
            {
                //dataGridView1.Rows.Add(Ex.ToString());
                //MessageBox.Show("WOW!: " + Ex.ToString());
            }
        }
        private void GETnotiff(DateTime ThisDate)
        {
            
            string date = ThisDate.ToString("yyyy-MM-dd hh-mm-ss").Remove(10); //2019-12-08 21:00:02
            string time = ThisDate.ToString("HH:mm:ss yyyy-MM-dd").Remove(8);
            //for(int i =2; i<=dataGridView1.Columns.Count;i++)
            for(int j=0;j<dataGridView1.Rows.Count;j++)
            { if (dataGridView1.Rows[j].Cells[1].Value.ToString() == date)
                {
                    string check = dataGridView1.Rows[j].Cells[2].Value.ToString().Remove(8);
                    //MessageBox.Show(check+" / "+ time);
                    if (check == time) 
                    {  MessBodyText = dataGridView1.Rows[j].Cells[0].Value.ToString(); break; }
                }
            }
            PopupNotifier poop = new PopupNotifier();
            //poop.Image = //Properties.Resources.pepega;
            poop.TitleText = MessTitleText;
            poop.ContentText = MessBodyText;
            poop.Popup();
        }
        /*
        private void SendToServ()
        {
            try
            {
                var deadline = GetDeadline();
                var jsonToWrite = JsonConvert.SerializeObject(deadline, Formatting.Indented);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:5000/views/");
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
                    {var result = streamReader.ReadToEnd();}
            }catch (Exception ex){ /*MessageBox.Show("Error: " + ex); }
        }
        private void ReadJsonFile()
        {

            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader(JsonPath))
                { jsonFromFile = reader.ReadToEnd(); }
                //richTextBox1.Text = jsonFromFile;
                var customerFromJson = JsonConvert.DeserializeObject<Deadline>(jsonFromFile);

                var details = JObject.Parse(jsonFromFile);

                MessTitleText = string.Concat(details["ProjectName"], "");
                MessBodyText = string.Concat(details["Note"], "");
                DATATIME = string.Concat(details["EndDate"], "");

            }
            catch (Exception ex)
            {MessageBox.Show("Error: " + ex);}
           
        }
*/

        private void AddDeadToDB()
        {
            try { 
            MySqlConnection conn = new MySqlConnection(ConnectStr);
            conn.Open();
            string Sql = "INSERT INTO deds VALUES('', '', '" + NT + "', '" + NTD + "')";
           // MessageBox.Show(Sql);
            MySqlCommand CommandSQL = new MySqlCommand(Sql, conn);
            string GetProjectName = CommandSQL.ExecuteScalar().ToString();
            conn.Close();
            }
            catch (Exception EX) { /* MessageBox.Show(EX.ToString()); */}
        }
        /*
        private void CreateJsonFile()
        {
            try
            {
                var deadline = GetDeadline();
                var jsonToWrite = JsonConvert.SerializeObject(deadline, Formatting.Indented);
                using (var writer = new StreamWriter(JsonPath))
                { writer.Write(jsonToWrite); }

            }
            catch (Exception ex)
            { MessageBox.Show("Error: " + ex); }
        }
        */
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NT = richTextBox1.Text;
                NTD = dateTimePicker1.Text;
                var deadlines = SendNewNotif();
                var jsonToWrite = JsonConvert.SerializeObject(deadlines, Formatting.Indented);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.43.69:8000/descpath/nm/");
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
                    var result = streamReader.ReadToEnd();
                    if (result.ToString() == "1")
                    { GetAllNotif(); AddDeadToDB(); }
                    else {MessageBox.Show("Error: " + result.ToString(), "Warning"); } 
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("WOW!: " + Ex.ToString());
            }
}

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //listBox1.Items.Add(DateTime.Now);
            times.Sort();
            times.Reverse();
            DateTime TimeNotif = times.Last();
            DateTime TimeNow = DateTime.Now;
            if(TimeNotif <= TimeNow)
            {
             GETnotiff(TimeNotif);
             times.RemoveAt(times.Count-1);
            }
            
        }
    }
}
