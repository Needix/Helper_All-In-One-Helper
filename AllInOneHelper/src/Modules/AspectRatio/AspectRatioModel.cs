using System;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.AspectRatio {
    [Serializable]
    public class AspectRatioModel : BaseModel {
        public String LastHeight { get; set; }
        public String LastWidth { get; set; }
        public String LastRatio { set; get; }
    }
}
