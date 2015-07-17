using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.DeleteEmpty {
    class DeleteEmptyController : BaseController {
        private readonly DeleteEmptyPanel _basePanel;
        private DeleteEmptyModel _model = new DeleteEmptyModel();

        public DeleteEmptyController(DeleteEmptyPanel panel) {
            this._basePanel = panel;
        }

        public override void Update() {
            throw new System.NotImplementedException();
        }

        public override BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (DeleteEmptyModel)model;
                Update();
                return null;
            }
        }

        public override void Close() { }
    }
}
