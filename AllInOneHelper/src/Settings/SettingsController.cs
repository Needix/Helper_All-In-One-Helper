using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Settings {
    class SettingsController : IBaseController {
        private static SettingsController _controller;
        public static SettingsController GetInstance {
            get { return _controller ?? (_controller = new SettingsController()); } //if(_controller == null) _controller = new SettingsController();
            private set { _controller = value; }
        }

        private SettingsPanel _basePanel; public SettingsPanel BasePanel { set { _basePanel = value; } }
        public const string SAVE_PATH = "data.xml";

        private SettingsModel _model = new SettingsModel();

        private SettingsController() { }

        public void SaveData(object sender, EventArgs e) {
            Serialize();
        }

        public void LoadData(object sender, EventArgs e) {
            LoadData(GUI.GUI.GetInstance.GetControllers());
        }
        public void LoadData(List<IBaseController> controllers) {
            _model = Deserialize();
            _basePanel.UpdateView();

            List<BaseModel> models = _model.Models;
            for (int i = 0; i < controllers.Count; i++) {
                IBaseController curController = controllers[i];
                for (int j = 0; j < models.Count; j++) {
                    BaseModel curModel = models[j];
                    if(curController.Model().GetType() != curModel.GetType()) continue;

                    //Debug.WriteLine("Changing "+curController+" model("+curController.Model()+") to "+curModel);
                    curController.Model(curModel);
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

        public SettingsModel Deserialize() {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingsModel));
            FileStream fs = new FileStream(SAVE_PATH, FileMode.Open);
            _model = (SettingsModel)serializer.Deserialize(fs);
            fs.Close();
            return _model;
        }

        public void CBoxDataChanged(object sender, EventArgs e) {
            CheckBox cbox = (CheckBox)sender;
            //Debug.WriteLine("CBoxDataChanged: " + cbox.Name);
            if ("cbox_alwayOnTop".Equals(cbox.Name))
                _model.AlwaysOnTop = cbox.Checked;
            else if ("cbox_closeIntoTray".Equals(cbox.Name))
                _model.CloseIntoTray = cbox.Checked;
            else
                _model.MinimizeIntoTray = cbox.Checked;
        }

        public void AddModel(BaseModel pModel) {
            _model.Models.Add(pModel);
        }

        public virtual BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (SettingsModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }

        public virtual void Close() { }
    }
}
