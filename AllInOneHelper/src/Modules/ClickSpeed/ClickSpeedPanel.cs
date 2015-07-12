using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.src.Modules.ClickSpeed {
    class ClickSpeedPanel : BasePanel {
        private TextBox tb_clickSpeed_acc;
        private TextBox tb_clickSpeed_info;
        private ClickSpeedController controller;
        private Button b_clickSpeed_reset;
        private Label l_clickSpeed_acc;

        public ClickSpeedPanel(TabPage tabPage) : base(tabPage){}

        protected override void RegisterEvents() {
            b_clickSpeed_reset.Click += new EventHandler(controller.Reset);
            tb_clickSpeed_acc.TextChanged += new EventHandler(ResetClickSpeed);
        }

        private void ResetClickSpeed(object sender, System.EventArgs e) {
            try {
                controller.Acc = Convert.ToInt32(tb_clickSpeed_acc.Text);
            } catch(FormatException) { }
        }

        protected override void InitializeComponent() {
            this.tb_clickSpeed_acc = new System.Windows.Forms.TextBox();
            this.tb_clickSpeed_info = new System.Windows.Forms.TextBox();
            this.l_clickSpeed_acc = new System.Windows.Forms.Label();
            this.controller = new AllInOneHelper.src.Modules.ClickSpeed.ClickSpeedController();
            this.b_clickSpeed_reset = new System.Windows.Forms.Button();
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
            this.tb_clickSpeed_info.Size = new System.Drawing.Size(930, 36);
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
            // panel_clickSpeed_clickSpeed
            // 
            this.controller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controller.Location = new System.Drawing.Point(11, 70);
            this.controller.Name = "controller";
            this.controller.Size = new System.Drawing.Size(922, 477);
            this.controller.TabIndex = 8;
            // 
            // b_clickSpeed_reset
            // 
            this.b_clickSpeed_reset.Location = new System.Drawing.Point(146, 41);
            this.b_clickSpeed_reset.Name = "b_clickSpeed_reset";
            this.b_clickSpeed_reset.Size = new System.Drawing.Size(75, 23);
            this.b_clickSpeed_reset.TabIndex = 9;
            this.b_clickSpeed_reset.Text = "Reset";
            this.b_clickSpeed_reset.UseVisualStyleBackColor = true;
            // 
            // ClickSpeedPanel
            // 
            this.Controls.Add(this.b_clickSpeed_reset);
            this.Controls.Add(this.controller);
            this.Controls.Add(this.tb_clickSpeed_acc);
            this.Controls.Add(this.tb_clickSpeed_info);
            this.Controls.Add(this.l_clickSpeed_acc);
            this.Name = "ClickSpeedPanel";
            this.Size = new System.Drawing.Size(936, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override void Close() {

        }
    }
}
