using System;
using System.Drawing;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.ClickSpeed {
    class ClickSpeedPanel : BasePanel {
        private TextBox tb_clickSpeed_acc;
        private TextBox tb_clickSpeed_info;
        private ClickSpeedView _view;
        private Button b_clickSpeed_reset;
        private Label l_clickSpeed_acc;

        public ClickSpeedPanel(TabPage tabPage) : base(tabPage){}

        protected override void RegisterEvents() {
            _view.BasePanel = this;

            b_clickSpeed_reset.Click += _view.Reset;
            tb_clickSpeed_acc.TextChanged += _view.AccuracyChanged;
        }

        public override void UpdateView() {
            ClickSpeedModel model = (ClickSpeedModel)_view.Model();
            tb_clickSpeed_acc.Text = model.Accuracy + "";
        }

        public override IBaseController GetController() {
            return _view;
        }

        public override void Close() { }

        protected override void InitializeComponent() {
            this.tb_clickSpeed_acc = new TextBox();
            this.tb_clickSpeed_info = new TextBox();
            this.l_clickSpeed_acc = new Label();
            this._view = new ClickSpeedView();
            this.b_clickSpeed_reset = new Button();
            this.SuspendLayout();
            // 
            // tb_clickSpeed_acc
            // 
            this.tb_clickSpeed_acc.Location = new Point(72, 39);
            this.tb_clickSpeed_acc.Name = "tb_clickSpeed_acc";
            this.tb_clickSpeed_acc.Size = new Size(68, 20);
            this.tb_clickSpeed_acc.TabIndex = 7;
            this.tb_clickSpeed_acc.Text = "5";
            // 
            // tb_clickSpeed_info
            // 
            this.tb_clickSpeed_info.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.tb_clickSpeed_info.Location = new Point(3, 3);
            this.tb_clickSpeed_info.Multiline = true;
            this.tb_clickSpeed_info.Name = "tb_clickSpeed_info";
            this.tb_clickSpeed_info.Size = new Size(930, 36);
            this.tb_clickSpeed_info.TabIndex = 5;
            this.tb_clickSpeed_info.Text = "Information: \r\nClick as fast as you can on the chart below.";
            this.tb_clickSpeed_info.TextAlign = HorizontalAlignment.Center;
            // 
            // l_clickSpeed_acc
            // 
            this.l_clickSpeed_acc.AutoSize = true;
            this.l_clickSpeed_acc.Location = new Point(8, 42);
            this.l_clickSpeed_acc.Name = "l_clickSpeed_acc";
            this.l_clickSpeed_acc.Size = new Size(58, 13);
            this.l_clickSpeed_acc.TabIndex = 6;
            this.l_clickSpeed_acc.Text = "Accuracy: ";
            // 
            // panel_clickSpeed_clickSpeed
            // 
            this._view.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this._view.Location = new Point(11, 70);
            this._view.Name = "_view";
            this._view.Size = new Size(922, 477);
            this._view.TabIndex = 8;
            // 
            // b_clickSpeed_reset
            // 
            this.b_clickSpeed_reset.Location = new Point(146, 41);
            this.b_clickSpeed_reset.Name = "b_clickSpeed_reset";
            this.b_clickSpeed_reset.Size = new Size(75, 23);
            this.b_clickSpeed_reset.TabIndex = 9;
            this.b_clickSpeed_reset.Text = "Reset";
            this.b_clickSpeed_reset.UseVisualStyleBackColor = true;
            // 
            // ClickSpeedPanel
            // 
            this.Controls.Add(this.b_clickSpeed_reset);
            this.Controls.Add(this._view);
            this.Controls.Add(this.tb_clickSpeed_acc);
            this.Controls.Add(this.tb_clickSpeed_info);
            this.Controls.Add(this.l_clickSpeed_acc);
            this.Name = "ClickSpeedPanel";
            this.Size = new Size(936, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
