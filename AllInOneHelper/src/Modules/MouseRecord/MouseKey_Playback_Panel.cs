using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.MouseRecord {
    class MouseKey_Playback_Panel : UserControl {
        private MouseKeyRecord_Panel _mouseRecordPanel;

        public MouseKey_Recorder MouseKeyRecorder { get; private set; }
        public MouseKey_Model Model { get; set; }

        private readonly Thread _playbackThread;
        private Boolean _playbackThreadAbort;
        private volatile Boolean _playbackThreadActive;

        public MouseKey_Playback_Panel() {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            Model = new MouseKey_Model();

            MouseKeyRecorder = new MouseKey_Recorder(Model, this);

            RedrawThread redrawThread = new RedrawThread(this, 100);
            redrawThread.Start();

            _playbackThread = new Thread(Run);
            _playbackThread.Name = "MouseRec_Playback_Thread";
            _playbackThread.Start();
        }

        private void Run() {
            while(!_playbackThreadAbort) {
                try { Thread.Sleep(MouseKey_Recorder.SMOOTHNESS); } catch(ThreadInterruptedException) { return; }
                if (!_playbackThreadActive) continue;

                //Update Key data
                object[] objects = MouseKeyRecorder.GetPressedKeys(Model.CurPlaybackTime);
                Model.PressedKeys = objects;

                //Update Mouse data
                List<CustomPoint> pointList = MouseKeyRecorder.PointList;
                Model.MaxPlaybackTime = pointList.Count;
                Model.CurPlaybackTime = Model.CurPlaybackTime;

                //Updat view
                _mouseRecordPanel.UpdateView();

                //Increase playbacktime / stop if playback reaches end
                Model.CurPlaybackTime++;
                if(Model.CurPlaybackTime >= pointList.Count) { //Stop if playback reaches the end
                    _mouseRecordPanel.Invoke((MethodInvoker)delegate { 
                        _mouseRecordPanel.StopPlayback();
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

            if(Model.ShowAllFrames) {
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

                if(Model.CurPlaybackTime >= pointList.Count) return;

                CustomPoint curPoint = pointList[Model.CurPlaybackTime];
                CustomPoint lastPoint = curPoint;
                if(Model.CurPlaybackTime != 0) lastPoint = pointList[Model.CurPlaybackTime - 1];

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
            if(MouseKeyRecorder.RecordSize <= Model.CurPlaybackTime) { Debug.WriteLine("Disallowed"); return; }
            
            _playbackThreadActive = true;

            Model.PlaybackStartEnabled = false;
            Model.PlaybackStopEnabled = true;
            Model.ShowAllFrames = false;

            _mouseRecordPanel.UpdateView();
        }

        public void StopPlayback(object sender, EventArgs e) {
            _playbackThreadActive = false;
            
            Model.PlaybackStartEnabled = true;
            Model.PlaybackStopEnabled = false;
            Model.ShowAllFrames = true;

            _mouseRecordPanel.UpdateView();
        }

        public void ChangePlaybackTime(object sender, EventArgs e) {
            int value = ((TrackBar) sender).Value;
            Model.CurPlaybackTime = value;
            Model.CurPlaybackTime = value;

            _mouseRecordPanel.UpdateView();
        }

        public void ChangeShowAllFrames(object sender, EventArgs e) {
            Boolean isChecked = ((CheckBox) sender).Checked;
            Model.ShowAllFrames = isChecked;

            _mouseRecordPanel.UpdateView();
        }
        #endregion

        public void RegisterBasePanel(MouseKeyRecord_Panel basePanel) {
            this._mouseRecordPanel = basePanel;
            MouseKeyRecorder._basePanel = basePanel;
        }

        protected void InitializeComponent() {
            this.SuspendLayout();
            // 
            // MousePlayback
            // 
            this.Name = "MousePlayback";
            this.Size = new Size(353, 230);
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
