using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameCaro
{
    public class Player
    {
        private string name; //Ctrl+R+E -> auto create property

        public string Name { get => name; set => name = value; }
        public Image Mark { get => mark; set => mark = value; }

        private Image mark;
        public Player(string name,Image mark) {
            this.Name= name;
            this.Mark = mark;   
        }
    }
}
