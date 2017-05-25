using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Google.Cloud.Speech.V1Beta1;
using DiffMatchPatch;

namespace VoiceRecognition
{
    public partial class Form : System.Windows.Forms.Form
    {
        //Secure Connection using SSL
        MySqlConnection sqlConnection = new MySqlConnection("server=127.0.0.1; uid=root; pwd=rlgus5125; database=seungseung; SslMode=Required;");
        MySqlConnection back_sqlConnection = new MySqlConnection("server=127.0.0.1; uid=root; pwd=rlgus5125; database=seungseung; SslMode=Required;");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        String videoDirectory = Directory.GetCurrentDirectory() + "\\video\\";
        String audioDirectory = Directory.GetCurrentDirectory() + "\\audio\\";
        String processedDirectory = Directory.GetCurrentDirectory() + "\\processed\\";
        float stopSecond = 2.0F;

        bool bSearch = false;
        bool bDate = false;

        String search_cmd = "SELECT * FROM scores WHERE ";

        BackgroundWorker worker;


        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // 이중 실행 체크. 이미 실행되고 있으면 박스 띄우고 트레이 하이라이트 하거나 활성화

            comboBoxPoint.SelectedIndex = 0;
            comboBoxScript.SelectedIndex = 0;

            try
            {
                sqlConnection.Open();
                back_sqlConnection.Open();
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

            cmd = new MySqlCommand("SELECT script_name FROM scripts", sqlConnection);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                comboBoxScript.Items.Add(reader["script_name"]);
            }
            reader.Close();

            FolderChecker();

            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            worker.RunWorkerAsync();
            
        }

        private void FolderChecker()
        {
            if (!Directory.Exists(videoDirectory))
                Directory.CreateDirectory(videoDirectory);
            if (!Directory.Exists(audioDirectory))
                Directory.CreateDirectory(audioDirectory);
            if (!Directory.Exists(processedDirectory))
                Directory.CreateDirectory(processedDirectory);

            DirectoryInfo dInfo = new DirectoryInfo(videoDirectory);

            videofsWatcher.Path = videoDirectory;
            videofsWatcher.NotifyFilter = NotifyFilters.FileName;
            videofsWatcher.Filter = "";

            //원래 폴더에 들어있던 파일에 대해 시행
            foreach (var item in dInfo.GetFiles())
            {
                videoAdded(item.Name);
            }

            videofsWatcher.Created += new FileSystemEventHandler(videoCreated);

        }

        
        private void videoCreated(object source, FileSystemEventArgs e)
        {
            videoAdded(e.Name);
        }

        private void videoAdded(String fileName)
        {
            /*
             * System init :: 전체 검사
             * 디렉토리 내부 변경 신호; catch : SQL 등록; 번호, 파일명, (점수), 처리날짜, 상태 (extracting voice)
             * 구글에 전달 : SQL 반영 (readout in google)
             * 비교 완료 : SQL 반영; 점수등록 (process complete)
             * 파일 이동 (video -> processed)
             * 
             * 들어올 파일의 이름은 '유저이름_스크립트_해시' 형태로 이루어져야 한다.
             * 파일의 이름은 전송하는 클라이언트 수준에서 변경되어 전송되어야 한다.
             * 즉, 해싱 또한 클라이언트에서 수행하여 서버로 전달하며 별도의 검사를 수행하지 않는다.
             * 해시는 파일 무결성을 보장함과 동시에 중복되지 않도록 하는 역할을 수행하도록 한다.
             * SHA256에 의하여 해싱한다. 해시 충돌은 없다고 가정한다.
             *
             */

            String inputVideo = fileName;
            String[] videoName = inputVideo.Split('.');
            String[] param = videoName[0].Split('_');
            //LAST_INSERT_ID()로 해당 row의 auto_increment를 알아내는 방법도 있으나 이후 병렬시행될 경우를 고려
            String hash = param[2];

            WriteLog("fileName : File Detected!");
            
            cmd = new MySqlCommand("SELECT EXISTS (SELECT * FROM scores WHERE hash = @hash) AS FLAG", sqlConnection);
            cmd.Parameters.AddWithValue("@hash", param[2]);
            reader = cmd.ExecuteReader();
            reader.Read();

            if (reader["FLAG"].ToString() == "0")
            {
                reader.Close();

                cmd = new MySqlCommand("INSERT INTO scores(user, date, script_name, state, hash) VALUES (@user, @date, @script_name, @state, @hash)", sqlConnection);
                cmd.Parameters.AddWithValue("@user", param[0]);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //.fff
                cmd.Parameters.AddWithValue("@script_name", param[1]);
                cmd.Parameters.AddWithValue("@state", "Converting");
                cmd.Parameters.AddWithValue("@hash", param[2]);
                cmd.ExecuteNonQuery();

                String arg = "-i \"" + videoDirectory + inputVideo + "\" -acodec flac -bits_per_raw_sample 16 -ar 44100 -ac 1 \"" + audioDirectory + videoName[0] + ".flac\"";

                ProcessStartInfo psInfo = new ProcessStartInfo("ffmpeg.exe", arg);
                psInfo.WindowStyle = ProcessWindowStyle.Hidden;
                psInfo.CreateNoWindow = true;
                Process.Start(psInfo).WaitForExit();
                WriteLog("fileName : File Converted. Queuing Google Speech API Server.");

                var speech = SpeechClient.Create();
                var response = speech.SyncRecognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                    SampleRate = 44100,
                    LanguageCode = "cmn-Hans-CN"
                }, RecognitionAudio.FromFile(audioDirectory + videoName[0] + ".flac"));


                String voice = "";
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        voice += alternative.Transcript.ToString() + ",";
                    }
                }
                voice = voice.Substring(0, voice.LastIndexOf(","));

                cmd = new MySqlCommand("UPDATE scores SET state=@state, script=@script WHERE hash = @hash", sqlConnection);
                cmd.Parameters.AddWithValue("@state", "Processing");
                cmd.Parameters.AddWithValue("@script", voice);
                cmd.Parameters.AddWithValue("@hash", hash);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("SELECT script FROM scripts WHERE script_name = @script_name", sqlConnection);
                cmd.Parameters.AddWithValue("@script_name", param[1]);
                reader = cmd.ExecuteReader();
                reader.Read();

                WriteLog("fileName : Script Converted. Calcuating score.");

                int del_count = 0;
                int all_count = 0;
                var diff = new diff_match_patch();
                var results = diff.diff_main(voice, reader["script"].ToString());
                foreach (var verbs in results)
                {
                    if(verbs.operation == Operation.DELETE)
                    {
                        del_count += verbs.ToString().Length;
                    }

                    all_count += verbs.ToString().Length;
                }

                float score = (float)(all_count - del_count) / all_count * 100;

                reader.Close();

                cmd = new MySqlCommand("UPDATE scores SET state=@state, score=@score WHERE hash = @hash", sqlConnection);
                cmd.Parameters.AddWithValue("@state", "Completed");
                cmd.Parameters.AddWithValue("@score", score);
                cmd.Parameters.AddWithValue("@hash", hash);
                cmd.ExecuteNonQuery();

                WriteLog("fileName : Process Completed.");

            }
            else
            {
                // hash 충돌 처리. 절대다수의 경우 동일파일.
                reader.Close();
                WriteLog("fileName : Hash Collision!");
            }

            FileInfo fi = new FileInfo(videoDirectory + fileName);

            fi.CopyTo(processedDirectory + fileName, true);
            fi.Delete();
            
        }

        private void WriteLog(String log)
        {
            textBoxLog.AppendText(log + "\n");
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            notifyIcon.ShowBalloonTip(3, "승승", "트레이로 이동합니다...", ToolTipIcon.Info);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램을 정말 종료합니까?", "프로그램 종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sqlConnection.Close();
                notifyIcon.Visible = false;
                Application.ExitThread();
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MySqlCommand back_cmd;
            MySqlDataReader back_reader;
            
            while(true)
            {
                CheckForIllegalCrossThreadCalls = false;
                listViewResults.BeginUpdate();

                if (bSearch)
                    back_cmd = new MySqlCommand(search_cmd + "ORDER BY number DESC", back_sqlConnection);
                else
                    back_cmd = new MySqlCommand("SELECT * FROM scores ORDER BY number DESC", back_sqlConnection);

                back_reader = back_cmd.ExecuteReader();
                while(back_reader.Read())
                {
                    ListViewItem lvi = new ListViewItem(back_reader["user"].ToString());
                    lvi.SubItems.Add(back_reader["date"].ToString());
                    lvi.SubItems.Add(back_reader["score"].ToString());
                    lvi.SubItems.Add(back_reader["script_name"].ToString());
                    lvi.SubItems.Add(back_reader["script"].ToString());
                    lvi.SubItems.Add(back_reader["state"].ToString());
                    listViewResults.Items.Add(lvi);
                }
                back_reader.Close();

                listViewResults.EndUpdate();
                System.Threading.Thread.Sleep((int)(stopSecond*1000));
                listViewResults.Items.Clear();

            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            bSearch = true;
            search_cmd = "SELECT * FROM scores WHERE ";

            if (textBoxName.Text.Trim() != "")
                search_cmd += "user = '" + textBoxName.Text.ToString() + "' AND ";

            if (bDate)
                search_cmd += "date(date) = '" + dateTimePicker.Value.ToString("yyyy-MM-dd") + "' AND ";

            if (textBoxScore.Text.Trim() != "")
            {
                if (comboBoxPoint.SelectedIndex == 0)
                    search_cmd += "score >= " + textBoxScore.Text.ToString() + " AND ";
                else
                    search_cmd += "score <= " + textBoxScore.Text.ToString() + " AND ";
            }

            if (comboBoxScript.SelectedIndex != 0)
                search_cmd += "script_name = '" + comboBoxScript.SelectedItem.ToString() + "' AND ";
            else
                search_cmd += "1=1 AND ";

            search_cmd = search_cmd.Substring(0, search_cmd.LastIndexOf("AND "));

        }

        private void dateTimePicker_DropDown(object sender, EventArgs e)
        {
            if(!bDate)
            {
                bDate = true;

                dateTimePicker.Format = DateTimePickerFormat.Short;
                dateTimePicker.Value = DateTime.Now;
            }
        }

        private void buttonFullList_Click(object sender, EventArgs e)
        {
            //Form Initialize
            bSearch = false;
            bDate = false;

            textBoxName.Text = "";
            textBoxScore.Text = "";

            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = " ";

            comboBoxScript.SelectedIndex = 0;
        }
    }
}
