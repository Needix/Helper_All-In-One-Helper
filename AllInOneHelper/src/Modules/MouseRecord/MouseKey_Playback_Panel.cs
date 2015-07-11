using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.MouseRecord {
    class MouseKey_Playback_Panel : BasePanel {
        private RedrawThread redrawThread;

        private MouseKeyRecord_Panel mouseRecord_Panel; public MouseKeyRecord_Panel MouseRecordPanel { set { mouseKey_Recorder.SetRecordPanel = value;  mouseRecord_Panel = value; } }
        private MouseKey_Recorder mouseKey_Recorder; public MouseKey_Recorder MouseKeyRecorder { get { return mouseKey_Recorder; } }

        private Thread playbackThread;
        private Boolean playbackThread_abort = false;
        private Boolean playbackThread_active = false;
        private Boolean showAllFrames = true;
        private int curPlaybackIndex = 0; public int CurPlaybackIndex { get { return curPlaybackIndex; } }

        public MouseKey_Playback_Panel() {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            mouseKey_Recorder = new MouseKey_Recorder(this);

            redrawThread = new RedrawThread(this);
            redrawThread.Start();

            playbackThread = new Thread(Run);
            playbackThread.Name = "MouseRec_Playback_Thread";
            playbackThread.Start();
        }

        private void Run() {
            while(!playbackThread_abort) {
                try { Thread.Sleep(MouseKey_Recorder.SMOOTHNESS); } catch(ThreadInterruptedException) { return; }

                if(playbackThread_active) {
                    //Update Key display
                    object[] objects = mouseKey_Recorder.GetPressedKeys(curPlaybackIndex);
                    mouseRecord_Panel.Invoke((MethodInvoker)delegate {
                        mouseRecord_Panel.listBox_mouseRecord_keyRecord.Items.Clear();
                        mouseRecord_Panel.listBox_mouseRecord_keyRecord.Items.AddRange((object[])objects);
                    });

                    //Update Mouse display
                    List<CustomPoint> pointList = mouseKey_Recorder.PointList;
                    mouseRecord_Panel.Invoke((MethodInvoker)delegate {
                        mouseRecord_Panel.slider_mouseRec_playback_progress.Maximum = pointList.Count;
                        mouseRecord_Panel.slider_mouseRec_playback_progress.Value = curPlaybackIndex;
                    });

                    //Increase playbacktime / stop if playback reaches end
                    curPlaybackIndex++;
                    if(curPlaybackIndex >= pointList.Count) { //Stop if playback reaches the end
                        mouseRecord_Panel.Invoke((MethodInvoker)delegate { 
                            mouseRecord_Panel.b_mouseRec_playback_stop.PerformClick(); 
                        }); 
                    }
                }
            }
        }

        protected override void RegisterEvents() {
            
        }

        #region Drawing
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if(mouseKey_Recorder == null) return;

            CustomPoint maxPoint = mouseKey_Recorder.MaxPoint;
            CustomPoint minPoint = mouseKey_Recorder.MinPoint;
            List<CustomPoint> pointList = mouseKey_Recorder.PointList;
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

            if(showAllFrames) {
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

                if(curPlaybackIndex >= pointList.Count) return;

                CustomPoint curPoint = pointList[curPlaybackIndex];
                CustomPoint lastPoint = curPoint;
                if(curPlaybackIndex != 0) lastPoint = pointList[curPlaybackIndex - 1];

                CustomPoint newCurPoint = TranslateCoordinates(curPoint, minX, minY, ratioX, ratioY);
                CustomPoint newLastPoint = TranslateCoordinates(lastPoint, minX, minY, ratioX, ratioY);

                Draw(g, defaultPen, newCurPoint, newLastPoint);
            }
        }

        private void Draw(Graphics g, Pen defaultPen, CustomPoint newPoint, CustomPoint oldPoint) {
            int tolerance = 5;
            int size = 10;
            if(tolerance < Math.Abs(newPoint.X - oldPoint.X) + Math.Abs(newPoint.Y - oldPoint.Y)) {
                g.DrawLine(defaultPen, new Point(newPoint.X, newPoint.Y), new Point(oldPoint.X, oldPoint.Y));
            } else {
                g.FillEllipse(defaultPen.Brush, newPoint.X-(size/2), newPoint.Y-(size/2), size, size);
            }
        }

        private CustomPoint TranslateCoordinates(CustomPoint point, int minX, int minY, double ratioX, double ratioY) {
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
        public void StartPlayback(object sender, System.EventArgs e) {
            if(mouseKey_Recorder.RecordSize <= CurPlaybackIndex) { System.Diagnostics.Debug.WriteLine("Disallowed"); return; }

            playbackThread_active = true;
            mouseRecord_Panel.b_mouseRec_playback_start.Enabled = false;
            mouseRecord_Panel.b_mouseRec_playback_stop.Enabled = true;
        }

        public void StopPlayback(object sender, System.EventArgs e) {
            playbackThread_active = false;
            mouseRecord_Panel.b_mouseRec_playback_start.Enabled = true;
            mouseRecord_Panel.b_mouseRec_playback_stop.Enabled = false;
        }

        public void ChangePlaybackTime(object sender, System.EventArgs e) {
            curPlaybackIndex = ((TrackBar)sender).Value;
        }

        public void ChangeShowAllFrames(object sender, System.EventArgs e) {
            showAllFrames = ((CheckBox)sender).Checked;
        }
        #endregion

        protected override void InitializeComponent() {
            this.SuspendLayout();
            // 
            // MousePlayback
            // 
            this.Name = "MousePlayback";
            this.Size = new System.Drawing.Size(353, 230);
            this.ResumeLayout(false);

        }

        public override void Close() {
            playbackThread_abort = true;
            playbackThread.Interrupt();
        }

        private Color CalculateNextColor(int index) {
            int total = mouseKey_Recorder.PointList.Count;
            double perc = index / (double)total;
            double colorChangePerPoint = 255 * 6 / (double)total;
            int value = (int)(index * colorChangePerPoint);

            int red = 255;
            int green = 0;
            int blue = 0;

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
