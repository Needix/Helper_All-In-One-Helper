using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules.ClickSpeed {
    class CustomPoint {
        private int m_startSpeed;
        private int x, y;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int StartSpeed { get { return m_startSpeed; } set { m_startSpeed = value; } }

        public CustomPoint(int x, int y, int startSpeed) {
            this.m_startSpeed = startSpeed;
            this.x = x;
            this.y = y;
        }
    }
}
