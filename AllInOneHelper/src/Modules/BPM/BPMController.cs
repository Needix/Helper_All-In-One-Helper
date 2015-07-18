using System;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.BPM {
    class BPMController : BaseController {
        private long _lastClick = 0;
        private double _averageBPM = 0;
        private int _curBPM = 0;

        private readonly BPMPanel _basePanel;
        private BPMModel _model = new BPMModel();

        public BPMController(BPMPanel panel) {
            _basePanel = panel;
        }

        public void Click(object sender, EventArgs e) {
            if(_lastClick!=0) {
                double diff = Environment.TickCount-_lastClick;

                _curBPM = (int)Math.Round(60000d / diff);
                _averageBPM = (_averageBPM + _curBPM) / 2;
            }
            _lastClick = Environment.TickCount;

            _model.AverageBPM = (int)Math.Round(_averageBPM);
            _model.CurrentBPM = _curBPM;
            _basePanel.UpdateView();
        }

        public void Reset(object sender, EventArgs e) {
            _lastClick = 0;
            _averageBPM = 0;
            _curBPM = 0;

            _model.AverageBPM = (int)Math.Round(_averageBPM);
            _model.CurrentBPM = _curBPM;
            _basePanel.UpdateView();
        }

        public override BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (BPMModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }

        public override void Close() { }
    }
}
