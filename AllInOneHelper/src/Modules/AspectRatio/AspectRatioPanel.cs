using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules {
    class AspectRatioPanel : UserControl {
        private Button b_aspectRatio_calcRatio;
        private Button b_aspectRatio_calcHeight;
        private Button b_aspectRatio_calcWidth;
        private TextBox tb_aspectRatio_ratio;
        private TextBox tb_aspectRatio_height;
        private TextBox tb_aspectRatio_width;
        private TextBox tb_aspectRatio_info;

        public AspectRatioPanel() {
            InitializeComponent();

            registerEvents();
        }

        private void registerEvents() {
            EventHandler handler = new EventHandler(buttonEventListener);
            b_aspectRatio_calcWidth.Click += handler;
            b_aspectRatio_calcHeight.Click += handler;
            b_aspectRatio_calcRatio.Click += handler;
        }

        private void buttonEventListener(object sender, System.EventArgs e) {
            Button button = (Button)sender;
            String s_width = tb_aspectRatio_width.Text;
            String s_height = tb_aspectRatio_height.Text;
            String ratio = tb_aspectRatio_ratio.Text;

            int width = 0;
            int height = 0;

            try {
                width = Convert.ToInt32(tb_aspectRatio_width.Text);
                height = Convert.ToInt32(tb_aspectRatio_height.Text);
                System.Diagnostics.Debug.WriteLine("");
                if(button.Name == "b_aspectRatio_calcWidth")
                    tb_aspectRatio_width.Text = AspectRatio.AspectRatio.calcWidth(height, ratio) + "";
                else if(button.Name == "b_aspectRatio_calcHeight")
                    tb_aspectRatio_height.Text = AspectRatio.AspectRatio.calcHeight(width, ratio) + "";
                else if(button.Name == "b_aspectRatio_calcRatio")
                    tb_aspectRatio_ratio.Text = AspectRatio.AspectRatio.calcRatio(width, height);
                else
                    Console.WriteLine("Error");
            } catch(System.FormatException) {
                if(width == 0) {
                    Console.WriteLine(s_width + " is not a number!");
                } else {
                    Console.WriteLine(s_height + " is not a number!");
                }
            }
        }

        private void InitializeComponent() {
            this.b_aspectRatio_calcRatio = new System.Windows.Forms.Button();
            this.b_aspectRatio_calcHeight = new System.Windows.Forms.Button();
            this.b_aspectRatio_calcWidth = new System.Windows.Forms.Button();
            this.tb_aspectRatio_ratio = new System.Windows.Forms.TextBox();
            this.tb_aspectRatio_height = new System.Windows.Forms.TextBox();
            this.tb_aspectRatio_width = new System.Windows.Forms.TextBox();
            this.tb_aspectRatio_info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_aspectRatio_calcRatio
            // 
            this.b_aspectRatio_calcRatio.Location = new System.Drawing.Point(879, 43);
            this.b_aspectRatio_calcRatio.Name = "b_aspectRatio_calcRatio";
            this.b_aspectRatio_calcRatio.Size = new System.Drawing.Size(165, 72);
            this.b_aspectRatio_calcRatio.TabIndex = 13;
            this.b_aspectRatio_calcRatio.Text = "Calculate Ratio";
            this.b_aspectRatio_calcRatio.UseVisualStyleBackColor = true;
            // 
            // b_aspectRatio_calcHeight
            // 
            this.b_aspectRatio_calcHeight.Location = new System.Drawing.Point(708, 43);
            this.b_aspectRatio_calcHeight.Name = "b_aspectRatio_calcHeight";
            this.b_aspectRatio_calcHeight.Size = new System.Drawing.Size(165, 72);
            this.b_aspectRatio_calcHeight.TabIndex = 12;
            this.b_aspectRatio_calcHeight.Text = "Calculate Height";
            this.b_aspectRatio_calcHeight.UseVisualStyleBackColor = true;
            // 
            // b_aspectRatio_calcWidth
            // 
            this.b_aspectRatio_calcWidth.Location = new System.Drawing.Point(537, 44);
            this.b_aspectRatio_calcWidth.Name = "b_aspectRatio_calcWidth";
            this.b_aspectRatio_calcWidth.Size = new System.Drawing.Size(165, 72);
            this.b_aspectRatio_calcWidth.TabIndex = 11;
            this.b_aspectRatio_calcWidth.Text = "Calculate Width";
            this.b_aspectRatio_calcWidth.UseVisualStyleBackColor = true;
            // 
            // tb_aspectRatio_ratio
            // 
            this.tb_aspectRatio_ratio.Location = new System.Drawing.Point(3, 96);
            this.tb_aspectRatio_ratio.MinimumSize = new System.Drawing.Size(50, 20);
            this.tb_aspectRatio_ratio.Name = "tb_aspectRatio_ratio";
            this.tb_aspectRatio_ratio.Size = new System.Drawing.Size(528, 20);
            this.tb_aspectRatio_ratio.TabIndex = 10;
            this.tb_aspectRatio_ratio.Text = "Ratio";
            // 
            // tb_aspectRatio_height
            // 
            this.tb_aspectRatio_height.Location = new System.Drawing.Point(3, 70);
            this.tb_aspectRatio_height.MinimumSize = new System.Drawing.Size(50, 20);
            this.tb_aspectRatio_height.Name = "tb_aspectRatio_height";
            this.tb_aspectRatio_height.Size = new System.Drawing.Size(528, 20);
            this.tb_aspectRatio_height.TabIndex = 9;
            this.tb_aspectRatio_height.Text = "Height";
            // 
            // tb_aspectRatio_width
            // 
            this.tb_aspectRatio_width.Location = new System.Drawing.Point(3, 44);
            this.tb_aspectRatio_width.MinimumSize = new System.Drawing.Size(50, 20);
            this.tb_aspectRatio_width.Name = "tb_aspectRatio_width";
            this.tb_aspectRatio_width.Size = new System.Drawing.Size(528, 20);
            this.tb_aspectRatio_width.TabIndex = 8;
            this.tb_aspectRatio_width.Text = "Width";
            // 
            // tb_aspectRatio_info
            // 
            this.tb_aspectRatio_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_aspectRatio_info.Location = new System.Drawing.Point(3, 3);
            this.tb_aspectRatio_info.Multiline = true;
            this.tb_aspectRatio_info.Name = "tb_aspectRatio_info";
            this.tb_aspectRatio_info.Size = new System.Drawing.Size(1041, 35);
            this.tb_aspectRatio_info.TabIndex = 7;
            this.tb_aspectRatio_info.Text = "Information:\r\nCalculates the ASPECT RATIO with the given width and height.";
            this.tb_aspectRatio_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.Size = new System.Drawing.Size(1051, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void close() {

        }
    }
}
