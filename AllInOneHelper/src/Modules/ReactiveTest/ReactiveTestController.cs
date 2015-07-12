using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.ReactiveTest {
    class ReactiveTestController : BaseController {
        private ReactiveTestPanel _basePanel;
        public ReactiveTestController(ReactiveTestPanel panel) {
            this._basePanel = panel;
        }

        public override void Close() {

        }
    }
}
