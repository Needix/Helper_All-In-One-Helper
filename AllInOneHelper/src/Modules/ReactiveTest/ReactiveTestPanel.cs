﻿using System.Drawing;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.ReactiveTest {
    class ReactiveTestPanel : BasePanel {
        private ReactiveTestController _controller;

        public ReactiveTestPanel(TabPage page) : base(page) {}

        protected override void RegisterEvents() {
            _controller = new ReactiveTestController(this);
            //EventHandler handler = new EventHandler(controller.);
            
        }

        public override void UpdateView() {
            ReactiveTestModel model = (ReactiveTestModel)_controller.Model();
        }

        public override BaseController GetController() {
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
