using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankGame
{
    public class Bullet
    {
        int speed = 20;
        public Directions direction;
        public PictureBox bullet_pic = new PictureBox();
        Timer bullet_timer = new Timer();
        public int bulletX;
        public int bulletY;

        public void makeBullet(Form form)
        {
            bullet_pic.BackColor = Color.Black;
            bullet_pic.Size = new Size(5, 5);
            bullet_pic.Left = bulletX;
            bullet_pic.Top = bulletY;
            bullet_pic.Tag = "bullet";
            bullet_pic.BringToFront();
            form.Controls.Add(bullet_pic);

            bullet_timer.Interval = speed;
            bullet_timer.Tick += new EventHandler(timer_Tick);
            bullet_timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            switch (direction)
            {
                case Directions.Left:
                    bullet_pic.Left -= speed;
                    break;
                case Directions.Right:
                    bullet_pic.Left += speed;
                    break;
                case Directions.Up:
                    bullet_pic.Top -= speed;
                    break;
                case Directions.Down:
                    bullet_pic.Top += speed;
                    break;
            }

            if (bullet_pic.Left < 32 || bullet_pic.Left > 868 || bullet_pic.Top < 32 || bullet_pic.Top > 756)
            {
                bullet_timer.Stop();
                bullet_timer.Dispose();
                bullet_pic.Dispose();
                bullet_timer = null;
                bullet_pic = null;
            }

        }

    }

    
}
