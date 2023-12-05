//=====================================================================================
// Digital Image Processing (OCV Part4  Camera)
//
// Yoon Hyung Tae (yht@induk.ac.kr)  2019.07 - 2020.02
// Gamejigi (Computer Software, Induk University)
//=====================================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;   // marshal 관련 선언

using OpenCvSharp.Extensions;

namespace OCV
{
    public partial class Form1 : Form
    {
        VideoCapture video;

        Mat src = new Mat();
        Mat two = new Mat();
        Mat dst = new Mat();

        Boolean isRecording = false;    // 녹음 On/Off
        Boolean isFace = false;           // 얼굴인식 On/Off
        Boolean isSobel = false;
        Boolean isDiff = false;


        VideoWriter Record;                  // video 전용 class

        public Form1()
        {
            InitializeComponent();


            
            // Timer 설정
            timer1.Interval = 33; // 30 프레임/초 (1000ms / 30fps)
            timer1.Tick += new EventHandler(timer1_Tick);

            // 웹캠 연결
            video = new VideoCapture(0);
            if (!video.IsOpened())
            {
                MessageBox.Show("웹캠을 열 수 없습니다!");
                return;
            }

            // 타이머 시작
            timer1.Start(); 
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            // 웹캠에서 프레임 읽기
            video.Read(src);

            // 좌우 반전
            Cv2.Flip(src, dst, FlipMode.Y);

            // 이미지 출력
            if (!dst.Empty())
            {
                Image1.Image = BitmapConverter.ToBitmap(dst);
            }*/

            video.Read(src); // 비디오 프레임 읽기


            // sobel
            if (isSobel) {
                if (src.Empty()) return;

                Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY); // 그레이스케일로 변환

                Cv2.Sobel(dst, dst, -1, 1, 0); // x 방향 미분
                Cv2.Sobel(dst, dst, -1, 0, 1); // x 방향 미분

                Image1.ImageIpl = dst;
            }


            //isDiff
            if (isDiff)
            {
                if (src.Empty()) return;

                //Cv2.CvtColor(src, src, ColorConversionCodes.BGR2GRAY); // 그레이스케일로 변환

                Mat pre_frame = new Mat();
                Mat diff = new Mat();
                video.Read(pre_frame);

                //double temp = 30.0;

                //abs = Cv2.Abs(src - pre_frame);
                Cv2.Absdiff(src, pre_frame, diff);

                Cv2.CvtColor(diff, diff, ColorConversionCodes.BGR2GRAY);

                int threshold = 100; // 임계값 설정
                int diffPixelCount = Cv2.CountNonZero(diff);


                if (diffPixelCount > threshold) {
                    MessageBox.Show("움직임!!!");
                }


                // 절대 차이에 임계값을 적용하여 움직임을 식별
                //Mat thresholded = new Mat();
                //Cv2.Threshold(diff, thresholded, temp, 255.0, ThresholdTypes.Binary);

                // 임계값을 적용한 이미지의 픽셀 값 합산
                //Scalar sum = Cv2.Sum(thresholded);

                // 픽셀 값의 총합을 기준으로 움직임이 있는지 판단
                //double total = sum.Val0;




                /*if (diff > 30.0) // 필요에 따라 임계값 조절
                {
                    // 움직임이 감지됨
                    //Image1.ImageIpl = thresholded; // 차이 이미지 표시 또는 필요한 작업 수행
                    isSobel = true;
                }
                else
                {
                    isSobel = false;
                    // 유의미한 움직임이 없음
                    // 움직임이 없는 프레임에 대한 작업을 수행하거나 비워둡니다.
                }*/

                //Image1.ImageIpl = diff;
            }
            



            /*if (isRecording)  // 녹화중인 경우
            {
                //Mat frame = new Mat(); // 프레임을 저장할 Mat 객체 생성
                // 여기서 웹캠에서 프레임을 읽거나, 이미지 프레임을 생성하는 코드를 작성해야 합니다.
                video.Read(src);

                if (!src.Empty())
                {
                    Record.Write(src); // 영상 녹화
                }
            }

            if (isFace) // 얼굴인식인 경우
            {


            }*/


        }

        // 폼 닫힐 때 웹캠 해제
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (video != null && video.IsOpened())
            {
                video.Release();
            }
        }

        //------------------------------------------------------------------
        // Button: Screen Capture
        //------------------------------------------------------------------
        private void button_Capture_Click(object sender, EventArgs e)
        {
            dst = Image1.ImageIpl;

            if (!dst.Empty())
            {
                // 이미지 캡처 및 저장
                string fileName = DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".png";
                string filePath = @"C:\MyImageFoler\" + fileName; // 저장할 경로로 수정

                Cv2.ImWrite(filePath, dst);

                // 이미지 표시 - 새 창으로
                Cv2.ImShow("캡처 이미지", dst);
                Cv2.WaitKey(0); // 사용자가 키를 누를 때까지 대기

                // 이미지 창 닫기
                Cv2.DestroyWindow("캡처 이미지");
            }
            else
            {
                MessageBox.Show("이미지를 캡처할 수 없습니다.");
            }
        }
        //------------------------------------------------------------------
        // Button: Video Record Start
        //------------------------------------------------------------------
        private void button_Record_Click(object sender, EventArgs e)
        {
            isRecording = !isRecording;
            if (isRecording)
            {
                button_Record.ImageIndex = 2;   // 버튼이미지 : ●

                string fileName = "output.mp4"; // 저장할 파일명 지정 (확장자에 주의하세요)
                int fourCC = VideoWriter.FourCC('X', 'V', 'I', 'D'); // 코덱 설정 (여기서는 XVID를 사용합니다)
                double fps = 30.0; // 프레임 속도 설정 (여기서는 30fps)

                Record = new VideoWriter(@"C:\MyImageFoler\" + fileName, fourCC, fps, new OpenCvSharp.Size(640, 480)); // 파일명, 코덱, FPS, 해상도
                if (!Record.IsOpened())
                {
                    MessageBox.Show("녹화를 시작할 수 없습니다!");
                    return;
                }

                isRecording = true;

            }
            else
            {
                button_Record.ImageIndex = 1;   // 버튼이미지 : ■

                isRecording = false;
                Record.Dispose();

            }
        }
        //------------------------------------------------------------------
        // Button: Video Play
        //------------------------------------------------------------------
        private void button_Play_Click(object sender, EventArgs e)
        {
            // OpenFileDialog를 이용하여 동영상 파일 선택
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "동영상 파일 (*.mp4;*.avi)|*.mp4;*.avi|모든 파일 (*.*)|*.*";
            openFileDialog1.Title = "동영상 파일 선택";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 선택한 동영상 파일명으로 VideoCapture 객체 생성
                VideoCapture video1 = new VideoCapture(openFileDialog1.FileName);

                if (!video1.IsOpened())
                {
                    MessageBox.Show("동영상을 열 수 없습니다.");
                    return;
                }

                // PictureBox에 이미지 표시 준비
                Image1.SizeMode = PictureBoxSizeMode.StretchImage; // 이미지가 PictureBox에 맞게 조절되도록 설정

                // 동영상 재생
                Mat frame = new Mat();
                int delay = (int)Math.Round(1000 / video1.Fps);

                while (true)
                {
                    video1.Read(frame); // 동영상에서 프레임 읽기

                    if (frame.Empty())
                    {
                        break; // 더 이상 프레임이 없으면 반복문 종료
                    }

                    Image1.Image = BitmapConverter.ToBitmap(frame); // PictureBox에 프레임 표시

                    int key = Cv2.WaitKey(delay);
                    if (key == 27) // ESC 키를 누르면 동영상 재생 종료
                    {
                        break;
                    }
                }

                video1.Dispose(); // 동영상 재생이 끝나면 VideoCapture 객체 해제


            }
        }
        //------------------------------------------------------------------
        // Button: Close
        //------------------------------------------------------------------
        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------------------------------------------------------------------
        // Button: Face
        //------------------------------------------------------------------
        private void button_Face_Click(object sender, EventArgs e)
        {
            isFace = ! isFace;
            if (isFace)
                button_Face.ImageIndex = 6;  // 버튼이미지: 얼굴+사각
            else
                button_Face.ImageIndex = 5;  // 버튼이미지: 얼굴
        }
        //------------------------------------------------------------------
        // Button: Open Image2
        //------------------------------------------------------------------
        private void button_Open2_Click(object sender, EventArgs e)
        {
            Refresh();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String Image1_Filename = openFileDialog1.FileName;
                string Document_Format = Image1_Filename.Substring(Image1_Filename.Length - 3, 3).ToUpper();
                if (Document_Format == "BMP" || Document_Format == "JPG" || Document_Format == "PNG")
                {
                    src = Cv2.ImRead(openFileDialog1.FileName, ImreadModes.Color);
                    Image1.ImageIpl = src;
                    Image1.Visible = true;
                }
                else
                    MessageBox.Show("JPG, PNG, BMP 만 사용할 수 있습니다.", "에러",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        //------------------------------------------------------------------
        private void Image2_Click(object sender, EventArgs e)
        {
            Image2.Visible = false;
        }
        //------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_isSobel_Click(object sender, EventArgs e)
        {
            isSobel = !isSobel;
        }

        private void button_isDiff_Click(object sender, EventArgs e)
        {
            isDiff = !isDiff;
        }

    }
}
