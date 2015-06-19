using AllInOneHelper.src.Modules;
using AllInOneHelper.src.Modules.AspectRatio;
using AllInOneHelper.src.Modules.BPM;
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

            InitializeModules();
        }

        private void InitializeModules() {
            //AspectRatio
            initSingleModule(new AspectRatioPanel(), tabPage_main_aspectRatio);
            initSingleModule(new BPMPanel(), tabPage_main_bpm);
            initSingleModule(new ClickSpeedPanel(), tabPage_main_clickSpeed);
            initSingleModule(new ClipboardPanel(), tabPage_main_clipboard);
            initSingleModule(new CopyFinderPanel(), tabPage_main_copyFinder);
            initSingleModule(new DeleteEmptyPanel(), tabPage_main_deleteEmpty);
            //initSingleModule(new KeyboardRecordPanel(), tabPage_main_keyboardRecord);
            initSingleModule(new MassFileManipulationPanel(), tabPage_main_fileManipulation);
            initSingleModule(new MouseRecordPanel(), tabPage_main_mouseRecord);
            initSingleModule(new ReactiveTestPanel(), tabPage_main_reactiveTest);
            initSingleModule(new SteamThumbnailPanel(), tabPage_main_steamThumbnailDeleter);
            initSingleModule(new SettingsPanel(), tabPage_main_settings);
        }

        private void initSingleModule(UserControl control, TabPage page) {
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);
        }

        #region Non-Module-Events
        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);

        }
        #endregion
    }
}
