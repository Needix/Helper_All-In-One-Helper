using System;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.ReactiveTest {
    class ReactiveTestController : IBaseController {
        private readonly ReactiveTestPanel _basePanel;
        private ReactiveTestModel _model = new ReactiveTestModel();

        public ReactiveTestController(ReactiveTestPanel panel) {
            this._basePanel = panel;
        }

        public void Reset(object sender, EventArgs e) {
            
        }

        public virtual BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (ReactiveTestModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }

        public virtual void Close() {

        }
    }
}
