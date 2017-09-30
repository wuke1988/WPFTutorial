using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics graphics = e.Graphics;

            Pen pen = new Pen(Color.Blue,2);

            graphics.DrawLine(pen,10,10,110,110);
            graphics.DrawEllipse(pen,10,10,100,100);
            graphics.DrawRectangle(pen,10,10,100,100);
        }
    }
}
