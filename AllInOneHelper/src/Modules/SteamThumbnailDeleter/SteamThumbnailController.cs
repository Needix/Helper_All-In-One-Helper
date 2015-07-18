using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.SteamThumbnailDeleter {
    class SteamThumbnailController : IBaseController {
        private readonly SteamThumbnailPanel _basePanel;
        private SteamThumbnailModel _model = new SteamThumbnailModel();

        public SteamThumbnailController(SteamThumbnailPanel panel) {
            this._basePanel = panel;
        }

        public virtual BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (SteamThumbnailModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }

        public virtual void Close() { }
    }
}
