using System;

namespace AllInOneHelper.Modules.Base {
    [Serializable]
    abstract class BaseController {
        protected BaseController() {
            
        }

        public abstract void Close();
    }
}
