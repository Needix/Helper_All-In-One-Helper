﻿using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.MassFileManipulation {
    class MassFileManipulationPanel : BasePanel {
        private MassFileManipulationController controller;

        protected override void RegisterEvents() {
            controller = new MassFileManipulationController(this);
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
