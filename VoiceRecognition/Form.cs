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
using System.IO;
using System.Diagnostics;
using Google.Cloud.Speech.V1Beta1;

namespace VoiceRecognition
{
    public partial class Form : System.Windows.Forms.Form
    {
        static MySqlConnection sqlConnection = new MySqlConnection("server=127.0.0.1; uid=root; pwd=rlgus5125; database=seungseung;");
        static MySqlCommand cmd = new MySqlCommand();
        static MySqlDataReader reader;

        static String videoDirectory = Directory.GetCurrentDirectory() + "\\video";
        static String audioDirectory = Directory.GetCurrentDirectory() + "\\audio";
        static String processedDirectory = Directory.GetCurrentDirectory() + "\\processed";

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

            FolderChecker();
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

            videofsWatcher.Created += new FileSystemEventHandler(videoCreated);
        }

        private static void videoCreated(object source, FileSystemEventArgs e)
        {
            videoAdded(e.Name);
        }

        private static void videoAdded(String fileName)
        {
            /*
             * 
             * System init :: 전체 검사
             * 디렉토리 내부 변경 신호; catch : SQL 등록; 번호, 파일명, (점수), 처리날짜, 상태 (extracting voice)
             * 구글에 전달 : SQL 반영 (readout in google)
             * 비교 완료 : SQL 반영; 점수등록 (process complete)
             * 파일 이동 (video -> processed)
             * 
            */

            //Log 반영코드 추가할것
            //SQL 반영코드 추가할것

            String inputVideo = fileName;
            String[] videoName = inputVideo.Split('.');
            String[] param = videoName[0].Split('_');

            cmd = new MySqlCommand("INSERT INTO scores(user, date, script_name) VALUES (@user, @date, @script_name)", sqlConnection);
            cmd.Parameters.AddWithValue("@user", param[0]);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd- HH:mm:ss"));
            cmd.Parameters.AddWithValue("@script_name", param[1]);
            cmd.ExecuteNonQuery();
            //SQL 최초등록

            String arg = "-i \"" + videoDirectory + "\\" + inputVideo + "\" -acodec flac -bits_per_raw_sample 16 -ar 44100 -ac 1 \"" + audioDirectory + "\\" + videoName[0] + ".flac\"";

            ProcessStartInfo psInfo = new ProcessStartInfo("ffmpeg.exe", arg);
            psInfo.WindowStyle = ProcessWindowStyle.Hidden;
            psInfo.CreateNoWindow = true;
            Process.Start(psInfo).WaitForExit();

            //중국어 간체를 Encoding하여 사용.
            //DB는 UTF8 general.
            //http://www.hoons.net/Board/QACSHAP/Content/40467

            var speech = SpeechClient.Create();
            var response = speech.SyncRecognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                SampleRate = 44100,
                LanguageCode = "cmn-Hans-CN"
            }, RecognitionAudio.FromFile(audioDirectory + videoName[0]+".flac"));

           foreach(var result in response.Results)
           {
                foreach (var alternative in result.Alternatives)
                {
                    
                    //Console.WriteLine(alternative.Transcript);
                    cmd = new MySqlCommand("UPDATE ", sqlConnection);

                    cmd.ExecuteNonQuery();
                }
           }


            // 비교
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
