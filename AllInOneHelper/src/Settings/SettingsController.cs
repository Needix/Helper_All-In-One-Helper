using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using AllInOneHelper.Modules.AspectRatio;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Settings {
    [Serializable]
    class SettingsController : BaseController {
        private SettingsPanel _basePanel;

        public const string SAVE_PATH = "data";
        private readonly IFormatter _formatter = new BinaryFormatter();

        public SettingsController(SettingsPanel panel) {
            this._basePanel = panel;
        }

        public void SaveData(object sender, EventArgs e) {
            FileStream s = new FileStream(SAVE_PATH, FileMode.Create);
            _formatter.Serialize(s, this);
            s.Close();
        }

        public void LoadData(object sender, EventArgs e) {
            FileStream s = new FileStream(SAVE_PATH, FileMode.Open);
            SettingsController t = (SettingsController)_formatter.Deserialize(s);
        }
        public List<BasePanel> LoadData() {
            List<BasePanel> result = new List<BasePanel>();
            FileStream s = new FileStream(SAVE_PATH, FileMode.Open);
            AspectRatioPanel arp = (AspectRatioPanel)_formatter.Deserialize(s);
            SettingsPanel sc = (SettingsPanel)_formatter.Deserialize(s);
            result.Add(arp);
            result.Add(sc);
            return result;
        }

        public void RevertToDefault(object sender, EventArgs e) {

        }

        public override void Close() { }
    }
}
