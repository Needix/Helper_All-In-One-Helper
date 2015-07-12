using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.GUI {
    class ModuleElement {
        public TabPage Page { set; get; }
        public BasePanel BasePanel { get; set; }

        public ModuleElement(TabPage page, BasePanel panel) {
            this.Page = page;
            this.BasePanel = panel;
        }
    }
}
