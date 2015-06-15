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
            this.tb_bpm_info = new System.Windows.Forms.TextBox();
            this.b_bpm_tap = new System.Windows.Forms.Button();
            this.b_bpm_reset = new System.Windows.Forms.Button();
            this.l_bpm_curBPM = new System.Windows.Forms.Label();
            this.l_bpm_averageBPM = new System.Windows.Forms.Label();
            this.radio_bpm_visualBPM = new System.Windows.Forms.RadioButton();
            this.tb_clickSpeed_info = new System.Windows.Forms.TextBox();
            this.l_clickSpeed_acc = new System.Windows.Forms.Label();
            this.tb_clickSpeed_acc = new System.Windows.Forms.TextBox();
            this.listBox_clipboard_list = new System.Windows.Forms.ListBox();
            this.b_clipboard_changeStatus = new System.Windows.Forms.Button();
            this.b_clipboard_deleteSelected = new System.Windows.Forms.Button();
            this.b_clipboard_deleteAll = new System.Windows.Forms.Button();
            this.b_clipboard_copySelectedIntoClipboard = new System.Windows.Forms.Button();
            this.cbox_clipboard_autoscroll = new System.Windows.Forms.CheckBox();
            this.listBox_copyFinder_list = new System.Windows.Forms.ListBox();
            this.l_copyFinder_searchedFolder = new System.Windows.Forms.Label();
            this.b_copyFinder_findCopiesEverywhere = new System.Windows.Forms.Button();
            this.b_copyFinder_findCopiesInFolder = new System.Windows.Forms.Button();
            this.cbox_copyFinder_deleteCopiesIfFound = new System.Windows.Forms.CheckBox();
            this.tb_clipboard_info = new System.Windows.Forms.TextBox();
            this.tb_copyFinder_info = new System.Windows.Forms.TextBox();
            this.b_copyFinder_deleteAllFolder = new System.Windows.Forms.Button();
            this.b_copyFinder_deleteSelectedFolder = new System.Windows.Forms.Button();
            this.tb_deleteEmpty_info = new System.Windows.Forms.TextBox();
            this.groupBox_deleteEmpty_options = new System.Windows.Forms.GroupBox();
            this.radio_deleteEmpty_options_files = new System.Windows.Forms.RadioButton();
            this.radio_deleteEmpty_options_folder = new System.Windows.Forms.RadioButton();
            this.radio_deleteEmpty_options_FAF = new System.Windows.Forms.RadioButton();
            this.cbox_deleteEmpty_options_countFirst = new System.Windows.Forms.CheckBox();
            this.cbox_deleteEmpty_options_includeSubdirs = new System.Windows.Forms.CheckBox();
            this.b_deleteEmpty_delete = new System.Windows.Forms.Button();
            this.groupBox_deleteEmpty_result = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_deleteEmpty_result = new System.Windows.Forms.ListBox();
            this.tabControl_main.SuspendLayout();
            this.main_tabPage_aspectRatio.SuspendLayout();
            this.main_tabPage_bpm.SuspendLayout();
            this.main_tabPage_clickSpeed.SuspendLayout();
            this.main_tabPage_clipboard.SuspendLayout();
            this.main_tabPage_copyFinder.SuspendLayout();
            this.main_tabPage_deleteEmpty.SuspendLayout();
            this.groupBox_deleteEmpty_options.SuspendLayout();
            this.groupBox_deleteEmpty_result.SuspendLayout();
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
            this.main_tabPage_bpm.Controls.Add(this.radio_bpm_visualBPM);
            this.main_tabPage_bpm.Controls.Add(this.l_bpm_averageBPM);
            this.main_tabPage_bpm.Controls.Add(this.l_bpm_curBPM);
            this.main_tabPage_bpm.Controls.Add(this.b_bpm_reset);
            this.main_tabPage_bpm.Controls.Add(this.b_bpm_tap);
            this.main_tabPage_bpm.Controls.Add(this.tb_bpm_info);
            this.main_tabPage_bpm.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_bpm.Name = "main_tabPage_bpm";
            this.main_tabPage_bpm.Padding = new System.Windows.Forms.Padding(3);
            this.main_tabPage_bpm.Size = new System.Drawing.Size(1076, 536);
            this.main_tabPage_bpm.TabIndex = 1;
            this.main_tabPage_bpm.Text = "BPM Measurement";
            this.main_tabPage_bpm.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_clickSpeed
            // 
            this.main_tabPage_clickSpeed.Controls.Add(this.tb_clickSpeed_acc);
            this.main_tabPage_clickSpeed.Controls.Add(this.l_clickSpeed_acc);
            this.main_tabPage_clickSpeed.Controls.Add(this.tb_clickSpeed_info);
            this.main_tabPage_clickSpeed.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_clickSpeed.Name = "main_tabPage_clickSpeed";
            this.main_tabPage_clickSpeed.Size = new System.Drawing.Size(1076, 536);
            this.main_tabPage_clickSpeed.TabIndex = 2;
            this.main_tabPage_clickSpeed.Text = "ClickSpeed";
            this.main_tabPage_clickSpeed.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_clipboard
            // 
            this.main_tabPage_clipboard.Controls.Add(this.tb_clipboard_info);
            this.main_tabPage_clipboard.Controls.Add(this.cbox_clipboard_autoscroll);
            this.main_tabPage_clipboard.Controls.Add(this.b_clipboard_copySelectedIntoClipboard);
            this.main_tabPage_clipboard.Controls.Add(this.b_clipboard_deleteAll);
            this.main_tabPage_clipboard.Controls.Add(this.b_clipboard_deleteSelected);
            this.main_tabPage_clipboard.Controls.Add(this.b_clipboard_changeStatus);
            this.main_tabPage_clipboard.Controls.Add(this.listBox_clipboard_list);
            this.main_tabPage_clipboard.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_clipboard.Name = "main_tabPage_clipboard";
            this.main_tabPage_clipboard.Size = new System.Drawing.Size(1076, 536);
            this.main_tabPage_clipboard.TabIndex = 3;
            this.main_tabPage_clipboard.Text = "Clipboard History";
            this.main_tabPage_clipboard.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_copyFinder
            // 
            this.main_tabPage_copyFinder.Controls.Add(this.b_copyFinder_deleteSelectedFolder);
            this.main_tabPage_copyFinder.Controls.Add(this.b_copyFinder_deleteAllFolder);
            this.main_tabPage_copyFinder.Controls.Add(this.tb_copyFinder_info);
            this.main_tabPage_copyFinder.Controls.Add(this.cbox_copyFinder_deleteCopiesIfFound);
            this.main_tabPage_copyFinder.Controls.Add(this.b_copyFinder_findCopiesInFolder);
            this.main_tabPage_copyFinder.Controls.Add(this.b_copyFinder_findCopiesEverywhere);
            this.main_tabPage_copyFinder.Controls.Add(this.l_copyFinder_searchedFolder);
            this.main_tabPage_copyFinder.Controls.Add(this.listBox_copyFinder_list);
            this.main_tabPage_copyFinder.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_copyFinder.Name = "main_tabPage_copyFinder";
            this.main_tabPage_copyFinder.Size = new System.Drawing.Size(1076, 536);
            this.main_tabPage_copyFinder.TabIndex = 4;
            this.main_tabPage_copyFinder.Text = "Copy Finder";
            this.main_tabPage_copyFinder.UseVisualStyleBackColor = true;
            // 
            // main_tabPage_deleteEmpty
            // 
            this.main_tabPage_deleteEmpty.Controls.Add(this.groupBox_deleteEmpty_result);
            this.main_tabPage_deleteEmpty.Controls.Add(this.b_deleteEmpty_delete);
            this.main_tabPage_deleteEmpty.Controls.Add(this.groupBox_deleteEmpty_options);
            this.main_tabPage_deleteEmpty.Controls.Add(this.tb_deleteEmpty_info);
            this.main_tabPage_deleteEmpty.Location = new System.Drawing.Point(4, 22);
            this.main_tabPage_deleteEmpty.Name = "main_tabPage_deleteEmpty";
            this.main_tabPage_deleteEmpty.Size = new System.Drawing.Size(1076, 536);
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
            // tb_bpm_info
            // 
            this.tb_bpm_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_bpm_info.Location = new System.Drawing.Point(8, 6);
            this.tb_bpm_info.Multiline = true;
            this.tb_bpm_info.Name = "tb_bpm_info";
            this.tb_bpm_info.Size = new System.Drawing.Size(1060, 36);
            this.tb_bpm_info.TabIndex = 1;
            this.tb_bpm_info.Text = "Information: \r\nMeasures the BPM of your tapping. Tap with same speed gives best r" +
    "esult. Click the reset button to reset it.";
            this.tb_bpm_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // b_bpm_tap
            // 
            this.b_bpm_tap.Location = new System.Drawing.Point(8, 48);
            this.b_bpm_tap.Name = "b_bpm_tap";
            this.b_bpm_tap.Size = new System.Drawing.Size(86, 23);
            this.b_bpm_tap.TabIndex = 2;
            this.b_bpm_tap.Text = "Tap Tap Tap";
            this.b_bpm_tap.UseVisualStyleBackColor = true;
            // 
            // b_bpm_reset
            // 
            this.b_bpm_reset.Location = new System.Drawing.Point(100, 48);
            this.b_bpm_reset.Name = "b_bpm_reset";
            this.b_bpm_reset.Size = new System.Drawing.Size(75, 23);
            this.b_bpm_reset.TabIndex = 3;
            this.b_bpm_reset.Text = "Reset";
            this.b_bpm_reset.UseVisualStyleBackColor = true;
            // 
            // l_bpm_curBPM
            // 
            this.l_bpm_curBPM.AutoSize = true;
            this.l_bpm_curBPM.Location = new System.Drawing.Point(181, 53);
            this.l_bpm_curBPM.Name = "l_bpm_curBPM";
            this.l_bpm_curBPM.Size = new System.Drawing.Size(79, 13);
            this.l_bpm_curBPM.TabIndex = 4;
            this.l_bpm_curBPM.Text = "Current BPM: 0";
            // 
            // l_bpm_averageBPM
            // 
            this.l_bpm_averageBPM.AutoSize = true;
            this.l_bpm_averageBPM.Location = new System.Drawing.Point(290, 53);
            this.l_bpm_averageBPM.Name = "l_bpm_averageBPM";
            this.l_bpm_averageBPM.Size = new System.Drawing.Size(85, 13);
            this.l_bpm_averageBPM.TabIndex = 5;
            this.l_bpm_averageBPM.Text = "Average BPM: 0";
            // 
            // radio_bpm_visualBPM
            // 
            this.radio_bpm_visualBPM.AutoSize = true;
            this.radio_bpm_visualBPM.Location = new System.Drawing.Point(427, 51);
            this.radio_bpm_visualBPM.Name = "radio_bpm_visualBPM";
            this.radio_bpm_visualBPM.Size = new System.Drawing.Size(79, 17);
            this.radio_bpm_visualBPM.TabIndex = 6;
            this.radio_bpm_visualBPM.TabStop = true;
            this.radio_bpm_visualBPM.Text = "Visual BPM";
            this.radio_bpm_visualBPM.UseVisualStyleBackColor = true;
            // 
            // tb_clickSpeed_info
            // 
            this.tb_clickSpeed_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_clickSpeed_info.Location = new System.Drawing.Point(3, 3);
            this.tb_clickSpeed_info.Multiline = true;
            this.tb_clickSpeed_info.Name = "tb_clickSpeed_info";
            this.tb_clickSpeed_info.Size = new System.Drawing.Size(1060, 36);
            this.tb_clickSpeed_info.TabIndex = 2;
            this.tb_clickSpeed_info.Text = "Information: \r\nClick as fast as you can on the chart below.";
            this.tb_clickSpeed_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_clickSpeed_acc
            // 
            this.l_clickSpeed_acc.AutoSize = true;
            this.l_clickSpeed_acc.Location = new System.Drawing.Point(8, 42);
            this.l_clickSpeed_acc.Name = "l_clickSpeed_acc";
            this.l_clickSpeed_acc.Size = new System.Drawing.Size(58, 13);
            this.l_clickSpeed_acc.TabIndex = 3;
            this.l_clickSpeed_acc.Text = "Accuracy: ";
            // 
            // tb_clickSpeed_acc
            // 
            this.tb_clickSpeed_acc.Location = new System.Drawing.Point(72, 39);
            this.tb_clickSpeed_acc.Name = "tb_clickSpeed_acc";
            this.tb_clickSpeed_acc.Size = new System.Drawing.Size(100, 20);
            this.tb_clickSpeed_acc.TabIndex = 4;
            this.tb_clickSpeed_acc.Text = "5";
            // 
            // listBox_clipboard_list
            // 
            this.listBox_clipboard_list.FormattingEnabled = true;
            this.listBox_clipboard_list.Location = new System.Drawing.Point(8, 42);
            this.listBox_clipboard_list.Name = "listBox_clipboard_list";
            this.listBox_clipboard_list.Size = new System.Drawing.Size(1060, 459);
            this.listBox_clipboard_list.TabIndex = 0;
            // 
            // b_clipboard_changeStatus
            // 
            this.b_clipboard_changeStatus.Location = new System.Drawing.Point(8, 505);
            this.b_clipboard_changeStatus.Name = "b_clipboard_changeStatus";
            this.b_clipboard_changeStatus.Size = new System.Drawing.Size(129, 23);
            this.b_clipboard_changeStatus.TabIndex = 1;
            this.b_clipboard_changeStatus.Text = "Activate";
            this.b_clipboard_changeStatus.UseVisualStyleBackColor = true;
            // 
            // b_clipboard_deleteSelected
            // 
            this.b_clipboard_deleteSelected.Location = new System.Drawing.Point(143, 505);
            this.b_clipboard_deleteSelected.Name = "b_clipboard_deleteSelected";
            this.b_clipboard_deleteSelected.Size = new System.Drawing.Size(129, 23);
            this.b_clipboard_deleteSelected.TabIndex = 2;
            this.b_clipboard_deleteSelected.Text = "Delete selected";
            this.b_clipboard_deleteSelected.UseVisualStyleBackColor = true;
            // 
            // b_clipboard_deleteAll
            // 
            this.b_clipboard_deleteAll.Location = new System.Drawing.Point(278, 505);
            this.b_clipboard_deleteAll.Name = "b_clipboard_deleteAll";
            this.b_clipboard_deleteAll.Size = new System.Drawing.Size(129, 23);
            this.b_clipboard_deleteAll.TabIndex = 3;
            this.b_clipboard_deleteAll.Text = "Delete all";
            this.b_clipboard_deleteAll.UseVisualStyleBackColor = true;
            // 
            // b_clipboard_copySelectedIntoClipboard
            // 
            this.b_clipboard_copySelectedIntoClipboard.Location = new System.Drawing.Point(413, 505);
            this.b_clipboard_copySelectedIntoClipboard.Name = "b_clipboard_copySelectedIntoClipboard";
            this.b_clipboard_copySelectedIntoClipboard.Size = new System.Drawing.Size(172, 23);
            this.b_clipboard_copySelectedIntoClipboard.TabIndex = 4;
            this.b_clipboard_copySelectedIntoClipboard.Text = "Copy first selected into clipboard";
            this.b_clipboard_copySelectedIntoClipboard.UseVisualStyleBackColor = true;
            // 
            // cbox_clipboard_autoscroll
            // 
            this.cbox_clipboard_autoscroll.AutoSize = true;
            this.cbox_clipboard_autoscroll.Checked = true;
            this.cbox_clipboard_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_clipboard_autoscroll.Location = new System.Drawing.Point(591, 509);
            this.cbox_clipboard_autoscroll.Name = "cbox_clipboard_autoscroll";
            this.cbox_clipboard_autoscroll.Size = new System.Drawing.Size(77, 17);
            this.cbox_clipboard_autoscroll.TabIndex = 5;
            this.cbox_clipboard_autoscroll.Text = "Auto-Scroll";
            this.cbox_clipboard_autoscroll.UseVisualStyleBackColor = true;
            // 
            // listBox_copyFinder_list
            // 
            this.listBox_copyFinder_list.FormattingEnabled = true;
            this.listBox_copyFinder_list.Location = new System.Drawing.Point(8, 42);
            this.listBox_copyFinder_list.Name = "listBox_copyFinder_list";
            this.listBox_copyFinder_list.Size = new System.Drawing.Size(1060, 420);
            this.listBox_copyFinder_list.TabIndex = 0;
            // 
            // l_copyFinder_searchedFolder
            // 
            this.l_copyFinder_searchedFolder.AutoSize = true;
            this.l_copyFinder_searchedFolder.Location = new System.Drawing.Point(8, 477);
            this.l_copyFinder_searchedFolder.Name = "l_copyFinder_searchedFolder";
            this.l_copyFinder_searchedFolder.Size = new System.Drawing.Size(94, 13);
            this.l_copyFinder_searchedFolder.TabIndex = 1;
            this.l_copyFinder_searchedFolder.Text = "Searched folder: 0";
            // 
            // b_copyFinder_findCopiesEverywhere
            // 
            this.b_copyFinder_findCopiesEverywhere.Location = new System.Drawing.Point(11, 505);
            this.b_copyFinder_findCopiesEverywhere.Name = "b_copyFinder_findCopiesEverywhere";
            this.b_copyFinder_findCopiesEverywhere.Size = new System.Drawing.Size(155, 23);
            this.b_copyFinder_findCopiesEverywhere.TabIndex = 2;
            this.b_copyFinder_findCopiesEverywhere.Text = "Find copies everywhere";
            this.b_copyFinder_findCopiesEverywhere.UseVisualStyleBackColor = true;
            // 
            // b_copyFinder_findCopiesInFolder
            // 
            this.b_copyFinder_findCopiesInFolder.Location = new System.Drawing.Point(172, 505);
            this.b_copyFinder_findCopiesInFolder.Name = "b_copyFinder_findCopiesInFolder";
            this.b_copyFinder_findCopiesInFolder.Size = new System.Drawing.Size(155, 23);
            this.b_copyFinder_findCopiesInFolder.TabIndex = 3;
            this.b_copyFinder_findCopiesInFolder.Text = "Find copies in folder...";
            this.b_copyFinder_findCopiesInFolder.UseVisualStyleBackColor = true;
            // 
            // cbox_copyFinder_deleteCopiesIfFound
            // 
            this.cbox_copyFinder_deleteCopiesIfFound.AutoSize = true;
            this.cbox_copyFinder_deleteCopiesIfFound.Location = new System.Drawing.Point(333, 509);
            this.cbox_copyFinder_deleteCopiesIfFound.Name = "cbox_copyFinder_deleteCopiesIfFound";
            this.cbox_copyFinder_deleteCopiesIfFound.Size = new System.Drawing.Size(192, 17);
            this.cbox_copyFinder_deleteCopiesIfFound.TabIndex = 4;
            this.cbox_copyFinder_deleteCopiesIfFound.Text = "Automatically delete copies if found";
            this.cbox_copyFinder_deleteCopiesIfFound.UseVisualStyleBackColor = true;
            // 
            // tb_clipboard_info
            // 
            this.tb_clipboard_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_clipboard_info.Location = new System.Drawing.Point(3, 3);
            this.tb_clipboard_info.Multiline = true;
            this.tb_clipboard_info.Name = "tb_clipboard_info";
            this.tb_clipboard_info.Size = new System.Drawing.Size(1060, 36);
            this.tb_clipboard_info.TabIndex = 6;
            this.tb_clipboard_info.Text = "Information: \r\nSaves all your past clipboard texts.";
            this.tb_clipboard_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_copyFinder_info
            // 
            this.tb_copyFinder_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_copyFinder_info.Location = new System.Drawing.Point(3, 3);
            this.tb_copyFinder_info.Multiline = true;
            this.tb_copyFinder_info.Name = "tb_copyFinder_info";
            this.tb_copyFinder_info.Size = new System.Drawing.Size(1060, 36);
            this.tb_copyFinder_info.TabIndex = 5;
            this.tb_copyFinder_info.Text = "Information: \r\nFind all folder with \"(Kopie)\" or \"(Copy)\" in their name.";
            this.tb_copyFinder_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // b_copyFinder_deleteAllFolder
            // 
            this.b_copyFinder_deleteAllFolder.Location = new System.Drawing.Point(531, 505);
            this.b_copyFinder_deleteAllFolder.Name = "b_copyFinder_deleteAllFolder";
            this.b_copyFinder_deleteAllFolder.Size = new System.Drawing.Size(155, 23);
            this.b_copyFinder_deleteAllFolder.TabIndex = 6;
            this.b_copyFinder_deleteAllFolder.Text = "Delete all folder";
            this.b_copyFinder_deleteAllFolder.UseVisualStyleBackColor = true;
            // 
            // b_copyFinder_deleteSelectedFolder
            // 
            this.b_copyFinder_deleteSelectedFolder.Location = new System.Drawing.Point(692, 505);
            this.b_copyFinder_deleteSelectedFolder.Name = "b_copyFinder_deleteSelectedFolder";
            this.b_copyFinder_deleteSelectedFolder.Size = new System.Drawing.Size(155, 23);
            this.b_copyFinder_deleteSelectedFolder.TabIndex = 7;
            this.b_copyFinder_deleteSelectedFolder.Text = "Delete selected folder";
            this.b_copyFinder_deleteSelectedFolder.UseVisualStyleBackColor = true;
            // 
            // tb_deleteEmpty_info
            // 
            this.tb_deleteEmpty_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_deleteEmpty_info.Location = new System.Drawing.Point(3, 3);
            this.tb_deleteEmpty_info.Multiline = true;
            this.tb_deleteEmpty_info.Name = "tb_deleteEmpty_info";
            this.tb_deleteEmpty_info.Size = new System.Drawing.Size(1060, 36);
            this.tb_deleteEmpty_info.TabIndex = 6;
            this.tb_deleteEmpty_info.Text = "Information: \r\nDeletes all empty folder/files.";
            this.tb_deleteEmpty_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox_deleteEmpty_options
            // 
            this.groupBox_deleteEmpty_options.Controls.Add(this.cbox_deleteEmpty_options_includeSubdirs);
            this.groupBox_deleteEmpty_options.Controls.Add(this.cbox_deleteEmpty_options_countFirst);
            this.groupBox_deleteEmpty_options.Controls.Add(this.radio_deleteEmpty_options_FAF);
            this.groupBox_deleteEmpty_options.Controls.Add(this.radio_deleteEmpty_options_folder);
            this.groupBox_deleteEmpty_options.Controls.Add(this.radio_deleteEmpty_options_files);
            this.groupBox_deleteEmpty_options.Location = new System.Drawing.Point(8, 45);
            this.groupBox_deleteEmpty_options.Name = "groupBox_deleteEmpty_options";
            this.groupBox_deleteEmpty_options.Size = new System.Drawing.Size(1055, 68);
            this.groupBox_deleteEmpty_options.TabIndex = 7;
            this.groupBox_deleteEmpty_options.TabStop = false;
            this.groupBox_deleteEmpty_options.Text = "Options";
            // 
            // radio_deleteEmpty_options_files
            // 
            this.radio_deleteEmpty_options_files.AutoSize = true;
            this.radio_deleteEmpty_options_files.Location = new System.Drawing.Point(6, 19);
            this.radio_deleteEmpty_options_files.Name = "radio_deleteEmpty_options_files";
            this.radio_deleteEmpty_options_files.Size = new System.Drawing.Size(46, 17);
            this.radio_deleteEmpty_options_files.TabIndex = 0;
            this.radio_deleteEmpty_options_files.TabStop = true;
            this.radio_deleteEmpty_options_files.Text = "Files";
            this.radio_deleteEmpty_options_files.UseVisualStyleBackColor = true;
            // 
            // radio_deleteEmpty_options_folder
            // 
            this.radio_deleteEmpty_options_folder.AutoSize = true;
            this.radio_deleteEmpty_options_folder.Location = new System.Drawing.Point(58, 19);
            this.radio_deleteEmpty_options_folder.Name = "radio_deleteEmpty_options_folder";
            this.radio_deleteEmpty_options_folder.Size = new System.Drawing.Size(54, 17);
            this.radio_deleteEmpty_options_folder.TabIndex = 1;
            this.radio_deleteEmpty_options_folder.TabStop = true;
            this.radio_deleteEmpty_options_folder.Text = "Folder";
            this.radio_deleteEmpty_options_folder.UseVisualStyleBackColor = true;
            // 
            // radio_deleteEmpty_options_FAF
            // 
            this.radio_deleteEmpty_options_FAF.AutoSize = true;
            this.radio_deleteEmpty_options_FAF.Location = new System.Drawing.Point(118, 19);
            this.radio_deleteEmpty_options_FAF.Name = "radio_deleteEmpty_options_FAF";
            this.radio_deleteEmpty_options_FAF.Size = new System.Drawing.Size(99, 17);
            this.radio_deleteEmpty_options_FAF.TabIndex = 2;
            this.radio_deleteEmpty_options_FAF.TabStop = true;
            this.radio_deleteEmpty_options_FAF.Text = "Files and Folder";
            this.radio_deleteEmpty_options_FAF.UseVisualStyleBackColor = true;
            // 
            // cbox_deleteEmpty_options_countFirst
            // 
            this.cbox_deleteEmpty_options_countFirst.AutoSize = true;
            this.cbox_deleteEmpty_options_countFirst.Location = new System.Drawing.Point(6, 42);
            this.cbox_deleteEmpty_options_countFirst.Name = "cbox_deleteEmpty_options_countFirst";
            this.cbox_deleteEmpty_options_countFirst.Size = new System.Drawing.Size(73, 17);
            this.cbox_deleteEmpty_options_countFirst.TabIndex = 3;
            this.cbox_deleteEmpty_options_countFirst.Text = "Count first";
            this.cbox_deleteEmpty_options_countFirst.UseVisualStyleBackColor = true;
            // 
            // cbox_deleteEmpty_options_includeSubdirs
            // 
            this.cbox_deleteEmpty_options_includeSubdirs.AutoSize = true;
            this.cbox_deleteEmpty_options_includeSubdirs.Checked = true;
            this.cbox_deleteEmpty_options_includeSubdirs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_deleteEmpty_options_includeSubdirs.Location = new System.Drawing.Point(118, 42);
            this.cbox_deleteEmpty_options_includeSubdirs.Name = "cbox_deleteEmpty_options_includeSubdirs";
            this.cbox_deleteEmpty_options_includeSubdirs.Size = new System.Drawing.Size(129, 17);
            this.cbox_deleteEmpty_options_includeSubdirs.TabIndex = 4;
            this.cbox_deleteEmpty_options_includeSubdirs.Text = "Include subdirectories";
            this.cbox_deleteEmpty_options_includeSubdirs.UseVisualStyleBackColor = true;
            // 
            // b_deleteEmpty_delete
            // 
            this.b_deleteEmpty_delete.Location = new System.Drawing.Point(8, 119);
            this.b_deleteEmpty_delete.Name = "b_deleteEmpty_delete";
            this.b_deleteEmpty_delete.Size = new System.Drawing.Size(1055, 23);
            this.b_deleteEmpty_delete.TabIndex = 8;
            this.b_deleteEmpty_delete.Text = "Delete Empty Folder/Files";
            this.b_deleteEmpty_delete.UseVisualStyleBackColor = true;
            // 
            // groupBox_deleteEmpty_result
            // 
            this.groupBox_deleteEmpty_result.Controls.Add(this.listBox_deleteEmpty_result);
            this.groupBox_deleteEmpty_result.Controls.Add(this.label3);
            this.groupBox_deleteEmpty_result.Controls.Add(this.label2);
            this.groupBox_deleteEmpty_result.Controls.Add(this.label1);
            this.groupBox_deleteEmpty_result.Location = new System.Drawing.Point(8, 148);
            this.groupBox_deleteEmpty_result.Name = "groupBox_deleteEmpty_result";
            this.groupBox_deleteEmpty_result.Size = new System.Drawing.Size(1060, 380);
            this.groupBox_deleteEmpty_result.TabIndex = 9;
            this.groupBox_deleteEmpty_result.TabStop = false;
            this.groupBox_deleteEmpty_result.Text = "Result";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Searched: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total: 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(485, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Deleted: 0";
            // 
            // listBox_deleteEmpty_result
            // 
            this.listBox_deleteEmpty_result.FormattingEnabled = true;
            this.listBox_deleteEmpty_result.Location = new System.Drawing.Point(9, 46);
            this.listBox_deleteEmpty_result.Name = "listBox_deleteEmpty_result";
            this.listBox_deleteEmpty_result.Size = new System.Drawing.Size(1045, 329);
            this.listBox_deleteEmpty_result.TabIndex = 3;
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
            this.main_tabPage_bpm.ResumeLayout(false);
            this.main_tabPage_bpm.PerformLayout();
            this.main_tabPage_clickSpeed.ResumeLayout(false);
            this.main_tabPage_clickSpeed.PerformLayout();
            this.main_tabPage_clipboard.ResumeLayout(false);
            this.main_tabPage_clipboard.PerformLayout();
            this.main_tabPage_copyFinder.ResumeLayout(false);
            this.main_tabPage_copyFinder.PerformLayout();
            this.main_tabPage_deleteEmpty.ResumeLayout(false);
            this.main_tabPage_deleteEmpty.PerformLayout();
            this.groupBox_deleteEmpty_options.ResumeLayout(false);
            this.groupBox_deleteEmpty_options.PerformLayout();
            this.groupBox_deleteEmpty_result.ResumeLayout(false);
            this.groupBox_deleteEmpty_result.PerformLayout();
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
        private System.Windows.Forms.RadioButton radio_bpm_visualBPM;
        private System.Windows.Forms.Label l_bpm_averageBPM;
        private System.Windows.Forms.Label l_bpm_curBPM;
        private System.Windows.Forms.Button b_bpm_reset;
        private System.Windows.Forms.Button b_bpm_tap;
        private System.Windows.Forms.TextBox tb_bpm_info;
        private System.Windows.Forms.TextBox tb_clickSpeed_acc;
        private System.Windows.Forms.Label l_clickSpeed_acc;
        private System.Windows.Forms.TextBox tb_clickSpeed_info;
        private System.Windows.Forms.CheckBox cbox_clipboard_autoscroll;
        private System.Windows.Forms.Button b_clipboard_copySelectedIntoClipboard;
        private System.Windows.Forms.Button b_clipboard_deleteAll;
        private System.Windows.Forms.Button b_clipboard_deleteSelected;
        private System.Windows.Forms.Button b_clipboard_changeStatus;
        private System.Windows.Forms.ListBox listBox_clipboard_list;
        private System.Windows.Forms.TextBox tb_clipboard_info;
        private System.Windows.Forms.Button b_copyFinder_deleteSelectedFolder;
        private System.Windows.Forms.Button b_copyFinder_deleteAllFolder;
        private System.Windows.Forms.TextBox tb_copyFinder_info;
        private System.Windows.Forms.CheckBox cbox_copyFinder_deleteCopiesIfFound;
        private System.Windows.Forms.Button b_copyFinder_findCopiesInFolder;
        private System.Windows.Forms.Button b_copyFinder_findCopiesEverywhere;
        private System.Windows.Forms.Label l_copyFinder_searchedFolder;
        private System.Windows.Forms.ListBox listBox_copyFinder_list;
        private System.Windows.Forms.GroupBox groupBox_deleteEmpty_options;
        private System.Windows.Forms.RadioButton radio_deleteEmpty_options_FAF;
        private System.Windows.Forms.RadioButton radio_deleteEmpty_options_folder;
        private System.Windows.Forms.RadioButton radio_deleteEmpty_options_files;
        private System.Windows.Forms.TextBox tb_deleteEmpty_info;
        private System.Windows.Forms.GroupBox groupBox_deleteEmpty_result;
        private System.Windows.Forms.ListBox listBox_deleteEmpty_result;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_deleteEmpty_delete;
        private System.Windows.Forms.CheckBox cbox_deleteEmpty_options_includeSubdirs;
        private System.Windows.Forms.CheckBox cbox_deleteEmpty_options_countFirst;
    }
}