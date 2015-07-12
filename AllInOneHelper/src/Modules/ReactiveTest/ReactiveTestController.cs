using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.ReactiveTest {
    class ReactiveTestController : BaseController {
        private ReactiveTestPanel _basePanel;
        public ReactiveTestController(ReactiveTestPanel panel) {
            this._basePanel = panel;
        }

        public override void Close() {

        }

        public override void Serialize(FileStream fileStream) {
            throw new System.NotImplementedException();
        }

        public override BasePanel Deserialize() {
            throw new System.NotImplementedException();
        }
    }
}
