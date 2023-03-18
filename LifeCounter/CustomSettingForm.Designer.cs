namespace LifeCounter
{
    partial class CustomSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.ColorSelectButton = new System.Windows.Forms.Button();
            this.ColorBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.LifeInitVale = new System.Windows.Forms.Label();
            this.textBoxLifeInitVale = new System.Windows.Forms.TextBox();
            this.checkBoxSound = new System.Windows.Forms.CheckBox();
            this.checkSubCounter = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ColorSelectButton
            // 
            this.ColorSelectButton.Location = new System.Drawing.Point(40, 120);
            this.ColorSelectButton.Name = "ColorSelectButton";
            this.ColorSelectButton.Size = new System.Drawing.Size(150, 40);
            this.ColorSelectButton.TabIndex = 0;
            this.ColorSelectButton.Text = "表示色設定";
            this.ColorSelectButton.UseVisualStyleBackColor = true;
            this.ColorSelectButton.Click += new System.EventHandler(this.ColorSelectButton_Click);
            // 
            // ColorBox
            // 
            this.ColorBox.Location = new System.Drawing.Point(220, 120);
            this.ColorBox.Multiline = true;
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(150, 40);
            this.ColorBox.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(200, 357);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(80, 30);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "ON";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // LifeInitVale
            // 
            this.LifeInitVale.AutoSize = true;
            this.LifeInitVale.Location = new System.Drawing.Point(40, 40);
            this.LifeInitVale.Name = "LifeInitVale";
            this.LifeInitVale.Size = new System.Drawing.Size(108, 24);
            this.LifeInitVale.TabIndex = 4;
            this.LifeInitVale.Text = "初期ライフ";
            // 
            // textBoxLifeInitVale
            // 
            this.textBoxLifeInitVale.Location = new System.Drawing.Point(220, 40);
            this.textBoxLifeInitVale.MaxLength = 2;
            this.textBoxLifeInitVale.Name = "textBoxLifeInitVale";
            this.textBoxLifeInitVale.Size = new System.Drawing.Size(60, 31);
            this.textBoxLifeInitVale.TabIndex = 0;
            this.textBoxLifeInitVale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxLifeInitVale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLifeInitValue_KeyPress);
            // 
            // checkBoxSound
            // 
            this.checkBoxSound.AutoSize = true;
            this.checkBoxSound.Location = new System.Drawing.Point(40, 280);
            this.checkBoxSound.Name = "checkBoxSound";
            this.checkBoxSound.Size = new System.Drawing.Size(147, 28);
            this.checkBoxSound.TabIndex = 5;
            this.checkBoxSound.Text = "サウンドON";
            this.checkBoxSound.UseVisualStyleBackColor = true;
            // 
            // checkSubCounter
            // 
            this.checkSubCounter.AutoSize = true;
            this.checkSubCounter.Location = new System.Drawing.Point(40, 200);
            this.checkSubCounter.Name = "checkSubCounter";
            this.checkSubCounter.Size = new System.Drawing.Size(202, 28);
            this.checkSubCounter.TabIndex = 6;
            this.checkSubCounter.Text = "サブカウンターON";
            this.checkSubCounter.UseVisualStyleBackColor = true;
            // 
            // CustomSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 433);
            this.Controls.Add(this.checkSubCounter);
            this.Controls.Add(this.checkBoxSound);
            this.Controls.Add(this.textBoxLifeInitVale);
            this.Controls.Add(this.LifeInitVale);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.ColorBox);
            this.Controls.Add(this.ColorSelectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomSettingForm";
            this.Text = "カスタム設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button ColorSelectButton;
        private System.Windows.Forms.TextBox ColorBox;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label LifeInitVale;
        private System.Windows.Forms.TextBox textBoxLifeInitVale;
        private System.Windows.Forms.CheckBox checkBoxSound;
        private System.Windows.Forms.CheckBox checkSubCounter;
    }
}