namespace LifeCounter
{
    partial class PlayerNumForm
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
            this.radioButtonNum1 = new System.Windows.Forms.RadioButton();
            this.radioButtonNum2 = new System.Windows.Forms.RadioButton();
            this.radioButtonNum3 = new System.Windows.Forms.RadioButton();
            this.radioButtonNum4 = new System.Windows.Forms.RadioButton();
            this.radioButtonNum5 = new System.Windows.Forms.RadioButton();
            this.radioButtonNum6 = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButtonNum1
            // 
            this.radioButtonNum1.AutoSize = true;
            this.radioButtonNum1.Location = new System.Drawing.Point(30, 30);
            this.radioButtonNum1.Name = "radioButtonNum1";
            this.radioButtonNum1.Size = new System.Drawing.Size(77, 28);
            this.radioButtonNum1.TabIndex = 0;
            this.radioButtonNum1.TabStop = true;
            this.radioButtonNum1.Text = "1人";
            this.radioButtonNum1.UseVisualStyleBackColor = true;
            // 
            // radioButtonNum2
            // 
            this.radioButtonNum2.AutoSize = true;
            this.radioButtonNum2.Location = new System.Drawing.Point(220, 30);
            this.radioButtonNum2.Name = "radioButtonNum2";
            this.radioButtonNum2.Size = new System.Drawing.Size(77, 28);
            this.radioButtonNum2.TabIndex = 1;
            this.radioButtonNum2.TabStop = true;
            this.radioButtonNum2.Text = "2人";
            this.radioButtonNum2.UseVisualStyleBackColor = true;
            // 
            // radioButtonNum3
            // 
            this.radioButtonNum3.AutoSize = true;
            this.radioButtonNum3.Location = new System.Drawing.Point(30, 100);
            this.radioButtonNum3.Name = "radioButtonNum3";
            this.radioButtonNum3.Size = new System.Drawing.Size(77, 28);
            this.radioButtonNum3.TabIndex = 2;
            this.radioButtonNum3.TabStop = true;
            this.radioButtonNum3.Text = "3人";
            this.radioButtonNum3.UseVisualStyleBackColor = true;
            // 
            // radioButtonNum4
            // 
            this.radioButtonNum4.AutoSize = true;
            this.radioButtonNum4.Location = new System.Drawing.Point(220, 100);
            this.radioButtonNum4.Name = "radioButtonNum4";
            this.radioButtonNum4.Size = new System.Drawing.Size(77, 28);
            this.radioButtonNum4.TabIndex = 3;
            this.radioButtonNum4.TabStop = true;
            this.radioButtonNum4.Text = "4人";
            this.radioButtonNum4.UseVisualStyleBackColor = true;
            // 
            // radioButtonNum5
            // 
            this.radioButtonNum5.AutoSize = true;
            this.radioButtonNum5.Location = new System.Drawing.Point(30, 170);
            this.radioButtonNum5.Name = "radioButtonNum5";
            this.radioButtonNum5.Size = new System.Drawing.Size(77, 28);
            this.radioButtonNum5.TabIndex = 4;
            this.radioButtonNum5.TabStop = true;
            this.radioButtonNum5.Text = "5人";
            this.radioButtonNum5.UseVisualStyleBackColor = true;
            // 
            // radioButtonNum6
            // 
            this.radioButtonNum6.AutoSize = true;
            this.radioButtonNum6.Location = new System.Drawing.Point(220, 170);
            this.radioButtonNum6.Name = "radioButtonNum6";
            this.radioButtonNum6.Size = new System.Drawing.Size(77, 28);
            this.radioButtonNum6.TabIndex = 5;
            this.radioButtonNum6.TabStop = true;
            this.radioButtonNum6.Text = "6人";
            this.radioButtonNum6.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(130, 240);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(80, 30);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // PlayerNumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(334, 299);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.radioButtonNum6);
            this.Controls.Add(this.radioButtonNum5);
            this.Controls.Add(this.radioButtonNum4);
            this.Controls.Add(this.radioButtonNum3);
            this.Controls.Add(this.radioButtonNum2);
            this.Controls.Add(this.radioButtonNum1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PlayerNumForm";
            this.Text = "対戦人数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonNum1;
        private System.Windows.Forms.RadioButton radioButtonNum2;
        private System.Windows.Forms.RadioButton radioButtonNum3;
        private System.Windows.Forms.RadioButton radioButtonNum4;
        private System.Windows.Forms.RadioButton radioButtonNum5;
        private System.Windows.Forms.RadioButton radioButtonNum6;
        private System.Windows.Forms.Button buttonOK;
    }
}