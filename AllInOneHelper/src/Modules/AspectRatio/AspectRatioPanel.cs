using System;
using System.Drawing;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.AspectRatio {
    class AspectRatioPanel : BasePanel {
        private Button b_aspectRatio_calcRatio;
        private Button b_aspectRatio_calcHeight;
        private Button b_aspectRatio_calcWidth;
        private TextBox tb_aspectRatio_ratio;
        private TextBox tb_aspectRatio_height;
        private TextBox tb_aspectRatio_width;
        private TextBox tb_aspectRatio_info;

        private AspectRatioController _controller;

        public AspectRatioPanel(TabPage tabPageMainAspectRatio) : base(tabPageMainAspectRatio) {}

        protected override void RegisterEvents() {
            _controller = new AspectRatioController(this);

            EventHandler tbChangeHandler = _controller.DataChange;
            tb_aspectRatio_ratio.TextChanged += tbChangeHandler;
            tb_aspectRatio_height.TextChanged += tbChangeHandler;
            tb_aspectRatio_width.TextChanged += tbChangeHandler;

            b_aspectRatio_calcWidth.Click += _controller.CalcWidth;
            b_aspectRatio_calcHeight.Click += _controller.CalcHeight;
            b_aspectRatio_calcRatio.Click += _controller.CalcRatio;
        }

        public override void UpdateView() {
            AspectRatioModel model = (AspectRatioModel)_controller.Model();
            tb_aspectRatio_ratio.Text = model.LastRatio;
            tb_aspectRatio_height.Text = model.LastHeight;
            tb_aspectRatio_width.Text = model.LastWidth;
        }

        public override BaseController GetController() {
            return _controller;
        }

        public override void Close() {}

        protected override void InitializeComponent() {
            this.b_aspectRatio_calcRatio = new Button();
            this.b_aspectRatio_calcHeight = new Button();
            this.b_aspectRatio_calcWidth = new Button();
            this.tb_aspectRatio_ratio = new TextBox();
            this.tb_aspectRatio_height = new TextBox();
            this.tb_aspectRatio_width = new TextBox();
            this.tb_aspectRatio_info = new TextBox();
            this.SuspendLayout();
            // 
            // b_aspectRatio_calcRatio
            // 
            this.b_aspectRatio_calcRatio.Location = new Point(879, 43);
            this.b_aspectRatio_calcRatio.Name = "b_aspectRatio_calcRatio";
            this.b_aspectRatio_calcRatio.Size = new Size(165, 72);
            this.b_aspectRatio_calcRatio.TabIndex = 13;
            this.b_aspectRatio_calcRatio.Text = "Calculate Ratio";
            this.b_aspectRatio_calcRatio.UseVisualStyleBackColor = true;
            // 
            // b_aspectRatio_calcHeight
            // 
            this.b_aspectRatio_calcHeight.Location = new Point(708, 43);
            this.b_aspectRatio_calcHeight.Name = "b_aspectRatio_calcHeight";
            this.b_aspectRatio_calcHeight.Size = new Size(165, 72);
            this.b_aspectRatio_calcHeight.TabIndex = 12;
            this.b_aspectRatio_calcHeight.Text = "Calculate Height";
            this.b_aspectRatio_calcHeight.UseVisualStyleBackColor = true;
            // 
            // b_aspectRatio_calcWidth
            // 
            this.b_aspectRatio_calcWidth.Location = new Point(537, 44);
            this.b_aspectRatio_calcWidth.Name = "b_aspectRatio_calcWidth";
            this.b_aspectRatio_calcWidth.Size = new Size(165, 72);
            this.b_aspectRatio_calcWidth.TabIndex = 11;
            this.b_aspectRatio_calcWidth.Text = "Calculate Width";
            this.b_aspectRatio_calcWidth.UseVisualStyleBackColor = true;
            // 
            // tb_aspectRatio_ratio
            // 
            this.tb_aspectRatio_ratio.Location = new Point(3, 96);
            this.tb_aspectRatio_ratio.MinimumSize = new Size(50, 20);
            this.tb_aspectRatio_ratio.Name = "tb_aspectRatio_ratio";
            this.tb_aspectRatio_ratio.Size = new Size(528, 20);
            this.tb_aspectRatio_ratio.TabIndex = 10;
            this.tb_aspectRatio_ratio.Text = "Ratio";
            // 
            // tb_aspectRatio_height
            // 
            this.tb_aspectRatio_height.Location = new Point(3, 70);
            this.tb_aspectRatio_height.MinimumSize = new Size(50, 20);
            this.tb_aspectRatio_height.Name = "tb_aspectRatio_height";
            this.tb_aspectRatio_height.Size = new Size(528, 20);
            this.tb_aspectRatio_height.TabIndex = 9;
            this.tb_aspectRatio_height.Text = "Height";
            // 
            // tb_aspectRatio_width
            // 
            this.tb_aspectRatio_width.Location = new Point(3, 44);
            this.tb_aspectRatio_width.MinimumSize = new Size(50, 20);
            this.tb_aspectRatio_width.Name = "tb_aspectRatio_width";
            this.tb_aspectRatio_width.Size = new Size(528, 20);
            this.tb_aspectRatio_width.TabIndex = 8;
            this.tb_aspectRatio_width.Text = "Width";
            // 
            // tb_aspectRatio_info
            // 
            this.tb_aspectRatio_info.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.tb_aspectRatio_info.Location = new Point(3, 3);
            this.tb_aspectRatio_info.Multiline = true;
            this.tb_aspectRatio_info.Name = "tb_aspectRatio_info";
            this.tb_aspectRatio_info.Size = new Size(1041, 35);
            this.tb_aspectRatio_info.TabIndex = 7;
            this.tb_aspectRatio_info.Text = "Information:\r\nCalculates the ASPECT RATIO with the given width and height.";
            this.tb_aspectRatio_info.TextAlign = HorizontalAlignment.Center;
            // 
            // UserPanel
            // 
            this.Controls.Add(this.b_aspectRatio_calcRatio);
            this.Controls.Add(this.b_aspectRatio_calcHeight);
            this.Controls.Add(this.b_aspectRatio_calcWidth);
            this.Controls.Add(this.tb_aspectRatio_ratio);
            this.Controls.Add(this.tb_aspectRatio_height);
            this.Controls.Add(this.tb_aspectRatio_width);
            this.Controls.Add(this.tb_aspectRatio_info);
            this.Name = "UserPanel";
            this.Size = new Size(1051, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
