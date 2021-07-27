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
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            Thread myThread = new Thread(Tracker);
            myThread.IsBackground = true;
            myThread.Start();
            
        }


        private void Tracker()
        {
            try
            {
                while (!labelX.IsDisposed)
                {
                    int x = MousePosition.X;
                    int y = MousePosition.Y;

                    Invoke(new Action(() =>
                    {
                        labelX.Text = x.ToString();
                        labelY.Text = y.ToString();
                    }));
                }
            }
            catch (Exception e)
            {
                if(e is ObjectDisposedException)
                {

                }
            }
        }

        private void FormTest_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
