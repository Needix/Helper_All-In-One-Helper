using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules {
    class RedrawThread {
        private static List<RedrawThread> redrawThreadList = new List<RedrawThread>();

        private const int THREAD_SLEEP = 100;

        private Thread thread;
        private volatile Boolean abort = false;
        private UserControl panel;

        public RedrawThread(UserControl panel) {
            this.panel = panel;

            RedrawThread.redrawThreadList.Add(this);
        }

        private void Run() {
            while(!abort) {
                panel.Invalidate();

                try {
                    Thread.Sleep(THREAD_SLEEP);
                } catch(ThreadInterruptedException) {
                    abort = true;
                }
            }
        }

        public void Start() {
            System.Diagnostics.Debug.WriteLine("Starting \""+panel+"\" Redraw Thread.");
            thread = new Thread(Run);
            thread.Name = panel+"_RedrawThread";
            thread.Start();
        }

        public void Close() {
            this.abort = true;
            thread.Interrupt();
        }

        public static void CloseAll() {
            for(int i = 0; i < redrawThreadList.Count; i++) {
                redrawThreadList[i].Close();
            }
        }
    }
}
