using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.GUI {
    public class ModuleElement {
        public BasePanel BasePanel { get; private set; }
        public BaseController BaseController { get; private set; }

        public ModuleElement(BasePanel panel, BaseController controller) {
            this.BasePanel = panel;
            this.BaseController = controller;
        }
    }
}
