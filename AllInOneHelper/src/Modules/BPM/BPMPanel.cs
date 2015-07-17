using System;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.BPM {
    class BPMPanel : BasePanel {
        private RadioButton radio_bpm_visualBPM;
        public Label l_bpm_averageBPM;
        public Label l_bpm_curBPM;
        private Button b_bpm_reset;
        private Button b_bpm_tap;
        private TextBox tb_bpm_info;

        private BPMController _controller;

        public BPMPanel(TabPage tabPage) : base(tabPage) { }

        //TODO Implement visual BPM
        protected override void RegisterEvents() {
            _controller = new BPMController(this);

            b_bpm_tap.Click += new EventHandler(_controller.Click);
            b_bpm_reset.Click += new EventHandler(_controller.Reset);
        }

        protected override void InitializeComponent() {
            this.radio_bpm_visualBPM = new System.Windows.Forms.RadioButton();
            this.l_bpm_averageBPM = new System.Windows.Forms.Label();
            this.l_bpm_curBPM = new System.Windows.Forms.Label();
            this.b_bpm_reset = new System.Windows.Forms.Button();
            this.b_bpm_tap = new System.Windows.Forms.Button();
            this.tb_bpm_info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // radio_bpm_visualBPM
            // 
            this.radio_bpm_visualBPM.AutoSize = true;
            this.radio_bpm_visualBPM.Location = new System.Drawing.Point(410, 48);
            this.radio_bpm_visualBPM.Name = "radio_bpm_visualBPM";
            this.radio_bpm_visualBPM.Size = new System.Drawing.Size(79, 17);
            this.radio_bpm_visualBPM.TabIndex = 12;
            this.radio_bpm_visualBPM.TabStop = true;
            this.radio_bpm_visualBPM.Text = "Visual BPM";
            this.radio_bpm_visualBPM.UseVisualStyleBackColor = true;
            // 
            // l_bpm_averageBPM
            // 
            this.l_bpm_averageBPM.AutoSize = true;
            this.l_bpm_averageBPM.Location = new System.Drawing.Point(273, 50);
            this.l_bpm_averageBPM.Name = "l_bpm_averageBPM";
            this.l_bpm_averageBPM.Size = new System.Drawing.Size(85, 13);
            this.l_bpm_averageBPM.TabIndex = 11;
            this.l_bpm_averageBPM.Text = "Average BPM: 0";
            // 
            // l_bpm_curBPM
            // 
            this.l_bpm_curBPM.AutoSize = true;
            this.l_bpm_curBPM.Location = new System.Drawing.Point(164, 50);
            this.l_bpm_curBPM.Name = "l_bpm_curBPM";
            this.l_bpm_curBPM.Size = new System.Drawing.Size(79, 13);
            this.l_bpm_curBPM.TabIndex = 10;
            this.l_bpm_curBPM.Text = "Current BPM: 0";
            // 
            // b_bpm_reset
            // 
            this.b_bpm_reset.Location = new System.Drawing.Point(95, 45);
            this.b_bpm_reset.Name = "b_bpm_reset";
            this.b_bpm_reset.Size = new System.Drawing.Size(63, 23);
            this.b_bpm_reset.TabIndex = 9;
            this.b_bpm_reset.Text = "Reset";
            this.b_bpm_reset.UseVisualStyleBackColor = true;
            // 
            // b_bpm_tap
            // 
            this.b_bpm_tap.Location = new System.Drawing.Point(3, 45);
            this.b_bpm_tap.Name = "b_bpm_tap";
            this.b_bpm_tap.Size = new System.Drawing.Size(86, 23);
            this.b_bpm_tap.TabIndex = 8;
            this.b_bpm_tap.Text = "Tap Tap Tap";
            this.b_bpm_tap.UseVisualStyleBackColor = true;
            // 
            // tb_bpm_info
            // 
            this.tb_bpm_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_bpm_info.Location = new System.Drawing.Point(3, 3);
            this.tb_bpm_info.Multiline = true;
            this.tb_bpm_info.Name = "tb_bpm_info";
            this.tb_bpm_info.Size = new System.Drawing.Size(538, 36);
            this.tb_bpm_info.TabIndex = 7;
            this.tb_bpm_info.Text = "Information: \r\nMeasures the BPM of your tapping. Tap with same speed gives best r" +
    "esult. Click the reset button to reset it.";
            this.tb_bpm_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BPMPanel
            // 
            this.Controls.Add(this.radio_bpm_visualBPM);
            this.Controls.Add(this.l_bpm_averageBPM);
            this.Controls.Add(this.l_bpm_curBPM);
            this.Controls.Add(this.b_bpm_reset);
            this.Controls.Add(this.b_bpm_tap);
            this.Controls.Add(this.tb_bpm_info);
            this.Name = "BPMPanel";
            this.Size = new System.Drawing.Size(544, 207);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override BaseController GetController() {
            return _controller;
        }

        public override void Close() {

        }
    }
}
