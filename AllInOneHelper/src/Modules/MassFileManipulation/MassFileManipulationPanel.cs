using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.MassFileManipulation {
    class MassFileManipulationPanel : BasePanel {
        private MassFileManipulationController _controller;

        public MassFileManipulationPanel(TabPage tabPage) : base(tabPage){}

        protected override void RegisterEvents() {
            _controller = new MassFileManipulationController(this);
            //EventHandler handler = new EventHandler(controller.);
        }

        protected override void InitializeComponent() {
            this.SuspendLayout();
            // 
            // CustomPanel
            // 
            this.Name = "CustomPanel";
            this.Size = new System.Drawing.Size(221, 199);
            this.ResumeLayout(false);

        }

        public override void Close() {

        }
    }
}
