using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules {
    abstract class Module {
        private static Control[] controls;

        public static void init(Control[] p_controls) {
            controls = p_controls;
        }

        /// <summary>
        /// Searches the controls list for the a control with the given name
        /// </summary>
        /// <param name="name">The control name to search</param>
        /// <returns>The control with the given name or NULL if control could not be found.</returns>
        private static Control getControl(String name) {
            for(int i = 0; i < controls.Length; i++) {
                if(controls[i].Name == name)
                    return controls[i];
            }
            return null;
        }
    }
}
