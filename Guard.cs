using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2
{
    [Serializable]
    class Guard : Alive
    {
        int xSrc;
        int ySrc;
        int xDes;
        int yDes;
        int direction;
        public Guard(System.Windows.Forms.PictureBox b)
        {
            this.a = b;
            xSrc = 0;
            ySrc = 0;
            xDes = 0;
            yDes = 0;
        }
        public Guard(int xSource, int ySource, int xDestination, int yDestination, System.Windows.Forms.PictureBox b)
        {
            this.a = b;
            xSrc = 0;
            ySrc = 0;
            xDes = 0;
            yDes = 0;
            if (xSource > 0)
                xSrc = xSource;
            if (ySource > 0)
                ySrc = ySource;
            if (xDestination > 0)
                xDes = xDestination;
            if (yDestination > 0)
                yDes = yDestination;
        }

        public Guard()
        {
            xSrc = 0;
            ySrc = 0;
            xDes = 0;
            yDes = 0;
            a = new System.Windows.Forms.PictureBox();
        }

        public void setPatrol(int xSource, int ySource, int xDestination, int yDestination,int direct)//destination and source
        {
            if (xSource > 0)
                xSrc = xSource;
            if (ySource > 0)
                ySrc = ySource;
            if (xDestination > 0)
                xDes = xDestination;
            if (yDestination > 0)
                yDes = yDestination;
            if (direct > 0)
                direction = 1;
            else direction = -1;
        }
        public int XSrc
        {
            get
            {
                return xSrc;
            }
            set
            {
                if (value > 0)
                    xSrc = value;
            }
        }
        public int YSrc
        {
            get
            {
                return ySrc;
            }
            set
            {
                if (value > 0)
                    ySrc = value;
            }
        }
        public int XDes
        {
            get
            {
                return xDes;
            }
            set
            {
                if (value > 0)
                    xDes = value;
            }
        }
        public int YDes
        {
            get
            {
                return yDes;
            }
            set
            {
                if (value > 0)
                    yDes = value;
            }
        }
        
        public int Direction
        {
            set
            {
                if (value < 0)
                    this.direction = -1;
                else this.direction = 1;
            }
            get
            {
                return this.direction;
            }
        }
    }
}
