using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task5_10
{
    
    public partial class Form1 : Form
    {

        private static BufferedGraphicsContext currentContext;
        private static BufferedGraphics myBuffer;
        private static Function gb;
        private static Graphics g;
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            g = myBuffer.Graphics;
            gb = new Function();
            gb.Rotate(Math.PI/-12,2);
            gb.Rotate(Math.PI / -3, 0);
        }

        public void Draw(char c)
        {
            g.Clear(Color.Gray);
            switch (c) 
            {
                case 'w': gb.Rotate(Math.PI/64, 0); break;
                case 's': gb.Rotate(-Math.PI/64, 0); break;
                case 'd': gb.Rotate(Math.PI / 64, 1); break;
                case 'a': gb.Rotate(-Math.PI / 64, 1); break;
                case 'q': gb.Rotate(Math.PI / 64, 2); break;
                case 'e': gb.Rotate(-Math.PI / 64, 2); break;
            };
            gb.Draw(g);
            myBuffer.Render(this.CreateGraphics());
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Draw(e.KeyChar);
        }
    }
}
