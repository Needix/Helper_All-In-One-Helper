using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.ClickSpeed {
    class ClickSpeedController : BaseController {
        private readonly ClickSpeedPanel _basePanel;
        private ClickSpeedModel _model = new ClickSpeedModel();

        public ClickSpeedController(ClickSpeedPanel panel) {
            _basePanel = panel;
        }

        public override void Close() { }

        public override BaseModel Model(BaseModel model = null) {
            if (model == null)
                return _model;
            else {
                _model = (ClickSpeedModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }
    }
}
