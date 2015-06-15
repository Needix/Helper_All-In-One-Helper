using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AllInOneHelper {
    static class Program {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(src.GUI.GUI.getInstance);
        }
    }
}
