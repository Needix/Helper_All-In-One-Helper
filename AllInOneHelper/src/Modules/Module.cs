using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllInOneHelper.src.Modules {
    abstract class Module {
        public static void registerEvent(System.Windows.Forms.Button[] buttons, Action<object, System.EventArgs> func) {
            EventHandler handler = new EventHandler(func);
            for(int i = 0; i < buttons.Length; i++) {
                buttons[i].Click += handler;
            }
        }
    }
}
