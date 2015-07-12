using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.DeleteEmpty {
    class DeleteEmptyController : BaseController {
        private DeleteEmptyPanel _basePanel;
        public DeleteEmptyController(DeleteEmptyPanel panel) {
            this._basePanel = panel;
        }

        public override void Close() { }
    }
}
