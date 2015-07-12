using System;
using System.IO;

namespace AllInOneHelper.Modules.Base {
    [Serializable]
    public abstract class BaseController {
        public BaseModel Model { get; set; }

        protected BaseController() {
            
        }

        public abstract void Close();

        public abstract void Serialize(FileStream fileStream);
        public abstract BasePanel Deserialize();
    }
}
