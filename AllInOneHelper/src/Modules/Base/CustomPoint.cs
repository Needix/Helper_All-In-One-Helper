namespace AllInOneHelper.Modules.Base {
    class CustomPoint {
        public int X { set; get; }
        public int Y { set; get; }

        public CustomPoint(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public override string ToString() {
            return base.ToString() + ": " + X + "/" + Y;
        }
    }
}
