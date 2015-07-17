using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using AllInOneHelper.Modules.AspectRatio;
using AllInOneHelper.Modules.BPM;
using AllInOneHelper.Modules.ClickSpeed;
using AllInOneHelper.Modules.ClipboardHistory;
using AllInOneHelper.Modules.CopyFinder;
using AllInOneHelper.Modules.DeleteEmpty;
using AllInOneHelper.Modules.MassFileManipulation;
using AllInOneHelper.Modules.MouseRecord;
using AllInOneHelper.Modules.ReactiveTest;
using AllInOneHelper.Modules.SteamThumbnailDeleter;
using AllInOneHelper.Settings;

namespace AllInOneHelper.Modules.Base {
    //[Serializable]
    [XmlInclude(typeof(AspectRatioModel)), XmlInclude(typeof(BPMModel)), XmlInclude(typeof(ClickSpeedModel)), 
    XmlInclude(typeof(ClipboardModel)), XmlInclude(typeof(CopyFinderModel)), XmlInclude(typeof(DeleteEmptyModel)),
    XmlInclude(typeof(MassFileManipulationModel)), XmlInclude(typeof(MouseKey_Model)), XmlInclude(typeof(ReactiveTestModel)),
    XmlInclude(typeof(SteamThumbnailModel))]
    public abstract class BaseModel { // : INotifyPropertyChanged {
        protected BaseModel() {
            if (this is SettingsModel) return;
            ((SettingsModel)SettingsController.GetInstance.Model()).Models.Add(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name) {
            Debug.WriteLine("Calling: OnPropertyChanged");
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}