using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules.BPM {
    class BPM {
        private static long lastClick = 0;
        private static double average = 0;
        public static double getAverage { get { return average; } }
        private static int curBPM = 0;
        public static int getCurBPM { get { return curBPM; }}

        public static void click() {
            if(lastClick!=0) {
                double diff = Environment.TickCount-lastClick;

                curBPM = (int)Math.Round(60000d / diff);
                average = (average + curBPM) / 2;
            }
            lastClick = Environment.TickCount;
        }

        public static void reset() {
            lastClick = 0;
            average = 0;
            curBPM = 0;
        }
    }
}
