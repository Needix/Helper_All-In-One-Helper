using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.GUI {
    public partial class GUI : Form {
        //Constants

        //Variables
        private static GUI gui;
        public static GUI getInstance {
            get {
                if(GUI.gui == null)
                    GUI.gui = new GUI();
                return GUI.gui; 
            }
        }

        //Constructor
        private GUI() {
            InitializeComponent();

            GUI.gui = this;
        }

        #region Events
        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);

        }
        #endregion
    }
}
