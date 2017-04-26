namespace VoiceRecognition
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
            this.buttonOption = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.comboBoxScript = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPoint = new System.Windows.Forms.ComboBox();
            this.textBoxPoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.videofsWatcher = new System.IO.FileSystemWatcher();
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
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "icon_list.png");
            this.imageList.Images.SetKeyName(1, "icon_option.png");
            this.imageList.Images.SetKeyName(2, "icon_search.png");
            // 
            // buttonOption
            // 
            this.buttonOption.ImageIndex = 1;
            this.buttonOption.ImageList = this.imageList;
            this.buttonOption.Location = new System.Drawing.Point(73, 12);
            this.buttonOption.Name = "buttonOption";
            this.buttonOption.Size = new System.Drawing.Size(55, 55);
            this.buttonOption.TabIndex = 1;
            this.buttonOption.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "이름 : ";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.comboBoxScript);
            this.groupBox.Controls.Add(this.buttonSearch);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.comboBoxPoint);
            this.groupBox.Controls.Add(this.textBoxPoint);
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
            // textBoxPoint
            // 
            this.textBoxPoint.Location = new System.Drawing.Point(491, 31);
            this.textBoxPoint.Name = "textBoxPoint";
            this.textBoxPoint.Size = new System.Drawing.Size(52, 26);
            this.textBoxPoint.TabIndex = 7;
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
            this.dateTimePicker.CustomFormat = "";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(289, 30);
            this.dateTimePicker.MaxDate = new System.DateTime(2039, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(125, 26);
            this.dateTimePicker.TabIndex = 5;
            this.dateTimePicker.Value = new System.DateTime(2017, 4, 15, 0, 0, 0, 0);
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
            this.listViewResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewResults.Location = new System.Drawing.Point(12, 177);
            this.listViewResults.MultiSelect = false;
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(1012, 453);
            this.listViewResults.TabIndex = 4;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.List;
            // 
            // videofsWatcher
            // 
            this.videofsWatcher.EnableRaisingEvents = true;
            this.videofsWatcher.SynchronizingObject = this;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 642);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.buttonOption);
            this.Controls.Add(this.buttonFullList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.Text = "Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videofsWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFullList;
        private System.Windows.Forms.Button buttonOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox textBoxPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxPoint;
        private System.Windows.Forms.ComboBox comboBoxScript;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListView listViewResults;
        private System.IO.FileSystemWatcher videofsWatcher;
    }
}

