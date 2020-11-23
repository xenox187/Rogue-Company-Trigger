using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoItX3Lib;

namespace RCTB
{
    public partial class Form1 : Form
    {
        //  ez ez = new ez();

        AutoItX3 au3 = new AutoItX3();

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        object pix;
        int newCol;
        int[] ScreenCoor = { Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 };
        int x, y;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            //   ez.SetInvi(this);
            //   ez.StartLoop(10, "Rogue Company  ", this);
            Thread tb = new Thread(Trigger) { IsBackground = true };
            tb.Start();
        }
        private void Trigger()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.F1) < 0)
                {
                    checkBox1.ForeColor = Color.Green;
                    checkBox1.Checked = true;
                }
                if (GetAsyncKeyState(Keys.F2) < 0)
                {
                    checkBox1.ForeColor = Color.Red;
                    checkBox1.Checked = false;
                }
                if (checkBox1.Checked)
                {


                    if (GetAsyncKeyState(Keys.RButton) < 0)
                    {
                        newCol = GrabColor();
                        textBox1.Text = newCol.ToString();
                        if (newCol > 16551953)
                        {
                            Thread.Sleep(1);
                            au3.MouseClick("LEFT");
                        }
                    }

                    if (GetAsyncKeyState(Keys.F10) < 0)
                    {
                        this.Close();
                    }

                }

                Thread.Sleep(1);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        int GrabColor()
        {
            pix = au3.PixelGetColor(ScreenCoor[0], ScreenCoor[1]);
            return Int32.Parse(pix.ToString());

        }
    }
}