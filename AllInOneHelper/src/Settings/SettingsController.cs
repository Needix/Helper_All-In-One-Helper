using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
using AllInOneHelper.Modules.AspectRatio;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Settings {
    class SettingsController : BaseController {
        public static SettingsController Controller { get; private set; }

        private readonly SettingsPanel _basePanel;
        public const string SAVE_PATH = "data.xml";

        public SettingsModel Model { get; set; }

        private SettingsController(SettingsPanel panel) {
            this._basePanel = panel;
        }

        public static SettingsController CreateController(SettingsPanel panel, bool loadFromFile) {
            Controller = new SettingsController(panel);
            if (!loadFromFile) Controller.Model = new SettingsModel();
            return Controller;
        }

        public void SaveData(object sender, EventArgs e) {
            Serialize();
        }

        public void LoadData(object sender, EventArgs e) {
            LoadData(GUI.GUI.GetInstance.GetControllers());
        }
        public void LoadData(List<BaseController> controllers) {
            List<BaseModel> models = Deserialize();
            for (int i = 0; i < controllers.Count; i++) {
                BaseController curController = controllers[i];
                for (int j = 0; j < models.Count; j++) {
                    BaseModel curModel = models[j];
                    if (curController.Model.GetType() != curModel.GetType()) continue;

                    curController.Model = curModel;
                    curController.Update();
                    break;
                }
            }
        }

        public void RevertToDefault(object sender, EventArgs e) {
            
        }

        public void Serialize() {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingsModel));

            if(File.Exists(SAVE_PATH)) File.Delete(SAVE_PATH);
            FileStream stream = new FileStream(SAVE_PATH, FileMode.Create);

            serializer.Serialize(stream, Model);
            stream.Close();
        }

        public List<BaseModel> Deserialize() {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingsModel));
            FileStream fs = new FileStream(SAVE_PATH, FileMode.Open);
            Model = (SettingsModel)serializer.Deserialize(fs);
            List<BaseModel> models = Model.Models;
            fs.Close();
            return models;
        }

        public void CBoxDataChanged(object sender, EventArgs e) {
            Debug.WriteLine("CBoxDataChanged: "+sender.ToString());
            CheckBox cbox = (CheckBox) sender;
            if ("cbox_AlwayOnTop".Equals(cbox.Name))
                Model.AlwaysOnTop = cbox.Checked;
            else if("cbox_closeIntoTray".Equals(cbox.Name))
                Model.CloseIntoTray = cbox.Checked;
            else
                Model.MinimizeIntoTray = cbox.Checked;
        }

        private void UpdateView() {
            _basePanel.Update(Model.AlwaysOnTop, Model.CloseIntoTray, Model.MinimizeIntoTray);
        }

        public void AddModel(BaseModel pModel) {
            Model.Models.Add(pModel);
        }

        public override void Update() {
            throw new NotImplementedException();
        }

        public override void Close() { }
    }
}
