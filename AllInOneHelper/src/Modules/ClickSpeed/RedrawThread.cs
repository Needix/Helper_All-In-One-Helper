using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.ClickSpeed {
    class RedrawThread {
        private const int THREAD_SLEEP = 100;

        private Thread thread;
        private volatile Boolean abort = false;
        private ClickSpeed panel;

        public RedrawThread(ClickSpeed panel) {
            this.panel = panel;
        }

        private void run() {
            while(!abort) {
                panel.Invalidate();

                try {
                    Thread.Sleep(THREAD_SLEEP);
                } catch(ThreadInterruptedException) {
                    abort = true;
                }
            }
        }

        public void start() {
            thread = new Thread(run);
            thread.Name = "ClickSpeed_RedrawThread";
            thread.Start();
        }
    }
}
