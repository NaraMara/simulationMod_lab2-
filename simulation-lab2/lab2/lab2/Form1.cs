using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        const double dt = 0.1;
        const double g = 9.81;
        double v0, angle, y0,cosa,sina;

        private void btnCont_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             
            t += dt;
            x = v0 * cosa * t;
            y = y0 + v0 * sina * t - g * t * t / 2;
            chart1.Series[0].Points.AddXY(x, y);
            labelTimeVal.Text = ""+t;
            if (y < 0) timer1.Stop();
             
        }

       
        double v, x,y,t;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            v=v0 = (double)numericSpeed.Value;
            y=y0 = (double)numericHeight.Value;
            angle = (double)numericAngle.Value*Math.PI/180;
            cosa = Math.Cos(angle);
            sina = Math.Sin(angle);
            t = 0;
            x = 0;
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(x, y);

            double maxWidth = v0 * v0 * Math.Sin(angle * 2) / g;
            double maxHeight = v0 * v0 * Math.Sin(angle ) * Math.Sin(angle) /(2* g);

            chart1.ChartAreas[0].AxisX.Maximum = Math.Round( maxWidth+1);        
            chart1.ChartAreas[0].AxisY.Maximum = Math.Round(maxHeight +1);
            
            timer1.Start();
            btnStop.Enabled = true;
            btnCont.Enabled = true;

        }
    }
}
