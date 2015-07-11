using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules.BPM {
    class BPMController : BaseController {
        private long lastClick = 0;
        private double average = 0;
        private int curBPM = 0;

        private BPMPanel basePanel;

        public BPMController(BPMPanel panel) {
            this.basePanel = panel;
        }

        public void Click(object sender, System.EventArgs e) {
            if(lastClick!=0) {
                double diff = Environment.TickCount-lastClick;

                curBPM = (int)Math.Round(60000d / diff);
                average = (average + curBPM) / 2;
            }
            lastClick = Environment.TickCount;

            UpdatePanelLabels();
        }

        public void Reset(object sender, System.EventArgs e) {
            lastClick = 0;
            average = 0;
            curBPM = 0;

            UpdatePanelLabels();
        }

        private void UpdatePanelLabels() {
            basePanel.l_bpm_averageBPM.Text = "Average BPM: " + (int)Math.Round(average);
            basePanel.l_bpm_curBPM.Text = "Current BPM: " + curBPM;
        }

        public override void Close() { }
    }
}
