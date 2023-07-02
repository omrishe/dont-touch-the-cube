using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace ProjectV2
{
    [Serializable]
    class Player : Alive
    {
        private int health;
        private int coins;
        private const int xStartPos = 226;
        private const int yStartPos = 536;


        public Player(ref System.Windows.Forms.PictureBox b, int health, int coins)
        {
            this.health = health;
            this.coins = coins;
            this.a = b;
        }
        public Player()
        {
            health = 0;
            coins = 0;
            a = new System.Windows.Forms.PictureBox();
        }
        public Player(System.Windows.Forms.PictureBox b)
        {
            a = b;
        }
        
        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value < 4 && value > 0)
                    this.health = value;
                else this.health = 0;
            }
        }
        public void Reset()
        {
            this.xPos = xStartPos;
            this.yPos = yStartPos;
        }
        public void copy(Player other)//copies x and y location of other player
        {
            this.Box.Top = other.Box.Top;
            this.Box.Left = other.Box.Left;
        }
        public void copy(System.Windows.Forms.PictureBox picture)//copies x and y of picture
        {
            this.Box.Top = picture.Top;
            this.Box.Left = picture.Left;
        }
    }
}
