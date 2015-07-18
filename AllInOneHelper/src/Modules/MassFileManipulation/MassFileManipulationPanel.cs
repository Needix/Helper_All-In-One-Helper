using System.Drawing;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.MassFileManipulation {
    class MassFileManipulationPanel : BasePanel {
        private MassFileManipulationController _controller;

        public MassFileManipulationPanel(TabPage tabPage) : base(tabPage){}

        protected override void RegisterEvents() {
            _controller = new MassFileManipulationController(this);
            //EventHandler handler = new EventHandler(controller.);
        }

        public override void UpdateView() {
            MassFileManipulationModel model = (MassFileManipulationModel)_controller.Model();
        }

        public override IBaseController GetController() {
            return _controller;
        }

        public override void Close() { }

        protected override void InitializeComponent() {
            this.SuspendLayout();
            // 
            // CustomPanel
            // 
            this.Name = "CustomPanel";
            this.Size = new Size(221, 199);
            this.ResumeLayout(false);
        }
    }
}
