using System;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.ClickSpeed {
    public class ClickSpeedModel : BaseModel {
        public ClickSpeedModel() {
            Accuracy = 5;
        }

        public int Accuracy { get; set; }
    }
}
