using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.BPM {
    class MassFileManipulationPanel : UserControl {
        public MassFileManipulationPanel() {
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
            this.SuspendLayout();
            // 
            // CustomPanel
            // 
            this.Name = "CustomPanel";
            this.Size = new System.Drawing.Size(221, 199);
            this.ResumeLayout(false);

        }

        public void close() {

        }
    }
}
