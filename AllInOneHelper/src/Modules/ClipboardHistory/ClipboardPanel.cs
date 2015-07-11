using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using AllInOneHelper.src.Modules.Base;

namespace AllInOneHelper.src.Modules.ClipboardHistory {
    class ClipboardPanel : BasePanel {
        private TextBox tb_clipboard_info;
        private CheckBox cbox_clipboard_autoscroll;
        private Button b_clipboard_copySelectedIntoClipboard;
        private Button b_clipboard_deleteAll;
        private Button b_clipboard_deleteSelected;
        public ListBox listBox_clipboard_list;
        private CheckBox cbox_clipboard_status;

        private ClipboardController controller;

        protected override void RegisterEvents() {
            controller = new ClipboardController(this);

            cbox_clipboard_status.Click += new EventHandler(controller.ChangeStatus);
            b_clipboard_copySelectedIntoClipboard.Click += new EventHandler(controller.CopySelectedIntoClipboard);
            b_clipboard_deleteAll.Click += new EventHandler(controller.DeleteAll);
            b_clipboard_deleteSelected.Click += new EventHandler(controller.DeleteSelected);
            cbox_clipboard_autoscroll.Click += new EventHandler(controller.AutoScrollChange);
        }

        protected override void InitializeComponent() {
            this.tb_clipboard_info = new System.Windows.Forms.TextBox();
            this.cbox_clipboard_autoscroll = new System.Windows.Forms.CheckBox();
            this.b_clipboard_copySelectedIntoClipboard = new System.Windows.Forms.Button();
            this.b_clipboard_deleteAll = new System.Windows.Forms.Button();
            this.b_clipboard_deleteSelected = new System.Windows.Forms.Button();
            this.listBox_clipboard_list = new System.Windows.Forms.ListBox();
            this.cbox_clipboard_status = new System.Windows.Forms.CheckBox();
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
            this.cbox_clipboard_autoscroll.Location = new System.Drawing.Point(555, 515);
            this.cbox_clipboard_autoscroll.Name = "cbox_clipboard_autoscroll";
            this.cbox_clipboard_autoscroll.Size = new System.Drawing.Size(77, 17);
            this.cbox_clipboard_autoscroll.TabIndex = 12;
            this.cbox_clipboard_autoscroll.Text = "Auto-Scroll";
            this.cbox_clipboard_autoscroll.UseVisualStyleBackColor = true;
            // 
            // b_clipboard_copySelectedIntoClipboard
            // 
            this.b_clipboard_copySelectedIntoClipboard.Location = new System.Drawing.Point(377, 511);
            this.b_clipboard_copySelectedIntoClipboard.Name = "b_clipboard_copySelectedIntoClipboard";
            this.b_clipboard_copySelectedIntoClipboard.Size = new System.Drawing.Size(172, 23);
            this.b_clipboard_copySelectedIntoClipboard.TabIndex = 11;
            this.b_clipboard_copySelectedIntoClipboard.Text = "Copy first selected into clipboard";
            this.b_clipboard_copySelectedIntoClipboard.UseVisualStyleBackColor = true;
            // 
            // b_clipboard_deleteAll
            // 
            this.b_clipboard_deleteAll.Location = new System.Drawing.Point(242, 511);
            this.b_clipboard_deleteAll.Name = "b_clipboard_deleteAll";
            this.b_clipboard_deleteAll.Size = new System.Drawing.Size(129, 23);
            this.b_clipboard_deleteAll.TabIndex = 10;
            this.b_clipboard_deleteAll.Text = "Delete all";
            this.b_clipboard_deleteAll.UseVisualStyleBackColor = true;
            // 
            // b_clipboard_deleteSelected
            // 
            this.b_clipboard_deleteSelected.Location = new System.Drawing.Point(107, 511);
            this.b_clipboard_deleteSelected.Name = "b_clipboard_deleteSelected";
            this.b_clipboard_deleteSelected.Size = new System.Drawing.Size(129, 23);
            this.b_clipboard_deleteSelected.TabIndex = 9;
            this.b_clipboard_deleteSelected.Text = "Delete selected";
            this.b_clipboard_deleteSelected.UseVisualStyleBackColor = true;
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
            // cbox_clipboard_status
            // 
            this.cbox_clipboard_status.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbox_clipboard_status.Checked = true;
            this.cbox_clipboard_status.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_clipboard_status.Location = new System.Drawing.Point(4, 511);
            this.cbox_clipboard_status.Name = "cbox_clipboard_status";
            this.cbox_clipboard_status.Size = new System.Drawing.Size(97, 23);
            this.cbox_clipboard_status.TabIndex = 14;
            this.cbox_clipboard_status.Text = "Deactivate";
            this.cbox_clipboard_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbox_clipboard_status.UseVisualStyleBackColor = true;
            // 
            // ClipboardPanel
            // 
            this.Controls.Add(this.cbox_clipboard_status);
            this.Controls.Add(this.tb_clipboard_info);
            this.Controls.Add(this.cbox_clipboard_autoscroll);
            this.Controls.Add(this.b_clipboard_copySelectedIntoClipboard);
            this.Controls.Add(this.b_clipboard_deleteAll);
            this.Controls.Add(this.b_clipboard_deleteSelected);
            this.Controls.Add(this.listBox_clipboard_list);
            this.Name = "ClipboardPanel";
            this.Size = new System.Drawing.Size(1075, 545);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override void Close() {
            controller.Close();
        }
    }
}
