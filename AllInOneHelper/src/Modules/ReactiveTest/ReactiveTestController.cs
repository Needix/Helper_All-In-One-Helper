using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.ReactiveTest {
    class ReactiveTestController : BaseController {
        private readonly ReactiveTestPanel _basePanel;
        private readonly ReactiveTestModel _model = new ReactiveTestModel();

        public ReactiveTestController(ReactiveTestPanel panel) {
            this._basePanel = panel;
        }

        public override void Update() {
            throw new System.NotImplementedException();
        }

        public override void Close() {

        }
    }
}
