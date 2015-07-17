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
        private static SettingsController _controller;
        public static SettingsController GetInstance {
            get { return _controller ?? (_controller = new SettingsController()); } //if(_controller == null) _controller = new SettingsController();
            private set { _controller = value; }
        }

        private SettingsPanel _basePanel; public SettingsPanel BasePanel { set { _basePanel = value; } }
        public const string SAVE_PATH = "data.xml";

        private SettingsModel _model = new SettingsModel();

        private SettingsController() { }
        private SettingsController(SettingsPanel panel) {
            this._basePanel = panel;
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
                    if(curController.Model().GetType() != curModel.GetType()) continue;

                    curController.Model(curModel);
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

            serializer.Serialize(stream, _model);
            stream.Close();
        }

        public List<BaseModel> Deserialize() {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingsModel));
            FileStream fs = new FileStream(SAVE_PATH, FileMode.Open);
            _model = (SettingsModel)serializer.Deserialize(fs);
            List<BaseModel> models = _model.Models;
            fs.Close();
            return models;
        }

        public void CBoxDataChanged(object sender, EventArgs e) {
            Debug.WriteLine("CBoxDataChanged: "+sender.ToString());
            CheckBox cbox = (CheckBox) sender;
            if ("cbox_AlwayOnTop".Equals(cbox.Name))
                _model.AlwaysOnTop = cbox.Checked;
            else if("cbox_closeIntoTray".Equals(cbox.Name))
                _model.CloseIntoTray = cbox.Checked;
            else
                _model.MinimizeIntoTray = cbox.Checked;
        }

        private void UpdateView() {
            _basePanel.Update(_model.AlwaysOnTop, _model.CloseIntoTray, _model.MinimizeIntoTray);
        }

        public void AddModel(BaseModel pModel) {
            _model.Models.Add(pModel);
        }

        public override void Update() {
            throw new NotImplementedException();
        }

        public override BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (SettingsModel)model;
                Update();
                return null;
            }
        }

        public override void Close() { }
    }
}
