using System;
using System.ComponentModel;
using System.Diagnostics;

namespace AllInOneHelper.Modules.Base {
    public abstract class BaseModel : INotifyPropertyChanged {
        protected BaseModel() {

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