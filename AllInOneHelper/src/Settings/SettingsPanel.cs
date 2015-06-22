using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.BPM {
    class SettingsPanel : UserControl {
        private GroupBox groupBox_settings_window;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private CheckBox cbox_settings_window_minimizeIntoTray;
        private GroupBox groupBox_settings_saveLoad;
        private Button b_settings_saveLoad_reset;
        private Button b_settings_saveLoad_load;
        private Button b_settings_saveLoad_save;
    
        public SettingsPanel() {
            InitializeComponent();

            registerEvents();
        }

        private void registerEvents() {
            EventHandler handler = new EventHandler(buttonEventListener);
            
        }

        private void buttonEventListener(object sender, System.EventArgs e) {
            Button button = (Button)sender;
            
        }

        private void InitializeComponent() {
            this.groupBox_settings_window = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbox_settings_window_minimizeIntoTray = new System.Windows.Forms.CheckBox();
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
            this.groupBox_settings_window.Controls.Add(this.checkBox2);
            this.groupBox_settings_window.Controls.Add(this.checkBox1);
            this.groupBox_settings_window.Controls.Add(this.cbox_settings_window_minimizeIntoTray);
            this.groupBox_settings_window.Location = new System.Drawing.Point(209, 3);
            this.groupBox_settings_window.Name = "groupBox_settings_window";
            this.groupBox_settings_window.Size = new System.Drawing.Size(127, 100);
            this.groupBox_settings_window.TabIndex = 3;
            this.groupBox_settings_window.TabStop = false;
            this.groupBox_settings_window.Text = "Window Settings";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(92, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Always on top";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Close into tray";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbox_settings_window_minimizeIntoTray
            // 
            this.cbox_settings_window_minimizeIntoTray.AutoSize = true;
            this.cbox_settings_window_minimizeIntoTray.Location = new System.Drawing.Point(6, 19);
            this.cbox_settings_window_minimizeIntoTray.Name = "cbox_settings_window_minimizeIntoTray";
            this.cbox_settings_window_minimizeIntoTray.Size = new System.Drawing.Size(106, 17);
            this.cbox_settings_window_minimizeIntoTray.TabIndex = 0;
            this.cbox_settings_window_minimizeIntoTray.Text = "Minimize into tray";
            this.cbox_settings_window_minimizeIntoTray.UseVisualStyleBackColor = true;
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
            // CustomPanel
            // 
            this.Controls.Add(this.groupBox_settings_window);
            this.Controls.Add(this.groupBox_settings_saveLoad);
            this.Name = "CustomPanel";
            this.Size = new System.Drawing.Size(379, 169);
            this.groupBox_settings_window.ResumeLayout(false);
            this.groupBox_settings_window.PerformLayout();
            this.groupBox_settings_saveLoad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void close() {

        }
    }
}
