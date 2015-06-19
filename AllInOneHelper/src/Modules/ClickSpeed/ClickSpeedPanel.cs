using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.BPM {
    class ClickSpeedPanel : UserControl {
        private TextBox tb_clickSpeed_acc;
        private TextBox tb_clickSpeed_info;
        private Label l_clickSpeed_acc;

        public ClickSpeedPanel() {
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
            this.tb_clickSpeed_acc = new System.Windows.Forms.TextBox();
            this.tb_clickSpeed_info = new System.Windows.Forms.TextBox();
            this.l_clickSpeed_acc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_clickSpeed_acc
            // 
            this.tb_clickSpeed_acc.Location = new System.Drawing.Point(72, 39);
            this.tb_clickSpeed_acc.Name = "tb_clickSpeed_acc";
            this.tb_clickSpeed_acc.Size = new System.Drawing.Size(68, 20);
            this.tb_clickSpeed_acc.TabIndex = 7;
            this.tb_clickSpeed_acc.Text = "5";
            // 
            // tb_clickSpeed_info
            // 
            this.tb_clickSpeed_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_clickSpeed_info.Location = new System.Drawing.Point(3, 3);
            this.tb_clickSpeed_info.Multiline = true;
            this.tb_clickSpeed_info.Name = "tb_clickSpeed_info";
            this.tb_clickSpeed_info.Size = new System.Drawing.Size(269, 36);
            this.tb_clickSpeed_info.TabIndex = 5;
            this.tb_clickSpeed_info.Text = "Information: \r\nClick as fast as you can on the chart below.";
            this.tb_clickSpeed_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_clickSpeed_acc
            // 
            this.l_clickSpeed_acc.AutoSize = true;
            this.l_clickSpeed_acc.Location = new System.Drawing.Point(8, 42);
            this.l_clickSpeed_acc.Name = "l_clickSpeed_acc";
            this.l_clickSpeed_acc.Size = new System.Drawing.Size(58, 13);
            this.l_clickSpeed_acc.TabIndex = 6;
            this.l_clickSpeed_acc.Text = "Accuracy: ";
            // 
            // CustomPanel
            // 
            this.Controls.Add(this.tb_clickSpeed_acc);
            this.Controls.Add(this.tb_clickSpeed_info);
            this.Controls.Add(this.l_clickSpeed_acc);
            this.Name = "CustomPanel";
            this.Size = new System.Drawing.Size(290, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
