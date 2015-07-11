using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules.MassFileManipulation {
    class MassFileManipulationController : BaseController {
        private MassFileManipulationPanel basePanel;
        public MassFileManipulationController(MassFileManipulationPanel panel) {
            this.basePanel = panel;
        }

        public override void Close() {}
    }
}
