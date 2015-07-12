using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.ClickSpeed {
    class ClickSpeedPoint : CustomPoint {
        public int StartSpeed { get; set; }

        public ClickSpeedPoint(int x, int y, int startSpeed) : base(x, y) {
            this.StartSpeed = startSpeed;
        }
    }
}
