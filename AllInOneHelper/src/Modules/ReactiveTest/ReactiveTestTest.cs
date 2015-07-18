using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.ReactiveTest {
    class ReactiveTestTest : UserControl, IBaseController {
        private enum STATES {
            START = 1,
            WAITING_FOR_TIMER = 2,
            WAITING_FOR_USER = 3
        }
        private STATES state = STATES.START;

        private readonly Thread _switchStateThread;
        private volatile Boolean _switchStateThreadAbort;
        private int _switchStateThreadStartTime;

        private int _bestTime = Int32.MaxValue;
        private int _worstTime = Int32.MinValue;
        private double _averageTime = 0;
        private int _amoutTimes = 0;

        private ReactiveTestModel _model = new ReactiveTestModel();

        private readonly Random _random = new Random();

        public ReactiveTestTest() {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            _switchStateThread = new Thread(RandomSwitchState);
            _switchStateThread.Name = "ReactiveTest_SwitchStateThread";
            _switchStateThread.Start();

            RedrawThread redrawThread = new RedrawThread(this, 25);
            redrawThread.Start();
        }

        protected override void OnClick(EventArgs e) {
            base.OnClick(e);

            if(state == STATES.START) {
                state = STATES.WAITING_FOR_TIMER;
            } else if(state == STATES.WAITING_FOR_TIMER) {
                _switchStateThreadStartTime = Environment.TickCount;
                _switchStateThread.Interrupt();
            } else { //Waiting for User
                state = STATES.WAITING_FOR_TIMER;

                int curTime = Environment.TickCount - _switchStateThreadStartTime;
                if (_bestTime > curTime) _bestTime = curTime;
                if(_worstTime < curTime) _worstTime = curTime;
                _averageTime = (_averageTime + curTime)/2d;
                _amoutTimes++;
            }

        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            switch (state) {
                case STATES.START:
                    DrawState_START(g);
                break;
                case STATES.WAITING_FOR_TIMER:
                    DrawState_WaitingFor(g);
                break;
                case STATES.WAITING_FOR_USER:
                    DrawState_WaitingFor(g);
                break;
            }
        }

        private void DrawState_START(Graphics g) { }

        private void DrawState_WaitingFor(Graphics g) {
            Brush paintBrush = state == STATES.WAITING_FOR_TIMER
                ? new SolidBrush(Color.Red)
                : new SolidBrush(Color.Green);
            Brush stringBrush = new SolidBrush(Color.Black);
            g.FillRectangle(paintBrush, 0, 80, Width, Height-80);

            g.DrawString("Out of "+_amoutTimes+" valid tests, these are your times (in milliseconds): ", DefaultFont, stringBrush, 0, 0);
            g.DrawString("Best: " + _bestTime, DefaultFont, stringBrush, 0, 20);
            g.DrawString("Average: " + Math.Round(_averageTime), DefaultFont, stringBrush, 0, 40);
            g.DrawString("Worst: " + _worstTime, DefaultFont, stringBrush, 0, 60);
        }

        private void RandomSwitchState() {
            while(!_switchStateThreadAbort) {
                if (state != STATES.WAITING_FOR_TIMER) continue;

                try {
                    Thread.Sleep(_random.Next(1000, 4000));
                    state = STATES.WAITING_FOR_USER;
                    _switchStateThreadStartTime = Environment.TickCount;
                } catch (ThreadInterruptedException) {}
            }
        }

        public void Reset(Object sender, EventArgs e) {
            _switchStateThread.Interrupt();
            state = STATES.START;
            _bestTime = Int32.MaxValue;
            _worstTime = Int32.MinValue;
            _averageTime = 0;
            _amoutTimes = 0;
        }

        public BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (ReactiveTestModel)model;
                //_basePanel.UpdateView();
                return null;
            }
        }

        public void Close() {
            _switchStateThreadAbort = true;
            _switchStateThread.Interrupt();
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // ReactiveTestTest
            // 
            this.Name = "ReactiveTestTest";
            this.Size = new System.Drawing.Size(804, 398);
            this.ResumeLayout(false);

        }
    }
}
