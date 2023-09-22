namespace GameCaro
{
    partial class CaroLAN
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelChessBoard = new Panel();
            panel3 = new Panel();
            pictureBoxAvatar = new PictureBox();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            pictureBoxMark = new PictureBox();
            label1 = new Label();
            progBarCooldown = new ProgressBar();
            buttonLAN = new Button();
            txtBoxIP = new TextBox();
            txBoxPlayerName = new TextBox();
            timerCoolDown = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMark).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelChessBoard
            // 
            panelChessBoard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelChessBoard.BackColor = SystemColors.Control;
            panelChessBoard.Location = new Point(8, 26);
            panelChessBoard.Margin = new Padding(3, 2, 3, 2);
            panelChessBoard.Name = "panelChessBoard";
            panelChessBoard.Size = new Size(502, 452);
            panelChessBoard.TabIndex = 0;
            panelChessBoard.Paint += panelChessBoard_Paint;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Controls.Add(pictureBoxAvatar);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(516, 26);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(330, 293);
            panel3.TabIndex = 1;
            // 
            // pictureBoxAvatar
            // 
            pictureBoxAvatar.BackColor = SystemColors.ActiveCaption;
            pictureBoxAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxAvatar.Image = Properties.Resources.caro1;
            pictureBoxAvatar.Location = new Point(0, 0);
            pictureBoxAvatar.Margin = new Padding(3, 2, 3, 2);
            pictureBoxAvatar.Name = "pictureBoxAvatar";
            pictureBoxAvatar.Size = new Size(330, 289);
            pictureBoxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAvatar.TabIndex = 0;
            pictureBoxAvatar.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(4, 322);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(165, 73);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.Controls.Add(pictureBoxMark);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(progBarCooldown);
            panel4.Controls.Add(buttonLAN);
            panel4.Controls.Add(txtBoxIP);
            panel4.Controls.Add(txBoxPlayerName);
            panel4.Location = new Point(516, 321);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(330, 157);
            panel4.TabIndex = 2;
            // 
            // pictureBoxMark
            // 
            pictureBoxMark.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxMark.BackColor = SystemColors.Control;
            pictureBoxMark.Location = new Point(156, 2);
            pictureBoxMark.Margin = new Padding(3, 2, 3, 2);
            pictureBoxMark.Name = "pictureBoxMark";
            pictureBoxMark.Size = new Size(174, 98);
            pictureBoxMark.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMark.TabIndex = 2;
            pictureBoxMark.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(60, 115);
            label1.Name = "label1";
            label1.Size = new Size(185, 26);
            label1.TabIndex = 5;
            label1.Text = "5 in a line to win";
            // 
            // progBarCooldown
            // 
            progBarCooldown.Location = new Point(3, 27);
            progBarCooldown.Margin = new Padding(3, 2, 3, 2);
            progBarCooldown.Name = "progBarCooldown";
            progBarCooldown.Size = new Size(146, 22);
            progBarCooldown.TabIndex = 4;
            // 
            // buttonLAN
            // 
            buttonLAN.Location = new Point(3, 78);
            buttonLAN.Margin = new Padding(3, 2, 3, 2);
            buttonLAN.Name = "buttonLAN";
            buttonLAN.Size = new Size(148, 22);
            buttonLAN.TabIndex = 3;
            buttonLAN.Text = "LAN";
            buttonLAN.UseVisualStyleBackColor = true;
            buttonLAN.Click += buttonLAN_Click;
            // 
            // txtBoxIP
            // 
            txtBoxIP.Location = new Point(4, 53);
            txtBoxIP.Margin = new Padding(3, 2, 3, 2);
            txtBoxIP.Name = "txtBoxIP";
            txtBoxIP.Size = new Size(148, 23);
            txtBoxIP.TabIndex = 2;
            txtBoxIP.Text = "127.0.0.1";
            // 
            // txBoxPlayerName
            // 
            txBoxPlayerName.Location = new Point(3, 2);
            txBoxPlayerName.Margin = new Padding(3, 2, 3, 2);
            txBoxPlayerName.Name = "txBoxPlayerName";
            txBoxPlayerName.Size = new Size(148, 23);
            txBoxPlayerName.TabIndex = 0;
            // 
            // timerCoolDown
            // 
            timerCoolDown.Tick += timer1_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(848, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, undoToolStripMenuItem, quitToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newGameToolStripMenuItem.Size = new Size(174, 22);
            newGameToolStripMenuItem.Text = "New game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(174, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            quitToolStripMenuItem.Size = new Size(174, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // CaroLAN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 490);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panelChessBoard);
            Controls.Add(menuStrip1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CaroLAN";
            Text = "Gomoku";
            FormClosing += CaroLAN_FormClosing;
            Load += CaroLAN_Load;
            Shown += CaroLAN_Shown;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMark).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelChessBoard;
        private Panel panel3;
        private PictureBox pictureBoxAvatar;
        private Panel panel4;
        private TextBox txBoxPlayerName;
        private Label label1;
        private ProgressBar progBarCooldown;
        private Button buttonLAN;
        private TextBox txtBoxIP;
        private PictureBox pictureBox1;
        private PictureBox pictureBoxMark;
        private System.Windows.Forms.Timer timerCoolDown;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
    }
}