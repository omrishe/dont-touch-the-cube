using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectV2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        int playerSpeed = 6;
        int gameHigh = 600;
        int gameWidth = 800;
        int guardspeed = 6;
        int score = 0;
        static int jewelAmount;
        static Player player = new Player();
        static Player futurePlayer = new Player();
        static Guard guard1 = new Guard();
        static Guard guard2 = new Guard();
        static Guard guard3 = new Guard();
        static Guard guard4 = new Guard();
        static InAnimate jewel1=new InAnimate();
        static InAnimate jewel2 = new InAnimate();
        static InAnimate jewel3 = new InAnimate();
        static InAnimate jewel4 = new InAnimate();
        static InAnimate wall7 = new InAnimate();

        bool moveLeft, moveRight, moveUp, moveDown; //default value of boolean is false

        private void DownKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                moveUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
        }



        private void playerBox_Click(object sender, EventArgs e)
        {

        }
        public PictureBox playerBoxObject
        {
            get
            {
                return playerBox;
            }
            set
            {
                playerBox = value;
            }
        }
        void gameWon()
        {
            gameScore.Top = 200;
            gameScore.Left = 200;
            jewelsAmt.Text = "jewels: 4";
            gameScore.Font = new Font("ariel", 32);
            gameScore.Text = "You Win! :)";
            GameTimer2.Stop();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GameTimer2_Tick(object sender, EventArgs e)
        {
            if (score%180==90)
                wall7++;
            
            if(score%180 ==0)
                wall7--;
            jewelsAmt.Text = "jewels: " + Convert.ToString(jewelAmount);
            playerHp.Text = "Health: " +  Convert.ToString(player.Health);
            label1.Text = "yposition: " + Convert.ToString(player.yPos);
            label2.Text = "xposition: " + Convert.ToString(player.xPos);
            score++;
            gameScore.Text = "score: " + Convert.ToString(score);
            var guards = new List<Guard> { guard1, guard2, guard3, guard4 };
            var jewels = new List<InAnimate> { jewel1, jewel2, jewel3,jewel4};
            foreach(InAnimate jewel in jewels)
            {
                if (player.Box.Bounds.IntersectsWith(jewel.Box.Bounds)&& jewel.visable() == true)
                {
                    jewel.vanish();
                    jewelAmount= jewelAmount+1;
                }
            }
            if (jewelAmount == jewels.Count)
                gameWon();
            foreach (Guard guard in guards)
            {
                {
                    if (player.Box.Bounds.IntersectsWith(guard.Box.Bounds))
                    {
                        gameLose(player);
                    }
                    if(score%2==0   )//guards move too fast-this halves by 2 thier speed, changing guardspeed to double raises alot of casting that might cause issues
                    guard.Box.Left = guardspeed * guard.Direction + guard.Box.Left;
                    if(guard.XSrc>guard.Box.Left)
                    {
                        guard.Direction = 1;//makes the guard go the opposite direction
                    }
                    if(guard.XDes<guard.Box.Left)
                    {
                        guard.Direction = -1;
                    }

                    
                }
            }

            futurePlayer.copy(player);
            if (moveUp == true )
            {
                foreach (Control picBox in this.Controls)
                    if (picBox is PictureBox)
                    {
                        if (((string)picBox.Name).Contains("wall"))
                        {
                            futurePlayer.copy(player);//sets the starting location of future player
                            futurePlayer.Go(8, playerSpeed / 2);//future "player" to check if it intersects after doing the 1 move
                            if (futurePlayer.Box.Bounds.IntersectsWith(picBox.Bounds))
                            {
                                moveUp = false;//if 1 picbox intersects with future player do not let the player move
                            }
                        }
                    }
            }

            if (moveDown == true )
            {
                foreach (Control picBox in this.Controls)
                    if (picBox is PictureBox)
                    {
                        if (((string)picBox.Name).Contains("wall"))
                        {
                            futurePlayer.copy(player);//sets the starting location of future player
                            futurePlayer.Go(2, playerSpeed / 2);//future "player" to check if it intersects after doing the 1 move
                            if (futurePlayer.Box.Bounds.IntersectsWith(picBox.Bounds))
                            {
                                moveDown = false;
                            }

                        }
                        if (((string)picBox.Name).Contains("guard"))//meaning the picturebox is a guard variant
                        {
                            if (player.Box.Bounds.IntersectsWith(picBox.Bounds))
                            {
                                gameLose(player);
                            }
                        }



                    }

            }
            if (moveLeft == true)
            {
                foreach (Control picBox in this.Controls)
                    if (picBox is PictureBox)
                    {
                        if (((string)picBox.Name).Contains("guard"))//meaning the picturebox is a guard variant
                        {
                            if (player.Box.Bounds.IntersectsWith(picBox.Bounds))
                            {
                                gameLose(player);
                            }
                        }

                        if (((string)picBox.Name).Contains("wall"))//only objects that are above the player
                        {
                            futurePlayer.copy(player);//sets the starting location of future player
                            futurePlayer.Go(4, playerSpeed / 2);//future "player" to check if it intersects after doing the 1 move
                            if (futurePlayer.Box.Bounds.IntersectsWith(picBox.Bounds))
                            {
                                moveLeft = false;
                            }
                        }

                    }
            }
            if (moveRight == true )
            {
                foreach (Control picBox in this.Controls)
                    if (picBox is PictureBox)
                    {

                        if (((string)picBox.Name).Contains("guard"))//meaning the picturebox is a guard variant
                        {
                            if (player.Box.Bounds.IntersectsWith(picBox.Bounds))
                            {
                                gameLose(player);
                            }
                        }

                        if (((string)picBox.Name).Contains("wall"))//only objects that are above the player
                        {
                            futurePlayer.copy(player);//sets the starting location of future player
                            futurePlayer.Go(6, playerSpeed / 2);//future "player" to check if it intersects after doing the 1 move
                            if (futurePlayer.Box.Bounds.IntersectsWith(picBox.Bounds))
                            {
                                moveRight = false;
                            }

                        }
                    }
            }
            //playerHp.Text = Convert.ToString(player.Health);
            futurePlayer.copy(player);
            if (moveLeft == true && futurePlayer.xPos - playerSpeed >= 0)
            {
                player.Go(4, playerSpeed);
            }
            futurePlayer.copy(player);
            if (moveRight == true && futurePlayer.xPos < gameWidth - playerSpeed)
            {
                player.Go(6, playerSpeed);
            }
            futurePlayer.copy(player);
            if (moveUp == true && (futurePlayer.yPos - playerSpeed) >= 0)
            {
                player.Go(8, playerSpeed);
            }
            futurePlayer.copy(player);
            if (moveDown == true && futurePlayer.yPos < gameHigh - 20)
            {
                player.Go(2, playerSpeed);
            }
            if(score%1000==0)//change color
            {
                foreach(Guard guard in guards)
                {
                    guard.Box.BackColor =Color.Navy ;
                }
            }
            if(score%1000==500)
            {
                foreach (Guard guard in guards)
                {
                    guard.Box.BackColor = Color.DarkGreen;
                }
            }
            
        }

        private void playerHp_Click(object sender, EventArgs e)
        {

        }


        private void PreviewedKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (Keys.Up==e.KeyData)
                e.IsInputKey = true;
        }

        private void lblSave_Click(object sender, EventArgs e)
        {
            File.Delete("file");
                Serialization serial = new Serialization();
                serial.SerializePlayer(player, "file");
        }

        private void lblLoad_Click(object sender, EventArgs e)
        {
               Serialization serial = new Serialization();
               serial=serial.DeSerialize("file");//loads from file the location of box and other variables
               player.coins = serial.coins;
               player.health = serial.health;
               player.Box.Top = serial.BoxTop;
               player.Box.Left = serial.BoxLeft;
            Invalidate();
        }

        void UpKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }

        void gameLose(Player player)
        {
            if (player.Health > 1)
            {
                player.Reset();
                player.Health = player.Health - 1;
            }
            else 
            {
                gameScore.Top = 200;
                gameScore.Left = 200;
                gameScore.Font = new Font("ariel", 32);
            gameScore.Text = "Game Over :(";
            GameTimer2.Stop();
            }
        }


        void Form1_Load(object sender, EventArgs e)
        {
            player.setBox(playerBox);
            player.Health = 3;
            futurePlayer.setBox(FakePlayerBox);
            guard1.setBox(guardBox1);
            guard2.setBox(guardBox2);
            guard3.setBox(guardBox3);
            guard4.setBox(guardBox4);
            var patrolList = new List<Guard> { guard1, guard2, guard3, guard4 };
            foreach(Guard guard in patrolList)
            {
                guard.setPatrol(40, 40, Width-80, Width-80,-1);
            }
            futurePlayer.Box.Visible =false;
            jewel1.setBox(jewelBox1);
            jewel2.setBox(jewelBox2);
            jewel3.setBox(jewelBox3);
            jewel4.setBox(jewelBox4);
            wall7.setBox(wallBox7);
            jewelAmount = 0;

        }
    }
}

