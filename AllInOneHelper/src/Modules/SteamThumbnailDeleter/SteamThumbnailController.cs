using System;
using System.Diagnostics;
using System.IO;
using AllInOneHelper.Modules.BaseModule;
using Microsoft.Win32;

namespace AllInOneHelper.Modules.SteamThumbnailDeleter {
    class SteamThumbnailController : IBaseController {
        private readonly SteamThumbnailPanel _basePanel;
        private SteamThumbnailModel _model = new SteamThumbnailModel();

        public SteamThumbnailController(SteamThumbnailPanel panel) {
            this._basePanel = panel;
        }

        public void DeleteThumbnails(object sender, EventArgs e) {
            object obj = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", null);
            if(obj == null) return;
            string path = obj + "\\userdata\\";
            RekFindThumbnailFolder(new DirectoryInfo(path));
        }

        private void RekFindThumbnailFolder(DirectoryInfo root) {
            DirectoryInfo[] dirs = root.GetDirectories();
            foreach (DirectoryInfo curInfo in dirs) {
                if (curInfo.Name.Equals("thumbnails")) {
                    curInfo.Delete(true);
                    _model.DeletedFolder++;
                    _basePanel.UpdateView();
                } else
                    RekFindThumbnailFolder(curInfo);
            }
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
