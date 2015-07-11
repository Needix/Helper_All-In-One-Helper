using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules.ReactiveTest {
    class ReactiveTestController : BaseController {
        private ReactiveTestPanel basePanel;
        public ReactiveTestController(ReactiveTestPanel panel) {
            this.basePanel = panel;
        }

        public override void Close() {

        }
    }
}
