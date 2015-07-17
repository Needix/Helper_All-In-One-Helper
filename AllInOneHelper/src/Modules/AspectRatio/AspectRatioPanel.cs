using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.AspectRatio {
    class AspectRatioPanel : BasePanel {
        public Button ButtonCalcRatio { get; set; }
        public Button ButtonCalcHeight { get; set; }
        public Button ButtonCalcWidth { get; set; }
        public TextBox TextBoxRatio { get; set; }
        public TextBox TextBoxHeight { get; set; }
        public TextBox TextBoxWidth { get; set; }
        public TextBox TextBoxInfo { get; set; }

        private AspectRatioController _controller;

        //public AspectRatioPanel() { }
        public AspectRatioPanel(TabPage tabPageMainAspectRatio) : base(tabPageMainAspectRatio) {}

        protected override void RegisterEvents() {
            _controller = new AspectRatioController(this);

            EventHandler tbChangeHandler = new EventHandler(_controller.DataChange);
            TextBoxRatio.TextChanged += tbChangeHandler;
            TextBoxHeight.TextChanged += tbChangeHandler;
            TextBoxWidth.TextChanged += tbChangeHandler;

            ButtonCalcWidth.Click += new EventHandler(_controller.CalcWidth);
            ButtonCalcHeight.Click += new EventHandler(_controller.CalcHeight);
            ButtonCalcRatio.Click += new EventHandler(_controller.CalcRatio);
        }

        protected override void InitializeComponent() {
            this.ButtonCalcRatio = new System.Windows.Forms.Button();
            this.ButtonCalcHeight = new System.Windows.Forms.Button();
            this.ButtonCalcWidth = new System.Windows.Forms.Button();
            this.TextBoxRatio = new System.Windows.Forms.TextBox();
            this.TextBoxHeight = new System.Windows.Forms.TextBox();
            this.TextBoxWidth = new System.Windows.Forms.TextBox();
            this.TextBoxInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_aspectRatio_calcRatio
            // 
            this.ButtonCalcRatio.Location = new System.Drawing.Point(879, 43);
            this.ButtonCalcRatio.Name = "b_aspectRatio_calcRatio";
            this.ButtonCalcRatio.Size = new System.Drawing.Size(165, 72);
            this.ButtonCalcRatio.TabIndex = 13;
            this.ButtonCalcRatio.Text = "Calculate Ratio";
            this.ButtonCalcRatio.UseVisualStyleBackColor = true;
            // 
            // b_aspectRatio_calcHeight
            // 
            this.ButtonCalcHeight.Location = new System.Drawing.Point(708, 43);
            this.ButtonCalcHeight.Name = "b_aspectRatio_calcHeight";
            this.ButtonCalcHeight.Size = new System.Drawing.Size(165, 72);
            this.ButtonCalcHeight.TabIndex = 12;
            this.ButtonCalcHeight.Text = "Calculate Height";
            this.ButtonCalcHeight.UseVisualStyleBackColor = true;
            // 
            // b_aspectRatio_calcWidth
            // 
            this.ButtonCalcWidth.Location = new System.Drawing.Point(537, 44);
            this.ButtonCalcWidth.Name = "b_aspectRatio_calcWidth";
            this.ButtonCalcWidth.Size = new System.Drawing.Size(165, 72);
            this.ButtonCalcWidth.TabIndex = 11;
            this.ButtonCalcWidth.Text = "Calculate Width";
            this.ButtonCalcWidth.UseVisualStyleBackColor = true;
            // 
            // tb_aspectRatio_ratio
            // 
            this.TextBoxRatio.Location = new System.Drawing.Point(3, 96);
            this.TextBoxRatio.MinimumSize = new System.Drawing.Size(50, 20);
            this.TextBoxRatio.Name = "tb_aspectRatio_ratio";
            this.TextBoxRatio.Size = new System.Drawing.Size(528, 20);
            this.TextBoxRatio.TabIndex = 10;
            this.TextBoxRatio.Text = "Ratio";
            // 
            // tb_aspectRatio_height
            // 
            this.TextBoxHeight.Location = new System.Drawing.Point(3, 70);
            this.TextBoxHeight.MinimumSize = new System.Drawing.Size(50, 20);
            this.TextBoxHeight.Name = "tb_aspectRatio_height";
            this.TextBoxHeight.Size = new System.Drawing.Size(528, 20);
            this.TextBoxHeight.TabIndex = 9;
            this.TextBoxHeight.Text = "Height";
            // 
            // tb_aspectRatio_width
            // 
            this.TextBoxWidth.Location = new System.Drawing.Point(3, 44);
            this.TextBoxWidth.MinimumSize = new System.Drawing.Size(50, 20);
            this.TextBoxWidth.Name = "tb_aspectRatio_width";
            this.TextBoxWidth.Size = new System.Drawing.Size(528, 20);
            this.TextBoxWidth.TabIndex = 8;
            this.TextBoxWidth.Text = "Width";
            // 
            // tb_aspectRatio_info
            // 
            this.TextBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxInfo.Location = new System.Drawing.Point(3, 3);
            this.TextBoxInfo.Multiline = true;
            this.TextBoxInfo.Name = "tb_aspectRatio_info";
            this.TextBoxInfo.Size = new System.Drawing.Size(1041, 35);
            this.TextBoxInfo.TabIndex = 7;
            this.TextBoxInfo.Text = "Information:\r\nCalculates the ASPECT RATIO with the given width and height.";
            this.TextBoxInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserPanel
            // 
            this.Controls.Add(this.ButtonCalcRatio);
            this.Controls.Add(this.ButtonCalcHeight);
            this.Controls.Add(this.ButtonCalcWidth);
            this.Controls.Add(this.TextBoxRatio);
            this.Controls.Add(this.TextBoxHeight);
            this.Controls.Add(this.TextBoxWidth);
            this.Controls.Add(this.TextBoxInfo);
            this.Name = "UserPanel";
            this.Size = new System.Drawing.Size(1051, 500);
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
