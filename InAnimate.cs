using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2
{
    [Serializable]
    class InAnimate:GameObject
    {
        bool wasEaten;
        public  InAnimate()
        {
            this.a = null;
        }
        public void changeColor(System.Drawing.Color color)
        {
            this.a.BackColor = color;
        }
        public void setBox(System.Windows.Forms.PictureBox Box)
        {
            a = Box;
        }
        public void vanish()
        {
            this.a.Visible=false;
            this.wasEaten = true;
        }
        public bool visable()
        {
            if (this.Box.Visible)
                return true;
            else return false;
        }
        static public InAnimate operator++ (InAnimate other)
        {
            other.Box.Top+=5;
            return other;

        }
        static public InAnimate operator--(InAnimate other)
        {
            other.Box.Top-=5;
            return other;
        }
        
    }
}
