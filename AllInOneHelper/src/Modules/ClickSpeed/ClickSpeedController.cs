using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.ClickSpeed {
    class ClickSpeedController : IBaseController {
        private readonly ClickSpeedPanel _basePanel;
        private ClickSpeedModel _model = new ClickSpeedModel();

        public ClickSpeedController(ClickSpeedPanel panel) {
            _basePanel = panel;
        }

        public virtual void Close() { }

        public virtual BaseModel Model(BaseModel model = null) {
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
