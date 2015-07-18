using System.Drawing;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.ReactiveTest {
    class ReactiveTestPanel : BasePanel {
        private ReactiveTestTest reactiveTestTest1;
        private Button b_reactiveTest_reset;
        private TextBox tb_aspectRatio_info;
        private ReactiveTestController _controller;

        public ReactiveTestPanel(TabPage page) : base(page) {}

        protected override void RegisterEvents() {
            _controller = new ReactiveTestController(this);
            b_reactiveTest_reset.Click += reactiveTestTest1.Reset;

        }

        public override void UpdateView() {
            ReactiveTestModel model = (ReactiveTestModel)_controller.Model();
        }

        public override BaseController GetController() {
            return _controller;
        }

        public override void Close() {
            reactiveTestTest1.Close();
        }

        protected override void InitializeComponent() {
            this.reactiveTestTest1 = new AllInOneHelper.Modules.ReactiveTest.ReactiveTestTest();
            this.b_reactiveTest_reset = new System.Windows.Forms.Button();
            this.tb_aspectRatio_info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // reactiveTestTest1
            // 
            this.reactiveTestTest1.Location = new System.Drawing.Point(4, 70);
            this.reactiveTestTest1.Name = "reactiveTestTest1";
            this.reactiveTestTest1.Size = new System.Drawing.Size(585, 295);
            this.reactiveTestTest1.TabIndex = 0;
            // 
            // b_reactiveTest_reset
            // 
            this.b_reactiveTest_reset.Location = new System.Drawing.Point(4, 3);
            this.b_reactiveTest_reset.Name = "b_reactiveTest_reset";
            this.b_reactiveTest_reset.Size = new System.Drawing.Size(75, 61);
            this.b_reactiveTest_reset.TabIndex = 1;
            this.b_reactiveTest_reset.Text = "Reset";
            this.b_reactiveTest_reset.UseVisualStyleBackColor = true;
            // 
            // tb_aspectRatio_info
            // 
            this.tb_aspectRatio_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_aspectRatio_info.Location = new System.Drawing.Point(85, 5);
            this.tb_aspectRatio_info.Multiline = true;
            this.tb_aspectRatio_info.Name = "tb_aspectRatio_info";
            this.tb_aspectRatio_info.Size = new System.Drawing.Size(498, 59);
            this.tb_aspectRatio_info.TabIndex = 8;
            this.tb_aspectRatio_info.Text = "Information:\r\nClick on the white empty space to start the reactive test. \r\nEveryt" +
    "ime the red field switches to green, click on it. \r\nClick the reset Button to re" +
    "set your stats";
            this.tb_aspectRatio_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ReactiveTestPanel
            // 
            this.Controls.Add(this.tb_aspectRatio_info);
            this.Controls.Add(this.b_reactiveTest_reset);
            this.Controls.Add(this.reactiveTestTest1);
            this.Name = "ReactiveTestPanel";
            this.Size = new System.Drawing.Size(592, 368);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
