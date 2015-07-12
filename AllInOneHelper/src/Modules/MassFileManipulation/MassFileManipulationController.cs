using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.MassFileManipulation {
    class MassFileManipulationController : BaseController {
        private MassFileManipulationPanel _basePanel;
        public MassFileManipulationController(MassFileManipulationPanel panel) {
            this._basePanel = panel;
        }

        public override void Close() {}
        public override void Serialize(FileStream fileStream) {
            throw new System.NotImplementedException();
        }

        public override BasePanel Deserialize() {
            throw new System.NotImplementedException();
        }
    }
}
