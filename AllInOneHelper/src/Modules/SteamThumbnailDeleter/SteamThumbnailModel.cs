using System.Xml.Serialization;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.SteamThumbnailDeleter {
    public class SteamThumbnailModel : BaseModel {
        [XmlIgnore]
        public int DeletedFolder { get; set; }
    }
}
