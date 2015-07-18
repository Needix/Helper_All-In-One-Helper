using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.MouseRecord {
    internal class MouseKey_Recorder : IBaseController {
        //Const
        public const int SMOOTHNESS = 50; //Less = smoother, more RAM; More = rough, less RAM

        ////Vars
        //Panels
        public MouseKeyRecord_Panel _basePanel { get; set; }
        private MouseKey_Playback_Panel _playbackPanel;
        private MouseKey_Model _model;

        //MousePoints
        public CustomPoint MinPoint { get; private set; }
        public CustomPoint MaxPoint { get; private set; }
        public List<CustomPoint> PointList { get; private set; }

        //MouseRecordThread
        private readonly Thread _mousePositionThread;
        public Boolean ActivePositionThread { set; get; }

        private volatile Boolean _abortPositionThread;

        private int _lastPause = Environment.TickCount;

        public Boolean AbortPositionThread {
            set { _abortPositionThread = value; }
        }

        public int RecordSize { get; private set; }

        //KeyboardStatus
        private readonly List<byte[]> _keyboardKeyStatus = new List<byte[]>();

        public MouseKey_Recorder(MouseKey_Model model, MouseKey_Playback_Panel playbackpanel) {
            _playbackPanel = playbackpanel;
            _model = model;
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

            _model.RecordedFrames = PointList.Count;
            _basePanel.UpdateView();
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

            _model.RecStartEnabled = false;
            _model.RecPauseEnabled = true;
            _model.RecStopEnabled = true;
            _model.RecResetEnabled = false;
            _basePanel.UpdateView();
        }

        public void PauseRec(object sender, EventArgs e) {
            CheckBox cbox = (CheckBox)sender;
            int curTime = Environment.TickCount;
            if(!_model.RecStopEnabled || curTime - _lastPause < 100) return; // Check if stop is enabled to ensure that stopRec didnt trigger this function
            ActivePositionThread = !cbox.Checked;
            _lastPause = curTime;

            _model.RecStartEnabled = false;
            _model.RecPauseEnabled = true;
            _model.RecPauseChecked = cbox.Checked;
            _model.RecStopEnabled = true;
            _model.RecResetEnabled = false;

            _basePanel.UpdateView();
        }

        public void StopRec(object sender, EventArgs e) {
            ActivePositionThread = false;

            _model.RecStartEnabled = false;
            _model.RecPauseEnabled = false;
            _model.RecPauseChecked = false;
            _model.RecStopEnabled = false;
            _model.RecResetEnabled = true;
            _basePanel.UpdateView();
        }

        public void ResetRec(object sender, EventArgs e) {
            PointList.Clear();
            _keyboardKeyStatus.Clear();

            ActivePositionThread = false;
            AbortPositionThread = false;
            MinPoint = null;
            MaxPoint = null;

            _model.RecordedFrames = 0;
            _model.RecStartEnabled = true;
            _model.RecPauseEnabled = false;
            _model.RecPauseChecked = false;
            _model.RecStopEnabled = false;
            _model.RecResetEnabled = false;
            _basePanel.UpdateView();
        }

        #endregion

        public virtual BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (MouseKey_Model)model;
                _playbackPanel.Model = _model;
                _basePanel.UpdateView();
                return null;
            }
        }

        public virtual void Close() {
            AbortPositionThread = true;
            _mousePositionThread.Interrupt();
        }
    }
}
