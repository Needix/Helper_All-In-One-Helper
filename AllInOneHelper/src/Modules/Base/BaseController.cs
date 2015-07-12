using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules.Base {
    abstract class BaseController {
        protected BaseController() {
            
        }

        public abstract void Close();
    }
}
