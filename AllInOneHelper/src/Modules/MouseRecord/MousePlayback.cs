using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.MouseRecord {
    class MousePlayback : UserControl {
        private RedrawThread redrawThread;

        private MouseRecordPanel mouseRecordPanel; public MouseRecordPanel MouseRecordPanel { set { mouseRecordPanel = value; } }
        private MouseRecord mouseRecord; public MouseRecord MouseRecord { set { this.mouseRecord = value; } }

        private Thread playbackThread;
        private Boolean playbackThread_abort = false;
        private Boolean playbackThread_active = false;
        private Boolean showAllFrames = true;
        private int curPlaybackIndex = 0;

        public MousePlayback() {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            redrawThread = new RedrawThread(this);
            redrawThread.start();

            playbackThread = new Thread(run);
            playbackThread.Name = "MouseRec_Playback_Thread";
            playbackThread.Start();
        }

        private void run() {
            while(!playbackThread_abort) {
                try { Thread.Sleep(MouseRecord.SMOOTHNESS); } catch(ThreadInterruptedException) { return; }

                if(playbackThread_active) {
                    List<CustomPoint> pointList = mouseRecord.PointList;
                    
                    //Update progress/slider
                    mouseRecordPanel.Invoke((MethodInvoker)delegate {
                        mouseRecordPanel.slider_mouseRec_playback_progress.Maximum = pointList.Count;
                        mouseRecordPanel.slider_mouseRec_playback_progress.Value = curPlaybackIndex;
                    });

                    curPlaybackIndex++;
                    if(curPlaybackIndex >= pointList.Count) { //Stop if playback reaches the end
                        mouseRecordPanel.Invoke((MethodInvoker)delegate { 
                            mouseRecordPanel.b_mouseRec_playback_stop.PerformClick(); 
                        }); 
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if(mouseRecord == null) return;

            CustomPoint maxPoint = mouseRecord.MaxPoint;
            CustomPoint minPoint = mouseRecord.MinPoint;
            List<CustomPoint> pointList = mouseRecord.PointList;

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
                    Brush defaultBrush = new SolidBrush(calculateNextColor(i));
                    Pen defaultPen = new Pen(defaultBrush);

                    CustomPoint newPoint = translateCoordinates(pointList[i], minX, minY, ratioX, ratioY);

                    //First iteration has no "last" point
                    if(lastX == -1) lastX = newPoint.X;
                    if(lastY == -1) lastY = newPoint.Y;

                    //g.DrawLine(defaultPen, new Point(newPoint.X, newPoint.Y), new Point(lastX, lastY));
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

                CustomPoint newCurPoint = translateCoordinates(curPoint, minX, minY, ratioX, ratioY);
                CustomPoint newLastPoint = translateCoordinates(lastPoint, minX, minY, ratioX, ratioY);

                Draw(g, defaultPen, newCurPoint, newLastPoint);
                //g.DrawLine(defaultPen, new Point(newCurPoint.X, newCurPoint.Y), new Point(newLastPoint.X, newLastPoint.Y));
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

        private CustomPoint translateCoordinates(CustomPoint point, int minX, int minY, double ratioX, double ratioY) {
            //Transform Point to 0/0 system
            int transformedX = point.X - minX;
            int transformedY = point.Y - minY;

            //Transform point from resolution (e.g. 1920x1080) into panel (e.g. 600x500) coordinates
            int relativeX = (int)(transformedX / ratioX);
            int relativeY = (int)(transformedY / ratioY);

            return new CustomPoint(relativeX, relativeY);
        }

        #region GUI-Playback
        public void startPlayback(object sender, System.EventArgs e) {
            playbackThread_active = true;
            mouseRecordPanel.b_mouseRec_playback_start.Enabled = false;
            mouseRecordPanel.b_mouseRec_playback_stop.Enabled = true;
        }

        public void stopPlayback(object sender, System.EventArgs e) {
            playbackThread_active = false;
            mouseRecordPanel.b_mouseRec_playback_start.Enabled = true;
            mouseRecordPanel.b_mouseRec_playback_stop.Enabled = false;
        }

        public void change_PlaybackTime(object sender, System.EventArgs e) {
            curPlaybackIndex = ((TrackBar)sender).Value;
        }

        public void change_ShowAllFrames(object sender, System.EventArgs e) {
            showAllFrames = ((CheckBox)sender).Checked;
        }
        #endregion

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // MousePlayback
            // 
            this.Name = "MousePlayback";
            this.Size = new System.Drawing.Size(353, 230);
            this.ResumeLayout(false);

        }

        public void close() {
            playbackThread_abort = true;
            playbackThread.Interrupt();
        }

        private Color calculateNextColor(int index) {
            int total = mouseRecord.PointList.Count;
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
