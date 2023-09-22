using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;
        public Panel ChessBoard {get { return chessBoard; } set { chessBoard = value; }}
        private List<Player> player;
        public List<Player> Player {get { return player; } set { player = value; }}

        private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

        TextBox playName;
        public TextBox PlayName { get => playName; set => playName = value; }


        PictureBox playMark;
        public PictureBox PlayMark { get => playMark; set => playMark = value; }


        private List<List<Button>> matrix;
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }
        public Stack<PlayInfo> PlayTimeLine1 { get => PlayTimeLine; set => PlayTimeLine = value; }

        private event EventHandler<ButtonClickEvent> playerMaked;
        public event EventHandler<ButtonClickEvent> PlayerMaked
        {
            add
            {
                playerMaked += value;   
            }
            remove
            {
                playerMaked -= value;
            }
        }

        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }

        private Stack<PlayInfo> PlayTimeLine;

        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard,TextBox playName,PictureBox mark)
        {
            this.chessBoard = chessBoard;
            this.playName = playName;
            this.PlayMark = mark;
            this.Player = new List<Player>() {
                new Player("Player 1",Image.FromFile(Application.StartupPath+"\\Resources\\O.png")),
                new Player("Player 2",Image.FromFile(Application.StartupPath+"\\Resources\\X.png"))
            };
        }
        
        #endregion

        #region Methods
        public void DrawChessBoard()
        {
            ChessBoard.Enabled = true;
            ChessBoard.Controls.Clear();

            PlayTimeLine = new Stack<PlayInfo>();

            currentPlayer = 0;
            changePlayer();

            matrix = new List<List<Button>>();

            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    };

                    btn.Click += btn_Click;

                    chessBoard.Controls.Add(btn);

                    matrix[i].Add(btn);

                    oldButton = btn;
                }

                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }
        
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if(btn.BackgroundImage != null) { return; }

            Mark(btn);

            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn),currentPlayer));


            currentPlayer = currentPlayer == 1 ? 0 : 1;

            changePlayer();

            if(playerMaked!=null)
            {
                playerMaked(this,new ButtonClickEvent(GetChessPoint(btn)));
            }

            if (isEndGame(btn))
            {
                EndGame();
            }
        }
        public void OtherPlayerMark(Point point)
        {
            Button btn = matrix[point.Y][point.X];

            if (btn.BackgroundImage != null) { return; }

            ChessBoard.Enabled = true;

            Mark(btn);

            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), currentPlayer));


            currentPlayer = currentPlayer == 1 ? 0 : 1;

            changePlayer();

            if (isEndGame(btn))
            {
                EndGame();
            }
        }
        private void EndGame()
        {
            if (endedGame != null)
            {
                endedGame(this, new EventArgs());

            }
        }
        public bool Undo()
        {
            if (PlayTimeLine.Count <= 0) return false;

            bool isUndo1=UndoAStep();
            bool isUndo2=UndoAStep();

            PlayInfo oldPoint = PlayTimeLine.Peek();
            currentPlayer = oldPoint.CurrentPlayer == 1 ? 0 : 1;

            return isUndo1 && isUndo2;
        }
        public bool UndoAStep()
        {
            if (PlayTimeLine.Count <= 0) return false;

            PlayInfo oldPoint = PlayTimeLine.Pop();
            Button btn = matrix[oldPoint.Point.Y][oldPoint.Point.X];

            btn.BackgroundImage = null;

            if (PlayTimeLine.Count <= 0)
            {
                currentPlayer = 0;
            }

            else
            {
                oldPoint = PlayTimeLine.Peek();
                
            }
            changePlayer();

            return true;
        }
        private bool isEndGame(Button btn)
        {
            return isEndGameHorizontal(btn) || isEndGamePrimaryDiagonal(btn) ||isEndGameVertical(btn) || isEndGameSubDiagonal(btn);
        }
        private Point GetChessPoint(Button btn)
        {
            
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal,vertical);

            return point;
        }
        private bool isEndGameHorizontal(Button btn)
        {
            Point point=GetChessPoint(btn);

            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else { break; }
            }

            int countRight = 0;
            for (int i = point.X+1; i < Cons.CHESS_BOARD_WIDTH; i++)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else { break; }
            }

            return countLeft+countRight==5;
        }
        private bool isEndGameVertical(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else { break; }
            }

            int countBottom = 0;
            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                if (matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else { break; }
            }

            return countTop + countBottom == 5;
        }
        private bool isEndGamePrimaryDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0) break;
                if (matrix[point.Y-i][point.X-i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else  break; 
            }

            int countBottom = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_HEIGHT || point.X + i >= Cons.CHESS_BOARD_WIDTH) break;
                if (matrix[point.Y+ i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else  break; 
            }

            return countTop + countBottom == 5;
        }
        private bool isEndGameSubDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >  Cons.CHESS_BOARD_WIDTH || point.Y - i < 0) break;
                if (matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else break;
            }

            int countBottom = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_HEIGHT || point.X - i <0) break;
                if (matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else break;
            }

            return countTop + countBottom == 5;
        }
        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[currentPlayer].Mark;
        }
        private void changePlayer()
        {
            playName.Text = Player[currentPlayer].Name;
            PlayMark.Image = Player[currentPlayer].Mark;
        }
        #endregion
    }
    public class ButtonClickEvent : EventArgs
    {
        private Point clickedPoint;
        public ButtonClickEvent(Point point)
        {
            this.clickedPoint = point;
        }

        public Point ClickedPoint { get => clickedPoint; set => clickedPoint = value; }
    }
}
