using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.MouseRecord {
    class MouseRecord {
        public const int SMOOTHNESS = 50; //Less = smoother, more RAM; More = rough, less RAM

        private MouseRecordPanel recordPanel; public MouseRecordPanel SetRecordPanel { set { recordPanel = value; } }

        private CustomPoint minPoint = null; public CustomPoint MinPoint { get { return this.minPoint; } }
        private CustomPoint maxPoint = null; public CustomPoint MaxPoint { get { return this.maxPoint; } }
        private List<CustomPoint> pointList = new List<CustomPoint>(); public List<CustomPoint> PointList { get { return this.pointList; } }

        private Thread mousePositionThread;
        private Boolean active_positionThread = false; public Boolean ActivePositionThread { set { active_positionThread = value; } get { return active_positionThread; } }
        private volatile Boolean abort_positionThread = false; public Boolean AbortPositionThread { set { abort_positionThread = value; } }

        public MouseRecord() {
            mousePositionThread = new Thread(run);
            mousePositionThread.Name = "GetMousePositionThread";
            mousePositionThread.Start();
        }

        public void addPoint(CustomPoint point) {
            if(minPoint == null)
                minPoint = point;
            if(maxPoint == null)
                maxPoint = point;

            int minX = minPoint.X;
            int minY = minPoint.Y;
            int maxX = maxPoint.X;
            int maxY = maxPoint.Y;

            if(minX > point.X) minX = point.X;
            if(minY > point.Y) minY = point.Y;
            if(maxX < point.X) maxX = point.X;
            if(maxY < point.Y) maxY = point.Y;

            minPoint = new CustomPoint(minX, minY);
            maxPoint = new CustomPoint(maxX, maxY);

            pointList.Add(point);

            // HACK Find out why ObjectDispoed/ThreadInterrupted is thrown
            try {
                recordPanel.l_mouseRec_rec_recFrames.Invoke((MethodInvoker)delegate {
                    recordPanel.l_mouseRec_rec_recFrames.Text = "Recorded Frames: " + pointList.Count;
                });
            } catch(ThreadInterruptedException) { }
            
        }

        private void run() {
            while(!abort_positionThread) {
                try { Thread.Sleep(SMOOTHNESS); } catch(ThreadInterruptedException) { return; }
                if(!this.active_positionThread) continue;

                Point curPoint = Cursor.Position;
                this.addPoint(new CustomPoint(curPoint.X, curPoint.Y));
            }
        }

        #region GUI-Recording
        public void startRec(object sender, System.EventArgs e) {
            active_positionThread = true;

            recordPanel.b_mouseRec_rec_start.Enabled = false;
            recordPanel.cbox_mouseRec_pause.Enabled = true;
            recordPanel.b_mouseRec_rec_stop.Enabled = true;
            recordPanel.b_mouseRec_rec_reset.Enabled = false;
        }

        public void pauseRec(object sender, System.EventArgs e) {
            CheckBox cbox = (CheckBox)sender;
            active_positionThread = !cbox.Checked;

            recordPanel.b_mouseRec_rec_start.Enabled = false;
            recordPanel.cbox_mouseRec_pause.Enabled = true;
            recordPanel.b_mouseRec_rec_stop.Enabled = true;
            recordPanel.b_mouseRec_rec_reset.Enabled = false;
        }

        public void stopRec(object sender, System.EventArgs e) {
            active_positionThread = false;

            recordPanel.b_mouseRec_rec_start.Enabled = false;
            recordPanel.cbox_mouseRec_pause.Enabled = false;
            recordPanel.cbox_mouseRec_pause.Checked = false;
            recordPanel.b_mouseRec_rec_stop.Enabled = false;
            recordPanel.b_mouseRec_rec_reset.Enabled = true;
        }

        public void resetRec(object sender, System.EventArgs e) {
            pointList.Clear();
            recordPanel.l_mouseRec_rec_recFrames.Text = "Recorded Frames: 0";
            this.active_positionThread = false;
            this.abort_positionThread = false;
            minPoint = null;
            maxPoint = null;

            recordPanel.b_mouseRec_rec_start.Enabled = true;
            recordPanel.cbox_mouseRec_pause.Enabled = false;
            recordPanel.cbox_mouseRec_pause.Checked = false;
            recordPanel.b_mouseRec_rec_stop.Enabled = false;
            recordPanel.b_mouseRec_rec_reset.Enabled = false;
        }
        #endregion

        public void close() {
            this.abort_positionThread = true;
            mousePositionThread.Interrupt();
        }
    }
}
