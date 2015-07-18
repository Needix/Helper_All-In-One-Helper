using System;
using System.Xml.Serialization;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.MouseRecord {
    public class MouseKey_Model : BaseModel {
        public MouseKey_Model() {
            RecStartEnabled = true;
            PlaybackStartEnabled = true;

        }

        public Boolean ShowAllFrames { get; set; }

        [XmlIgnore]
        public int RecordedFrames { get; set; }

        [XmlIgnore]
        public Boolean RecStartEnabled { get; set; }
        [XmlIgnore]
        public Boolean RecStopEnabled { get; set; }
        [XmlIgnore]
        public Boolean RecPauseChecked { get; set; }
        [XmlIgnore]
        public Boolean RecPauseEnabled { get; set; }
        [XmlIgnore]
        public Boolean RecResetEnabled { get; set; }

        [XmlIgnore]
        public Boolean PlaybackStartEnabled { get; set; }
        [XmlIgnore]
        public Boolean PlaybackStopEnabled { get; set; }

        [XmlIgnore]
        public Object[] PressedKeys { get; set; }
        [XmlIgnore]
        public int MaxPlaybackTime { get; set; }
        [XmlIgnore]
        public int CurPlaybackTime { get; set; }
    }
}
