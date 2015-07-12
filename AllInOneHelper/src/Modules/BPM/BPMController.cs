using System;
using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.BPM {
    [Serializable]
    class BPMController : BaseController {
        private long _lastClick = 0;
        private double _average = 0;
        private int _curBpm = 0;

        private readonly BPMPanel _basePanel;

        public BPMController(BPMPanel panel) {
            this._basePanel = panel;
        }

        public void Click(object sender, System.EventArgs e) {
            if(_lastClick!=0) {
                double diff = Environment.TickCount-_lastClick;

                _curBpm = (int)Math.Round(60000d / diff);
                _average = (_average + _curBpm) / 2;
            }
            _lastClick = Environment.TickCount;

            UpdatePanelLabels();
        }

        public void Reset(object sender, System.EventArgs e) {
            _lastClick = 0;
            _average = 0;
            _curBpm = 0;

            UpdatePanelLabels();
        }

        private void UpdatePanelLabels() {
            _basePanel.l_bpm_averageBPM.Text = "Average BPM: " + (int)Math.Round(_average);
            _basePanel.l_bpm_curBPM.Text = "Current BPM: " + _curBpm;
        }

        public override void Close() { }
        public override void Serialize(FileStream fileStream) {
            throw new NotImplementedException();
        }

        public override BasePanel Deserialize() {
            throw new NotImplementedException();
        }
    }
}
