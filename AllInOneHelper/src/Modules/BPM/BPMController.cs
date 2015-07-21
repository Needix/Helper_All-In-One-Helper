using System;
using System.Diagnostics;
using System.Threading;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.BPM {
    class BPMController : IBaseController {
        private long _lastClick;

        private readonly BPMPanel _basePanel;
        private BPMModel _model = new BPMModel();

        private readonly Thread _visualBPMThread;
        private volatile Boolean _abortVisualBPMThread;
        private long _lastBlinkCurrent;
        private long _lastBlinkAverage;

        public BPMController(BPMPanel panel) {
            _basePanel = panel;

            _visualBPMThread = new Thread(VisualBPMThread);
            _visualBPMThread.Name = "VisualBPMThread";
            _visualBPMThread.Start();
        }

        public void Click(object sender, EventArgs e) {
            int curBPM = 0;
            double averageBPM = _model.AverageBPM;

            if(_lastClick!=0) {
                double diff = Environment.TickCount-_lastClick;

                curBPM = (int)Math.Round(60000d / diff);
                averageBPM = (averageBPM + curBPM) / 2;
            }
            _lastClick = Environment.TickCount;

            _model.AverageBPM = (int)Math.Round(averageBPM);
            _model.CurrentBPM = curBPM;
            _basePanel.UpdateView();
        }

        private void VisualBPMThread() {
            while (!_abortVisualBPMThread) {
                long EnvTick = Environment.TickCount;
                if(_lastBlinkCurrent == 0 || _lastBlinkAverage==0) {
                    _lastBlinkCurrent = EnvTick;
                    _lastBlinkAverage = EnvTick;
                }

                long curDiff = EnvTick - _lastBlinkCurrent;
                long avDiff =  EnvTick - _lastBlinkAverage;
                double curPerSec =  60000d / _model.CurrentBPM;
                double avPerSec =   60000d / _model.AverageBPM;

                if(curPerSec < curDiff) {
                    _basePanel.ToggleVisualBPM("current");
                    _lastBlinkCurrent = EnvTick;
                }
                if(avPerSec < avDiff) {
                    _basePanel.ToggleVisualBPM("average");
                    _lastBlinkAverage = EnvTick;
                }

                Thread.Sleep(20);
            }
        }

        public void Reset(object sender, EventArgs e) {
            _lastClick = 0;

            _model.AverageBPM = 0;
            _model.CurrentBPM = 0;
            _basePanel.UpdateView();
        }

        public virtual BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;

            _model = (BPMModel)model;
            _basePanel.UpdateView();
            return null;
        }

        public virtual void Close() {
            _abortVisualBPMThread = true;
        }
    }
}
