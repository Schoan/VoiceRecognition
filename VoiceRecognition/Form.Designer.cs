﻿namespace VoiceRecognition
{
    partial class Form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.buttonFullList = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.comboBoxScript = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPoint = new System.Windows.Forms.ComboBox();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.ch_user = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_score = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_script_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_script = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.videofsWatcher = new System.IO.FileSystemWatcher();
            this.buttonExit = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videofsWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFullList
            // 
            this.buttonFullList.ImageIndex = 0;
            this.buttonFullList.ImageList = this.imageList;
            this.buttonFullList.Location = new System.Drawing.Point(12, 12);
            this.buttonFullList.Name = "buttonFullList";
            this.buttonFullList.Size = new System.Drawing.Size(55, 55);
            this.buttonFullList.TabIndex = 0;
            this.buttonFullList.UseVisualStyleBackColor = true;
            this.buttonFullList.Click += new System.EventHandler(this.buttonFullList_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "icon_list.png");
            this.imageList.Images.SetKeyName(1, "icon_option.png");
            this.imageList.Images.SetKeyName(2, "icon_search.png");
            this.imageList.Images.SetKeyName(3, "icon_exit.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID : ";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.comboBoxScript);
            this.groupBox.Controls.Add(this.buttonSearch);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.comboBoxPoint);
            this.groupBox.Controls.Add(this.textBoxScore);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.dateTimePicker);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.textBoxName);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Location = new System.Drawing.Point(12, 81);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(1012, 78);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "검색";
            // 
            // comboBoxScript
            // 
            this.comboBoxScript.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScript.FormattingEnabled = true;
            this.comboBoxScript.Items.AddRange(new object[] {
            "(전체 검색)"});
            this.comboBoxScript.Location = new System.Drawing.Point(696, 29);
            this.comboBoxScript.Name = "comboBoxScript";
            this.comboBoxScript.Size = new System.Drawing.Size(219, 28);
            this.comboBoxScript.TabIndex = 4;
            // 
            // buttonSearch
            // 
            this.buttonSearch.ImageIndex = 2;
            this.buttonSearch.ImageList = this.imageList;
            this.buttonSearch.Location = new System.Drawing.Point(946, 16);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(55, 55);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(642, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "대본 : ";
            // 
            // comboBoxPoint
            // 
            this.comboBoxPoint.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPoint.DropDownWidth = 44;
            this.comboBoxPoint.FormattingEnabled = true;
            this.comboBoxPoint.Items.AddRange(new object[] {
            "이상",
            "이하"});
            this.comboBoxPoint.Location = new System.Drawing.Point(549, 30);
            this.comboBoxPoint.MaxDropDownItems = 2;
            this.comboBoxPoint.Name = "comboBoxPoint";
            this.comboBoxPoint.Size = new System.Drawing.Size(72, 28);
            this.comboBoxPoint.TabIndex = 8;
            // 
            // textBoxScore
            // 
            this.textBoxScore.Location = new System.Drawing.Point(491, 31);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.Size = new System.Drawing.Size(52, 26);
            this.textBoxScore.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "점수 : ";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = " ";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(289, 30);
            this.dateTimePicker.MaxDate = new System.DateTime(2039, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(125, 26);
            this.dateTimePicker.TabIndex = 5;
            this.dateTimePicker.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.DropDown += new System.EventHandler(this.dateTimePicker_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "등록 날짜 :";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(73, 30);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 26);
            this.textBoxName.TabIndex = 3;
            // 
            // listViewResults
            // 
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_user,
            this.ch_date,
            this.ch_score,
            this.ch_script_name,
            this.ch_script,
            this.ch_state});
            this.listViewResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewResults.Location = new System.Drawing.Point(12, 177);
            this.listViewResults.MultiSelect = false;
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(1012, 302);
            this.listViewResults.TabIndex = 4;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            // 
            // ch_user
            // 
            this.ch_user.DisplayIndex = 1;
            this.ch_user.Text = "id";
            this.ch_user.Width = 80;
            // 
            // ch_date
            // 
            this.ch_date.DisplayIndex = 2;
            this.ch_date.Text = "날짜";
            this.ch_date.Width = 120;
            // 
            // ch_score
            // 
            this.ch_score.DisplayIndex = 3;
            this.ch_score.Text = "점수";
            this.ch_score.Width = 80;
            // 
            // ch_script_name
            // 
            this.ch_script_name.DisplayIndex = 4;
            this.ch_script_name.Text = "대본";
            this.ch_script_name.Width = 80;
            // 
            // ch_script
            // 
            this.ch_script.DisplayIndex = 5;
            this.ch_script.Text = "발화문";
            this.ch_script.Width = 400;
            // 
            // ch_state
            // 
            this.ch_state.DisplayIndex = 0;
            this.ch_state.Text = "상태";
            this.ch_state.Width = 80;
            // 
            // videofsWatcher
            // 
            this.videofsWatcher.EnableRaisingEvents = true;
            this.videofsWatcher.SynchronizingObject = this;
            // 
            // buttonExit
            // 
            this.buttonExit.ImageIndex = 3;
            this.buttonExit.ImageList = this.imageList;
            this.buttonExit.Location = new System.Drawing.Point(73, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(55, 55);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "승승";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxLog.Location = new System.Drawing.Point(12, 498);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(1012, 130);
            this.textBoxLog.TabIndex = 6;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1036, 644);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.buttonFullList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.Text = "승승";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videofsWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFullList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox textBoxScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxPoint;
        private System.Windows.Forms.ComboBox comboBoxScript;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListView listViewResults;
        private System.IO.FileSystemWatcher videofsWatcher;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.ColumnHeader ch_user;
        private System.Windows.Forms.ColumnHeader ch_date;
        private System.Windows.Forms.ColumnHeader ch_score;
        private System.Windows.Forms.ColumnHeader ch_script_name;
        private System.Windows.Forms.ColumnHeader ch_script;
        private System.Windows.Forms.ColumnHeader ch_state;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

