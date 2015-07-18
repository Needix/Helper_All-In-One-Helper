using System;
using System.Collections.Generic;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Settings {
    [Serializable]
    public class SettingsModel : BaseModel {
        private bool _closeIntoTray;
        public bool CloseIntoTray { set { _closeIntoTray = value; OnPropertyChanged("CloseIntoTray"); } get { return _closeIntoTray; } }

        private bool _minimizeIntoTray;
        public bool MinimizeIntoTray { get { return _minimizeIntoTray; } set { _minimizeIntoTray = value; } }

        private bool _alwaysOnTop;
        public bool AlwaysOnTop { get { return _alwaysOnTop; } 
            set { 
                _alwaysOnTop = value;
                GUI.GUI.GetInstance.TopMost = value;
            } 
        }

        private List<BaseModel> _models = new List<BaseModel>(); 
        public List<BaseModel> Models { 
            get { return _models; }
        }
    }
}