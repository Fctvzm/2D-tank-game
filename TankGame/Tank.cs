using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankGame
{
    public enum Directions { Left, Right, Up, Down };
    public class Tank
    {
        public int health = 100;
        public int speed = 20;
        public int score = 0;
        public bool gameOver = false;
        public PictureBox tank_pic;
        public Directions direction = Directions.Up;
        Form form;
        Image left, right, up, down;
        

        public Tank(Form form, Image left, Image right, Image down, Image up, Point loc, String tag)
        {
            this.left = left;
            this.right = right;
            this.down = down;
            this.up = up;
            this.form = form;
            tank_pic = new PictureBox();
            tank_pic.Tag = tag;
            tank_pic.Image = this.up;
            tank_pic.Size = new Size(45, 70);
            tank_pic.SizeMode = PictureBoxSizeMode.StretchImage;
            tank_pic.Location = loc;
            tank_pic.BackColor = Color.Transparent;
            tank_pic.BringToFront();
            form.Controls.Add(tank_pic);
        }

        public void move(Directions dir)
        {
            if (gameOver) return;

            switch (dir)
            {
                case Directions.Left:
                    if (direction != Directions.Left)
                        tank_pic.Image = left;
                    if (tank_pic.Left > 32) {
                        tank_pic.Size = new Size(70, 45);
                        tank_pic.Left -= speed;
                    }
                    break;
                case Directions.Right:
                    if (direction != Directions.Right)
                        tank_pic.Image = right;
                    if (tank_pic.Left + tank_pic.Width < 868) {
                        tank_pic.Size = new Size(70, 45);
                        tank_pic.Left += speed;
                    }
                    break;
                case Directions.Up:
                    if (direction != Directions.Up)
                        tank_pic.Image = up;
                    if (tank_pic.Top > 32) {
                        tank_pic.Size = new Size(45, 70);
                        tank_pic.Top -= speed;
                    }
                    break;
                case Directions.Down:
                    if (direction != Directions.Down)
                        tank_pic.Image = down;
                    if (tank_pic.Top + tank_pic.Height < 756) {
                        tank_pic.Size = new Size(45, 70);
                        tank_pic.Top += speed;
                    }
                    break;
            }
            direction = dir;
        }

        public void shoot(Directions dir)
        {
            Bullet b = new Bullet();
            b.direction = dir;
            b.bulletX = tank_pic.Left + (tank_pic.Width / 2);
            b.bulletY = tank_pic.Top + (tank_pic.Height / 2);
            b.makeBullet(form);
        }

    }


}
