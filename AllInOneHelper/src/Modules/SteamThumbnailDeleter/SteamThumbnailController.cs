using System.IO;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.SteamThumbnailDeleter {
    class SteamThumbnailController : BaseController {
        private readonly SteamThumbnailPanel _basePanel;
        private readonly SteamThumbnailModel _model = new SteamThumbnailModel();

        public SteamThumbnailController(SteamThumbnailPanel panel) {
            this._basePanel = panel;
        }

        public override void Update() {
            throw new System.NotImplementedException();
        }

        public override void Close() { }
    }
}
