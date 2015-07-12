using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using AllInOneHelper.Modules.AspectRatio;
using AllInOneHelper.Modules.Base;
using AllInOneHelper.Modules.BPM;
using AllInOneHelper.Modules.ClickSpeed;
using AllInOneHelper.Modules.ClipboardHistory;
using AllInOneHelper.Modules.CopyFinder;
using AllInOneHelper.Modules.DeleteEmpty;
using AllInOneHelper.Modules.MassFileManipulation;
using AllInOneHelper.Modules.MouseRecord;
using AllInOneHelper.Modules.SteamThumbnailDeleter;
using AllInOneHelper.Settings;

namespace AllInOneHelper.GUI {
    public partial class GUI : Form {
        //Constants

        //Variables
        private static GUI _gui;
        public static GUI GetInstance { //Singleton
            get { return GUI._gui ?? (GUI._gui = new GUI()); }
        }

        private readonly List<BasePanel> _modules = new List<BasePanel>();

        //Constructor
        private GUI() {
            GUI._gui = this;

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

        private void InitializeModules()
        {
            if(File.Exists(SettingsController.SAVE_PATH))
                LoadModulesFromFile();
            else
                LoadDefaultModules();

            foreach (BasePanel curElement in _modules)
            {
                InitSingleModule(curElement, curElement.Page);
            }
        }

        private static void LoadModulesFromFile() {
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

        private static void InitSingleModule(UserControl control, TabPage page) {
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
