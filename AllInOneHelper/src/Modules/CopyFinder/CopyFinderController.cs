using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.CopyFinder {
    class CopyFinderController : BaseController {
        private readonly CopyFinderPanel _basePanel;
        private CopyFinderModel _model = new CopyFinderModel();

        public CopyFinderController(CopyFinderPanel panel) {
            this._basePanel = panel;
        }

        public override void Update() {
            throw new System.NotImplementedException();
        }

        public override void Close() {
            throw new System.NotImplementedException();
        }

        public override BaseModel Model(BaseModel model) {
            if(model==null)
                return _model;
            else {
                _model = (CopyFinderModel)model;
                return null;
            }
        }
    }
}
