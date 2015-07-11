using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules.ClickSpeed {
    class ClickSpeedPoint : CustomPoint {
        private int m_startSpeed; public int StartSpeed { get { return m_startSpeed; } set { m_startSpeed = value; } }

        public ClickSpeedPoint(int x, int y, int startSpeed) : base(x, y) {
            this.m_startSpeed = startSpeed;
        }
    }
}
