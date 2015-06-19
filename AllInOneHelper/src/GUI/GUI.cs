using AllInOneHelper.src.Modules;
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

            InitializeModules();

            registerEvents();
        }

        private void InitializeModules() {
            AspectRatioPanel arPanel = new AspectRatioPanel();
            arPanel.Dock = DockStyle.Fill;
            tabPage_main_aspectRatio.Controls.Add(arPanel);
            //AspectRatio.init(new Control[] { tb_aspectRatio_info, tb_aspectRatio_width, tb_aspectRatio_height, tb_aspectRatio_ratio });
        }

        public void registerEvents() {
            //AspectRatio
            //EventHandler handler = new EventHandler(AspectRatio.buttonEventListener);
            //b_aspectRatio_calcWidth.Click += handler;
            //b_aspectRatio_calcHeight.Click += handler;
            //b_aspectRatio_calcRatio.Click += handler;
            //BPM

            //ClickSpeed

            //ClipboardHistory

            //CopyFinder

            //DeleteEmpty

            //KeyboardRecord

            //MassFileManipulation

            //MouseRecord

            //ReactiveTest

            //SteamThumbnailDeleter
        }

        #region Non-Module-Events
        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);

        }
        #endregion
    }
}
