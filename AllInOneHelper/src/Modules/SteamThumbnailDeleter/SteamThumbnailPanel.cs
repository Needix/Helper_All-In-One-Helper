using System.Drawing;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.SteamThumbnailDeleter {
    class SteamThumbnailPanel : BasePanel {
        private Label l_steamTD_deletedFolder;
        private Button b_steamTD_deleteAll;

        private SteamThumbnailController _controller;

        public SteamThumbnailPanel(TabPage tabPage) : base(tabPage){}

        protected override void RegisterEvents() {
            _controller = new SteamThumbnailController(this);
        }

        public override void UpdateView() {
            SteamThumbnailModel model = (SteamThumbnailModel)_controller.Model();
        }

        public override BaseController GetController() {
            return _controller;
        }

        public override void Close() { }

        protected override void InitializeComponent() {
            this.l_steamTD_deletedFolder = new Label();
            this.b_steamTD_deleteAll = new Button();
            this.SuspendLayout();
            // 
            // l_steamTD_deletedFolder
            // 
            this.l_steamTD_deletedFolder.AutoSize = true;
            this.l_steamTD_deletedFolder.Location = new Point(3, 29);
            this.l_steamTD_deletedFolder.Name = "l_steamTD_deletedFolder";
            this.l_steamTD_deletedFolder.Size = new Size(133, 13);
            this.l_steamTD_deletedFolder.TabIndex = 3;
            this.l_steamTD_deletedFolder.Text = "Deleted thumbnail folder: 0";
            // 
            // b_steamTD_deleteAll
            // 
            this.b_steamTD_deleteAll.Location = new Point(3, 3);
            this.b_steamTD_deleteAll.Name = "b_steamTD_deleteAll";
            this.b_steamTD_deleteAll.Size = new Size(1065, 23);
            this.b_steamTD_deleteAll.TabIndex = 2;
            this.b_steamTD_deleteAll.Text = "Delete all thumbnail folder from steam screenshots";
            this.b_steamTD_deleteAll.UseVisualStyleBackColor = true;
            // 
            // CustomPanel
            // 
            this.Controls.Add(this.l_steamTD_deletedFolder);
            this.Controls.Add(this.b_steamTD_deleteAll);
            this.Name = "CustomPanel";
            this.Size = new Size(1072, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
