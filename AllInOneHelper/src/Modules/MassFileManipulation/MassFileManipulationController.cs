using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.MassFileManipulation {
    class MassFileManipulationController : BaseController {
        private readonly MassFileManipulationPanel _basePanel;
        private MassFileManipulationModel _model = new MassFileManipulationModel();

        public MassFileManipulationController(MassFileManipulationPanel panel) {
            this._basePanel = panel;
        }

        public override BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (MassFileManipulationModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }

        public override void Close() {}
    }
}
