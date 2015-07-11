using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Settings {
    class SettingsController : BaseController {
        private SettingsPanel basePanel;
        public SettingsController(SettingsPanel panel) {
            this.basePanel = panel;
        }

        public override void Close() { }
    }
}
