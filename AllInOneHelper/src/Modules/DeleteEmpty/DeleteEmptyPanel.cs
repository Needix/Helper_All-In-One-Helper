using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.src.Modules.DeleteEmpty {
    class DeleteEmptyPanel : BasePanel {
        private GroupBox groupBox_deleteEmpty_result;
        private ListBox listBox_deleteEmpty_result;
        private Label l_deleteEmpty_result_deleted;
        private Label l_deleteEmpty_result_total;
        private Label l_deleteEmpty_result_searched;
        private GroupBox groupBox_deleteEmpty_options;
        private CheckBox cbox_deleteEmpty_options_includeSubdirs;
        private CheckBox cbox_deleteEmpty_options_countFirst;
        private RadioButton radio_deleteEmpty_options_FAF;
        private RadioButton radio_deleteEmpty_options_folder;
        private RadioButton radio_deleteEmpty_options_files;
        private Button b_deleteEmpty_delete;
        private TextBox tb_deleteEmpty_info;

        private DeleteEmptyController controller;

        public DeleteEmptyPanel(TabPage tabPage) : base(tabPage) { }

        protected override void RegisterEvents() {
            controller = new DeleteEmptyController(this);
            //EventHandler handler = new EventHandler(controller.);
        }

        protected override void InitializeComponent() {
            this.groupBox_deleteEmpty_result = new System.Windows.Forms.GroupBox();
            this.listBox_deleteEmpty_result = new System.Windows.Forms.ListBox();
            this.l_deleteEmpty_result_deleted = new System.Windows.Forms.Label();
            this.l_deleteEmpty_result_total = new System.Windows.Forms.Label();
            this.l_deleteEmpty_result_searched = new System.Windows.Forms.Label();
            this.groupBox_deleteEmpty_options = new System.Windows.Forms.GroupBox();
            this.cbox_deleteEmpty_options_includeSubdirs = new System.Windows.Forms.CheckBox();
            this.cbox_deleteEmpty_options_countFirst = new System.Windows.Forms.CheckBox();
            this.radio_deleteEmpty_options_FAF = new System.Windows.Forms.RadioButton();
            this.radio_deleteEmpty_options_folder = new System.Windows.Forms.RadioButton();
            this.radio_deleteEmpty_options_files = new System.Windows.Forms.RadioButton();
            this.tb_deleteEmpty_info = new System.Windows.Forms.TextBox();
            this.b_deleteEmpty_delete = new System.Windows.Forms.Button();
            this.groupBox_deleteEmpty_result.SuspendLayout();
            this.groupBox_deleteEmpty_options.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_deleteEmpty_result
            // 
            this.groupBox_deleteEmpty_result.Controls.Add(this.listBox_deleteEmpty_result);
            this.groupBox_deleteEmpty_result.Controls.Add(this.l_deleteEmpty_result_deleted);
            this.groupBox_deleteEmpty_result.Controls.Add(this.l_deleteEmpty_result_total);
            this.groupBox_deleteEmpty_result.Controls.Add(this.l_deleteEmpty_result_searched);
            this.groupBox_deleteEmpty_result.Location = new System.Drawing.Point(3, 148);
            this.groupBox_deleteEmpty_result.Name = "groupBox_deleteEmpty_result";
            this.groupBox_deleteEmpty_result.Size = new System.Drawing.Size(1055, 380);
            this.groupBox_deleteEmpty_result.TabIndex = 12;
            this.groupBox_deleteEmpty_result.TabStop = false;
            this.groupBox_deleteEmpty_result.Text = "Result";
            // 
            // listBox_deleteEmpty_result
            // 
            this.listBox_deleteEmpty_result.FormattingEnabled = true;
            this.listBox_deleteEmpty_result.Location = new System.Drawing.Point(9, 46);
            this.listBox_deleteEmpty_result.Name = "listBox_deleteEmpty_result";
            this.listBox_deleteEmpty_result.Size = new System.Drawing.Size(1045, 329);
            this.listBox_deleteEmpty_result.TabIndex = 3;
            // 
            // l_deleteEmpty_result_deleted
            // 
            this.l_deleteEmpty_result_deleted.AutoSize = true;
            this.l_deleteEmpty_result_deleted.Location = new System.Drawing.Point(485, 16);
            this.l_deleteEmpty_result_deleted.Name = "l_deleteEmpty_result_deleted";
            this.l_deleteEmpty_result_deleted.Size = new System.Drawing.Size(56, 13);
            this.l_deleteEmpty_result_deleted.TabIndex = 2;
            this.l_deleteEmpty_result_deleted.Text = "Deleted: 0";
            // 
            // l_deleteEmpty_result_total
            // 
            this.l_deleteEmpty_result_total.AutoSize = true;
            this.l_deleteEmpty_result_total.Location = new System.Drawing.Point(255, 16);
            this.l_deleteEmpty_result_total.Name = "l_deleteEmpty_result_total";
            this.l_deleteEmpty_result_total.Size = new System.Drawing.Size(43, 13);
            this.l_deleteEmpty_result_total.TabIndex = 1;
            this.l_deleteEmpty_result_total.Text = "Total: 0";
            // 
            // l_deleteEmpty_result_searched
            // 
            this.l_deleteEmpty_result_searched.AutoSize = true;
            this.l_deleteEmpty_result_searched.Location = new System.Drawing.Point(6, 16);
            this.l_deleteEmpty_result_searched.Name = "l_deleteEmpty_result_searched";
            this.l_deleteEmpty_result_searched.Size = new System.Drawing.Size(65, 13);
            this.l_deleteEmpty_result_searched.TabIndex = 0;
            this.l_deleteEmpty_result_searched.Text = "Searched: 0";
            // 
            // groupBox_deleteEmpty_options
            // 
            this.groupBox_deleteEmpty_options.Controls.Add(this.cbox_deleteEmpty_options_includeSubdirs);
            this.groupBox_deleteEmpty_options.Controls.Add(this.cbox_deleteEmpty_options_countFirst);
            this.groupBox_deleteEmpty_options.Controls.Add(this.radio_deleteEmpty_options_FAF);
            this.groupBox_deleteEmpty_options.Controls.Add(this.radio_deleteEmpty_options_folder);
            this.groupBox_deleteEmpty_options.Controls.Add(this.radio_deleteEmpty_options_files);
            this.groupBox_deleteEmpty_options.Location = new System.Drawing.Point(3, 45);
            this.groupBox_deleteEmpty_options.Name = "groupBox_deleteEmpty_options";
            this.groupBox_deleteEmpty_options.Size = new System.Drawing.Size(1055, 68);
            this.groupBox_deleteEmpty_options.TabIndex = 11;
            this.groupBox_deleteEmpty_options.TabStop = false;
            this.groupBox_deleteEmpty_options.Text = "Options";
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
            // tb_deleteEmpty_info
            // 
            this.tb_deleteEmpty_info.Location = new System.Drawing.Point(3, 3);
            this.tb_deleteEmpty_info.Multiline = true;
            this.tb_deleteEmpty_info.Name = "tb_deleteEmpty_info";
            this.tb_deleteEmpty_info.Size = new System.Drawing.Size(1055, 36);
            this.tb_deleteEmpty_info.TabIndex = 10;
            this.tb_deleteEmpty_info.Text = "Information: \r\nDeletes all empty folder/files.";
            this.tb_deleteEmpty_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // b_deleteEmpty_delete
            // 
            this.b_deleteEmpty_delete.Location = new System.Drawing.Point(3, 119);
            this.b_deleteEmpty_delete.Name = "b_deleteEmpty_delete";
            this.b_deleteEmpty_delete.Size = new System.Drawing.Size(1055, 23);
            this.b_deleteEmpty_delete.TabIndex = 9;
            this.b_deleteEmpty_delete.Text = "Delete Empty Folder/Files";
            this.b_deleteEmpty_delete.UseVisualStyleBackColor = true;
            // 
            // CustomPanel
            // 
            this.Controls.Add(this.b_deleteEmpty_delete);
            this.Controls.Add(this.groupBox_deleteEmpty_result);
            this.Controls.Add(this.groupBox_deleteEmpty_options);
            this.Controls.Add(this.tb_deleteEmpty_info);
            this.Name = "CustomPanel";
            this.Size = new System.Drawing.Size(1074, 543);
            this.groupBox_deleteEmpty_result.ResumeLayout(false);
            this.groupBox_deleteEmpty_result.PerformLayout();
            this.groupBox_deleteEmpty_options.ResumeLayout(false);
            this.groupBox_deleteEmpty_options.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override void Close() {

        }
    }
}
