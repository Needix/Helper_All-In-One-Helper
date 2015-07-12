using AllInOneHelper.src.Modules.AspectRatio;
using AllInOneHelper.src.Modules.Base;
using AllInOneHelper.src.Modules.BPM;
using AllInOneHelper.src.Modules.ClickSpeed;
using AllInOneHelper.src.Modules.ClipboardHistory;
using AllInOneHelper.src.Modules.CopyFinder;
using AllInOneHelper.src.Modules.DeleteEmpty;
using AllInOneHelper.src.Modules.MassFileManipulation;
using AllInOneHelper.src.Modules.MouseRecord;
using AllInOneHelper.src.Modules.ReactiveTest;
using AllInOneHelper.src.Modules.SteamThumbnailDeleter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.src.Settings {
    [Serializable]
    class SettingsController : BaseController {
        private SettingsPanel _basePanel;

        public const string SAVE_PATH = "data";
        private readonly IFormatter formatter = new BinaryFormatter();

        public SettingsController(SettingsPanel panel) {
            this._basePanel = panel;
        }

        public void SaveData(object sender, System.EventArgs e) {
            FileStream s = new FileStream(SAVE_PATH, FileMode.Create);
            formatter.Serialize(s, this);
            s.Close();
        }

        public void LoadData(object sender, System.EventArgs e) {
            FileStream s = new FileStream(SAVE_PATH, FileMode.Open);
            SettingsController t = (SettingsController)formatter.Deserialize(s);
        }
        public List<BasePanel> LoadData() {
            List<BasePanel> result = new List<BasePanel>();
            FileStream s = new FileStream(SAVE_PATH, FileMode.Open);
            AspectRatioPanel ARP = (AspectRatioPanel)formatter.Deserialize(s);
            SettingsPanel SC = (SettingsPanel)formatter.Deserialize(s);
            result.Add(SC);
            result.Add(ARP);
            return result;
        }

        public void RevertToDefault(object sender, System.EventArgs e) {

        }

        public override void Close() { }
    }
}
