using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
using AllInOneHelper.Modules.AspectRatio;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Settings {
    class SettingsController : BaseController {
        private SettingsPanel _basePanel;
        public const string SAVE_PATH = "data";

        public SettingsModel model = new SettingsModel();

        public SettingsController(SettingsPanel panel) {
            this._basePanel = panel;
        }

        public void SaveData(object sender, EventArgs e) {
            IFormatter binaryFormatter = new BinaryFormatter();
            FileStream s = new FileStream(SAVE_PATH, FileMode.Create);
            List<BasePanel> panelList = GUI.GUI.GetInstance.ModuleList;
            foreach (BasePanel panel in panelList) {
                panel.Controller.Serialize(s);
            }
            binaryFormatter.Serialize(s, GUI.GUI.GetInstance.ModuleList);
            s.Close();
        }

        
        public void LoadData(object sender, EventArgs e) {
            LoadData();
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

        public override void Serialize(FileStream fileStream) {
            XmlSerializer s = new XmlSerializer(typeof(SettingsModel));
            TextWriter writer = new StreamWriter(SAVE_PATH);
            s.Serialize(writer, model);
        }

        public override BasePanel Deserialize() {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingsModel));
            FileStream fs = new FileStream(SAVE_PATH, FileMode.Open);
            model = (SettingsModel) serializer.Deserialize(fs);
            UpdateView();
            return null;
        }

        public void CBoxDataChanged(object sender, EventArgs e) {
            Debug.WriteLine("CBoxDataChanged: "+sender.ToString());
            CheckBox cbox = (CheckBox) sender;
            if ("cbox_AlwayOnTop".Equals(cbox.Name))
                model.AlwaysOnTop = cbox.Checked;
            else if("cbox_closeIntoTray".Equals(cbox.Name))
                model.CloseIntoTray = cbox.Checked;
            else
                model.MinimizeIntoTray = cbox.Checked;
        }

        private void UpdateView() {
            _basePanel.Update(model.AlwaysOnTop, model.CloseIntoTray, model.MinimizeIntoTray);
        }

        public override void Close() { }
    }
}
