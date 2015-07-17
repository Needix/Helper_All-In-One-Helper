using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.MouseRecord {
    class MouseKey_Playback_Panel : UserControl {
        //HACK Panel changes others classes RecordPanel via set ?! /// MouseKey_Playback_Panel serves as "Uber controller" over MouseKey_Recorder (create "real" controller for both small-controller?)
        private MouseKeyRecord_Panel _mouseRecordPanel; public MouseKeyRecord_Panel MouseRecordPanel { set { MouseKeyRecorder.SetRecordPanel = value;  _mouseRecordPanel = value; } }

        public MouseKey_Recorder MouseKeyRecorder { get; private set; }

        private readonly Thread _playbackThread;
        private Boolean _playbackThreadAbort = false;
        private Boolean _playbackThreadActive = false;
        private Boolean _showAllFrames = true;
        public int CurPlaybackIndex { get; private set; }

        public MouseKey_Playback_Panel() {
            CurPlaybackIndex = 0;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            MouseKeyRecorder = new MouseKey_Recorder();

            RedrawThread redrawThread = new RedrawThread(this);
            redrawThread.Start();

            _playbackThread = new Thread(Run);
            _playbackThread.Name = "MouseRec_Playback_Thread";
            _playbackThread.Start();
        }

        private void Run() {
            while(!_playbackThreadAbort) {
                try { Thread.Sleep(MouseKey_Recorder.SMOOTHNESS); } catch(ThreadInterruptedException) { return; }
                if (!_playbackThreadActive) continue; 

                //Update Key display
                object[] objects = MouseKeyRecorder.GetPressedKeys(CurPlaybackIndex);
                _mouseRecordPanel.Invoke((MethodInvoker)delegate {
                    _mouseRecordPanel.listBox_mouseRecord_keyRecord.Items.Clear();
                    _mouseRecordPanel.listBox_mouseRecord_keyRecord.Items.AddRange(objects);
                });

                //Update Mouse display
                List<CustomPoint> pointList = MouseKeyRecorder.PointList;
                _mouseRecordPanel.Invoke((MethodInvoker)delegate {
                    _mouseRecordPanel.slider_mouseRec_playback_progress.Maximum = pointList.Count;
                    _mouseRecordPanel.slider_mouseRec_playback_progress.Value = CurPlaybackIndex;
                });

                //Increase playbacktime / stop if playback reaches end
                CurPlaybackIndex++;
                if(CurPlaybackIndex >= pointList.Count) { //Stop if playback reaches the end
                    _mouseRecordPanel.Invoke((MethodInvoker)delegate { 
                        _mouseRecordPanel.b_mouseRec_playback_stop.PerformClick(); 
                    }); 
                }
            }
        }

        #region Drawing
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if(MouseKeyRecorder == null) return;

            CustomPoint maxPoint = MouseKeyRecorder.MaxPoint;
            CustomPoint minPoint = MouseKeyRecorder.MinPoint;
            List<CustomPoint> pointList = MouseKeyRecorder.PointList;
            if(minPoint == null || maxPoint == null) return;

            int minX = minPoint.X;
            int minY = minPoint.Y;
            int maxX = maxPoint.X + 10;
            int maxY = maxPoint.Y + 10;

            //Transform min/max to min=(0/0) system (multi-monitor support)
            maxX -= minX;
            maxY -= minY;

            int lastX = -1;
            int lastY = -1;
            double ratioX = maxX / (double)this.Width;
            double ratioY = maxY / (double)this.Height;
            if(ratioX == 0) ratioX = 1;
            if(ratioY == 0) ratioY = 1;

            if(_showAllFrames) {
                for(int i = 0; i < pointList.Count; i++) {
                    Brush defaultBrush = new SolidBrush(CalculateNextColor(i));
                    Pen defaultPen = new Pen(defaultBrush);

                    CustomPoint newPoint = TranslateCoordinates(pointList[i], minX, minY, ratioX, ratioY);

                    //First iteration has no "last" point
                    if(lastX == -1) lastX = newPoint.X;
                    if(lastY == -1) lastY = newPoint.Y;

                    Draw(g, defaultPen, newPoint, new CustomPoint(lastX, lastY));

                    //Save this point for next iteration
                    lastX = newPoint.X;
                    lastY = newPoint.Y;
                }
            } else {
                Brush defaultBrush = new SolidBrush(Color.Black);
                Pen defaultPen = new Pen(defaultBrush);

                if(CurPlaybackIndex >= pointList.Count) return;

                CustomPoint curPoint = pointList[CurPlaybackIndex];
                CustomPoint lastPoint = curPoint;
                if(CurPlaybackIndex != 0) lastPoint = pointList[CurPlaybackIndex - 1];

                CustomPoint newCurPoint = TranslateCoordinates(curPoint, minX, minY, ratioX, ratioY);
                CustomPoint newLastPoint = TranslateCoordinates(lastPoint, minX, minY, ratioX, ratioY);

                Draw(g, defaultPen, newCurPoint, newLastPoint);
            }
        }

        private static void Draw(Graphics g, Pen defaultPen, CustomPoint newPoint, CustomPoint oldPoint) {
            const int tolerance = 5;
            const int size = 10;
            if(tolerance < Math.Abs(newPoint.X - oldPoint.X) + Math.Abs(newPoint.Y - oldPoint.Y)) {
                g.DrawLine(defaultPen, new Point(newPoint.X, newPoint.Y), new Point(oldPoint.X, oldPoint.Y));
            } else {
                g.FillEllipse(defaultPen.Brush, newPoint.X-(size/2), newPoint.Y-(size/2), size, size);
            }
        }

        private static CustomPoint TranslateCoordinates(CustomPoint point, int minX, int minY, double ratioX, double ratioY) {
            //Transform Point to 0/0 system
            int transformedX = point.X - minX;
            int transformedY = point.Y - minY;

            //Transform point from resolution (e.g. 1920x1080) into panel (e.g. 600x500) coordinates
            int relativeX = (int)(transformedX / ratioX);
            int relativeY = (int)(transformedY / ratioY);

            return new CustomPoint(relativeX, relativeY);
        }
        #endregion

        #region GUI-Playback
        public void StartPlayback(object sender, EventArgs e) {
            if(MouseKeyRecorder.RecordSize <= CurPlaybackIndex) { System.Diagnostics.Debug.WriteLine("Disallowed"); return; }

            _playbackThreadActive = true;
            _mouseRecordPanel.b_mouseRec_playback_start.Enabled = false;
            _mouseRecordPanel.b_mouseRec_playback_stop.Enabled = true;
        }

        public void StopPlayback(object sender, EventArgs e) {
            _playbackThreadActive = false;
            _mouseRecordPanel.b_mouseRec_playback_start.Enabled = true;
            _mouseRecordPanel.b_mouseRec_playback_stop.Enabled = false;
        }

        public void ChangePlaybackTime(object sender, EventArgs e) {
            CurPlaybackIndex = ((TrackBar)sender).Value;
        }

        public void ChangeShowAllFrames(object sender, EventArgs e) {
            _showAllFrames = ((CheckBox)sender).Checked;
        }
        #endregion

        protected void InitializeComponent() {
            this.SuspendLayout();
            // 
            // MousePlayback
            // 
            this.Name = "MousePlayback";
            this.Size = new System.Drawing.Size(353, 230);
            this.ResumeLayout(false);

        }

        public void Close() {
            _playbackThreadAbort = true;
            _playbackThread.Interrupt();
        }

        private Color CalculateNextColor(int index) {
            int total = MouseKeyRecorder.PointList.Count;
            double colorChangePerPoint = 255 * 6 / (double)total;
            int value = (int)(index * colorChangePerPoint);

            int red;
            int green;
            int blue;

            int rest = value % 255;
            int dev = value / 255;

            if(dev == 0) { //red,_green
                red = 255;
                green = rest;
                blue = 0;
            } else if(dev == 1) { //_red, green
                red = 255 - rest;
                green = 255;
                blue = 0;
            } else if(dev == 2) { //green, _blue
                red = 0;
                green = 255;
                blue = rest;
            } else if(dev == 3) { //_green, blue
                red = 0;
                green = 255 - rest;
                blue = 255;
            } else if(dev == 4) { //blue, _red
                red = rest;
                green = 0;
                blue = 255;
            } else if(dev == 5) { //blue, _red
                red = 255;
                green = 0;
                blue = 255 - rest;
            } else {
                throw new InvalidOperationException("Divide is " + dev + "! Has to be between 0(inclusive) and 5(inclusive).");
            }

            Color color = Color.FromArgb(red, green, blue);
            return color;
        }
    }
}
