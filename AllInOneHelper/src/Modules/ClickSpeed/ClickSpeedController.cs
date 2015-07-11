using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.ClickSpeed {
    class ClickSpeedController : UserControl {
        //TODO Rewrite ClickSpeed from scratch
        private const int MAX_Y_DRAW = 50;

        private int acc = 5;
        public int Acc { set { 
            Reset(null, null);
            acc = value; 
        }}

        private int lastClick = 0;

        private int maxY = 0;
        private int minX = int.MaxValue;

        private int indexLastUp = -1;

        private int bestSpeed = int.MaxValue;
        private int worstSpeed = 0;

        private ClickSpeedPoint[] points = new ClickSpeedPoint[1000];

        public ClickSpeedController() {
            this.Click += new EventHandler(PanelClick);

            for(int i = 0; i < points.Length; i++) {
                points[i] = new ClickSpeedPoint(i, 0, acc*i);
            }
        }

        #region Paint
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            //Background
            g.Clear(Color.White);

            //Calc Minimum && Maximum
            CalculateMaximumAndMinimum();

            //Axis
            DrawAxis(g);

            //Linien
            double proPixelEinheit = ((double)maxY) / (this.Height - 25);
            DrawLines(g, proPixelEinheit);

            //Text
            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 10);
            g.DrawString("Maximum (" + (maxY) + ")", font, brush, 5, 13);
            g.DrawString((maxY * 0.75) + "", font, brush, 5, (int)(this.Height * 0.25));
            g.DrawString((maxY * 0.5) + "", font, brush, 5, (int)(this.Height * 0.5));
            g.DrawString((maxY * 0.25) + "", font, brush, 5, (int)(this.Height * 0.75));
        }

        private void DrawLines(Graphics g, double proPixelEinheit) {
            Brush brush = new SolidBrush(Color.FromArgb(0, 204, 0));
            Pen pen = new Pen(brush);
            Font font = new Font("Arial", 10);

            int lastX = 70;
            int xDiff = 50;
            for(int i = 0; i < points.Length; i++) {
                if(i >= minX) {
                    ClickSpeedPoint curAP = points[i];
                    if(curAP != null && curAP.Y>0) {
                        int y = (int)((maxY - curAP.Y) / proPixelEinheit);

                        if(y > this.Height - MAX_Y_DRAW) y = this.Height - MAX_Y_DRAW;
                        if(y < 0) y = 0;

                        if(indexLastUp == i) {
                            brush = new SolidBrush(Color.Red);
                        } else {
                            brush = new SolidBrush(Color.Green);
                        }
                        g.DrawLine(pen, lastX, y, lastX, this.Height - MAX_Y_DRAW); //DrawLine

                        //Draw "(x) to (x+acc)" string
                        int height = i % 2 == 0 ? this.Height - 25 : this.Height - 40; //Höhenverschiebung (i%2==0 -> unten; i%2==1 -> oben)
                        g.DrawString((i * acc) + "-" + ((i + 1) * acc), font, brush, lastX-(xDiff/2), height);

                        lastX += xDiff;
                        if(lastX > this.Width) return;
                    }
                }
            }
        }

        private void DrawAxis(Graphics g) {
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            Font font = new Font("Arial", 10);

            g.DrawLine(pen, 45, 40, 45, this.Height - 2); //Y
            g.DrawLine(pen, 2, this.Height - MAX_Y_DRAW, this.Width - 2, this.Height - MAX_Y_DRAW); //X
        }

        private void CalculateMaximumAndMinimum() {
            int curMax = -1;
            int curMinIndex = -1;
            for(int i = 0; i < points.Length; i++) {
                ClickSpeedPoint curAP = points[i];
                int cur = curAP.Y;
                curMax = cur > curMax ? cur : curMax;
                if(cur > 0 && curMinIndex == -1) { curMinIndex = i; } //Set minX to index of first element!=0
            }
            maxY = curMax;
            minX = curMinIndex;
        }
        #endregion

        /////////////////////////////////////////////////Panel Events
        private void PanelClick(object sender, System.EventArgs e) {
            int curDiff = Environment.TickCount - lastClick;

            if(lastClick == 0) {
                lastClick = Environment.TickCount;
                return;
            }
            lastClick = Environment.TickCount;

            bestSpeed = curDiff < bestSpeed ? curDiff : bestSpeed;
            worstSpeed = curDiff > worstSpeed ? curDiff : worstSpeed;

            int speedLow = (int)Math.Floor(curDiff / (double)acc);
            indexLastUp = speedLow;
            if(indexLastUp < points.Length) {
                //System.Diagnostics.Debug.WriteLine("Registered Click to "+speedLow+". Diff: "+curDiff+". CurrentValue: "+points[indexLastUp].Y);
                System.Diagnostics.Debug.WriteLine("Registered Click to " + speedLow + ". Diff: " + curDiff + ".");
                points[indexLastUp].Y++; 
            }

            this.Invalidate();
        }

        /////////////////////////////////////////////////General
        public void Reset(object sender, System.EventArgs e) {
            acc = 5;
            indexLastUp = 0;
            lastClick = 0;
            worstSpeed = 0;
            maxY = 0;
            bestSpeed = int.MaxValue;
            points = new ClickSpeedPoint[100];
        }
    }
}
