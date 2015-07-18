using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.SteamThumbnailDeleter {
    class SteamThumbnailController : BaseController {
        private readonly SteamThumbnailPanel _basePanel;
        private SteamThumbnailModel _model = new SteamThumbnailModel();

        public SteamThumbnailController(SteamThumbnailPanel panel) {
            this._basePanel = panel;
        }

        public override BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (SteamThumbnailModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }

        public override void Close() { }
    }
}
