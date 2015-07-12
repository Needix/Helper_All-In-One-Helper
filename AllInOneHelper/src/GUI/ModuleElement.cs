using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.src.GUI {
    class ModuleElement {
        public TabPage Page { set; get; }
        public BasePanel BasePanel { get; set; }

        public ModuleElement(TabPage page, BasePanel panel) {
            this.Page = page;
            this.BasePanel = panel;
        }
    }
}
