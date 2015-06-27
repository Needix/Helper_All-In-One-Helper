using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules {
    class CustomPoint {
        private int x; public int X { set { x = value; } get { return x; } }
        private int y; public int Y { set { y = value; } get { return y; } }

        public CustomPoint(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public override string ToString() {
            return base.ToString() + ": " + x + "/" + y;
        }
    }
}
