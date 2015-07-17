using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.DeleteEmpty {
    class DeleteEmptyController : BaseController {
        private readonly DeleteEmptyPanel _basePanel;
        private readonly DeleteEmptyModel _model = new DeleteEmptyModel();

        public DeleteEmptyController(DeleteEmptyPanel panel) {
            this._basePanel = panel;
        }

        public override void Update() {
            throw new System.NotImplementedException();
        }

        public override void Close() { }
    }
}
