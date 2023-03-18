using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeCounter
{

    public partial class PlayerNumForm : Form
    {
        // 定数
        public const int MAX_PLAYER = 6;

        // メンバ変数
        private int m_nPlayerNum;
        private System.Windows.Forms.RadioButton[] RadioButtonNums;

        /// <summary>
        /// UserLife.xaml の相互作用ロジック
        /// </summary>
        public PlayerNumForm()
        {
            InitializeComponent();

            // メンバ変数初期化
            this.RadioButtonNums = new System.Windows.Forms.RadioButton[MAX_PLAYER];
            this.RadioButtonNums[0] = this.radioButtonNum1;
            this.RadioButtonNums[1] = this.radioButtonNum2;
            this.RadioButtonNums[2] = this.radioButtonNum3;
            this.RadioButtonNums[3] = this.radioButtonNum4;
            this.RadioButtonNums[4] = this.radioButtonNum5;
            this.RadioButtonNums[5] = this.radioButtonNum6;
        }

        /// <summary>
        /// OKボタン_クリックイベント
        /// </summary>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            for(int i=0; i < MAX_PLAYER; i++)
            {
                if(this.RadioButtonNums[i].Checked == true)
                {
                    m_nPlayerNum = i + 1;
                    break;
                }
            }
            this.Close();
        }

        /// <summary>
        /// プレイヤー人数設定
        /// </summary>
        public void SetPlayerNum(int nPlayerNum)
        {
            m_nPlayerNum = nPlayerNum;
            this.RadioButtonNums[nPlayerNum - 1].Checked = true;
        }

        /// <summary>
        /// プレイヤー人数取得
        /// </summary>
        public int GetPlayerNum()
        {
            return m_nPlayerNum;
        }
    }
}
