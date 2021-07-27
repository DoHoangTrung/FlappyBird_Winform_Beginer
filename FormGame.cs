using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_bird
{
    public partial class FormGame : Form
    {
        const int width = 800;
        const int height = 790;
        int gravity = 20;
        int pipeSpeed = 8;
        int score = 0;

        public FormGame()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            labelScore.Text = score.ToString();

            if (pipeTop.Right < 0)
            {
                pipeTop.Left = this.Width;
            }

            if (pipeBottom.Right < 0)
            {
                pipeBottom.Left = this.Width;
            }

            //get scores
            if (flappyBird.Left > pipeBottom.Right )
            {
                score++;
            }

            if (flappyBird.Left > pipeTop.Right)
            {
                score++;
            }

            //when player loose
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                //stop the game
                gameTimer.Stop();

                //show message
                Label messageLable = new Label();

                messageLable.Text = $"Your score is: {score}";
                messageLable.Font = new Font("Arial", 24, FontStyle.Bold);

                //lable show at center of form
                messageLable.AutoSize = false;
                messageLable.TextAlign = ContentAlignment.MiddleCenter;
                messageLable.Dock = DockStyle.Fill;

                this.Controls.Add(messageLable);

            }
        }

        private void game_KeyUp(object sender, KeyEventArgs e)
        {
            //when key release, image go up
            gravity = 15;
        }

        private void game_KeyDown(object sender, KeyEventArgs e)
        {
            //when key pressed, image go down
            gravity = -15;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameTimer.Start();

            Thread counterThread = new Thread(getRightPositionPipeBox);
            counterThread.IsBackground = true;
            counterThread.Start();
        }

        void getRightPositionPipeBox()
        {
            try
            {
                while (true)
                {
                    Invoke(new Action(() =>
                    {
                        labelRight.Text = pipeTop.Right.ToString();
                    }));
                }
            }
            catch (Exception e)
            {
                if (e is ObjectDisposedException)
                {

                }
            }
        }
    }
}
