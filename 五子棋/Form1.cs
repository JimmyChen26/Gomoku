using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace 五子棋
{
    public partial class Form1 : Form
    {
        private const int BoardSize = 15;
        private const int CellSize = 40;
        private const int Margin = 20;
        private const int PieceRadius = 16;

        // 0 = 空格, 1 = 黑棋, 2 = 白棋
        private int[,] board = new int[BoardSize, BoardSize];

        private int currentPlayer = 1;
        private bool gameOver = false;
        private int moveCount = 0;

        private int lastMoveX = -1;
        private int lastMoveY = -1;

        private bool isCpuThinking = false;
        private Random random = new Random();
        private Timer cpuTimer = new Timer();

        // 音效設定
        private bool enableAllSound = true;
        private bool enableTurnSound = true;

        // CPU 模式下玩家顏色：1 = 黑棋，2 = 白棋
        private int humanPlayer = 1;

        private enum GameMode
        {
            PVP,
            EasyCPU,
            MediumCPU,
            HardCPU
        }

        private GameMode currentMode = GameMode.PVP;

        public Form1()
        {
            InitializeComponent();

            SetupInstructionText();

            BindEvents();
            StartNewGame(false);

            cpuTimer.Interval = 450;
            cpuTimer.Tick += CpuTimer_Tick;

            this.Shown += Form1_Shown;
        }
        private void SetupInstructionText()
        {
            lblRuleTitle.Text = "遊戲規則";

            lblRuleText.Text =
                "黑白雙方輪流下子，先連成五子者獲勝。" + Environment.NewLine +
                "CPU 模式可選擇簡單、中等或困難難度。" + Environment.NewLine +
                "玩家可選擇黑棋或白棋，黑棋永遠先手。";

            lblOperationTitle.Text = "操作說明";

            lblOperationText.Text =
                "1. 先選擇遊戲模式。" + Environment.NewLine +
                "2. CPU 模式可選玩家黑棋或白棋。" + Environment.NewLine +
                "3. 點擊棋盤交叉點即可落子。";
            lblOperationText2.Text =
               "4. 可關閉輪流語音或全部音效。" + Environment.NewLine +
               "5. 按下重新開始可重置棋局。";
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            PlaySound("game_start.wav");
        }

        private void BindEvents()
        {
            picBoard.Paint -= picBoard_Paint;
            picBoard.MouseClick -= picBoard_MouseClick;

            btnPVP.Click -= btnPVP_Click;
            btnEasyCPU.Click -= btnEasyCPU_Click;
            btnMediumCPU.Click -= btnMediumCPU_Click;
            btnHardCPU.Click -= btnHardCPU_Click;
            btnRestart.Click -= btnRestart_Click;

            btnPlayerBlack.Click -= btnPlayerBlack_Click;
            btnPlayerWhite.Click -= btnPlayerWhite_Click;
            btnTurnSound.Click -= btnTurnSound_Click;
            btnAllSound.Click -= btnAllSound_Click;

            picBoard.Paint += picBoard_Paint;
            picBoard.MouseClick += picBoard_MouseClick;

            btnPVP.Click += btnPVP_Click;
            btnEasyCPU.Click += btnEasyCPU_Click;
            btnMediumCPU.Click += btnMediumCPU_Click;
            btnHardCPU.Click += btnHardCPU_Click;
            btnRestart.Click += btnRestart_Click;

            btnPlayerBlack.Click += btnPlayerBlack_Click;
            btnPlayerWhite.Click += btnPlayerWhite_Click;
            btnTurnSound.Click += btnTurnSound_Click;
            btnAllSound.Click += btnAllSound_Click;
        }

        private void btnPVP_Click(object sender, EventArgs e)
        {
            currentMode = GameMode.PVP;
            StartNewGame(true);
        }

        private void btnEasyCPU_Click(object sender, EventArgs e)
        {
            currentMode = GameMode.EasyCPU;
            StartNewGame(true);
        }

        private void btnMediumCPU_Click(object sender, EventArgs e)
        {
            currentMode = GameMode.MediumCPU;
            StartNewGame(true);
        }

        private void btnHardCPU_Click(object sender, EventArgs e)
        {
            currentMode = GameMode.HardCPU;
            StartNewGame(true);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartNewGame(false);
            PlaySound("restart.wav");
        }

        private void btnPlayerBlack_Click(object sender, EventArgs e)
        {
            humanPlayer = 1;
            StartNewGame(true);
        }

        private void btnPlayerWhite_Click(object sender, EventArgs e)
        {
            humanPlayer = 2;
            StartNewGame(true);
        }

        private void btnTurnSound_Click(object sender, EventArgs e)
        {
            enableTurnSound = !enableTurnSound;
            UpdateSoundText();
        }

        private void btnAllSound_Click(object sender, EventArgs e)
        {
            enableAllSound = !enableAllSound;
            UpdateSoundText();
        }

        private void StartNewGame(bool playStartSound)
        {
            board = new int[BoardSize, BoardSize];

            currentPlayer = 1;
            gameOver = false;
            moveCount = 0;
            isCpuThinking = false;

            lastMoveX = -1;
            lastMoveY = -1;

            cpuTimer.Stop();

            UpdateModeText();
            UpdateTurnText();
            UpdatePlayerColorText();
            UpdateSoundText();

            lblStatus.Text = "請點擊棋盤下棋";

            picBoard.Invalidate();

            if (playStartSound)
            {
                PlaySound("game_start.wav");
            }

            // 如果 CPU 模式下玩家選白棋，CPU 會先下黑棋
            if (IsCpuTurn())
            {
                StartCpuThinking();
            }
        }

        private void UpdateModeText()
        {
            if (currentMode == GameMode.PVP)
            {
                lblMode.Text = "目前模式：雙人對決";
            }
            else if (currentMode == GameMode.EasyCPU)
            {
                lblMode.Text = "目前模式：簡單 CPU";
            }
            else if (currentMode == GameMode.MediumCPU)
            {
                lblMode.Text = "目前模式：中等 CPU";
            }
            else
            {
                lblMode.Text = "目前模式：困難 CPU";
            }
        }

        private void UpdateTurnText()
        {
            if (currentPlayer == 1)
            {
                lblTurn.Text = "目前回合：黑棋";
            }
            else
            {
                lblTurn.Text = "目前回合：白棋";
            }
        }

        private void UpdatePlayerColorText()
        {
            if (currentMode == GameMode.PVP)
            {
                lblPlayerColor.Text = "玩家顏色：雙人模式";
            }
            else if (humanPlayer == 1)
            {
                lblPlayerColor.Text = "玩家顏色：黑棋";
            }
            else
            {
                lblPlayerColor.Text = "玩家顏色：白棋";
            }
        }

        private void UpdateSoundText()
        {
            btnTurnSound.Text = enableTurnSound ? "輪流語音：開" : "輪流語音：關";
            btnAllSound.Text = enableAllSound ? "全部音效：開" : "全部音效：關";
        }

        private void picBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawBoard(g);
            DrawPieces(g);
            DrawLastMoveMarker(g);
        }

        private void DrawBoard(Graphics g)
        {
            g.Clear(picBoard.BackColor);

            using (Pen linePen = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < BoardSize; i++)
                {
                    int pos = Margin + i * CellSize;

                    g.DrawLine(
                        linePen,
                        Margin,
                        pos,
                        Margin + (BoardSize - 1) * CellSize,
                        pos
                    );

                    g.DrawLine(
                        linePen,
                        pos,
                        Margin,
                        pos,
                        Margin + (BoardSize - 1) * CellSize
                    );
                }
            }

            DrawStarPoint(g, 3, 3);
            DrawStarPoint(g, 3, 11);
            DrawStarPoint(g, 7, 7);
            DrawStarPoint(g, 11, 3);
            DrawStarPoint(g, 11, 11);
        }

        private void DrawStarPoint(Graphics g, int x, int y)
        {
            int px = Margin + x * CellSize;
            int py = Margin + y * CellSize;

            g.FillEllipse(Brushes.Black, px - 5, py - 5, 10, 10);
        }

        private void DrawPieces(Graphics g)
        {
            for (int y = 0; y < BoardSize; y++)
            {
                for (int x = 0; x < BoardSize; x++)
                {
                    if (board[x, y] == 0)
                        continue;

                    int px = Margin + x * CellSize;
                    int py = Margin + y * CellSize;

                    Rectangle shadowRect = new Rectangle(
                        px - PieceRadius + 3,
                        py - PieceRadius + 3,
                        PieceRadius * 2,
                        PieceRadius * 2
                    );

                    using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(70, 0, 0, 0)))
                    {
                        g.FillEllipse(shadowBrush, shadowRect);
                    }

                    Rectangle pieceRect = new Rectangle(
                        px - PieceRadius,
                        py - PieceRadius,
                        PieceRadius * 2,
                        PieceRadius * 2
                    );

                    if (board[x, y] == 1)
                    {
                        g.FillEllipse(Brushes.Black, pieceRect);
                        g.DrawEllipse(Pens.DimGray, pieceRect);
                    }
                    else
                    {
                        g.FillEllipse(Brushes.White, pieceRect);
                        g.DrawEllipse(Pens.Black, pieceRect);
                    }
                }
            }
        }

        private void DrawLastMoveMarker(Graphics g)
        {
            if (lastMoveX == -1 || lastMoveY == -1)
                return;

            int px = Margin + lastMoveX * CellSize;
            int py = Margin + lastMoveY * CellSize;

            Rectangle rect = new Rectangle(px - 8, py - 8, 16, 16);

            using (Pen pen = new Pen(Color.Red, 2))
            {
                g.DrawRectangle(pen, rect);
            }
        }

        private void picBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameOver || isCpuThinking)
                return;

            // CPU 模式下，只能在玩家回合下棋
            if (currentMode != GameMode.PVP && currentPlayer != humanPlayer)
                return;

            int x = (int)Math.Round((e.X - Margin) / (double)CellSize);
            int y = (int)Math.Round((e.Y - Margin) / (double)CellSize);

            if (!IsInsideBoard(x, y))
                return;

            int centerX = Margin + x * CellSize;
            int centerY = Margin + y * CellSize;

            if (Math.Abs(e.X - centerX) > CellSize / 2 ||
                Math.Abs(e.Y - centerY) > CellSize / 2)
            {
                return;
            }

            if (board[x, y] != 0)
            {
                lblStatus.Text = "這裡已經有棋子了！";
                PlaySound("invalid_move.wav");
                return;
            }

            MakeMove(x, y, currentPlayer);

            if (CheckGameEnd(x, y, currentPlayer))
                return;

            SwitchTurn();

            if (IsCpuTurn())
            {
                StartCpuThinking();
            }
        }

        private void MakeMove(int x, int y, int player)
        {
            board[x, y] = player;
            moveCount++;

            lastMoveX = x;
            lastMoveY = y;

            picBoard.Invalidate();
        }

        private bool CheckGameEnd(int x, int y, int player)
        {
            if (CheckWin(x, y, player))
            {
                gameOver = true;

                if (player == 1)
                {
                    lblStatus.Text = "黑棋獲勝！";
                    lblTurn.Text = "遊戲結束";
                    PlaySound("black_win.wav");
                    MessageBox.Show("黑棋獲勝，恭喜！", "遊戲結束");
                }
                else
                {
                    lblStatus.Text = "白棋獲勝！";
                    lblTurn.Text = "遊戲結束";
                    PlaySound("white_win.wav");
                    MessageBox.Show("白棋獲勝，恭喜！", "遊戲結束");
                }

                return true;
            }

            if (moveCount >= BoardSize * BoardSize)
            {
                gameOver = true;
                lblTurn.Text = "遊戲結束";
                lblStatus.Text = "棋盤已滿，雙方平手！";
                PlaySound("draw.wav");
                MessageBox.Show("棋盤已滿，雙方平手！", "遊戲結束");
                return true;
            }

            return false;
        }

        private void SwitchTurn()
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;

            UpdateTurnText();

            if (currentMode == GameMode.PVP)
            {
                if (currentPlayer == 1)
                {
                    lblStatus.Text = "請黑棋下棋";
                    PlaySound("black_turn.wav", true);
                }
                else
                {
                    lblStatus.Text = "請白棋下棋";
                    PlaySound("white_turn.wav", true);
                }
            }
            else
            {
                if (currentPlayer == humanPlayer)
                {
                    lblStatus.Text = "請玩家下棋";

                    if (currentPlayer == 1)
                        PlaySound("black_turn.wav", true);
                    else
                        PlaySound("white_turn.wav", true);
                }
                else
                {
                    lblStatus.Text = "CPU 思考中...";

                    if (currentPlayer == 1)
                        PlaySound("black_turn.wav", true);
                    else
                        PlaySound("white_turn.wav", true);
                }
            }
        }

        private bool IsCpuTurn()
        {
            return currentMode != GameMode.PVP &&
                   currentPlayer != humanPlayer &&
                   !gameOver;
        }

        private void StartCpuThinking()
        {
            isCpuThinking = true;
            lblStatus.Text = "CPU 思考中...";
            cpuTimer.Start();
        }

        private void CpuTimer_Tick(object sender, EventArgs e)
        {
            cpuTimer.Stop();

            if (gameOver)
            {
                isCpuThinking = false;
                return;
            }

            Point cpuMove;

            if (currentMode == GameMode.EasyCPU)
            {
                cpuMove = GetEasyCpuMove();
            }
            else if (currentMode == GameMode.MediumCPU)
            {
                cpuMove = GetMediumCpuMove();
            }
            else
            {
                cpuMove = GetHardCpuMove();
            }

            if (cpuMove.X == -1 || cpuMove.Y == -1)
            {
                isCpuThinking = false;
                return;
            }

            MakeMove(cpuMove.X, cpuMove.Y, currentPlayer);

            isCpuThinking = false;

            if (CheckGameEnd(cpuMove.X, cpuMove.Y, currentPlayer))
                return;

            SwitchTurn();
        }

        private Point GetEasyCpuMove()
        {
            List<Point> available = GetAvailableMoves();

            if (available.Count == 0)
                return new Point(-1, -1);

            List<Point> nearMoves = new List<Point>();

            foreach (Point p in available)
            {
                if (HasNeighbor(p.X, p.Y, 1))
                {
                    nearMoves.Add(p);
                }
            }

            if (nearMoves.Count > 0)
            {
                return nearMoves[random.Next(nearMoves.Count)];
            }

            return available[random.Next(available.Count)];
        }

        private Point GetMediumCpuMove()
        {
            List<Point> available = GetAvailableMoves();

            if (available.Count == 0)
                return new Point(-1, -1);

            int cpuPlayer = currentPlayer;
            int opponentPlayer = cpuPlayer == 1 ? 2 : 1;

            // 1. CPU 可以直接贏，先贏
            foreach (Point p in available)
            {
                if (WouldWin(p.X, p.Y, cpuPlayer))
                {
                    return p;
                }
            }

            // 2. 玩家下一步會贏，先擋
            foreach (Point p in available)
            {
                if (WouldWin(p.X, p.Y, opponentPlayer))
                {
                    return p;
                }
            }

            // 3. 從附近位置中挑選較好的點
            List<Point> candidates = GetCandidateMoves();

            if (candidates.Count == 0)
            {
                candidates = available;
            }

            double bestScore = double.MinValue;
            List<Point> bestMoves = new List<Point>();

            foreach (Point p in candidates)
            {
                double attackScore = EvaluateMove(p.X, p.Y, cpuPlayer);
                double defendScore = EvaluateMove(p.X, p.Y, opponentPlayer);
                double centerScore = GetCenterBonus(p.X, p.Y);

                // 中等 CPU：會進攻、會防守，但權重比困難 CPU 保守
                double totalScore = attackScore + defendScore * 0.9 + centerScore * 0.5;

                if (totalScore > bestScore)
                {
                    bestScore = totalScore;
                    bestMoves.Clear();
                    bestMoves.Add(p);
                }
                else if (Math.Abs(totalScore - bestScore) < 0.001)
                {
                    bestMoves.Add(p);
                }
            }

            return bestMoves[random.Next(bestMoves.Count)];
        }

        private Point GetHardCpuMove()
        {
            List<Point> available = GetAvailableMoves();

            if (available.Count == 0)
                return new Point(-1, -1);

            int cpuPlayer = currentPlayer;
            int opponentPlayer = cpuPlayer == 1 ? 2 : 1;

            // 1. CPU 可以直接贏
            foreach (Point p in available)
            {
                if (WouldWin(p.X, p.Y, cpuPlayer))
                {
                    return p;
                }
            }

            // 2. 玩家下一步會贏，CPU 先擋
            foreach (Point p in available)
            {
                if (WouldWin(p.X, p.Y, opponentPlayer))
                {
                    return p;
                }
            }

            // 3. 評估分數
            List<Point> candidates = GetCandidateMoves();

            if (candidates.Count == 0)
            {
                candidates = available;
            }

            double bestScore = double.MinValue;
            List<Point> bestMoves = new List<Point>();

            foreach (Point p in candidates)
            {
                double cpuAttackScore = EvaluateMove(p.X, p.Y, cpuPlayer);
                double playerThreatScore = EvaluateMove(p.X, p.Y, opponentPlayer);
                double centerScore = GetCenterBonus(p.X, p.Y);

                double totalScore = cpuAttackScore * 1.2 + playerThreatScore + centerScore;

                if (totalScore > bestScore)
                {
                    bestScore = totalScore;
                    bestMoves.Clear();
                    bestMoves.Add(p);
                }
                else if (Math.Abs(totalScore - bestScore) < 0.001)
                {
                    bestMoves.Add(p);
                }
            }

            return bestMoves[random.Next(bestMoves.Count)];
        }

        private List<Point> GetAvailableMoves()
        {
            List<Point> moves = new List<Point>();

            for (int y = 0; y < BoardSize; y++)
            {
                for (int x = 0; x < BoardSize; x++)
                {
                    if (board[x, y] == 0)
                    {
                        moves.Add(new Point(x, y));
                    }
                }
            }

            return moves;
        }

        private List<Point> GetCandidateMoves()
        {
            List<Point> moves = new List<Point>();

            if (moveCount == 0)
            {
                moves.Add(new Point(7, 7));
                return moves;
            }

            for (int y = 0; y < BoardSize; y++)
            {
                for (int x = 0; x < BoardSize; x++)
                {
                    if (board[x, y] == 0 && HasNeighbor(x, y, 2))
                    {
                        moves.Add(new Point(x, y));
                    }
                }
            }

            return moves;
        }

        private bool HasNeighbor(int x, int y, int distance)
        {
            for (int dy = -distance; dy <= distance; dy++)
            {
                for (int dx = -distance; dx <= distance; dx++)
                {
                    if (dx == 0 && dy == 0)
                        continue;

                    int nx = x + dx;
                    int ny = y + dy;

                    if (IsInsideBoard(nx, ny) && board[nx, ny] != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool WouldWin(int x, int y, int player)
        {
            if (board[x, y] != 0)
                return false;

            board[x, y] = player;
            bool result = CheckWin(x, y, player);
            board[x, y] = 0;

            return result;
        }

        private double EvaluateMove(int x, int y, int player)
        {
            if (board[x, y] != 0)
                return -1;

            board[x, y] = player;

            double score = 0;

            score += EvaluateDirection(x, y, 1, 0, player);
            score += EvaluateDirection(x, y, 0, 1, player);
            score += EvaluateDirection(x, y, 1, 1, player);
            score += EvaluateDirection(x, y, 1, -1, player);

            board[x, y] = 0;

            return score;
        }

        private double EvaluateDirection(int x, int y, int dx, int dy, int player)
        {
            int count = 1;
            int openEnds = 0;

            int nx = x + dx;
            int ny = y + dy;

            while (IsInsideBoard(nx, ny) && board[nx, ny] == player)
            {
                count++;
                nx += dx;
                ny += dy;
            }

            if (IsInsideBoard(nx, ny) && board[nx, ny] == 0)
            {
                openEnds++;
            }

            nx = x - dx;
            ny = y - dy;

            while (IsInsideBoard(nx, ny) && board[nx, ny] == player)
            {
                count++;
                nx -= dx;
                ny -= dy;
            }

            if (IsInsideBoard(nx, ny) && board[nx, ny] == 0)
            {
                openEnds++;
            }

            if (count >= 5)
                return 1000000;

            if (count == 4 && openEnds == 2)
                return 100000;

            if (count == 4 && openEnds == 1)
                return 10000;

            if (count == 3 && openEnds == 2)
                return 5000;

            if (count == 3 && openEnds == 1)
                return 800;

            if (count == 2 && openEnds == 2)
                return 300;

            if (count == 2 && openEnds == 1)
                return 80;

            if (count == 1 && openEnds == 2)
                return 10;

            return 1;
        }

        private double GetCenterBonus(int x, int y)
        {
            int center = BoardSize / 2;

            double distance = Math.Sqrt(
                (x - center) * (x - center) +
                (y - center) * (y - center)
            );

            return Math.Max(0, 20 - distance);
        }

        private bool CheckWin(int x, int y, int player)
        {
            return CountPieces(x, y, 1, 0, player) >= 5 ||
                   CountPieces(x, y, 0, 1, player) >= 5 ||
                   CountPieces(x, y, 1, 1, player) >= 5 ||
                   CountPieces(x, y, 1, -1, player) >= 5;
        }

        private int CountPieces(int x, int y, int dx, int dy, int player)
        {
            int count = 1;

            count += CountOneDirection(x, y, dx, dy, player);
            count += CountOneDirection(x, y, -dx, -dy, player);

            return count;
        }

        private int CountOneDirection(int x, int y, int dx, int dy, int player)
        {
            int count = 0;

            int nx = x + dx;
            int ny = y + dy;

            while (IsInsideBoard(nx, ny))
            {
                if (board[nx, ny] == player)
                {
                    count++;
                    nx += dx;
                    ny += dy;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private bool IsInsideBoard(int x, int y)
        {
            return x >= 0 && x < BoardSize &&
                   y >= 0 && y < BoardSize;
        }

        private void PlaySound(string fileName)
        {
            PlaySound(fileName, false);
        }

        private void PlaySound(string fileName, bool isTurnSound)
        {
            if (!enableAllSound)
                return;

            if (isTurnSound && !enableTurnSound)
                return;

            try
            {
                string path = Path.Combine(Application.StartupPath, "Sounds", fileName);

                if (File.Exists(path))
                {
                    SoundPlayer player = new SoundPlayer(path);
                    player.Play();
                }
                else
                {
                    SystemSounds.Asterisk.Play();
                }
            }
            catch
            {
                SystemSounds.Asterisk.Play();
            }
        }

        // 設計器有綁到這些事件時保留即可
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void lblRuleText_Click(object sender, EventArgs e)
        {
        }

        private void lblPlayerColor_Click(object sender, EventArgs e)
        {
        }
    }
}