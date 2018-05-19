using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankGame
{
    public partial class Form1 : Form
    {
        public Tank tank, enemy;
        public Form1()
        {
            InitializeComponent();
            tank = new Tank(this, Properties.Resources.left,
                Properties.Resources.right, Properties.Resources.down,
                Properties.Resources.up, new Point(100, 100), "tank");
            enemy = new Tank(this, Properties.Resources.eleft,
                Properties.Resources.eright, Properties.Resources.edown,
                Properties.Resources.eup, new Point(200, 200), "enemy");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.Left:
                    tank.move(Directions.Left);
                    break;
                case Keys.Right:
                    tank.move(Directions.Right);
                    break;
                case Keys.Up:
                    tank.move(Directions.Up);
                    break;
                case Keys.Down:
                    tank.move(Directions.Down);
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                tank.shoot(tank.direction);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tank.health > 1)
            {
                progressBar1.Value = Convert.ToInt32(tank.health);
            } else
            {
                tank.gameOver = true;
            }
            foreach (Control x in Controls)
            {
                if (x is PictureBox && x.Tag.Equals("bullet"))
                {
                    if (((PictureBox)x).Left < 100 || ((PictureBox)x).Left > 700 ||
                        ((PictureBox)x).Top < 100 || ((PictureBox)x).Top > 700)
                    {
                        Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                    }

                    if ((((PictureBox)x).Left > enemy.tank_pic.Left && ((PictureBox)x).Left < (enemy.tank_pic.Width + enemy.tank_pic.Left)) &&
                        (((PictureBox)x).Top > enemy.tank_pic.Top && ((PictureBox)x).Top < (enemy.tank_pic.Height + enemy.tank_pic.Top)))
                    {
                        Controls.Remove(enemy.tank_pic);
                        enemy.tank_pic.Dispose();
                        Controls.Remove(x);
                        x.Dispose();
                    }
                }

                if (x is PictureBox && x.Tag.Equals("enemy"))
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(tank.tank_pic.Bounds)) {
                        tank.health -= 1;
                    }

                    if (((PictureBox)x).Left > tank.tank_pic.Left)
                    {
                        enemy.move(Directions.Left);
                        continue;
                    }

                    if (((PictureBox)x).Top > tank.tank_pic.Top)
                    {
                        enemy.move(Directions.Up);
                        continue;
                    }

                    if (((PictureBox)x).Left < tank.tank_pic.Left)
                    {
                        enemy.move(Directions.Right);
                        continue;
                    }

                    if (((PictureBox)x).Top < tank.tank_pic.Top)
                    {
                        enemy.move(Directions.Down);
                        continue;
                    }
                }

            }
        }
    }
}
