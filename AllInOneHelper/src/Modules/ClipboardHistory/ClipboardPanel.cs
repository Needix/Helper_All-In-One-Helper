using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.BPM {
    class ClipboardPanel : UserControl {
        private TextBox tb_clipboard_info;
        private CheckBox cbox_clipboard_autoscroll;
        private Button b_clipboard_copySelectedIntoClipboard;
        private Button b_clipboard_deleteAll;
        private Button b_clipboard_deleteSelected;
        private Button b_clipboard_changeStatus;
        private ListBox listBox_clipboard_list;

        public ClipboardPanel() {
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
            this.tb_clipboard_info = new System.Windows.Forms.TextBox();
            this.cbox_clipboard_autoscroll = new System.Windows.Forms.CheckBox();
            this.b_clipboard_copySelectedIntoClipboard = new System.Windows.Forms.Button();
            this.b_clipboard_deleteAll = new System.Windows.Forms.Button();
            this.b_clipboard_deleteSelected = new System.Windows.Forms.Button();
            this.b_clipboard_changeStatus = new System.Windows.Forms.Button();
            this.listBox_clipboard_list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tb_clipboard_info
            // 
            this.tb_clipboard_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_clipboard_info.Location = new System.Drawing.Point(3, 3);
            this.tb_clipboard_info.Multiline = true;
            this.tb_clipboard_info.Name = "tb_clipboard_info";
            this.tb_clipboard_info.Size = new System.Drawing.Size(1060, 36);
            this.tb_clipboard_info.TabIndex = 13;
            this.tb_clipboard_info.Text = "Information: \r\nSaves all your past clipboard texts.";
            this.tb_clipboard_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbox_clipboard_autoscroll
            // 
            this.cbox_clipboard_autoscroll.AutoSize = true;
            this.cbox_clipboard_autoscroll.Checked = true;
            this.cbox_clipboard_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_clipboard_autoscroll.Location = new System.Drawing.Point(587, 514);
            this.cbox_clipboard_autoscroll.Name = "cbox_clipboard_autoscroll";
            this.cbox_clipboard_autoscroll.Size = new System.Drawing.Size(77, 17);
            this.cbox_clipboard_autoscroll.TabIndex = 12;
            this.cbox_clipboard_autoscroll.Text = "Auto-Scroll";
            this.cbox_clipboard_autoscroll.UseVisualStyleBackColor = true;
            // 
            // b_clipboard_copySelectedIntoClipboard
            // 
            this.b_clipboard_copySelectedIntoClipboard.Location = new System.Drawing.Point(409, 510);
            this.b_clipboard_copySelectedIntoClipboard.Name = "b_clipboard_copySelectedIntoClipboard";
            this.b_clipboard_copySelectedIntoClipboard.Size = new System.Drawing.Size(172, 23);
            this.b_clipboard_copySelectedIntoClipboard.TabIndex = 11;
            this.b_clipboard_copySelectedIntoClipboard.Text = "Copy first selected into clipboard";
            this.b_clipboard_copySelectedIntoClipboard.UseVisualStyleBackColor = true;
            // 
            // b_clipboard_deleteAll
            // 
            this.b_clipboard_deleteAll.Location = new System.Drawing.Point(274, 510);
            this.b_clipboard_deleteAll.Name = "b_clipboard_deleteAll";
            this.b_clipboard_deleteAll.Size = new System.Drawing.Size(129, 23);
            this.b_clipboard_deleteAll.TabIndex = 10;
            this.b_clipboard_deleteAll.Text = "Delete all";
            this.b_clipboard_deleteAll.UseVisualStyleBackColor = true;
            // 
            // b_clipboard_deleteSelected
            // 
            this.b_clipboard_deleteSelected.Location = new System.Drawing.Point(139, 510);
            this.b_clipboard_deleteSelected.Name = "b_clipboard_deleteSelected";
            this.b_clipboard_deleteSelected.Size = new System.Drawing.Size(129, 23);
            this.b_clipboard_deleteSelected.TabIndex = 9;
            this.b_clipboard_deleteSelected.Text = "Delete selected";
            this.b_clipboard_deleteSelected.UseVisualStyleBackColor = true;
            // 
            // b_clipboard_changeStatus
            // 
            this.b_clipboard_changeStatus.Location = new System.Drawing.Point(4, 510);
            this.b_clipboard_changeStatus.Name = "b_clipboard_changeStatus";
            this.b_clipboard_changeStatus.Size = new System.Drawing.Size(129, 23);
            this.b_clipboard_changeStatus.TabIndex = 8;
            this.b_clipboard_changeStatus.Text = "Activate";
            this.b_clipboard_changeStatus.UseVisualStyleBackColor = true;
            // 
            // listBox_clipboard_list
            // 
            this.listBox_clipboard_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_clipboard_list.FormattingEnabled = true;
            this.listBox_clipboard_list.Location = new System.Drawing.Point(3, 45);
            this.listBox_clipboard_list.Name = "listBox_clipboard_list";
            this.listBox_clipboard_list.Size = new System.Drawing.Size(1060, 459);
            this.listBox_clipboard_list.TabIndex = 7;
            // 
            // CustomPanel
            // 
            this.Controls.Add(this.tb_clipboard_info);
            this.Controls.Add(this.cbox_clipboard_autoscroll);
            this.Controls.Add(this.b_clipboard_copySelectedIntoClipboard);
            this.Controls.Add(this.b_clipboard_deleteAll);
            this.Controls.Add(this.b_clipboard_deleteSelected);
            this.Controls.Add(this.b_clipboard_changeStatus);
            this.Controls.Add(this.listBox_clipboard_list);
            this.Name = "CustomPanel";
            this.Size = new System.Drawing.Size(1075, 545);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
