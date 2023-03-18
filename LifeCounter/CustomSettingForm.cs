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
    public partial class CustomSettingForm : Form
    {
        // 定数
        public const int MAX_ONOFF = 2;
        // メンバ変数
        private bool m_nSubCounterON;
        private bool m_nSoundON;
        private int m_nInitLifeValue;
        private Color m_cChangeColor;

        /// <summary>
        /// インスタンス
        /// </summary>
        public CustomSettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 色選択ボタン_クリックイベント
        /// </summary>
        private void ColorSelectButton_Click(object sender, EventArgs e)
        {
            var ret = this.colorDialog.ShowDialog();
            if (ret == DialogResult.OK)
            {
                this.ColorBox.BackColor = this.colorDialog.Color;
            }
        }

        /// <summary>
        /// 色選択設定
        /// </summary>
        public void SetColorSelect(Color color)
        {
            m_cChangeColor = color;
            this.ColorBox.BackColor = color;
        }

        /// <summary>
        /// 色選択取得
        /// </summary>
        public Color GetColor()
        {
            return m_cChangeColor;
        }

        /// <summary>
        /// OKボタン_クリックイベント
        /// </summary>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            m_cChangeColor = this.ColorBox.BackColor;
            this.Close();
        }

        /// <summary>
        /// 初期ライフテキストボックス_クリックイベント
        /// </summary>
        private void textBoxLifeInitValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
                m_nInitLifeValue = int.Parse(textBoxLifeInitVale.Text.ToString());
            }
        }

        /// <summary>
        /// 初期ライフ取得
        /// </summary>
        public int GetInitLifeValie()
        {
            return m_nInitLifeValue;
        }

        /// <summary>
        /// 初期ライフ設定
        /// </summary>
        public void SetInitLifeValie(int nInitValie)
        {
            m_nInitLifeValue = nInitValie;
            this.textBoxLifeInitVale.AppendText(m_nInitLifeValue.ToString());
        }

        /// <summary>
        /// サブカウンターON取得
        /// </summary>
        public bool GetSubCounterON()
        {
            return m_nSubCounterON;
        }

        /// <summary>
        /// サブカウンターON設定
        /// </summary>
        public void SetSubCounterON(bool nSubCounterON)
        {
            m_nSubCounterON = nSubCounterON;
            this.checkSubCounter.Checked = nSubCounterON;
        }

        /// <summary>
        /// サウンドON取得
        /// </summary>
        public bool GetSoundON()
        {
            return m_nSoundON;
        }

        /// <summary>
        /// サウンドON設定
        /// </summary>
        public void SetSoundON(bool nSoundON)
        {
            m_nSubCounterON = nSoundON;
            this.checkBoxSound.Checked = nSoundON;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_nInitLifeValue = int.Parse(textBoxLifeInitVale.Text.ToString());
            m_cChangeColor = m_cChangeColor = this.ColorBox.BackColor;
            m_nSubCounterON = this.checkSubCounter.Checked;
            m_nSoundON = this.checkBoxSound.Checked;
            this.Close();
        }
    }
}
