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

namespace LifeCounter
{
    /// <summary>
    /// UserLife.xaml の相互作用ロジック
    /// </summary>
    public partial class UserLife : UserControl
    {
        // 定数
        public const int UPPER_COUNT = 99;
        public const int LOWER_COUNT = 0;

        // メンバ変数
        public int m_nLifeCount;            // ライフカウント
        private int m_nSubLifeCount;        // サブカウント
        private bool m_bSoundON;              // サウンドON
        System.Media.SoundPlayer SoundRecovery; // 回復サウンド
        System.Media.SoundPlayer SoundDamage;   // ダメージサウンド
        System.Media.SoundPlayer SoundSubPsuh;  // サブプッシュサウンド

        /// <summary>
        /// ■コンストラクタ
        /// </summary>
        public UserLife()
        {
            InitializeComponent();

            // メンバ初期化
            // メインカウンター
            m_nLifeCount = 40;
            MainCounterUpdate(m_nLifeCount);
            // サブカウンター
            m_nSubLifeCount = 0;
            SubCounterUpdate(m_nSubLifeCount);
            // サウンド
            SoundRecovery   = new System.Media.SoundPlayer("Recovery.wav");
            SoundDamage    =  new System.Media.SoundPlayer("Damage.wav");
            SoundSubPsuh    = new System.Media.SoundPlayer("SubPush.wav");
        }
  
        /// <summary>
        /// ■共通_色設定
        /// </summary>
        public void AllTextSetColor(Brush cBrush)
        {
            this.MainCounter.Foreground = cBrush;
            this.SubCounter.Foreground = cBrush;
            this.PlayerName.Foreground = cBrush;
            this.Plus.Foreground = cBrush;
            this.Minus.Foreground = cBrush;
            this.RightKey.Foreground = cBrush;
            this.LeftKey.Foreground = cBrush;
        }

        /// <summary>
        /// ■プレイヤー名_初期化
        /// </summary>
        public void TextBoxInit(int nNum)
        {
            string strPlayer = "プレイヤー" + nNum.ToString();
            this.PlayerName.Text = strPlayer;
        }

        /// <summary>
        /// メインカウンター_更新
        /// </summary>
        private void MainCounterUpdate(int nUpdateCount)
        {
            string strTemp = nUpdateCount.ToString();
            this.MainCounter.Content = strTemp;
        }

        /// <summary>
        /// プラスグリッドー_タッチダウンイベント
        /// </summary>
        private void PlusGrid_TouchDown(object sender, TouchEventArgs e)
        {
            MainCounterPlus();
        }

        /// <summary>
        /// プラスグリッドー_マウスダウンイベント
        /// </summary>
        private void PlusGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.StylusDevice == null)
            {
                MainCounterPlus();
            }
        }

        /// <summary>
        /// プラスグリッド_共通プラス処理
        /// </summary>
        private void MainCounterPlus()
        {
            if (m_bSoundON == true)
            {
                SoundRecovery.Play();
            }
            if (m_nLifeCount < UPPER_COUNT)
            {
                m_nLifeCount++;
                MainCounterUpdate(m_nLifeCount);
            }
        }

        /// <summary>
        /// マイナスグリッドー_タッチダウンイベント
        /// </summary>
        private void MinusGrid_TouchDown(object sender, TouchEventArgs e)
        {
            MainCounterMinus();
        }

        /// <summary>
        /// マイナスグリッドー_マウスダウンイベント
        /// </summary>
        private void MinusGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.StylusDevice == null)
            {
                MainCounterMinus();
            }
        }

        /// <summary>
        /// マイナスグリッド_共通マイナス処理
        /// </summary>
        private void MainCounterMinus()
        {
            if (m_bSoundON == true)
            {
                SoundDamage.Play();
            }
            if (m_nLifeCount > LOWER_COUNT)
            {
                m_nLifeCount--;
                MainCounterUpdate(m_nLifeCount);
            }
            this.MainCounter.Foreground = Brushes.Red;
        }

        /// <summary>
        /// サブカウンター_更新
        /// </summary>
        private void SubCounterUpdate(int nUpdateCount)
        {
            string strTemp = nUpdateCount.ToString();
            this.SubCounter.Content = strTemp;
        }

        /// <summary>
        /// 左キー_タッチダウンイベント
        /// </summary>
        private void LeftKeyGrid_TouchDown(object sender, TouchEventArgs e)
        {
            SubCounterPlus();
        }

        /// <summary>
        /// 左キー_マウスダウンイベント
        /// </summary>
        private void LeftKeyGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.StylusDevice == null)
            {
                SubCounterPlus();
            }
        }

        /// <summary>
        /// 左キー_共通プラス処理
        /// </summary>
        private void SubCounterPlus()
        {
            if(m_bSoundON == true)
            {
                SoundSubPsuh.Play();
            }
            if (m_nSubLifeCount < UPPER_COUNT)
            {
                m_nSubLifeCount++;
                SubCounterUpdate(m_nSubLifeCount);
            }
        }

        /// <summary>
        /// 右キー_タッチダウンイベント
        /// </summary>
        private void RightKeyGrid_TouchDown(object sender, TouchEventArgs e)
        {
            SubCounterMinus();
        }

        /// <summary>
        /// 右キー_マウスチダウンイベント
        /// </summary>
        private void RightKeyGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.StylusDevice == null)
            {
                SubCounterMinus();
            }
        }

        /// <summary>
        /// 右キー_共通マイナス処理
        /// </summary>
        private void SubCounterMinus()
        {
            if (m_bSoundON == true)
            {
                SoundSubPsuh.Play();
            }
            if (m_nSubLifeCount > LOWER_COUNT)
            {
                m_nSubLifeCount--;
                SubCounterUpdate(m_nSubLifeCount);
            }
        }

        /// <summary>
        /// サブカウンター表示ON
        /// </summary>
        public void SubCounterON()
        {
            this.SubCounterGird.Visibility  = Visibility.Visible;
            this.LeftKeyGrid.Visibility     = Visibility.Visible;
            this.RightKeyGrid.Visibility    = Visibility.Visible;
        }

        /// <summary>
        /// サブカウンター表示OFF
        /// </summary>
        public void SubCounterOFF()
        {
            this.SubCounterGird.Visibility = Visibility.Collapsed;
            this.LeftKeyGrid.Visibility = Visibility.Collapsed;
            this.RightKeyGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// メインカウンター値設定
        /// </summary>
        public void SetMainCounterNum(int nCount)
        {
            m_nLifeCount = nCount;
            MainCounterUpdate(m_nLifeCount);
        }
        /// <summary>
        /// サウンドON取得
        /// </summary>
        public bool GetSoundON()
        {
            return m_bSoundON;
        }
        /// <summary>
        /// サウンドON設定
        /// </summary>
        public void SetSoundON(bool bSoundON)
        {
            m_bSoundON = bSoundON;
        }
    }
}
