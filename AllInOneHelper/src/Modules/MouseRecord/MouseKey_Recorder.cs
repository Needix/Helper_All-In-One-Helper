using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.MouseRecord {
    internal class MouseKey_Recorder : BaseController {
        //Const
        public const int SMOOTHNESS = 50; //Less = smoother, more RAM; More = rough, less RAM

        //Vars
        //Panels
        public MouseKeyRecord_Panel SetRecordPanel { get; set; }
        private MouseKey_Model _model = new MouseKey_Model();

        //MousePoints
        public CustomPoint MinPoint { get; private set; }
        public CustomPoint MaxPoint { get; private set; }
        public List<CustomPoint> PointList { get; private set; }

        //MouseRecordThread
        private readonly Thread _mousePositionThread;
        public Boolean ActivePositionThread { set; get; }

        private volatile Boolean _abortPositionThread;

        public Boolean AbortPositionThread {
            set { _abortPositionThread = value; }
        }

        public int RecordSize { get; private set; }

        //KeyboardStatus
        private readonly List<byte[]> _keyboardKeyStatus = new List<byte[]>();

        public MouseKey_Recorder() {
            RecordSize = 0;
            ActivePositionThread = false;
            PointList = new List<CustomPoint>();
            MaxPoint = null;
            MinPoint = null;
            _mousePositionThread = new Thread(Run);
            _mousePositionThread.Name = "GetMousePositionThread";
            _mousePositionThread.Start();
        }

        #region PointLogic

        public void AddPoint(CustomPoint point) {
            if (MinPoint == null)
                MinPoint = point;
            if (MaxPoint == null)
                MaxPoint = point;

            int minX = MinPoint.X;
            int minY = MinPoint.Y;
            int maxX = MaxPoint.X;
            int maxY = MaxPoint.Y;

            if (minX > point.X) minX = point.X;
            if (minY > point.Y) minY = point.Y;
            if (maxX < point.X) maxX = point.X;
            if (maxY < point.Y) maxY = point.Y;

            MinPoint = new CustomPoint(minX, minY);
            MaxPoint = new CustomPoint(maxX, maxY);

            PointList.Add(point);
            RecordSize = PointList.Count;

            // HACK Find out why ObjectDispoed/ThreadInterrupted is thrown
            try {
                SetRecordPanel.l_mouseRec_rec_recFrames.Invoke((MethodInvoker) delegate {
                    SetRecordPanel.l_mouseRec_rec_recFrames.Text = "Recorded Frames: " + PointList.Count;
                });
            } catch (ThreadInterruptedException) {}

        }

        #endregion

        #region KeyLogic

        private void AddKeys(byte[] pressedKeys) {
            _keyboardKeyStatus.Add(pressedKeys);
        }

        public object[] GetPressedKeys(int time) {
            List<object> result = new List<object>();
            byte[] timeArray = _keyboardKeyStatus[time];

            for (int i = 0; i < timeArray.Length; i++) {
                if (timeArray[i] == 1) result.Add(new KeysConverter().ConvertToString(i) + " (" + i + ")");
            }
            return result.ToArray();
        }

        #endregion

        private void Run() {
            while (!_abortPositionThread) {
                try {
                    Thread.Sleep(SMOOTHNESS);
                } catch (ThreadInterruptedException) {
                    return;
                }
                if (!ActivePositionThread) continue;

                //Record Keys/Keyboard
                byte[] pressedKeys = Keyboard_Status.GetStatus();
                AddKeys(pressedKeys);

                //Record Mouse
                Point curPoint = Cursor.Position;
                AddPoint(new CustomPoint(curPoint.X, curPoint.Y));
            }
        }

        #region GUI-Recording

        public void StartRec(object sender, EventArgs e) {
            ActivePositionThread = true;

            SetRecordPanel.b_mouseRec_rec_start.Enabled = false;
            SetRecordPanel.cbox_mouseRec_pause.Enabled = true;
            SetRecordPanel.b_mouseRec_rec_stop.Enabled = true;
            SetRecordPanel.b_mouseRec_rec_reset.Enabled = false;
        }

        public void PauseRec(object sender, EventArgs e) {
            CheckBox cbox = (CheckBox) sender;
            if (!SetRecordPanel.b_mouseRec_rec_stop.Enabled)
                return; // Check if stop is enabled to ensure that stopRec didnt trigger this function
            ActivePositionThread = !cbox.Checked;

            SetRecordPanel.b_mouseRec_rec_start.Enabled = false;
            SetRecordPanel.cbox_mouseRec_pause.Enabled = true;
            SetRecordPanel.b_mouseRec_rec_stop.Enabled = true;
            SetRecordPanel.b_mouseRec_rec_reset.Enabled = false;
        }

        public void StopRec(object sender, EventArgs e) {
            ActivePositionThread = false;

            SetRecordPanel.b_mouseRec_rec_start.Enabled = false;
            SetRecordPanel.b_mouseRec_rec_stop.Enabled = false;
            SetRecordPanel.cbox_mouseRec_pause.Enabled = false;
            SetRecordPanel.cbox_mouseRec_pause.Checked = false;
            SetRecordPanel.b_mouseRec_rec_reset.Enabled = true;
        }

        public void ResetRec(object sender, EventArgs e) {
            PointList.Clear();
            _keyboardKeyStatus.Clear();

            ActivePositionThread = false;
            AbortPositionThread = false;
            MinPoint = null;
            MaxPoint = null;

            SetRecordPanel.l_mouseRec_rec_recFrames.Text = "Recorded Frames: 0";
            SetRecordPanel.b_mouseRec_rec_start.Enabled = true;
            SetRecordPanel.cbox_mouseRec_pause.Enabled = false;
            SetRecordPanel.cbox_mouseRec_pause.Checked = false;
            SetRecordPanel.b_mouseRec_rec_stop.Enabled = false;
            SetRecordPanel.b_mouseRec_rec_reset.Enabled = false;
        }

        #endregion

        public override void Update() {
            throw new NotImplementedException();
        }

        public override BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (MouseKey_Model)model;
                Update();
                return null;
            }
        }

        public override void Close() {
            AbortPositionThread = true;
            _mousePositionThread.Interrupt();
        }
    }
}
