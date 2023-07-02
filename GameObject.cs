using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2
{
    [Serializable]
    class GameObject:Serialization
    {
        protected string m_Name;
        public System.Windows.Forms.PictureBox a;
        public string String
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public int xPos
        {
            get
            {
                return a.Left;
            }
            set
            {
                a.Left = value;
            }
        }
        public int yPos
        {
            get
            {
                return a.Top;
            }
            set
            {
                a.Top = value;
            }
        }
        public System.Windows.Forms.PictureBox Box
        {
            get
            {
                return this.a;
            }
            set 
            { 
               ;
            }
            
        }
    }

    internal class boolean
    {
    }
}
