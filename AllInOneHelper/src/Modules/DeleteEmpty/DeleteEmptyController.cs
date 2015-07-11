using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules.DeleteEmpty {
    class DeleteEmptyController : BaseController {
        private DeleteEmptyPanel basePanel;
        public DeleteEmptyController(DeleteEmptyPanel panel) {
            this.basePanel = panel;
        }

        public override void Close() { }
    }
}
