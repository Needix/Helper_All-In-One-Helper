using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.GUI {
    public class ModuleElement {
        public BasePanel BasePanel { get; private set; }
        public IBaseController BaseController { get; private set; }

        public ModuleElement(BasePanel panel, IBaseController controller) {
            this.BasePanel = panel;
            this.BaseController = controller;
        }
    }
}
