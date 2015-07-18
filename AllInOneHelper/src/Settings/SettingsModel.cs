using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Settings {
    [Serializable]
    public class SettingsModel : BaseModel {
        private bool _closeIntoTray;
        public bool CloseIntoTray { set { _closeIntoTray = value; OnPropertyChanged("CloseIntoTray"); } get { return _closeIntoTray; } }

        private bool _minimizeIntoTray;
        public bool MinimizeIntoTray { get { return _minimizeIntoTray; } set { _minimizeIntoTray = value; OnPropertyChanged("MinimizeIntoTray"); } }

        private bool _alwaysOnTop;
        public bool AlwaysOnTop { get { return _alwaysOnTop; } set { _alwaysOnTop = value; OnPropertyChanged("AlwaysOnTop"); } }

        private List<BaseModel> _models = new List<BaseModel>(); 
        public List<BaseModel> Models { 
            get { return _models; }
        }
    }
}