using AllInOneHelper.src.Modules;
using AllInOneHelper.src.Modules.AspectRatio;
using AllInOneHelper.src.Modules.BPM;
using AllInOneHelper.src.Modules.ClickSpeed;
using AllInOneHelper.src.Modules.ClipboardHistory;
using AllInOneHelper.src.Modules.CopyFinder;
using AllInOneHelper.src.Modules.DeleteEmpty;
using AllInOneHelper.src.Modules.KeyboardRecord;
using AllInOneHelper.src.Modules.MassFileManipulation;
using AllInOneHelper.src.Modules.MouseRecord;
using AllInOneHelper.src.Modules.ReactiveTest;
using AllInOneHelper.src.Modules.SteamThumbnailDeleter;
using AllInOneHelper.src.Settings;
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

        //Panels
        AspectRatioPanel ARPanel;
        BPMPanel BPMPanel;
        ClickSpeedPanel CSPanel;
        ClipboardPanel CBPanel;
        CopyFinderPanel CFPanel;
        DeleteEmptyPanel DEPanel;
        KeyboardRecordPanel KRPanel;
        MassFileManipulationPanel MFMPanel;
        MouseRecord_Panel MRPanel;
        ReactiveTestPanel RTPanel;
        SteamThumbnailPanel STPanel;
        SettingsPanel SPanel;

        //Constructor
        private GUI() {
            GUI.gui = this;

            InitializeComponent();

            InitializeModules();
        }

        private void InitializeModules() {
            //AspectRatio
            initSingleModule(ARPanel = new AspectRatioPanel(), tabPage_main_aspectRatio);
            initSingleModule(BPMPanel = new BPMPanel(), tabPage_main_bpm);
            initSingleModule(CSPanel = new ClickSpeedPanel(), tabPage_main_clickSpeed);
            initSingleModule(CBPanel = new ClipboardPanel(), tabPage_main_clipboard);
            initSingleModule(CFPanel = new CopyFinderPanel(), tabPage_main_copyFinder);
            initSingleModule(DEPanel = new DeleteEmptyPanel(), tabPage_main_deleteEmpty);
            //initSingleModule(KRPanel = new KeyboardRecordPanel(), tabPage_main_keyboardRecord);
            initSingleModule(MFMPanel = new MassFileManipulationPanel(), tabPage_main_fileManipulation);
            initSingleModule(MRPanel = new MouseRecord_Panel(), tabPage_main_mouseRecord);
            initSingleModule(RTPanel = new ReactiveTestPanel(), tabPage_main_reactiveTest);
            initSingleModule(STPanel = new SteamThumbnailPanel(), tabPage_main_steamThumbnailDeleter);
            initSingleModule(SPanel = new SettingsPanel(), tabPage_main_settings);
        }

        private void initSingleModule(UserControl control, TabPage page) {
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);
        }

        #region Non-Module-Events
        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);

            ARPanel.close();
            BPMPanel.close();
            CSPanel.close();
            CBPanel.close();
            CFPanel.close();
            DEPanel.close();
            //KRPanel.close();
            MRPanel.close();
            MFMPanel.close();
            RTPanel.close();
            STPanel.close();
            SPanel.close();

            RedrawThread.closeAll();
        }
        #endregion
    }
}
