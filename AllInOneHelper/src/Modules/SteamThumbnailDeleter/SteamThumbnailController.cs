using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules.SteamThumbnailDeleter {
    class SteamThumbnailController : BaseController {
        private SteamThumbnailPanel basePanel;
        public SteamThumbnailController(SteamThumbnailPanel panel) {
            this.basePanel = panel;
        }

        public override void Close() { }
    }
}
