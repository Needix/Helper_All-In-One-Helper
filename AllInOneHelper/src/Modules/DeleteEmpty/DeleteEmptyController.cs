using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.DeleteEmpty {
    class DeleteEmptyController : BaseController {
        private DeleteEmptyPanel _basePanel;
        public DeleteEmptyController(DeleteEmptyPanel panel) {
            this._basePanel = panel;
        }

        public override void Close() { }
        public override void Serialize(FileStream fileStream) {
            throw new System.NotImplementedException();
        }

        public override BasePanel Deserialize() {
            throw new System.NotImplementedException();
        }
    }
}
