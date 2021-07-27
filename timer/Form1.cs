using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer
{
    public partial class Form1 : Form
    {
        const string message = "JUMP JUMP JUMP!!! CHEER UP";
        int indexCharacter;
        int length = message.Length;

        bool timerStop;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(indexCharacter > (length -1))
            {
                indexCharacter = 0;
                label1.Text = string.Empty;
            }
            else
            {
                label1.Text += message[indexCharacter];
                indexCharacter++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            indexCharacter = 0;
            label1.Text = string.Empty;
            timer1.Start();
            button1.Text = "Pause";
            timerStop = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timerStop)
            {
                timer1.Start();
                timerStop = false;
            }
            else
            {
                timer1.Stop();
                timerStop = true;
            }
        }
    }
}
