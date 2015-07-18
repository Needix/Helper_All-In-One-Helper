using System;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.ClickSpeed {
    class ClickSpeedDummyController : BaseController {
        //TODO Code real ClickSpeedController
        private readonly ClickSpeedPanel _basePanel;
        private ClickSpeedModel _model = new ClickSpeedModel();

        public ClickSpeedDummyController(ClickSpeedPanel panel) {
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
