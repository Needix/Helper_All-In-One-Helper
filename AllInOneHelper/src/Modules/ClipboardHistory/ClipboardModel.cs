using System;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.ClipboardHistory {
    public class ClipboardModel : BaseModel {
        public Boolean Activated { get; set; }
        public Boolean AutoScroll { get; set; }
    }
}
