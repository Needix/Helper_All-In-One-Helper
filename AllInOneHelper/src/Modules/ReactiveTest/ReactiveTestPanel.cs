﻿using System;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.ReactiveTest {
    class ReactiveTestPanel : BasePanel {
        private ReactiveTestController _controller;

        public ReactiveTestPanel(TabPage page) : base(page) {}

        protected override void RegisterEvents() {
            _controller = new ReactiveTestController(this);
            //EventHandler handler = new EventHandler(controller.);
            
        }

        public override BaseController GetController() {
            return _controller;
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
