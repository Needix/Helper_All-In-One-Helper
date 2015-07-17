using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Settings {
    class SettingsPanel : BasePanel {
        private GroupBox groupBox_settings_window;
        private CheckBox cbox_alwayOnTop;
        private CheckBox cbox_closeIntoTray;
        private CheckBox cbox_minimizeIntoTray;
        private GroupBox groupBox_settings_saveLoad;
        private Button b_settings_saveLoad_reset;
        private Button b_settings_saveLoad_load;
        private Button b_settings_saveLoad_save;

        private SettingsController _controller;

        //public SettingsPanel() { }
        public SettingsPanel(TabPage tabPage) : base(tabPage) { }

        protected override void RegisterEvents() {
            _controller = SettingsController.GetInstance;
            _controller.BasePanel = this;

            b_settings_saveLoad_save.Click += new EventHandler(_controller.SaveData);
            b_settings_saveLoad_load.Click += new EventHandler(_controller.LoadData);
            b_settings_saveLoad_reset.Click += new EventHandler(_controller.RevertToDefault);

            EventHandler dataChanged = new EventHandler(_controller.CBoxDataChanged);
            cbox_minimizeIntoTray.Click += dataChanged;
            cbox_closeIntoTray.Click += dataChanged;
            cbox_alwayOnTop.Click += dataChanged;
        }

        public void Update(Boolean alwaysOnTop, Boolean closeIntoTray, Boolean minimizeIntoTray) {
            cbox_closeIntoTray.Checked = closeIntoTray;
            cbox_alwayOnTop.Checked = alwaysOnTop;
            cbox_minimizeIntoTray.Checked = minimizeIntoTray;
        }

        protected override void InitializeComponent() {
            this.groupBox_settings_window = new System.Windows.Forms.GroupBox();
            this.cbox_alwayOnTop = new System.Windows.Forms.CheckBox();
            this.cbox_closeIntoTray = new System.Windows.Forms.CheckBox();
            this.cbox_minimizeIntoTray = new System.Windows.Forms.CheckBox();
            this.groupBox_settings_saveLoad = new System.Windows.Forms.GroupBox();
            this.b_settings_saveLoad_reset = new System.Windows.Forms.Button();
            this.b_settings_saveLoad_load = new System.Windows.Forms.Button();
            this.b_settings_saveLoad_save = new System.Windows.Forms.Button();
            this.groupBox_settings_window.SuspendLayout();
            this.groupBox_settings_saveLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_settings_window
            // 
            this.groupBox_settings_window.Controls.Add(this.cbox_alwayOnTop);
            this.groupBox_settings_window.Controls.Add(this.cbox_closeIntoTray);
            this.groupBox_settings_window.Controls.Add(this.cbox_minimizeIntoTray);
            this.groupBox_settings_window.Location = new System.Drawing.Point(209, 3);
            this.groupBox_settings_window.Name = "groupBox_settings_window";
            this.groupBox_settings_window.Size = new System.Drawing.Size(127, 100);
            this.groupBox_settings_window.TabIndex = 3;
            this.groupBox_settings_window.TabStop = false;
            this.groupBox_settings_window.Text = "Window Settings";
            // 
            // cbox_alwayOnTop
            // 
            this.cbox_alwayOnTop.AutoSize = true;
            this.cbox_alwayOnTop.Location = new System.Drawing.Point(6, 65);
            this.cbox_alwayOnTop.Name = "cbox_alwayOnTop";
            this.cbox_alwayOnTop.Size = new System.Drawing.Size(92, 17);
            this.cbox_alwayOnTop.TabIndex = 2;
            this.cbox_alwayOnTop.Text = "Always on top";
            this.cbox_alwayOnTop.UseVisualStyleBackColor = true;
            // 
            // cbox_closeIntoTray
            // 
            this.cbox_closeIntoTray.AutoSize = true;
            this.cbox_closeIntoTray.Location = new System.Drawing.Point(6, 42);
            this.cbox_closeIntoTray.Name = "cbox_closeIntoTray";
            this.cbox_closeIntoTray.Size = new System.Drawing.Size(92, 17);
            this.cbox_closeIntoTray.TabIndex = 1;
            this.cbox_closeIntoTray.Text = "Close into tray";
            this.cbox_closeIntoTray.UseVisualStyleBackColor = true;
            // 
            // cbox_minimizeIntoTray
            // 
            this.cbox_minimizeIntoTray.AutoSize = true;
            this.cbox_minimizeIntoTray.Location = new System.Drawing.Point(6, 19);
            this.cbox_minimizeIntoTray.Name = "cbox_minimizeIntoTray";
            this.cbox_minimizeIntoTray.Size = new System.Drawing.Size(106, 17);
            this.cbox_minimizeIntoTray.TabIndex = 0;
            this.cbox_minimizeIntoTray.Text = "Minimize into tray";
            this.cbox_minimizeIntoTray.UseVisualStyleBackColor = true;
            // 
            // groupBox_settings_saveLoad
            // 
            this.groupBox_settings_saveLoad.Controls.Add(this.b_settings_saveLoad_reset);
            this.groupBox_settings_saveLoad.Controls.Add(this.b_settings_saveLoad_load);
            this.groupBox_settings_saveLoad.Controls.Add(this.b_settings_saveLoad_save);
            this.groupBox_settings_saveLoad.Location = new System.Drawing.Point(3, 3);
            this.groupBox_settings_saveLoad.Name = "groupBox_settings_saveLoad";
            this.groupBox_settings_saveLoad.Size = new System.Drawing.Size(200, 114);
            this.groupBox_settings_saveLoad.TabIndex = 2;
            this.groupBox_settings_saveLoad.TabStop = false;
            this.groupBox_settings_saveLoad.Text = "Save/Load Settings";
            // 
            // b_settings_saveLoad_reset
            // 
            this.b_settings_saveLoad_reset.Location = new System.Drawing.Point(6, 77);
            this.b_settings_saveLoad_reset.Name = "b_settings_saveLoad_reset";
            this.b_settings_saveLoad_reset.Size = new System.Drawing.Size(188, 23);
            this.b_settings_saveLoad_reset.TabIndex = 2;
            this.b_settings_saveLoad_reset.Text = "Reset all settings";
            this.b_settings_saveLoad_reset.UseVisualStyleBackColor = true;
            // 
            // b_settings_saveLoad_load
            // 
            this.b_settings_saveLoad_load.Location = new System.Drawing.Point(6, 48);
            this.b_settings_saveLoad_load.Name = "b_settings_saveLoad_load";
            this.b_settings_saveLoad_load.Size = new System.Drawing.Size(188, 23);
            this.b_settings_saveLoad_load.TabIndex = 1;
            this.b_settings_saveLoad_load.Text = "Revert to user-default settings";
            this.b_settings_saveLoad_load.UseVisualStyleBackColor = true;
            // 
            // b_settings_saveLoad_save
            // 
            this.b_settings_saveLoad_save.Location = new System.Drawing.Point(6, 19);
            this.b_settings_saveLoad_save.Name = "b_settings_saveLoad_save";
            this.b_settings_saveLoad_save.Size = new System.Drawing.Size(188, 23);
            this.b_settings_saveLoad_save.TabIndex = 0;
            this.b_settings_saveLoad_save.Text = "Save current settings as default";
            this.b_settings_saveLoad_save.UseVisualStyleBackColor = true;
            // 
            // SettingsPanel
            // 
            this.Controls.Add(this.groupBox_settings_window);
            this.Controls.Add(this.groupBox_settings_saveLoad);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(379, 169);
            this.groupBox_settings_window.ResumeLayout(false);
            this.groupBox_settings_window.PerformLayout();
            this.groupBox_settings_saveLoad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public override BaseController GetController() {
            return _controller;
        }

        public override void Close() {

        }
    }
}
