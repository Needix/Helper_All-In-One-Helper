﻿using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.ReactiveTest {
    class ReactiveTestController : BaseController {
        private readonly ReactiveTestPanel _basePanel;
        private ReactiveTestModel _model = new ReactiveTestModel();

        public ReactiveTestController(ReactiveTestPanel panel) {
            this._basePanel = panel;
        }

        public override BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (ReactiveTestModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }

        public override void Close() {

        }
    }
}
