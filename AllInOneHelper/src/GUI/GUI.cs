using AllInOneHelper.src.Modules.AspectRatio;
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
            GUI.gui = this;

            InitializeComponent();

            InitializeAllModules();
        }

        private void InitializeAllModules() {
            AspectRatio.init(
                new Button[3] { b_aspectRatio_calcWidth, b_aspectRatio_calcHeight, b_aspectRatio_calcRatio }
            );
        }

        #region Events
        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);

        }
        #endregion
    }
}
