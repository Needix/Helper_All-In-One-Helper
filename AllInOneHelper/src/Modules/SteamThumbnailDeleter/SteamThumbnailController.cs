using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.SteamThumbnailDeleter {
    class SteamThumbnailController : BaseController {
        private SteamThumbnailPanel _basePanel;
        public SteamThumbnailController(SteamThumbnailPanel panel) {
            this._basePanel = panel;
        }

        public override void Close() { }
    }
}
