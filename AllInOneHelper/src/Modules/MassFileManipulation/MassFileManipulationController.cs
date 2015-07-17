using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.MassFileManipulation {
    class MassFileManipulationController : BaseController {
        private readonly MassFileManipulationPanel _basePanel;
        private MassFileManipulationModel _model = new MassFileManipulationModel();

        public MassFileManipulationController(MassFileManipulationPanel panel) {
            this._basePanel = panel;
        }

        public override void Update() {
            throw new System.NotImplementedException();
        }

        public override BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (MassFileManipulationModel)model;
                Update();
                return null;
            }
        }

        public override void Close() {}
    }
}
