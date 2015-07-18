using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace AllInOneHelper.Modules.BaseModule {
    class RedrawThread {
        private static readonly List<RedrawThread> redrawThreadList = new List<RedrawThread>();

        private const int THREAD_SLEEP = 100;

        private Thread _thread;
        private volatile Boolean _abort = false;
        private readonly UserControl _panel;

        public RedrawThread(UserControl panel) {
            this._panel = panel;

            redrawThreadList.Add(this);
        }

        private void Run() {
            while(!_abort) {
                _panel.Invalidate();

                try {
                    Thread.Sleep(THREAD_SLEEP);
                } catch(ThreadInterruptedException) {
                    _abort = true;
                }
            }
        }

        public void Start() {
            Debug.WriteLine("Starting \""+_panel+"\" Redraw Thread.");
            _thread = new Thread(Run);
            _thread.Name = _panel+"_RedrawThread";
            _thread.Start();
        }

        public void Close() {
            this._abort = true;
            _thread.Interrupt();
        }

        public static void CloseAll() {
            foreach (RedrawThread thread in redrawThreadList) {
                thread.Close();
            }
        }
    }
}
