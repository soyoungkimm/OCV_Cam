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
        Boolean isMoving = false;
        Boolean isQR = false;

        CascadeClassifier faceCascade = new CascadeClassifier();
        CascadeClassifier smileCascade = new CascadeClassifier();
    

        VideoWriter Record;                  // video 전용 class

        public Form1()
        {
            InitializeComponent();

            faceCascade.Load("C:/Users/astems-SM/Documents/Visual Studio 2012/Projects/OCV2/harrcascade/haarcascade_frontalface_alt2.xml"); // 얼굴 검출
            //faceCascade.Load("C:/Users/astems-SM/Documents/Visual Studio 2012/Projects/OCV2/harrcascade/haarcascade_eye.xml"); // 눈 검출

            smileCascade.Load("C:/Users/astems-SM/Documents/Visual Studio 2012/Projects/OCV2/harrcascade/haarcascade_smile.xml"); // 미소 감지


            // Timer 설정
            timer1.Interval = 33; // 30 프레임/초 (1000ms / 30fps)
            timer1.Tick += new EventHandler(timer1_Tick);

            // 웹캠 연결 --------------
            video = new VideoCapture(0);
            if (!video.IsOpened())
            {
                MessageBox.Show("웹캠을 열 수 없습니다!");
                return;
            }
            // -------------------------

            // 자동차 영상 연결 -------------
            /*string videoPath = @"D:\cars.mp4";
            video = new VideoCapture(videoPath);
            video.Read(src);

            string fileName = "car_auto_save.mp4"; // 저장할 파일명 지정 
            int fourCC = VideoWriter.FourCC('X', 'V', 'I', 'D'); // 코덱 설정 
            double fps = 30.0; // 프레임 속도 설정 (여기서는 30fps)
            Record = new VideoWriter(@"C:\MyImageFoler\" + fileName, fourCC, fps, new OpenCvSharp.Size(src.Width, src.Height)); // 파일명, 코덱, FPS, 해상도*/
            // -------------------------------

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
            if (isSobel)
            {
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

                Mat pre_frame = new Mat();
                Mat diff = new Mat();
                video.Read(pre_frame);


                Cv2.Absdiff(src, pre_frame, diff);

                Cv2.CvtColor(diff, diff, ColorConversionCodes.BGR2GRAY);

                int threshold = 220000; // 임계값 설정
                int diffPixelCount = Cv2.CountNonZero(diff);


                if (diffPixelCount > threshold)
                {
                    isSobel = true;
                }
                else
                {
                    isSobel = false;
                    // 새로운 Mat을 생성하고 검은 화면으로 초기화
                    int width = 877;
                    int height = 539;

                    Mat blackImage = new Mat(height, width, MatType.CV_8UC3, Scalar.Black);

                    // PictureBoxIpl에 이미지를 표시
                    Image1.ImageIpl = blackImage;
                }

            }

            /*if (isFace) // 얼굴에 빨간색 사각형 띄우기
            {
                Rect[] faces = faceCascade.DetectMultiScale(src);  // 얼굴검출
                foreach (var item in faces)
                {            
                    // 검색된 얼굴좌표(LTWH)
                    Cv2.Rectangle(src, item, Scalar.Red, 2);  // 빨강사각형
                    toolStripStatusLabel_Etc.Text = "faces : " + item;
                    Image1.ImageIpl = src;
                }
            }*/


            // 캠에 얼굴 인식해서 고양이 귀 삽입
            /*if (isFace)
            {
                Rect[] faces = faceCascade.DetectMultiScale(src);  // 얼굴검출
                foreach (var item in faces)
                {            // 검색된 얼굴좌표(LTWH)
                    //Cv2.Rectangle(src, item, Scalar.Red, 2);  // 빨강사각형
                    toolStripStatusLabel_Etc.Text = "faces : " + item;
                    if (Image2.Image != null)   // 고양이귀 이미지
                    {
                        two = Image2.ImageIpl.Clone();
                        dst = two.Clone();

                        // 고양이 귀 이미지 크기 조정
                        Cv2.Resize(dst, dst, new OpenCvSharp.Size(dst.Width / 6, dst.Height / 6));
                        Cv2.Resize(two, two, new OpenCvSharp.Size(two.Width / 6, two.Height / 6));

                        // 마스크 생성
                        Mat mask = new Mat();
                        Cv2.CvtColor(dst, dst, ColorConversionCodes.BGR2GRAY); // 컬러 이미지를 흑백 이미지로 변환
                        Cv2.Threshold(dst, mask, 100, 255, ThresholdTypes.Binary);
                        Cv2.CvtColor(dst, dst, ColorConversionCodes.GRAY2BGR); // 컬러 이미지를 흑백 이미지로 변환


                        // 마스크 적용하여 영역 추출
                        Mat tmp1 = new Mat();
                        Cv2.BitwiseAnd(two, two, tmp1, mask: mask);

                        // 마스크 반전
                        Mat mask_inv = new Mat();
                        Cv2.BitwiseNot(mask, mask_inv);


                        // 특정 영역 추출
                        OpenCvSharp.Rect rect = new OpenCvSharp.Rect(item.Location.X + (mask.Width / 4), item.Location.Y - mask.Height, mask.Width, mask.Height); // 예시로 임의의 영역  133, 320
                        Mat region = src.SubMat(rect);


                        // 마스크 적용하여 영역 추출
                        Mat tmp2 = new Mat();
                        Cv2.BitwiseAnd(region, region, tmp2, mask: mask_inv);


                        // tmp1과 tmp2를 합치기
                        Mat tmp3 = new Mat();
                        Cv2.Add(tmp1, tmp2, tmp3);

                        tmp3.CopyTo(region);

                        Image1.ImageIpl = src;
                    }
                }
            }
            */
            if (isFace) // 얼굴인식인 경우
            {
                Rect[] faces = faceCascade.DetectMultiScale(src, 1.3, 5);  // 얼굴검출
                foreach (var item in faces)
                {
                    // 검색된 얼굴좌표(LTWH)
                    Cv2.Rectangle(src, item, Scalar.Red, 2);  // 빨강사각형

                    Mat tmp = src.SubMat(item);
                    Rect[] smiles = smileCascade.DetectMultiScale(tmp, 3, 10);
                    foreach (var item_s in smiles)
                    {
                        Cv2.Rectangle(tmp, item_s, Scalar.Blue, 2);  // 파란 사각형
                    }

                    if (smiles.Length > 0)
                    {
                        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        Cv2.PutText(src, currentTime, new OpenCvSharp.Point(10, 30), HersheyFonts.HersheyComplex, 1.0, Scalar.Red, 2); // 텍스트 추가

                        string fileName = "smile.png"; // 저장할 파일명 지정 
                        string filePath = @"C:\MyImageFoler\" + fileName; // 파일 경로
                        Mat result = src.Clone();
                        Cv2.ImWrite(filePath, result);
                        Cv2.ImShow("미소감지", src);
                    }
                    else {
                      
                        Cv2.PutText(src, " ", new OpenCvSharp.Point(10, 30), HersheyFonts.HersheyComplex, 1.0, Scalar.Red, 2); // 텍스트 추가

                        
                    }

                }

                Image1.ImageIpl = src;
            }



            if (isQR) {
                
                Cv2.Rectangle(src, new OpenCvSharp.Point(100, 100), new OpenCvSharp.Point(400, 400), Scalar.Red, 2);
                Image1.ImageIpl = src;
                // (500, 200, 300, 300) 영역 crop 이미지
                Mat tmp1 = src.SubMat(new Rect(100, 100, 300, 300));
               
               // 이진 이미지로 변환
                Mat gray = new Mat();
                Cv2.CvtColor(tmp1, gray, ColorConversionCodes.BGR2GRAY);
                Cv2.Threshold(gray, gray, 128, 255, ThresholdTypes.Binary);

                // QR 코드 검출
                QRCodeDetector detector = new QRCodeDetector();
                OpenCvSharp.Point2f[] point2;
                Mat straightQrCode = new Mat();
                string decodedText = detector.DetectAndDecode(gray, out point2, straightQrCode);

                if (!string.IsNullOrEmpty(decodedText))
                {
                    isQR = false;
                    MessageBox.Show(decodedText, "QR Code");
                }
            }



            if (isRecording)  // 녹화중인 경우
            {
                video.Read(dst);

                const double threshold = 3.0; // 임계값 설정

                Mat diff = new Mat();
                Cv2.Absdiff(dst, src, diff); // 차이 이미지 계산

                Scalar mean = Cv2.Mean(diff); // 평균값 계산

                bool isMoving = mean.Val0 > threshold || mean.Val1 > threshold || mean.Val2 > threshold;

                if (isMoving)
                {
                    string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Cv2.PutText(src, currentTime, new OpenCvSharp.Point(10, 30), HersheyFonts.HersheyComplex, 1.0, Scalar.Red, 2); // 텍스트 추가

                    Record.Write(src); // 동영상 저장
                }
                Image1.ImageIpl = src;

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

           */


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

            /*if (isRecording)
            {
                button_Record.ImageIndex = 2;   // 버튼이미지 : ●

                string fileName = "output.mp4"; // 저장할 파일명 지정 
                int fourCC = VideoWriter.FourCC('X', 'V', 'I', 'D'); // 코덱 설정 
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

            }*/
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
               
                VideoCapture video1 = new VideoCapture(@openFileDialog1.FileName);

                if (!video1.IsOpened())
                {
                    MessageBox.Show("동영상을 열 수 없습니다.");
                    return;
                }


                // 보행자 검출 -----------------------------------------------------------------
                BackgroundSubtractorMOG2 mog2 = BackgroundSubtractorMOG2.Create();
                Mat mask = new Mat();
              
               
                while (true)
                {
                    video1.Read(src);
                    Cv2.WaitKey(1);
                    

                    // 배경 제거
                    mog2.Apply(src, mask);

                  
                    // 경계 찾기 
                    var contours = new OpenCvSharp.Point[][] { };
                    var hierarchy = new HierarchyIndex[] { };
                    Cv2.FindContours(mask, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

                    foreach (OpenCvSharp.Point[] contour in contours)
                    {
                        double area = Cv2.ContourArea(contour); // 컨투어 영역 계산

                        if (area > 500) // 예시로 설정된 보행자 면적
                        {
                            // 사각형 그리기
                            Rect rect = Cv2.BoundingRect(contour);
                            Cv2.Rectangle(src, rect, Scalar.Red, 2); // 빨간색 사각형 그리기
                        }
                    }

                    Image1.ImageIpl = src;
                }
                // -------------------------------------------------------------------------------

                /*
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

                video1.Dispose(); // 동영상 재생이 끝나면 VideoCapture 객체 해제*/


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
            isFace = !isFace;
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
                    two = Cv2.ImRead(openFileDialog1.FileName, ImreadModes.Color);
                    Image2.ImageIpl = two;
                    Image2.Visible = true;
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

        private void button_QR_Click(object sender, EventArgs e)
        {
            isQR = true;
        }

        

    }
}
