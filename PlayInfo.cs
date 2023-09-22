using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class PlayInfo
    {
        private Point point;

        public Point Point { get => point; set => point = value; }
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

        private int currentPlayer;

        public PlayInfo(Point point, int currentPlayer)
        {
            this.point = point;
            this.currentPlayer = currentPlayer;
        }
    }
}
