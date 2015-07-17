using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.MassFileManipulation {
    class MassFileManipulationController : BaseController {
        private readonly MassFileManipulationPanel _basePanel;
        private readonly MassFileManipulationModel _model = new MassFileManipulationModel();

        public MassFileManipulationController(MassFileManipulationPanel panel) {
            this._basePanel = panel;
        }

        public override void Update() {
            throw new System.NotImplementedException();
        }

        public override void Close() {}
    }
}
