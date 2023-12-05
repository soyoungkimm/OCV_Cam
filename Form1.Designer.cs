namespace OCV
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Image1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.button_Record = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button_Close = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Name = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_width = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_etcname = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Etc = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_Capture = new System.Windows.Forms.Button();
            this.button_Play = new System.Windows.Forms.Button();
            this.button_Open2 = new System.Windows.Forms.Button();
            this.Image2 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.button_Face = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_isSobel = new System.Windows.Forms.Button();
            this.button_isDiff = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image2)).BeginInit();
            this.SuspendLayout();
            // 
            // Image1
            // 
            this.Image1.BackColor = System.Drawing.Color.White;
            this.Image1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Image1.Location = new System.Drawing.Point(5, 61);
            this.Image1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(877, 539);
            this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // button_Record
            // 
            this.button_Record.ImageIndex = 1;
            this.button_Record.ImageList = this.imageList1;
            this.button_Record.Location = new System.Drawing.Point(648, 9);
            this.button_Record.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Record.Name = "button_Record";
            this.button_Record.Size = new System.Drawing.Size(43, 48);
            this.button_Record.TabIndex = 22;
            this.button_Record.UseVisualStyleBackColor = true;
            this.button_Record.Click += new System.EventHandler(this.button_Record_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "camera.png");
            this.imageList1.Images.SetKeyName(1, "record.png");
            this.imageList1.Images.SetKeyName(2, "stop_red.png");
            this.imageList1.Images.SetKeyName(3, "play.png");
            this.imageList1.Images.SetKeyName(4, "stop_black.png");
            this.imageList1.Images.SetKeyName(5, "face_on.png");
            this.imageList1.Images.SetKeyName(6, "face_off.png");
            this.imageList1.Images.SetKeyName(7, "icon_image2.png");
            this.imageList1.Images.SetKeyName(8, "exit.png");
            // 
            // button_Close
            // 
            this.button_Close.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button_Close.FlatAppearance.BorderSize = 0;
            this.button_Close.ImageIndex = 8;
            this.button_Close.ImageList = this.imageList1;
            this.button_Close.Location = new System.Drawing.Point(838, 9);
            this.button_Close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(43, 48);
            this.button_Close.TabIndex = 20;
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_Name,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_width,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel_Time,
            this.toolStripStatusLabel_etcname,
            this.toolStripStatusLabel_Etc,
            this.toolStripStatusLabel8});
            this.statusStrip1.Location = new System.Drawing.Point(0, 606);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(886, 29);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(49, 24);
            this.toolStripStatusLabel2.Text = "Name";
            // 
            // toolStripStatusLabel_Name
            // 
            this.toolStripStatusLabel_Name.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_Name.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel_Name.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel_Name.Name = "toolStripStatusLabel_Name";
            this.toolStripStatusLabel_Name.Size = new System.Drawing.Size(78, 24);
            this.toolStripStatusLabel_Name.Text = "             ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(36, 24);
            this.toolStripStatusLabel1.Text = "Size";
            // 
            // toolStripStatusLabel_width
            // 
            this.toolStripStatusLabel_width.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_width.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel_width.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel_width.Name = "toolStripStatusLabel_width";
            this.toolStripStatusLabel_width.Size = new System.Drawing.Size(63, 24);
            this.toolStripStatusLabel_width.Text = "          ";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(42, 24);
            this.toolStripStatusLabel4.Text = "Time";
            // 
            // toolStripStatusLabel_Time
            // 
            this.toolStripStatusLabel_Time.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_Time.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel_Time.Name = "toolStripStatusLabel_Time";
            this.toolStripStatusLabel_Time.Size = new System.Drawing.Size(63, 24);
            this.toolStripStatusLabel_Time.Text = "          ";
            // 
            // toolStripStatusLabel_etcname
            // 
            this.toolStripStatusLabel_etcname.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel_etcname.Name = "toolStripStatusLabel_etcname";
            this.toolStripStatusLabel_etcname.Size = new System.Drawing.Size(45, 24);
            this.toolStripStatusLabel_etcname.Text = " ETC ";
            // 
            // toolStripStatusLabel_Etc
            // 
            this.toolStripStatusLabel_Etc.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_Etc.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel_Etc.Name = "toolStripStatusLabel_Etc";
            this.toolStripStatusLabel_Etc.Size = new System.Drawing.Size(63, 24);
            this.toolStripStatusLabel_Etc.Text = "          ";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(430, 24);
            this.toolStripStatusLabel8.Spring = true;
            this.toolStripStatusLabel8.Text = " ";
            // 
            // button_Capture
            // 
            this.button_Capture.BackColor = System.Drawing.SystemColors.Control;
            this.button_Capture.ImageIndex = 0;
            this.button_Capture.ImageList = this.imageList1;
            this.button_Capture.Location = new System.Drawing.Point(603, 9);
            this.button_Capture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Capture.Name = "button_Capture";
            this.button_Capture.Size = new System.Drawing.Size(43, 48);
            this.button_Capture.TabIndex = 38;
            this.button_Capture.UseVisualStyleBackColor = false;
            this.button_Capture.Click += new System.EventHandler(this.button_Capture_Click);
            // 
            // button_Play
            // 
            this.button_Play.BackColor = System.Drawing.SystemColors.Control;
            this.button_Play.ImageIndex = 3;
            this.button_Play.ImageList = this.imageList1;
            this.button_Play.Location = new System.Drawing.Point(693, 9);
            this.button_Play.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Play.Name = "button_Play";
            this.button_Play.Size = new System.Drawing.Size(43, 48);
            this.button_Play.TabIndex = 40;
            this.button_Play.UseVisualStyleBackColor = false;
            this.button_Play.Click += new System.EventHandler(this.button_Play_Click);
            // 
            // button_Open2
            // 
            this.button_Open2.BackColor = System.Drawing.SystemColors.Control;
            this.button_Open2.ImageIndex = 7;
            this.button_Open2.ImageList = this.imageList1;
            this.button_Open2.Location = new System.Drawing.Point(786, 9);
            this.button_Open2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Open2.Name = "button_Open2";
            this.button_Open2.Size = new System.Drawing.Size(43, 48);
            this.button_Open2.TabIndex = 41;
            this.button_Open2.UseVisualStyleBackColor = false;
            this.button_Open2.Click += new System.EventHandler(this.button_Open2_Click);
            // 
            // Image2
            // 
            this.Image2.BackColor = System.Drawing.Color.White;
            this.Image2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Image2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Image2.Location = new System.Drawing.Point(689, 78);
            this.Image2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Image2.Name = "Image2";
            this.Image2.Size = new System.Drawing.Size(182, 136);
            this.Image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image2.TabIndex = 66;
            this.Image2.TabStop = false;
            this.Image2.Visible = false;
            this.Image2.Click += new System.EventHandler(this.Image2_Click);
            // 
            // button_Face
            // 
            this.button_Face.BackColor = System.Drawing.SystemColors.Control;
            this.button_Face.ImageIndex = 5;
            this.button_Face.ImageList = this.imageList1;
            this.button_Face.Location = new System.Drawing.Point(739, 9);
            this.button_Face.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Face.Name = "button_Face";
            this.button_Face.Size = new System.Drawing.Size(43, 48);
            this.button_Face.TabIndex = 67;
            this.button_Face.UseVisualStyleBackColor = false;
            this.button_Face.Click += new System.EventHandler(this.button_Face_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "이미지/동영상|*.avi;*.mp4;*.bmp;*.jpg;*.png|모든 파일|*.*";
            this.openFileDialog1.Title = " ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_isSobel
            // 
            this.button_isSobel.Location = new System.Drawing.Point(12, 12);
            this.button_isSobel.Name = "button_isSobel";
            this.button_isSobel.Size = new System.Drawing.Size(78, 26);
            this.button_isSobel.TabIndex = 68;
            this.button_isSobel.Text = "isSobel";
            this.button_isSobel.UseVisualStyleBackColor = true;
            this.button_isSobel.Click += new System.EventHandler(this.button_isSobel_Click);
            // 
            // button_isDiff
            // 
            this.button_isDiff.Location = new System.Drawing.Point(96, 12);
            this.button_isDiff.Name = "button_isDiff";
            this.button_isDiff.Size = new System.Drawing.Size(78, 26);
            this.button_isDiff.TabIndex = 69;
            this.button_isDiff.Text = "isDiff";
            this.button_isDiff.UseVisualStyleBackColor = true;
            this.button_isDiff.Click += new System.EventHandler(this.button_isDiff_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 635);
            this.Controls.Add(this.button_isDiff);
            this.Controls.Add(this.button_isSobel);
            this.Controls.Add(this.button_Face);
            this.Controls.Add(this.Image2);
            this.Controls.Add(this.button_Open2);
            this.Controls.Add(this.button_Play);
            this.Controls.Add(this.button_Capture);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_Record);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.Image1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenCV  Part4 Camera       by Induk Univ. 윤형태 (2019.07-2020.02.20)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl Image1;
        private System.Windows.Forms.Button button_Record;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_width;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Time;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_etcname;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Etc;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Name;
        private System.Windows.Forms.Button button_Capture;
        private System.Windows.Forms.Button button_Play;
        private System.Windows.Forms.Button button_Open2;
        private OpenCvSharp.UserInterface.PictureBoxIpl Image2;
        private System.Windows.Forms.Button button_Face;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button_isSobel;
        private System.Windows.Forms.Button button_isDiff;
    }
}

