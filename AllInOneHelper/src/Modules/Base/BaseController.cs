using System;
using System.IO;

namespace AllInOneHelper.Modules.Base {
    public abstract class BaseController {
        //public BaseModel Model { get; set; }

        protected BaseController() {
            
        }

        public abstract void Update();
        public abstract void Close();
        public abstract BaseModel Model(BaseModel model = null);

        //public abstract void Serialize(FileStream fileStream);
        //public abstract BasePanel Deserialize();
    }
}
