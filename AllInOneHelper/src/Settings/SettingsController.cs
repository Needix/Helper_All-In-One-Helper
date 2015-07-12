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

        [NonSerialized]
        public const string SAVE_PATH = "data";

        public SettingsController(SettingsPanel panel) {
            this._basePanel = panel;
        }

        public void SaveData(object sender, EventArgs e) {
            IFormatter binaryFormatter = new BinaryFormatter();
            FileStream s = new FileStream(SAVE_PATH, FileMode.Create);
            binaryFormatter.Serialize(s, GUI.GUI.GetInstance.ModuleList);
            s.Close();
        }

        public void LoadData(object sender, EventArgs e) {
            IFormatter binaryFormatter = new BinaryFormatter();
            FileStream s = new FileStream(SAVE_PATH, FileMode.Open);
            SettingsController t = (SettingsController)binaryFormatter.Deserialize(s);
        }
        public List<BasePanel> LoadData() {
            IFormatter formatter = new BinaryFormatter();
            List<BasePanel> result = new List<BasePanel>();
            FileStream s = new FileStream(SAVE_PATH, FileMode.Open);
            List<BasePanel> sc = (List<BasePanel>)formatter.Deserialize(s);
            return result;
        }

        public void RevertToDefault(object sender, EventArgs e) {

        }

        public override void Close() { }
    }
}
