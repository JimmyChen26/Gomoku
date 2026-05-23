namespace 五子棋
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.picBoard = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblRuleTitle = new System.Windows.Forms.Label();
            this.lblRuleText = new System.Windows.Forms.Label();
            this.btnPVP = new System.Windows.Forms.Button();
            this.btnEasyCPU = new System.Windows.Forms.Button();
            this.btnHardCPU = new System.Windows.Forms.Button();
            this.lblPlayerColor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPlayerBlack = new System.Windows.Forms.Button();
            this.btnPlayerWhite = new System.Windows.Forms.Button();
            this.btnTurnSound = new System.Windows.Forms.Button();
            this.btnAllSound = new System.Windows.Forms.Button();
            this.btnMediumCPU = new System.Windows.Forms.Button();
            this.lblOperationTitle = new System.Windows.Forms.Label();
            this.lblOperationText = new System.Windows.Forms.Label();
            this.lblOperationText2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).BeginInit();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTurn.Location = new System.Drawing.Point(20, 105);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(181, 30);
            this.lblTurn.TabIndex = 1;
            this.lblTurn.Text = "目前回合：黑棋";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblStatus.Location = new System.Drawing.Point(20, 140);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(181, 30);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "請點擊棋盤下棋";
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRestart.Location = new System.Drawing.Point(30, 654);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(280, 40);
            this.btnRestart.TabIndex = 3;
            this.btnRestart.Text = "重新開始";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // picBoard
            // 
            this.picBoard.BackColor = System.Drawing.Color.BurlyWood;
            this.picBoard.Location = new System.Drawing.Point(20, 20);
            this.picBoard.Name = "picBoard";
            this.picBoard.Size = new System.Drawing.Size(954, 890);
            this.picBoard.TabIndex = 4;
            this.picBoard.TabStop = false;
            this.picBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoard_Paint);
            this.picBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBoard_MouseClick);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.btnMediumCPU);
            this.panelRight.Controls.Add(this.btnAllSound);
            this.panelRight.Controls.Add(this.btnTurnSound);
            this.panelRight.Controls.Add(this.btnPlayerWhite);
            this.panelRight.Controls.Add(this.btnPlayerBlack);
            this.panelRight.Controls.Add(this.label2);
            this.panelRight.Controls.Add(this.lblPlayerColor);
            this.panelRight.Controls.Add(this.btnHardCPU);
            this.panelRight.Controls.Add(this.btnEasyCPU);
            this.panelRight.Controls.Add(this.btnPVP);
            this.panelRight.Controls.Add(this.lblRuleText);
            this.panelRight.Controls.Add(this.lblRuleTitle);
            this.panelRight.Controls.Add(this.btnRestart);
            this.panelRight.Controls.Add(this.lblStatus);
            this.panelRight.Controls.Add(this.lblMode);
            this.panelRight.Controls.Add(this.lblTurn);
            this.panelRight.Controls.Add(this.lblTitle);
            this.panelRight.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panelRight.Location = new System.Drawing.Point(998, 59);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(501, 904);
            this.panelRight.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(189, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "五子棋 Gomoku";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(20, 70);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(229, 30);
            this.lblMode.TabIndex = 1;
            this.lblMode.Text = "目前模式：雙人對決";
            // 
            // lblRuleTitle
            // 
            this.lblRuleTitle.AutoSize = true;
            this.lblRuleTitle.Location = new System.Drawing.Point(20, 728);
            this.lblRuleTitle.Name = "lblRuleTitle";
            this.lblRuleTitle.Size = new System.Drawing.Size(109, 30);
            this.lblRuleTitle.TabIndex = 2;
            this.lblRuleTitle.Text = "遊戲規則";
            // 
            // lblRuleText
            // 
            this.lblRuleText.AutoSize = true;
            this.lblRuleText.Location = new System.Drawing.Point(20, 768);
            this.lblRuleText.Name = "lblRuleText";
            this.lblRuleText.Size = new System.Drawing.Size(421, 30);
            this.lblRuleText.TabIndex = 3;
            this.lblRuleText.Text = "黑白雙方輪流下子，先連成五子者獲勝";
            this.lblRuleText.Click += new System.EventHandler(this.lblRuleText_Click);
            // 
            // btnPVP
            // 
            this.btnPVP.Location = new System.Drawing.Point(30, 200);
            this.btnPVP.Name = "btnPVP";
            this.btnPVP.Size = new System.Drawing.Size(280, 40);
            this.btnPVP.TabIndex = 4;
            this.btnPVP.Text = "雙人對決";
            this.btnPVP.UseVisualStyleBackColor = true;
            // 
            // btnEasyCPU
            // 
            this.btnEasyCPU.Location = new System.Drawing.Point(30, 250);
            this.btnEasyCPU.Name = "btnEasyCPU";
            this.btnEasyCPU.Size = new System.Drawing.Size(280, 40);
            this.btnEasyCPU.TabIndex = 5;
            this.btnEasyCPU.Text = "簡單 CPU";
            this.btnEasyCPU.UseVisualStyleBackColor = true;
            // 
            // btnHardCPU
            // 
            this.btnHardCPU.Location = new System.Drawing.Point(30, 350);
            this.btnHardCPU.Name = "btnHardCPU";
            this.btnHardCPU.Size = new System.Drawing.Size(280, 40);
            this.btnHardCPU.TabIndex = 6;
            this.btnHardCPU.Text = "困難 CPU";
            this.btnHardCPU.UseVisualStyleBackColor = true;
            // 
            // lblPlayerColor
            // 
            this.lblPlayerColor.AutoSize = true;
            this.lblPlayerColor.Location = new System.Drawing.Point(20, 439);
            this.lblPlayerColor.Name = "lblPlayerColor";
            this.lblPlayerColor.Size = new System.Drawing.Size(181, 30);
            this.lblPlayerColor.TabIndex = 7;
            this.lblPlayerColor.Text = "玩家顏色：黑棋";
            this.lblPlayerColor.Click += new System.EventHandler(this.lblPlayerColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 524);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "音效設定";
            // 
            // btnPlayerBlack
            // 
            this.btnPlayerBlack.Location = new System.Drawing.Point(30, 469);
            this.btnPlayerBlack.Name = "btnPlayerBlack";
            this.btnPlayerBlack.Size = new System.Drawing.Size(130, 40);
            this.btnPlayerBlack.TabIndex = 9;
            this.btnPlayerBlack.Text = "玩家黑棋";
            this.btnPlayerBlack.UseVisualStyleBackColor = true;
            this.btnPlayerBlack.Click += new System.EventHandler(this.btnPlayerBlack_Click);
            // 
            // btnPlayerWhite
            // 
            this.btnPlayerWhite.Location = new System.Drawing.Point(180, 469);
            this.btnPlayerWhite.Name = "btnPlayerWhite";
            this.btnPlayerWhite.Size = new System.Drawing.Size(130, 40);
            this.btnPlayerWhite.TabIndex = 10;
            this.btnPlayerWhite.Text = "玩家白棋";
            this.btnPlayerWhite.UseVisualStyleBackColor = true;
            this.btnPlayerWhite.Click += new System.EventHandler(this.btnPlayerWhite_Click);
            // 
            // btnTurnSound
            // 
            this.btnTurnSound.Location = new System.Drawing.Point(30, 554);
            this.btnTurnSound.Name = "btnTurnSound";
            this.btnTurnSound.Size = new System.Drawing.Size(280, 40);
            this.btnTurnSound.TabIndex = 11;
            this.btnTurnSound.Text = "輪流語音：開";
            this.btnTurnSound.UseVisualStyleBackColor = true;
            this.btnTurnSound.Click += new System.EventHandler(this.btnTurnSound_Click);
            // 
            // btnAllSound
            // 
            this.btnAllSound.Location = new System.Drawing.Point(30, 604);
            this.btnAllSound.Name = "btnAllSound";
            this.btnAllSound.Size = new System.Drawing.Size(280, 40);
            this.btnAllSound.TabIndex = 12;
            this.btnAllSound.Text = "全部音效：開";
            this.btnAllSound.UseVisualStyleBackColor = true;
            this.btnAllSound.Click += new System.EventHandler(this.btnAllSound_Click);
            // 
            // btnMediumCPU
            // 
            this.btnMediumCPU.Location = new System.Drawing.Point(30, 300);
            this.btnMediumCPU.Name = "btnMediumCPU";
            this.btnMediumCPU.Size = new System.Drawing.Size(280, 40);
            this.btnMediumCPU.TabIndex = 13;
            this.btnMediumCPU.Text = "中等 CPU";
            this.btnMediumCPU.UseVisualStyleBackColor = true;
            this.btnMediumCPU.Click += new System.EventHandler(this.btnMediumCPU_Click);
            // 
            // lblOperationTitle
            // 
            this.lblOperationTitle.AutoSize = true;
            this.lblOperationTitle.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOperationTitle.Location = new System.Drawing.Point(15, 913);
            this.lblOperationTitle.Name = "lblOperationTitle";
            this.lblOperationTitle.Size = new System.Drawing.Size(109, 30);
            this.lblOperationTitle.TabIndex = 14;
            this.lblOperationTitle.Text = "操作說明";
            // 
            // lblOperationText
            // 
            this.lblOperationText.AutoSize = true;
            this.lblOperationText.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOperationText.Location = new System.Drawing.Point(130, 913);
            this.lblOperationText.Name = "lblOperationText";
            this.lblOperationText.Size = new System.Drawing.Size(231, 30);
            this.lblOperationText.TabIndex = 15;
            this.lblOperationText.Text = "1. 先選擇遊戲模式。";
            // 
            // lblOperationText2
            // 
            this.lblOperationText2.AutoSize = true;
            this.lblOperationText2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOperationText2.Location = new System.Drawing.Point(592, 923);
            this.lblOperationText2.Name = "lblOperationText2";
            this.lblOperationText2.Size = new System.Drawing.Size(351, 30);
            this.lblOperationText2.TabIndex = 16;
            this.lblOperationText2.Text = "4. 可關閉輪流語音或全部音效。";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(239)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1577, 1272);
            this.Controls.Add(this.lblOperationText2);
            this.Controls.Add(this.lblOperationText);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.lblOperationTitle);
            this.Controls.Add(this.picBoard);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五子棋 Gomoku";
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.PictureBox picBoard;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblRuleText;
        private System.Windows.Forms.Label lblRuleTitle;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnHardCPU;
        private System.Windows.Forms.Button btnEasyCPU;
        private System.Windows.Forms.Button btnPVP;
        private System.Windows.Forms.Button btnAllSound;
        private System.Windows.Forms.Button btnTurnSound;
        private System.Windows.Forms.Button btnPlayerWhite;
        private System.Windows.Forms.Button btnPlayerBlack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPlayerColor;
        private System.Windows.Forms.Button btnMediumCPU;
        private System.Windows.Forms.Label lblOperationText;
        private System.Windows.Forms.Label lblOperationTitle;
        private System.Windows.Forms.Label lblOperationText2;
    }
}

