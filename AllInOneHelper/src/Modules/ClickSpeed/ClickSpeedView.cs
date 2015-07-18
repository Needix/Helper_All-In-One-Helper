using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AllInOneHelper.Modules.ClickSpeed {
    class ClickSpeedView : UserControl {
        //TODO Rewrite ClickSpeed from scratch
        private const int MAX_Y_DRAW = 50;

        private int _acc = 5;
        public int Acc { set { 
            Reset(null, null);
            _acc = value; 
        }}

        private int _lastClick = 0;

        private int _maxY = 0;
        private int _minX = int.MaxValue;

        private int _indexLastUp = -1;

        private int _bestSpeed = int.MaxValue;
        private int _worstSpeed = 0;

        private ClickSpeedPoint[] _points = new ClickSpeedPoint[1000];

        public ClickSpeedView() {
            this.Click += PanelClick;

            for(int i = 0; i < _points.Length; i++) {
                _points[i] = new ClickSpeedPoint(i, 0, _acc*i);
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
            double proPixelEinheit = ((double)_maxY) / (this.Height - 25);
            DrawLines(g, proPixelEinheit);

            //Text
            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 10);
            g.DrawString("Maximum (" + (_maxY) + ")", font, brush, 5, 13);
            g.DrawString((_maxY * 0.75) + "", font, brush, 5, (int)(this.Height * 0.25));
            g.DrawString((_maxY * 0.5) + "", font, brush, 5, (int)(this.Height * 0.5));
            g.DrawString((_maxY * 0.25) + "", font, brush, 5, (int)(this.Height * 0.75));
        }

        private void DrawLines(Graphics g, double proPixelEinheit) {
            Brush brush = new SolidBrush(Color.FromArgb(0, 204, 0));
            Pen pen = new Pen(brush);
            Font font = new Font("Arial", 10);

            int lastX = 70;
            const int xDiff = 50;
            for(int i = 0; i < _points.Length; i++) {
                if (i < _minX) continue; //Skip first unused values

                ClickSpeedPoint curPoint = _points[i];
                if (curPoint == null || curPoint.Y <= 0) continue; //Skips points that are outside range

                int y = (int)((_maxY - curPoint.Y) / proPixelEinheit);

                if(y > this.Height - MAX_Y_DRAW) y = this.Height - MAX_Y_DRAW;
                if(y < 0) y = 0;

                brush = _indexLastUp == i ? new SolidBrush(Color.Red) : new SolidBrush(Color.Green);
                g.DrawLine(pen, lastX, y, lastX, this.Height - MAX_Y_DRAW); //DrawLine

                //Draw "(x) to (x+acc)" string
                int height = i % 2 == 0 ? this.Height - 25 : this.Height - 40; //Heightdiff (i%2==0 -> down; i%2==1 -> up)
                g.DrawString((i * _acc) + "-" + ((i + 1) * _acc), font, brush, lastX-(xDiff/2), height);

                lastX += xDiff;
                if(lastX > this.Width) return;
            }
        }

        private void DrawAxis(Graphics g) {
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);

            g.DrawLine(pen, 45, 40, 45, this.Height - 2); //Y
            g.DrawLine(pen, 2, this.Height - MAX_Y_DRAW, this.Width - 2, this.Height - MAX_Y_DRAW); //X
        }

        private void CalculateMaximumAndMinimum() {
            int curMax = -1;
            int curMinIndex = -1;
            for(int i = 0; i < _points.Length; i++) {
                ClickSpeedPoint curPoint = _points[i];
                int cur = curPoint.Y;
                curMax = cur > curMax ? cur : curMax;
                if(cur > 0 && curMinIndex == -1) { curMinIndex = i; } //Set minX to index of first element!=0
            }
            _maxY = curMax;
            _minX = curMinIndex;
        }
        #endregion

        /////////////////////////////////////////////////Panel Events
        private void PanelClick(object sender, EventArgs e) {
            int curDiff = Environment.TickCount - _lastClick;

            if(_lastClick == 0) {
                _lastClick = Environment.TickCount;
                return;
            }
            _lastClick = Environment.TickCount;

            _bestSpeed = curDiff < _bestSpeed ? curDiff : _bestSpeed;
            _worstSpeed = curDiff > _worstSpeed ? curDiff : _worstSpeed;

            int speedLow = (int)Math.Floor(curDiff / (double)_acc);
            _indexLastUp = speedLow;
            if(_indexLastUp < _points.Length) {
                //System.Diagnostics.Debug.WriteLine("Registered Click to "+speedLow+". Diff: "+curDiff+". CurrentValue: "+points[indexLastUp].Y);
                Debug.WriteLine("Registered Click to " + speedLow + ". Diff: " + curDiff + ".");
                _points[_indexLastUp].Y++; 
            }

            Invalidate();
        }

        /////////////////////////////////////////////////General
        public void Reset(object sender, EventArgs e) {
            _acc = 5;
            _indexLastUp = 0;
            _lastClick = 0;
            _worstSpeed = 0;
            _maxY = 0;
            _bestSpeed = int.MaxValue;
            _points = new ClickSpeedPoint[100];
        }
    }
}
