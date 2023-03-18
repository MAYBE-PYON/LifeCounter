using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Threading;
using System.Windows.Threading;

namespace LifeCounter
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // 定数
        public const int MAX_PLAYER = 6;
        public const int USER_LIFE_OFFSET = 20;
        //　列挙体
        enum SETTINGCOMBO
        {
           SETTING_LABEL = 0,
           SETTING_WALLPEPAR,
           SETTING_PLAYERNUM,
           SETTING_VIEWITEM,
           SETTING_MAX
        }

        // メンバ変数
        private int m_nPlayerNum;
        private bool m_bSubCounterON;
        private bool m_bSoundON;
        private string m_strWallPaper;
        private int m_nLifeInitValue;
        private double m_nWidth;
        private double m_nHeight;
        private System.Drawing.Color m_cTextColor;
        private UserLife[] m_usUserLifes;
        UserLife m_usUserLife1;
        UserLife m_usUserLife2;
        UserLife m_usUserLife3;
        UserLife m_usUserLife4;
        UserLife m_usUserLife5;
        UserLife m_usUserLife6;
        Thread thread;          // 監視スレッド;

        /// <summary>
        /// インスタンス
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // 初期化処理

            // 設定ファイル保存
            SettingFIle settingfile = new SettingFIle();
            SettingFileData settingfiledata = new SettingFileData();
            settingfile.LoadFile(ref settingfiledata);
            this.m_nPlayerNum       = settingfiledata.nPlayerNum;
            this.m_bSubCounterON    = settingfiledata.bSubCounterON;
            this.m_bSoundON         = settingfiledata.bSoundON;
            this.m_strWallPaper     = settingfiledata.strWallPaper;
            this.m_nLifeInitValue   = settingfiledata.nLifeInitValue;
            this.m_cTextColor       = System.Drawing.Color.FromArgb(settingfiledata.R, settingfiledata.G, settingfiledata.B);

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;  
            this.Width  = System.Windows.SystemParameters.WorkArea.Width;
            this.Height = System.Windows.SystemParameters.WorkArea.Height;
            m_nWidth = this.Width;
            m_nHeight = this.Height;

            // 表示色

            // ライフカウンター初期化
            this.m_usUserLifes = new UserLife[MAX_PLAYER];
            m_usUserLife1 = new UserLife();
            m_usUserLife2 = new UserLife();
            m_usUserLife3 = new UserLife();
            m_usUserLife4 = new UserLife();
            m_usUserLife5 = new UserLife();
            m_usUserLife6 = new UserLife();
            m_usUserLifes[0] = m_usUserLife1;
            m_usUserLifes[1] = m_usUserLife2;
            m_usUserLifes[2] = m_usUserLife3;
            m_usUserLifes[3] = m_usUserLife4;
            m_usUserLifes[4] = m_usUserLife5;
            m_usUserLifes[5] = m_usUserLife6;

            
            for (int i = 0; i < MAX_PLAYER; i++)
            {
                m_usUserLifes[i].TextBoxInit(i+1);
                Brush brush = new SolidColorBrush(DrawMediaColor(m_cTextColor));
                m_usUserLifes[i].AllTextSetColor(brush);
                canvas1.Children.Add(m_usUserLifes[i]);
            }
            // 描画
            InitDrawBackImage();
            ReDraw();
            
            // 監視スレッド作成・開始
            thread = new Thread(new ThreadStart(ThreadProc));
            thread.Start();
        }

        /// <summary>
        /// 背景描画
        /// </summary>
        private void InitDrawBackImage()
        {
            if(System.IO.File.Exists(this.m_strWallPaper))
            {
                BitmapImage cBitmapImage = new BitmapImage();
                cBitmapImage.BeginInit();
                cBitmapImage.UriSource = new Uri(this.m_strWallPaper, UriKind.Relative);
                cBitmapImage.EndInit();

                // イメージブラシの作成
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = cBitmapImage;

                this.Background = imageBrush;
            }
    
        }

        /// <summary>
        /// 背景描画
        /// </summary>
        private void DrawBackImage()
        {
            OpenFileDialog cOpenFileDialog = new OpenFileDialog();
            cOpenFileDialog.Title = "ファイルを開く";
            cOpenFileDialog.Filter = "イメージファイル|*.bmp;*.jpg;*.gif";
            cOpenFileDialog.CheckFileExists = true;
            cOpenFileDialog.ReadOnlyChecked = true;
            
            if(cOpenFileDialog.ShowDialog() == true)
            {
                BitmapImage cBitmapImage = new BitmapImage();
                cBitmapImage.BeginInit();
                cBitmapImage.UriSource = new Uri(cOpenFileDialog.FileName, UriKind.Relative);
                cBitmapImage.EndInit();

                // イメージブラシの作成
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = cBitmapImage;

                this.Background = imageBrush;
            }
            this.m_strWallPaper = cOpenFileDialog.FileName;
        }

        /// <summary>
        /// 設定コンボボックス_選択変更イベント
        /// </summary>
        private void SettingConboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(this.SettingConboBox.SelectedIndex)
            {
                // 壁紙
                case (int)SETTINGCOMBO.SETTING_WALLPEPAR:
                    DrawBackImage();
                    break;
                // プレイヤー人数
                case (int)SETTINGCOMBO.SETTING_PLAYERNUM:
                    PlayerNumForm cPlayerNumForm = new PlayerNumForm();
                    cPlayerNumForm.SetPlayerNum(m_nPlayerNum);
                    cPlayerNumForm.ShowDialog();
                    m_nPlayerNum = cPlayerNumForm.GetPlayerNum();
                    ReDraw();
                    break;
                // カスタム設定
                case (int)SETTINGCOMBO.SETTING_VIEWITEM:
                    CustomSettingForm cCustomSettingForm = new CustomSettingForm();
                    cCustomSettingForm.SetInitLifeValie(m_nLifeInitValue);
                    cCustomSettingForm.SetSubCounterON(m_bSubCounterON);
                    cCustomSettingForm.SetSoundON(m_bSoundON);

                    cCustomSettingForm.SetColorSelect(m_cTextColor);
                    cCustomSettingForm.ShowDialog();
                    m_cTextColor = cCustomSettingForm.GetColor();
                    m_bSubCounterON = cCustomSettingForm.GetSubCounterON();
                    m_bSoundON = cCustomSettingForm.GetSoundON();
                    m_nLifeInitValue = cCustomSettingForm.GetInitLifeValie();
                    ReDraw();
                    break;
                default:
                    break;
            }
            this.SettingConboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// メインウィンドウ_クローズイベント
        /// </summary>
        private void LifeCounterWIndow_Closed(object sender, EventArgs e)
        {
            this.thread.Abort();

            // 設定ファイル保存
            SettingFileData settingfiledata = new SettingFileData();
            settingfiledata.nLifeInitValue = this.m_nLifeInitValue;
            settingfiledata.nPlayerNum = this.m_nPlayerNum;
            settingfiledata.bSoundON = this.m_bSubCounterON;
            settingfiledata.bSoundON = this.m_bSoundON;
            settingfiledata.strWallPaper = this.m_strWallPaper;
            settingfiledata.R = this.m_cTextColor.R;
            settingfiledata.G = this.m_cTextColor.G;
            settingfiledata.B = this.m_cTextColor.B;
            SettingFIle settingfile = new SettingFIle();

            settingfile.SaveFile(settingfiledata);
        }

        /// <summary>
        /// ライフカウンター再描画
        /// </summary>
        private void ReDraw()
        {
            // 表示消去、色設定、サブカウンター設定
            for (int i = 0; i < MAX_PLAYER; i++)
            {
                m_usUserLifes[i].Visibility = Visibility.Collapsed;
                Brush a = new SolidColorBrush(DrawMediaColor(m_cTextColor));
                m_usUserLifes[i].AllTextSetColor(a);
                m_usUserLifes[i].SetMainCounterNum(m_nLifeInitValue);
                m_usUserLifes[i].SetSoundON(m_bSoundON);
                if (this.m_bSubCounterON == true)
                {
                    m_usUserLifes[i].SubCounterON();
                }
                else
                {
                    m_usUserLifes[i].SubCounterOFF();
                }
            }
            // 人数によりレイアウト変更
            double nXpos;
            double nYpos;
            double nTempX1;
            switch (m_nPlayerNum-1)
            {
                case 0:
                    //画面１
                    nXpos = this.m_nWidth / 2;
                    nXpos -= (m_usUserLife1.Width/2);
                    nYpos = this.m_nHeight / 2;
                    nYpos -= (m_usUserLife1.Height / 2);
                    Canvas.SetLeft(m_usUserLife1, nXpos);
                    Canvas.SetTop(m_usUserLife1, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife1.Visibility = Visibility.Visible;
                    break;

                case 1:
                    // 画面１
                    nXpos = (this.m_nWidth/2) / 2;
                    nXpos -= (m_usUserLife1.Width/ 2);
                    nYpos = this.m_nHeight / 2;
                    nYpos -= (m_usUserLife1.Height / 2);
                    Canvas.SetLeft(m_usUserLife1, nXpos);
                    Canvas.SetTop(m_usUserLife1, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife1.Visibility = Visibility.Visible;
                    // 画面２
                    nXpos = (this.m_nWidth / 2) + (this.m_nWidth / 4);
                    nXpos -= (m_usUserLife2.Width / 2);
                    Canvas.SetLeft(m_usUserLife2, nXpos);
                    Canvas.SetTop(m_usUserLife2, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife2.Visibility = Visibility.Visible;
                    break;

                case 2:
                    // 画面１
                    nYpos = this.m_nHeight / 2;
                    nYpos -= (m_usUserLife1.Height / 2);
                    Canvas.SetLeft(m_usUserLife1, 0);
                    Canvas.SetTop(m_usUserLife1, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife1.Visibility = Visibility.Visible;
                    // 画面２
                    nXpos = this.m_nWidth / 2;
                    nXpos -= (m_usUserLife2.Width / 2);
                    nTempX1 = nXpos;
                    Canvas.SetLeft(m_usUserLife2, nXpos);
                    Canvas.SetTop(m_usUserLife2, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife2.Visibility = Visibility.Visible;
                    // 画面３
                    nXpos = this.m_nWidth / 2 + nTempX1;
                    nXpos -= (m_usUserLife3.Width /2 ) ;
                    Canvas.SetLeft(m_usUserLife3, nXpos);
                    Canvas.SetTop(m_usUserLife3, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife3.Visibility = Visibility.Visible;
                    break;
                case 3:
                    // 画面１
                    nXpos = (this.m_nWidth / 2) / 2;
                    nXpos -= (m_usUserLife1.Width / 2);
                    nYpos = (this.m_nHeight / 2) / 2;
                    nYpos -= (m_usUserLife1.Height / 2);
                    Canvas.SetLeft(m_usUserLife1, nXpos);
                    Canvas.SetTop(m_usUserLife1, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife1.Visibility = Visibility.Visible;
                    // 画面２
                    nXpos = (this.m_nWidth / 2) + (this.m_nWidth / 4);
                    nXpos -= (m_usUserLife2.Width / 2);
                    Canvas.SetLeft(m_usUserLife2, nXpos);
                    Canvas.SetTop(m_usUserLife2, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife2.Visibility = Visibility.Visible;
                    // 画面３
                    nXpos = (this.m_nWidth / 2) / 2;
                    nXpos -= (m_usUserLife1.Width / 2);
                    nYpos = (this.m_nHeight / 2) / 2;
                    nYpos += (m_usUserLife1.Height / 2);
                    Canvas.SetLeft(m_usUserLife3, nXpos);
                    Canvas.SetTop(m_usUserLife3, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife3.Visibility = Visibility.Visible;
                    // 画面４
                    nXpos = (this.m_nWidth / 2) + (this.m_nWidth / 4);
                    nXpos -= (m_usUserLife2.Width / 2);
                    Canvas.SetLeft(m_usUserLife4, nXpos);
                    Canvas.SetTop(m_usUserLife4, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife4.Visibility = Visibility.Visible;
                    break;
                case 4:
                    // 画面１
                    nYpos = (this.m_nHeight / 2) / 2;
                    nYpos -= (m_usUserLife1.Height / 2);
                    Canvas.SetLeft(m_usUserLife1, 0);
                    Canvas.SetTop(m_usUserLife1, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife1.Visibility = Visibility.Visible;
                    // 画面２
                    nXpos = this.m_nWidth / 2;
                    nXpos -= (m_usUserLife2.Width / 2);
                    nTempX1 = nXpos;
                    Canvas.SetLeft(m_usUserLife2, nXpos);
                    Canvas.SetTop(m_usUserLife2, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife2.Visibility = Visibility.Visible;
                    // 画面３
                    nXpos = this.m_nWidth / 2 + nTempX1;
                    nXpos -= (m_usUserLife3.Width / 2);
                    Canvas.SetLeft(m_usUserLife3, nXpos);
                    Canvas.SetTop(m_usUserLife3, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife3.Visibility = Visibility.Visible;
                    // 画面４
                    nXpos = (this.m_nWidth / 2) / 2;
                    nXpos -= (m_usUserLife1.Width / 2);
                    nYpos = (this.m_nHeight / 2) / 2;
                    nYpos += (m_usUserLife1.Height / 2);
                    Canvas.SetLeft(m_usUserLife4, nXpos);
                    Canvas.SetTop(m_usUserLife4, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife4.Visibility = Visibility.Visible;
                    // 画面５
                    nXpos = (this.m_nWidth / 2) + (this.m_nWidth / 4);
                    nXpos -= (m_usUserLife2.Width / 2);
                    Canvas.SetLeft(m_usUserLife5, nXpos);
                    Canvas.SetTop(m_usUserLife5, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife5.Visibility = Visibility.Visible;
                    break;
                case 5:
                    // 画面１
                    nYpos = (this.m_nHeight / 2) / 2;
                    nYpos -= (m_usUserLife1.Height / 2);
                    Canvas.SetLeft(m_usUserLife1, 0);
                    Canvas.SetTop(m_usUserLife1, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife1.Visibility = Visibility.Visible;
                    // 画面２
                    nXpos = this.m_nWidth / 2;
                    nXpos -= (m_usUserLife2.Width / 2);
                    nTempX1 = nXpos;
                    Canvas.SetLeft(m_usUserLife2, nXpos);
                    Canvas.SetTop(m_usUserLife2, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife2.Visibility = Visibility.Visible;
                    // 画面３
                    nXpos = this.m_nWidth / 2 + nTempX1;
                    nXpos -= (m_usUserLife3.Width / 2);
                    Canvas.SetLeft(m_usUserLife3, nXpos);
                    Canvas.SetTop(m_usUserLife3, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife3.Visibility = Visibility.Visible;
                    // 画面４
                    nYpos = (this.m_nHeight / 2) / 2;
                    nYpos += (m_usUserLife1.Height / 2);
                    Canvas.SetLeft(m_usUserLife4, 0);
                    Canvas.SetTop(m_usUserLife4, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife4.Visibility = Visibility.Visible;
                    // 画面５
                    nXpos = this.m_nWidth / 2;
                    nXpos -= (m_usUserLife2.Width / 2);
                    nTempX1 = nXpos;
                    nYpos = (this.m_nHeight / 2) / 2;
                    nYpos += (m_usUserLife1.Height / 2);
                    Canvas.SetLeft(m_usUserLife5, nXpos);
                    Canvas.SetTop(m_usUserLife5, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife5.Visibility = Visibility.Visible;
                    // 画面６
                    nXpos = this.m_nWidth / 2 + nTempX1;
                    nXpos -= (m_usUserLife6.Width / 2);
                    Canvas.SetLeft(m_usUserLife6, nXpos);
                    Canvas.SetTop(m_usUserLife6, nYpos + USER_LIFE_OFFSET);
                    m_usUserLife6.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 監視スレッド処理
        /// </summary>
        public void ThreadProc()
        {
            // 1000msタイマー監視
            TimerCallback timerDelegate = new TimerCallback(TimerProc);
            Timer timer = new Timer(timerDelegate, null, 0, 1000);
            while (true)
            {
                //　無限ループ
            }
        }

        /// <summary>
        /// タイマー処理
        /// </summary>
        public void TimerProc(object o)
        {
            bool bFind = false;
            for (int i = 0; i < MAX_PLAYER; i++)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    if ((m_usUserLifes[i].MainCounter.Foreground == Brushes.Red) && (m_usUserLifes[i].m_nLifeCount != 0))
                    {
                        Brush brush = new SolidColorBrush(DrawMediaColor(m_cTextColor));
                        m_usUserLifes[i].MainCounter.Foreground = brush;

                    }
                }));
            }

            if(bFind == true)
            {
                DoEvents();
            }
        } 

        /// <summary>
        /// コントロール更新
        /// </summary>
        private void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            var callback = new DispatcherOperationCallback(obj =>
            {
                ((DispatcherFrame)obj).Continue = false;
                return null;
            });
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, callback, frame);
            Dispatcher.PushFrame(frame);
        }

        /// <summary>
        /// 色変換
        /// </summary>
        static public System.Windows.Media.Color DrawMediaColor(System.Drawing.Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        /// <summary>
        /// リセットボタン_クリックイベント
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ReDraw();
        }
    }
}
