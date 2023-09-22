using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    [Serializable]
    public class SocketData
    {
        private int command;
        private Point point;
        private string? message;
        public SocketData(int command, Point point,string? message=null)
        {
            this.message = message;
            this.command = command; 
            this.point = point; 
        }

        public int Command { get => command; set => command = value; }
        public Point Point { get => point; set => point = value; }
        public string? Message { get => message; set => message = value; }
    }
    public enum SocketCommand
    {
        SEND_POINT,
        NOTIFY,
        NEW_GAME,
        UNDO,
        END_GAME,
        TIME_OUT,
        QUIT

    }
}


