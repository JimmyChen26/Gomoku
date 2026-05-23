# 五子棋 Gomoku

## 專案簡介

本專案為 C# Windows Forms 製作的五子棋遊戲。玩家可以在圖形化介面中進行雙人對戰，也可以選擇與 CPU 對戰。遊戲支援簡單、中等、困難三種 CPU 難度，並提供玩家黑棋或白棋選擇、音效控制、重新開始與勝利提示等功能。

## 遊戲特色

- 15 × 15 五子棋棋盤
- 黑白棋輪流落子
- 支援四種遊戲模式：
  - 雙人對決
  - 簡單 CPU
  - 中等 CPU
  - 困難 CPU
- CPU 模式可選擇玩家擔任黑棋或白棋
- 支援音效功能：
  - 遊戲開始音效
  - 黑棋 / 白棋回合語音
  - 無效落子提示音效
  - 勝利音效
- 可單獨關閉輪流語音
- 可關閉全部音效
- 顯示目前模式、目前回合與遊戲狀態
- 最後一步落子會以紅框標記
- 提供重新開始功能

## 遊戲規則

黑棋與白棋輪流在棋盤交叉點落子。  
任一方先在橫向、直向或斜向連成五顆棋子，即可獲得勝利。  
若棋盤已滿且雙方都沒有連成五子，則判定為平手。

## 操作說明

1. 開啟遊戲後，預設為「雙人對決」模式。
2. 可點選右側按鈕切換遊戲模式：
   - 雙人對決
   - 簡單 CPU
   - 中等 CPU
   - 困難 CPU
3. 在 CPU 模式下，可選擇玩家擔任黑棋或白棋。
4. 使用滑鼠點擊棋盤交叉點即可落子。
5. 若點擊的位置已有棋子，系統會提示無法落子。
6. 可使用「輪流語音：開 / 關」按鈕控制回合語音。
7. 可使用「全部音效：開 / 關」按鈕控制所有音效。
8. 按下「重新開始」可重置目前棋局。

## CPU 難度說明

### 簡單 CPU

簡單 CPU 會優先選擇靠近已有棋子的位置，並從可落子位置中隨機選擇一格。此模式適合初學者遊玩。

### 中等 CPU

中等 CPU 會判斷是否可以直接獲勝，也會阻擋玩家下一步可能形成五連線的位置，並根據進攻、防守與中心位置進行簡單評分。

### 困難 CPU

困難 CPU 會進一步評估每個位置的進攻與防守分數，優先選擇較有利的位置，例如可以形成活三、活四或阻止玩家威脅的位置。

## 執行環境

- 作業系統：Windows
- 開發工具：Visual Studio
- 程式語言：C#
- 專案類型：Windows Forms App

## 執行方式

1. 使用 Visual Studio 開啟本專案。
2. 確認音效檔案已放在 `Sounds` 資料夾中。
3. 確認音效檔屬性設定：
   - Build Action：Content
   - Copy to Output Directory：Copy if newer
4. 按下 Visual Studio 的 Start 按鈕執行遊戲。

<img width="785" height="528" alt="image" src="https://github.com/user-attachments/assets/89cc1127-6652-43f8-b436-2d955fb7eb6b" />


## 專案結構

```text
五子棋/
├── Form1.cs
├── Form1.Designer.cs
├── Program.cs
├── Sounds/
│   ├── game_start.wav
│   ├── black_turn.wav
│   ├── white_turn.wav
│   ├── invalid_move.wav
│   ├── black_win.wav
│   ├── white_win.wav
│   ├── draw.wav
│   └── restart.wav
└── README.md
