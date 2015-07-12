using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.src.Modules.SteamThumbnailDeleter {
    class SteamThumbnailPanel : BasePanel {
        private Label l_steamTD_deletedFolder;
        private Button b_steamTD_deleteAll;

        private SteamThumbnailController controller;

        public SteamThumbnailPanel(TabPage tabPage) : base(tabPage){}

        protected override void RegisterEvents() {
            controller = new SteamThumbnailController(this);
        }

        protected override void InitializeComponent() {
            this.l_steamTD_deletedFolder = new System.Windows.Forms.Label();
            this.b_steamTD_deleteAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_steamTD_deletedFolder
            // 
            this.l_steamTD_deletedFolder.AutoSize = true;
            this.l_steamTD_deletedFolder.Location = new System.Drawing.Point(3, 29);
            this.l_steamTD_deletedFolder.Name = "l_steamTD_deletedFolder";
            this.l_steamTD_deletedFolder.Size = new System.Drawing.Size(133, 13);
            this.l_steamTD_deletedFolder.TabIndex = 3;
            this.l_steamTD_deletedFolder.Text = "Deleted thumbnail folder: 0";
            // 
            // b_steamTD_deleteAll
            // 
            this.b_steamTD_deleteAll.Location = new System.Drawing.Point(3, 3);
            this.b_steamTD_deleteAll.Name = "b_steamTD_deleteAll";
            this.b_steamTD_deleteAll.Size = new System.Drawing.Size(1065, 23);
            this.b_steamTD_deleteAll.TabIndex = 2;
            this.b_steamTD_deleteAll.Text = "Delete all thumbnail folder from steam screenshots";
            this.b_steamTD_deleteAll.UseVisualStyleBackColor = true;
            // 
            // CustomPanel
            // 
            this.Controls.Add(this.l_steamTD_deletedFolder);
            this.Controls.Add(this.b_steamTD_deleteAll);
            this.Name = "CustomPanel";
            this.Size = new System.Drawing.Size(1072, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override void Close() {

        }
    }
}
