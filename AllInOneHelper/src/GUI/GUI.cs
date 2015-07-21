using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;
using AllInOneHelper.Modules.AspectRatio;
using AllInOneHelper.Modules.BaseModule;
using AllInOneHelper.Modules.BPM;
using AllInOneHelper.Modules.ClickSpeed;
using AllInOneHelper.Modules.ClipboardHistory;
using AllInOneHelper.Modules.CopyFinder;
using AllInOneHelper.Modules.DeleteEmpty;
using AllInOneHelper.Modules.MassFileManipulation;
using AllInOneHelper.Modules.MouseRecord;
using AllInOneHelper.Modules.ReactiveTest;
using AllInOneHelper.Modules.SteamThumbnailDeleter;
using AllInOneHelper.Settings;

namespace AllInOneHelper.GUI {
    public partial class GUI : Form {
        //Constants

        //Variables
        private static GUI _gui;
        public static GUI GetInstance { //Singleton
            get { return _gui ?? (_gui = new GUI()); }
        }

        //public List<ModuleElement> ModuleElements { get; private set; }
        public List<BasePanel> ModuleList { get; private set; } 

        //Constructor
        private GUI() {
            _gui = this;

            ModuleList = new List<BasePanel>();

            InitializeComponent();

            InitializeEvents();

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
            LoadDefaultModules();

            if(File.Exists(SettingsController.SAVE_PATH)) LoadModelsFromFile();

            foreach(BasePanel curElement in ModuleList)
            {
                InitSingleModule(curElement, curElement.Page);
            }
        }

        private void LoadModelsFromFile() {
            SettingsController controller = (SettingsController)((SettingsPanel)ModuleList[0]).GetController();
            List<IBaseController> controllers = GetControllers();
            controller.LoadData(controllers);
        }

        private void LoadDefaultModules() {
            ModuleList.Add(new SettingsPanel(tabPage_main_settings));
            ModuleList.Add(new AspectRatioPanel(tabPage_main_aspectRatio));
            ModuleList.Add(new BPMPanel(tabPage_main_bpm));
            ModuleList.Add(new ClickSpeedPanel(tabPage_main_clickSpeed));
            ModuleList.Add(new ClipboardPanel(tabPage_main_clipboard));
            ModuleList.Add(new CopyFinderPanel(tabPage_main_copyFinder));
            ModuleList.Add(new DeleteEmptyPanel(tabPage_main_deleteEmpty));
            ModuleList.Add(new MassFileManipulationPanel(tabPage_main_fileManipulation));
            ModuleList.Add(new MouseKeyRecord_Panel(tabPage_main_mouseRecord));
            ModuleList.Add(new ReactiveTestPanel(tabPage_main_reactiveTest));
            ModuleList.Add(new SteamThumbnailPanel(tabPage_main_steamThumbnailDeleter));
        }

        private static void InitSingleModule(UserControl control, TabPage page) {
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);
        }

        public List<IBaseController> GetControllers() {
            List<IBaseController> controllers = new List<IBaseController>();
            foreach (BasePanel curPanel in ModuleList) {
                controllers.Add(curPanel.GetController());
            }
            return controllers;
        }

        #region Non-Module-Events
        private void InitializeEvents() {
            this.Resize += OnResize;
            this.FormClosing += OnClosing;
            notifyIcon_trayIcon.DoubleClick += OnResize;
        }

        protected void OnClosing(Object sender, FormClosingEventArgs e) {
            SettingsController controller = SettingsController.GetInstance;
            SettingsModel model = (SettingsModel) controller.Model();
            if(model.CloseIntoTray) {
                e.Cancel = true;
                notifyIcon_trayIcon.Visible = true;
                Hide();
                return;
            }

            controller.Serialize();

            foreach(BasePanel panel in ModuleList)
            {
                //Debug.WriteLine("Closing "+panel);
                panel.Close();
            }

            RedrawThread.CloseAll();
        }

        private void OnResize(object sender, EventArgs e) {
            SettingsModel model = (SettingsModel) SettingsController.GetInstance.Model();
            if(sender is NotifyIcon) {
                notifyIcon_trayIcon.Visible = false;
                Show();
                this.WindowState = FormWindowState.Normal;
                BringToFront();
            } else if(FormWindowState.Minimized == this.WindowState && model.MinimizeIntoTray) {
                notifyIcon_trayIcon.Visible = true;
                Hide();
            }
        }
        #endregion
    }
}
