using System;
using System.Xml.Serialization;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.BPM {
    [Serializable]
    public class BPMModel : BaseModel {
        [XmlIgnore]
        public int AverageBPM { get; set; }
        [XmlIgnore]
        public int CurrentBPM { get; set; }
    }
}
