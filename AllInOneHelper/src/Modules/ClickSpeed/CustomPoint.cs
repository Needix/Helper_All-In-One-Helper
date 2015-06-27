using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules.ClickSpeed {
    class CustomPoint : AllInOneHelper.src.Modules.CustomPoint {
        private int m_startSpeed;
        public int StartSpeed { get { return m_startSpeed; } set { m_startSpeed = value; } }

        public CustomPoint(int x, int y, int startSpeed) :base(x, y) {
            this.m_startSpeed = startSpeed;
        }
    }
}
