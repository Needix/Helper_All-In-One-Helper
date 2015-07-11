using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.MouseRecord {
    class MouseKey_Recorder : BaseController {
        //Const
        public const int SMOOTHNESS = 50; //Less = smoother, more RAM; More = rough, less RAM

        //Vars
        //Panels
        private MouseKeyRecord_Panel mainPanel; public MouseKeyRecord_Panel SetRecordPanel { set { mainPanel = value; } }
        private MouseKey_Playback_Panel playbackPanel;

        //MousePoints
        private CustomPoint mouse_minPoint = null; public CustomPoint MinPoint { get { return this.mouse_minPoint; } }
        private CustomPoint mouse_maxPoint = null; public CustomPoint MaxPoint { get { return this.mouse_maxPoint; } }
        private List<CustomPoint> mouse_pointList = new List<CustomPoint>(); public List<CustomPoint> PointList { get { return this.mouse_pointList; } }

        //MouseRecordThread
        private Thread mousePositionThread;
        private Boolean active_positionThread = false; public Boolean ActivePositionThread { set { active_positionThread = value; } get { return active_positionThread; } }
        private volatile Boolean abort_positionThread = false; public Boolean AbortPositionThread { set { abort_positionThread = value; } }

        private int recordSize = 0; public int RecordSize { get { return recordSize; } }

        //KeyboardStatus
        private List<byte[]> keyboard_keyStatus = new List<byte[]>();

        public MouseKey_Recorder(MouseKey_Playback_Panel playbackPanel) {
            this.playbackPanel = playbackPanel;

            mousePositionThread = new Thread(Run);
            mousePositionThread.Name = "GetMousePositionThread";
            mousePositionThread.Start();
        }

        #region PointLogic
        public void AddPoint(CustomPoint point) {
            if(mouse_minPoint == null)
                mouse_minPoint = point;
            if(mouse_maxPoint == null)
                mouse_maxPoint = point;

            int minX = mouse_minPoint.X;
            int minY = mouse_minPoint.Y;
            int maxX = mouse_maxPoint.X;
            int maxY = mouse_maxPoint.Y;

            if(minX > point.X) minX = point.X;
            if(minY > point.Y) minY = point.Y;
            if(maxX < point.X) maxX = point.X;
            if(maxY < point.Y) maxY = point.Y;

            mouse_minPoint = new CustomPoint(minX, minY);
            mouse_maxPoint = new CustomPoint(maxX, maxY);

            mouse_pointList.Add(point);
            recordSize = mouse_pointList.Count;

            // HACK Find out why ObjectDispoed/ThreadInterrupted is thrown
            try {
                mainPanel.l_mouseRec_rec_recFrames.Invoke((MethodInvoker)delegate {
                    mainPanel.l_mouseRec_rec_recFrames.Text = "Recorded Frames: " + mouse_pointList.Count;
                });
            } catch(ThreadInterruptedException) { }

        }
        #endregion

        #region KeyLogic
        private void AddKeys(byte[] pressedKeys) {
            keyboard_keyStatus.Add(pressedKeys);
        }

        public object[] GetPressedKeys(int time) {
            List<object> result = new List<object>();
            byte[] timeArray = keyboard_keyStatus[time];

            for(int i = 0; i < timeArray.Length; i++) {
                if(timeArray[i] == 1) result.Add(new KeysConverter().ConvertToString(i) + " (" + i + ")");
            }
            return result.ToArray();
        }
        #endregion

        private void Run() {
            while(!abort_positionThread) {
                try { Thread.Sleep(SMOOTHNESS); } catch(ThreadInterruptedException) { return; }
                if(!this.active_positionThread) continue;

                //Record Keys/Keyboard
                byte[] pressedKeys = Keyboard_Status.GetStatus();
                this.AddKeys(pressedKeys);

                //Record Mouse
                Point curPoint = Cursor.Position;
                this.AddPoint(new CustomPoint(curPoint.X, curPoint.Y));
            }
        }

        #region GUI-Recording
        public void StartRec(object sender, System.EventArgs e) {
            active_positionThread = true;

            mainPanel.b_mouseRec_rec_start.Enabled = false;
            mainPanel.cbox_mouseRec_pause.Enabled = true;
            mainPanel.b_mouseRec_rec_stop.Enabled = true;
            mainPanel.b_mouseRec_rec_reset.Enabled = false;
        }

        public void PauseRec(object sender, System.EventArgs e) {
            CheckBox cbox = (CheckBox)sender;
            if(!mainPanel.b_mouseRec_rec_stop.Enabled) return; // Check if stop is enabled to ensure that stopRec didnt trigger this function
            active_positionThread = !cbox.Checked;

            mainPanel.b_mouseRec_rec_start.Enabled = false;
            mainPanel.cbox_mouseRec_pause.Enabled = true;
            mainPanel.b_mouseRec_rec_stop.Enabled = true;
            mainPanel.b_mouseRec_rec_reset.Enabled = false;
        }

        public void StopRec(object sender, System.EventArgs e) {
            active_positionThread = false;

            mainPanel.b_mouseRec_rec_start.Enabled = false;
            mainPanel.b_mouseRec_rec_stop.Enabled = false;
            mainPanel.cbox_mouseRec_pause.Enabled = false;
            mainPanel.cbox_mouseRec_pause.Checked = false;
            mainPanel.b_mouseRec_rec_reset.Enabled = true;
        }

        public void ResetRec(object sender, System.EventArgs e) {
            mouse_pointList.Clear();
            keyboard_keyStatus.Clear();

            this.active_positionThread = false;
            this.abort_positionThread = false;
            mouse_minPoint = null;
            mouse_maxPoint = null;

            mainPanel.l_mouseRec_rec_recFrames.Text = "Recorded Frames: 0";
            mainPanel.b_mouseRec_rec_start.Enabled = true;
            mainPanel.cbox_mouseRec_pause.Enabled = false;
            mainPanel.cbox_mouseRec_pause.Checked = false;
            mainPanel.b_mouseRec_rec_stop.Enabled = false;
            mainPanel.b_mouseRec_rec_reset.Enabled = false;
        }
        #endregion

        public override void Close() {
            this.abort_positionThread = true;
            mousePositionThread.Interrupt();
        }
    }
}
