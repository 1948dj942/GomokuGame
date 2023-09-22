using System.Net.NetworkInformation;

namespace GameCaro
{
    public partial class CaroLAN : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;

        SocketManager socket;
        #endregion
        public CaroLAN()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            ChessBoard = new ChessBoardManager(panelChessBoard, txBoxPlayerName, pictureBoxMark);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMaked += ChessBoard_PlayerMaked;

            progBarCooldown.Step = Cons.COOL_DOWN_STEP;
            progBarCooldown.Maximum = Cons.COOL_DOWN_TIME;
            progBarCooldown.Value = 0;

            timerCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;

            socket = new SocketManager();

            NewGame();

        }
        #region Methods
        void EndGame()
        {
            timerCoolDown.Stop();
            panelChessBoard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            //MessageBox.Show("Game over!");
        }
        void NewGame()
        {
            progBarCooldown.Value = 0;
            timerCoolDown.Stop();
            undoToolStripMenuItem.Enabled = true;
            ChessBoard.DrawChessBoard();
        }
        void Quit() { Application.Exit(); }
        void Undo() { ChessBoard.Undo();
            progBarCooldown.Value = 0;
        }
        private void ChessBoard_PlayerMaked(object sender, ButtonClickEvent e)
        {
            timerCoolDown.Start();
            panelChessBoard.Enabled = false;
            progBarCooldown.Value = 0;

            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, e.ClickedPoint,""));

            undoToolStripMenuItem.Enabled=false;

            Listen();
        }

        void ChessBoard_EndedGame(object sender, EventArgs e) 
        { 
            EndGame();

            socket.Send(new SocketData((int)SocketCommand.END_GAME, new Point(), ""));
        }

        private void CaroLAN_Load(object sender, EventArgs e) { }

        private void panelChessBoard_Paint(object sender, PaintEventArgs e) { }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progBarCooldown.PerformStep();

            if (progBarCooldown.Value >= progBarCooldown.Maximum)
            {
                EndGame();

                socket.Send(new SocketData((int)SocketCommand.TIME_OUT, new Point(), ""));
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e) { NewGame();
            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, new Point(), ""));
            panelChessBoard.Enabled = true;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) { Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) { Quit();
        }

        private void CaroLAN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to end the game?", "Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, new Point(), ""));
                }
                catch { }
            }
        }

        private void buttonLAN_Click(object sender, EventArgs e)
        {
            socket.IP = txtBoxIP.Text;

            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                panelChessBoard.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                panelChessBoard.Enabled = false;
                Listen();
            }
        }

        private void CaroLAN_Shown(object sender, EventArgs e)
        {
            txtBoxIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(txtBoxIP.Text))
            {
                txtBoxIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    var data = (SocketData)socket.Receive();
                    ProcessData(data);
                }
                catch(Exception ex)
                { 

                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }
        private void ProcessData(SocketData data)
        {
            switch (data.Command) 
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;

                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        panelChessBoard.Enabled=false;
                    }));
                    break;

                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        progBarCooldown.Value = 0;
                        panelChessBoard.Enabled = true;
                        timerCoolDown.Start();
                        ChessBoard.OtherPlayerMark(data.Point);
                        undoToolStripMenuItem.Enabled = true;
                    }));
                    break;

                case (int)SocketCommand.UNDO:
                    Undo();
                    progBarCooldown.Value = 0;
                    break;

                case (int)SocketCommand.END_GAME:
                    MessageBox.Show("Game over!");
                    break;

                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show("Time out!");
                    break;
                case (int)SocketCommand.QUIT:
                    timerCoolDown.Stop();
                    MessageBox.Show("Other player quits!");
                    break;

                default: 
                    break;
            }
            Listen();
        }
        #endregion
    }
}