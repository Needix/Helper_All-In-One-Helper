namespace AllInOneHelper.src.GUI {
    partial class GUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.main_tabPage_aspectRatio = new System.Windows.Forms.TabPage();
            this.main_tabPage_bpm = new System.Windows.Forms.TabPage();
            this.main_tabPage_clickSpeed = new System.Windows.Forms.TabPage();
            this.main_tabPage_clipboard = new System.Windows.Forms.TabPage();
            this.main_tabPage_copyFinder = new System.Windows.Forms.TabPage();
            this.main_tabPage_deleteEmpty = new System.Windows.Forms.TabPage();
            this.main_tabPage_fileManipulation = new System.Windows.Forms.TabPage();
            this.main_tabPage_mouseRecord = new System.Windows.Forms.TabPage();
            this.main_tabPage_keyboardRecord = new System.Windows.Forms.TabPage();
            this.main_tabPage_reactiveTest = new System.Windows.Forms.TabPage();
            this.main_tabPage_steamThumbnailDeleter = new System.Windows.Forms.TabPage();
            this.main_tabPage_settings = new System.Windows.Forms.TabPage();
            this.tb_aspectRatio_info = new System.Windows.Forms.TextBox();
            this.tb_aspectRatio_width = new System.Windows.Forms.TextBox();
            this.tb_aspectRatio_height = new System.Windows.Forms.TextBox();
            this.tb_aspectRatio_ratio = new System.Windows.Forms.TextBox();
            this.b_aspectRatio_calcWidth = new System.Windows.Forms.Button();
            this.b_aspectRatio_calcHeight = new System.Windows.Forms.Button();
            this.b_aspectRatio_calcRatio = new System.Windows.Forms.Button();
            this.tabControl_main.SuspendLayout();
            this.main_tabPage_aspectRatio.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.main_tabPage_aspectRatio);
            this.tabControl_main.Controls.Add(this.main_tabPage_bpm);
            this.tabControl_main.Controls.Add(this.main_tabPage_clickSpeed);
            this.tabControl_main.Controls.Add(this.main_tabPage_clipboard);
            this.tabControl_main.Controls.Add(this.main_tabPage_copyFinder);
            this.tabControl_main.Controls.Add(this.main_tabPage_deleteEmpty);
            this.tabControl_main.Controls.Add(this.main_tabPage_fileManipulation);
            this.tabControl_main.Controls.Add(this.main_tabPage_keyboardRecord);
            this.tabControl_main.Controls.Add(this.main_tabPage_mouseRecord);
            this.tabControl_main.Controls.Add(this.main_tabPage_reactiveTest);
            this.tabControl_main.Controls.Add(this.main_tabPage_steamThumbnailDeleter);
            this.tabControl_main.Controls.Add(this.main_tabPage_settings);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Multiline = true;
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(1084, 562);
            this.tabControl_main.TabIndex = 0;
            // 
            // main_tabPage_aspectRatio
            // 
            this.main_tabPage_aspectRatio.Controls.Add(this.b_aspectRatio_calcRatio);
            this.main_tabPage_aspectRatio.Controls.Add(this.b_aspectRatio_calcHeight);
            this.main_tabPage_aspectRatio.Controls.Add(this.b_aspectRatio_calcWidth);
            this.main_tabPage_aspectRatio.Controls.Add(this.tb_aspectRatio_ratio);
            this.main_tabPage_aspectRatio.Controls.Add(this.tb_aspectRatio_height);
            this.main_tabPage_aspectRatio.Controls.Add(this.tb_aspectRatio_width);
            this.main_tabPage_aspectRatio.Controls.Add(this.tb_aspectRatio_info);
            this.main_tabPage_aspectRatio.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_aspectRatio.Name = "main_tabPage_aspectRatio";
            this.main_tabPage_aspectRatio.Padding = new System.Windows.Forms.Padding(3);
            this.main_tabPage_aspectRatio.Size = new System.Drawing.Size(1076, 536);
            this.main_tabPage_aspectRatio.TabIndex = 0;
            this.main_tabPage_aspectRatio.Text = "Aspect Ratio";
            this.main_tabPage_aspectRatio.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_bpm
            // 
            this.main_tabPage_bpm.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_bpm.Name = "main_tabPage_bpm";
            this.main_tabPage_bpm.Padding = new System.Windows.Forms.Padding(3);
            this.main_tabPage_bpm.Size = new System.Drawing.Size(976, 536);
            this.main_tabPage_bpm.TabIndex = 1;
            this.main_tabPage_bpm.Text = "BPM Measurement";
            this.main_tabPage_bpm.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_clickSpeed
            // 
            this.main_tabPage_clickSpeed.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_clickSpeed.Name = "main_tabPage_clickSpeed";
            this.main_tabPage_clickSpeed.Size = new System.Drawing.Size(976, 536);
            this.main_tabPage_clickSpeed.TabIndex = 2;
            this.main_tabPage_clickSpeed.Text = "ClickSpeed";
            this.main_tabPage_clickSpeed.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_clipboard
            // 
            this.main_tabPage_clipboard.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_clipboard.Name = "main_tabPage_clipboard";
            this.main_tabPage_clipboard.Size = new System.Drawing.Size(976, 536);
            this.main_tabPage_clipboard.TabIndex = 3;
            this.main_tabPage_clipboard.Text = "Clipboard History";
            this.main_tabPage_clipboard.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_copyFinder
            // 
            this.main_tabPage_copyFinder.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_copyFinder.Name = "main_tabPage_copyFinder";
            this.main_tabPage_copyFinder.Size = new System.Drawing.Size(976, 536);
            this.main_tabPage_copyFinder.TabIndex = 4;
            this.main_tabPage_copyFinder.Text = "Copy Finder";
            this.main_tabPage_copyFinder.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_deleteEmpty
            // 
            this.main_tabPage_deleteEmpty.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_deleteEmpty.Name = "main_tabPage_deleteEmpty";
            this.main_tabPage_deleteEmpty.Size = new System.Drawing.Size(976, 536);
            this.main_tabPage_deleteEmpty.TabIndex = 5;
            this.main_tabPage_deleteEmpty.Text = "Delete Empty";
            this.main_tabPage_deleteEmpty.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_fileManipulation
            // 
            this.main_tabPage_fileManipulation.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_fileManipulation.Name = "main_tabPage_fileManipulation";
            this.main_tabPage_fileManipulation.Size = new System.Drawing.Size(976, 536);
            this.main_tabPage_fileManipulation.TabIndex = 6;
            this.main_tabPage_fileManipulation.Text = "File Manipulation";
            this.main_tabPage_fileManipulation.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_mouseRecord
            // 
            this.main_tabPage_mouseRecord.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_mouseRecord.Name = "main_tabPage_mouseRecord";
            this.main_tabPage_mouseRecord.Size = new System.Drawing.Size(976, 536);
            this.main_tabPage_mouseRecord.TabIndex = 7;
            this.main_tabPage_mouseRecord.Text = "MouseRecord";
            this.main_tabPage_mouseRecord.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_keyboardRecord
            // 
            this.main_tabPage_keyboardRecord.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_keyboardRecord.Name = "main_tabPage_keyboardRecord";
            this.main_tabPage_keyboardRecord.Size = new System.Drawing.Size(976, 536);
            this.main_tabPage_keyboardRecord.TabIndex = 8;
            this.main_tabPage_keyboardRecord.Text = "Keyboard Record";
            this.main_tabPage_keyboardRecord.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_reactiveTest
            // 
            this.main_tabPage_reactiveTest.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_reactiveTest.Name = "main_tabPage_reactiveTest";
            this.main_tabPage_reactiveTest.Size = new System.Drawing.Size(976, 536);
            this.main_tabPage_reactiveTest.TabIndex = 9;
            this.main_tabPage_reactiveTest.Text = "Reactive Test";
            this.main_tabPage_reactiveTest.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_steamThumbnailDeleter
            // 
            this.main_tabPage_steamThumbnailDeleter.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_steamThumbnailDeleter.Name = "main_tabPage_steamThumbnailDeleter";
            this.main_tabPage_steamThumbnailDeleter.Size = new System.Drawing.Size(976, 536);
            this.main_tabPage_steamThumbnailDeleter.TabIndex = 10;
            this.main_tabPage_steamThumbnailDeleter.Text = "Steam Thumbnail Deleter";
            this.main_tabPage_steamThumbnailDeleter.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_settings
            // 
            this.main_tabPage_settings.Location = new System.Drawing.Point(4, 40);
            this.main_tabPage_settings.Name = "main_tabPage_settings";
            this.main_tabPage_settings.Size = new System.Drawing.Size(976, 518);
            this.main_tabPage_settings.TabIndex = 11;
            this.main_tabPage_settings.Text = "Settings";
            this.main_tabPage_settings.UseVisualStyleBackColor = true;
            // 
            // tb_aspectRatio_info
            // 
            this.tb_aspectRatio_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_aspectRatio_info.Location = new System.Drawing.Point(8, 6);
            this.tb_aspectRatio_info.Multiline = true;
            this.tb_aspectRatio_info.Name = "tb_aspectRatio_info";
            this.tb_aspectRatio_info.Size = new System.Drawing.Size(1060, 35);
            this.tb_aspectRatio_info.TabIndex = 0;
            this.tb_aspectRatio_info.Text = "Information:\r\nCalculates the ASPECT RATIO with the given width and height.";
            this.tb_aspectRatio_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_aspectRatio_width
            // 
            this.tb_aspectRatio_width.Location = new System.Drawing.Point(8, 47);
            this.tb_aspectRatio_width.MinimumSize = new System.Drawing.Size(50, 20);
            this.tb_aspectRatio_width.Name = "tb_aspectRatio_width";
            this.tb_aspectRatio_width.Size = new System.Drawing.Size(528, 20);
            this.tb_aspectRatio_width.TabIndex = 1;
            this.tb_aspectRatio_width.Text = "Width";
            // 
            // tb_aspectRatio_height
            // 
            this.tb_aspectRatio_height.Location = new System.Drawing.Point(8, 73);
            this.tb_aspectRatio_height.MinimumSize = new System.Drawing.Size(50, 20);
            this.tb_aspectRatio_height.Name = "tb_aspectRatio_height";
            this.tb_aspectRatio_height.Size = new System.Drawing.Size(528, 20);
            this.tb_aspectRatio_height.TabIndex = 2;
            this.tb_aspectRatio_height.Text = "Height";
            // 
            // tb_aspectRatio_ratio
            // 
            this.tb_aspectRatio_ratio.Location = new System.Drawing.Point(8, 99);
            this.tb_aspectRatio_ratio.MinimumSize = new System.Drawing.Size(50, 20);
            this.tb_aspectRatio_ratio.Name = "tb_aspectRatio_ratio";
            this.tb_aspectRatio_ratio.Size = new System.Drawing.Size(528, 20);
            this.tb_aspectRatio_ratio.TabIndex = 3;
            this.tb_aspectRatio_ratio.Text = "Ratio";
            // 
            // b_aspectRatio_calcWidth
            // 
            this.b_aspectRatio_calcWidth.Location = new System.Drawing.Point(542, 47);
            this.b_aspectRatio_calcWidth.Name = "b_aspectRatio_calcWidth";
            this.b_aspectRatio_calcWidth.Size = new System.Drawing.Size(165, 72);
            this.b_aspectRatio_calcWidth.TabIndex = 4;
            this.b_aspectRatio_calcWidth.Text = "Calculate Width";
            this.b_aspectRatio_calcWidth.UseVisualStyleBackColor = true;
            // 
            // b_aspectRatio_calcHeight
            // 
            this.b_aspectRatio_calcHeight.Location = new System.Drawing.Point(713, 46);
            this.b_aspectRatio_calcHeight.Name = "b_aspectRatio_calcHeight";
            this.b_aspectRatio_calcHeight.Size = new System.Drawing.Size(165, 72);
            this.b_aspectRatio_calcHeight.TabIndex = 5;
            this.b_aspectRatio_calcHeight.Text = "Calculate Height";
            this.b_aspectRatio_calcHeight.UseVisualStyleBackColor = true;
            // 
            // b_aspectRatio_calcRatio
            // 
            this.b_aspectRatio_calcRatio.Location = new System.Drawing.Point(884, 46);
            this.b_aspectRatio_calcRatio.Name = "b_aspectRatio_calcRatio";
            this.b_aspectRatio_calcRatio.Size = new System.Drawing.Size(165, 72);
            this.b_aspectRatio_calcRatio.TabIndex = 6;
            this.b_aspectRatio_calcRatio.Text = "Calculate Ratio";
            this.b_aspectRatio_calcRatio.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 562);
            this.Controls.Add(this.tabControl_main);
            this.Name = "GUI";
            this.Text = "GUI";
            this.tabControl_main.ResumeLayout(false);
            this.main_tabPage_aspectRatio.ResumeLayout(false);
            this.main_tabPage_aspectRatio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage main_tabPage_aspectRatio;
        private System.Windows.Forms.TabPage main_tabPage_bpm;
        private System.Windows.Forms.TabPage main_tabPage_clickSpeed;
        private System.Windows.Forms.TabPage main_tabPage_clipboard;
        private System.Windows.Forms.TabPage main_tabPage_copyFinder;
        private System.Windows.Forms.TabPage main_tabPage_deleteEmpty;
        private System.Windows.Forms.TabPage main_tabPage_fileManipulation;
        private System.Windows.Forms.TabPage main_tabPage_keyboardRecord;
        private System.Windows.Forms.TabPage main_tabPage_mouseRecord;
        private System.Windows.Forms.TabPage main_tabPage_reactiveTest;
        private System.Windows.Forms.TabPage main_tabPage_steamThumbnailDeleter;
        private System.Windows.Forms.TabPage main_tabPage_settings;
        private System.Windows.Forms.TextBox tb_aspectRatio_height;
        private System.Windows.Forms.TextBox tb_aspectRatio_width;
        private System.Windows.Forms.TextBox tb_aspectRatio_info;
        private System.Windows.Forms.Button b_aspectRatio_calcRatio;
        private System.Windows.Forms.Button b_aspectRatio_calcHeight;
        private System.Windows.Forms.Button b_aspectRatio_calcWidth;
        private System.Windows.Forms.TextBox tb_aspectRatio_ratio;
    }
}