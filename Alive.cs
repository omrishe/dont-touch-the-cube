using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2
{
    [Serializable]
    class Alive:GameObject
    {
        public void Go(int dir,int speed) //moves the object with speed to a specific location
            //direction is like in the num keys in the side of keyboard
        {
            if(dir==2)//go down 
            {
                //this.yPos=this.yPosition-speed;
                a.Top += speed;
            }
            if(dir==4)//go left
            {
                // this.xPos = this.xPosition - speed;
                a.Left -= speed;
            }
            if(dir==6)//go right
            {
                //this.xPos = this.xPosition + speed;
                a.Left += speed;
            }
            if(dir==8) //go up
            {
                //this.yPos = this.yPosition + speed;
                a.Top -= speed;
            }
        }
        public void setBox(System.Windows.Forms.PictureBox b)
        {
            this.a = b;
        }
    }
}
