using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.src.Modules.ReactiveTest {
    class ReactiveTestPanel : BasePanel {
        private ReactiveTestController controller;

        public ReactiveTestPanel(TabPage page) : base(page) {}

        protected override void RegisterEvents() {
            controller = new ReactiveTestController(this);
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
