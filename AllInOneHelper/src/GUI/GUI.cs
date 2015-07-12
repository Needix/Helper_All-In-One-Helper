using AllInOneHelper.src.Modules;
using AllInOneHelper.src.Modules.AspectRatio;
using AllInOneHelper.src.Modules.Base;
using AllInOneHelper.src.Modules.BPM;
using AllInOneHelper.src.Modules.ClickSpeed;
using AllInOneHelper.src.Modules.ClipboardHistory;
using AllInOneHelper.src.Modules.CopyFinder;
using AllInOneHelper.src.Modules.DeleteEmpty;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.src.GUI {
    public partial class GUI : Form {
        //Constants

        //Variables
        private static GUI gui;
        public static GUI getInstance { //Singleton
            get {
                if(GUI.gui == null)
                    GUI.gui = new GUI();
                return GUI.gui; 
            }
        }

        private readonly List<BasePanel> _modules = new List<BasePanel>();

        //Constructor
        private GUI() {
            GUI.gui = this;

            InitializeComponent();

            InitializeModules();
        }

        /*
        //TODO Implement Registe/Deregister behaviour
        public void RegisterModule(BasePanel module, TabPage page) {
            modules.Add(module);

            module.Dock = DockStyle.Fill;
            page.Controls.Add(module);

            this.tabControl_main.Controls.Add(page);
        }

        public void DeregisterModule(BasePanel module) {
            modules.Remove(module);
            
            //this.tabControl_main.Controls.Remove();
        }
        */

        private void InitializeModules() {
            if(File.Exists(SettingsController.SAVE_PATH))
                LoadModulesFromFile();
            else
                LoadDefaultModules();

            for(int i = 0; i < _modules.Count; i++) {
                BasePanel curElement = _modules[i];
                initSingleModule(curElement, curElement.Page);
            }
        }

        private void LoadModulesFromFile() {
            SettingsController controller = new SettingsController(null);
            List<BasePanel> panels = controller.LoadData();
        }

        private void LoadDefaultModules() {
            _modules.Add(new AspectRatioPanel(tabPage_main_aspectRatio));
            _modules.Add(new BPMPanel(tabPage_main_bpm));
            _modules.Add(new ClickSpeedPanel(tabPage_main_clickSpeed));
            _modules.Add(new ClipboardPanel(tabPage_main_clipboard));
            _modules.Add(new CopyFinderPanel(tabPage_main_copyFinder));
            _modules.Add(new DeleteEmptyPanel(tabPage_main_deleteEmpty));
            _modules.Add(new MassFileManipulationPanel(tabPage_main_fileManipulation));
            _modules.Add(new MouseKeyRecord_Panel(tabPage_main_mouseRecord));
            _modules.Add(new SteamThumbnailPanel(tabPage_main_steamThumbnailDeleter));
            _modules.Add(new SettingsPanel(tabPage_main_settings));
        }

        private void initSingleModule(UserControl control, TabPage page) {
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);
        }

        #region Non-Module-Events
        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);

            foreach (BasePanel panel in _modules)
            {
                panel.Close();
            }

            RedrawThread.CloseAll();
        }
        #endregion
    }
}
