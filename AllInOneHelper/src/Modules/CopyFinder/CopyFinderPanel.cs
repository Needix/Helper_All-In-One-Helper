using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.CopyFinder {
    class CopyFinderPanel : UserControl {
        private Button b_copyFinder_deleteSelectedFolder;
        private Button b_copyFinder_deleteAllFolder;
        private TextBox tb_copyFinder_info;
        private CheckBox cbox_copyFinder_deleteCopiesIfFound;
        private Button b_copyFinder_findCopiesInFolder;
        private Button b_copyFinder_findCopiesEverywhere;
        private Label l_copyFinder_searchedFolder;
        private ListBox listBox_copyFinder_list;

        public CopyFinderPanel() {
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
            this.b_copyFinder_deleteSelectedFolder = new System.Windows.Forms.Button();
            this.b_copyFinder_deleteAllFolder = new System.Windows.Forms.Button();
            this.tb_copyFinder_info = new System.Windows.Forms.TextBox();
            this.cbox_copyFinder_deleteCopiesIfFound = new System.Windows.Forms.CheckBox();
            this.b_copyFinder_findCopiesInFolder = new System.Windows.Forms.Button();
            this.b_copyFinder_findCopiesEverywhere = new System.Windows.Forms.Button();
            this.l_copyFinder_searchedFolder = new System.Windows.Forms.Label();
            this.listBox_copyFinder_list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // b_copyFinder_deleteSelectedFolder
            // 
            this.b_copyFinder_deleteSelectedFolder.Location = new System.Drawing.Point(692, 508);
            this.b_copyFinder_deleteSelectedFolder.Name = "b_copyFinder_deleteSelectedFolder";
            this.b_copyFinder_deleteSelectedFolder.Size = new System.Drawing.Size(150, 23);
            this.b_copyFinder_deleteSelectedFolder.TabIndex = 15;
            this.b_copyFinder_deleteSelectedFolder.Text = "Delete selected folder";
            this.b_copyFinder_deleteSelectedFolder.UseVisualStyleBackColor = true;
            // 
            // b_copyFinder_deleteAllFolder
            // 
            this.b_copyFinder_deleteAllFolder.Location = new System.Drawing.Point(531, 508);
            this.b_copyFinder_deleteAllFolder.Name = "b_copyFinder_deleteAllFolder";
            this.b_copyFinder_deleteAllFolder.Size = new System.Drawing.Size(150, 23);
            this.b_copyFinder_deleteAllFolder.TabIndex = 14;
            this.b_copyFinder_deleteAllFolder.Text = "Delete all folder";
            this.b_copyFinder_deleteAllFolder.UseVisualStyleBackColor = true;
            // 
            // tb_copyFinder_info
            // 
            this.tb_copyFinder_info.Location = new System.Drawing.Point(3, 6);
            this.tb_copyFinder_info.Multiline = true;
            this.tb_copyFinder_info.Name = "tb_copyFinder_info";
            this.tb_copyFinder_info.Size = new System.Drawing.Size(1060, 36);
            this.tb_copyFinder_info.TabIndex = 13;
            this.tb_copyFinder_info.Text = "Information: \r\nFind all folder with \"(Kopie)\" or \"(Copy)\" in their name.";
            this.tb_copyFinder_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbox_copyFinder_deleteCopiesIfFound
            // 
            this.cbox_copyFinder_deleteCopiesIfFound.AutoSize = true;
            this.cbox_copyFinder_deleteCopiesIfFound.Location = new System.Drawing.Point(328, 512);
            this.cbox_copyFinder_deleteCopiesIfFound.Name = "cbox_copyFinder_deleteCopiesIfFound";
            this.cbox_copyFinder_deleteCopiesIfFound.Size = new System.Drawing.Size(192, 17);
            this.cbox_copyFinder_deleteCopiesIfFound.TabIndex = 12;
            this.cbox_copyFinder_deleteCopiesIfFound.Text = "Automatically delete copies if found";
            this.cbox_copyFinder_deleteCopiesIfFound.UseVisualStyleBackColor = true;
            // 
            // b_copyFinder_findCopiesInFolder
            // 
            this.b_copyFinder_findCopiesInFolder.Location = new System.Drawing.Point(172, 508);
            this.b_copyFinder_findCopiesInFolder.Name = "b_copyFinder_findCopiesInFolder";
            this.b_copyFinder_findCopiesInFolder.Size = new System.Drawing.Size(150, 23);
            this.b_copyFinder_findCopiesInFolder.TabIndex = 11;
            this.b_copyFinder_findCopiesInFolder.Text = "Find copies in folder...";
            this.b_copyFinder_findCopiesInFolder.UseVisualStyleBackColor = true;
            // 
            // b_copyFinder_findCopiesEverywhere
            // 
            this.b_copyFinder_findCopiesEverywhere.Location = new System.Drawing.Point(11, 508);
            this.b_copyFinder_findCopiesEverywhere.Name = "b_copyFinder_findCopiesEverywhere";
            this.b_copyFinder_findCopiesEverywhere.Size = new System.Drawing.Size(150, 23);
            this.b_copyFinder_findCopiesEverywhere.TabIndex = 10;
            this.b_copyFinder_findCopiesEverywhere.Text = "Find copies everywhere";
            this.b_copyFinder_findCopiesEverywhere.UseVisualStyleBackColor = true;
            // 
            // l_copyFinder_searchedFolder
            // 
            this.l_copyFinder_searchedFolder.AutoSize = true;
            this.l_copyFinder_searchedFolder.Location = new System.Drawing.Point(3, 480);
            this.l_copyFinder_searchedFolder.Name = "l_copyFinder_searchedFolder";
            this.l_copyFinder_searchedFolder.Size = new System.Drawing.Size(94, 13);
            this.l_copyFinder_searchedFolder.TabIndex = 9;
            this.l_copyFinder_searchedFolder.Text = "Searched folder: 0";
            // 
            // listBox_copyFinder_list
            // 
            this.listBox_copyFinder_list.FormattingEnabled = true;
            this.listBox_copyFinder_list.Location = new System.Drawing.Point(3, 45);
            this.listBox_copyFinder_list.Name = "listBox_copyFinder_list";
            this.listBox_copyFinder_list.Size = new System.Drawing.Size(1060, 420);
            this.listBox_copyFinder_list.TabIndex = 8;
            // 
            // CustomPanel
            // 
            this.Controls.Add(this.b_copyFinder_deleteSelectedFolder);
            this.Controls.Add(this.b_copyFinder_deleteAllFolder);
            this.Controls.Add(this.tb_copyFinder_info);
            this.Controls.Add(this.cbox_copyFinder_deleteCopiesIfFound);
            this.Controls.Add(this.b_copyFinder_findCopiesInFolder);
            this.Controls.Add(this.b_copyFinder_findCopiesEverywhere);
            this.Controls.Add(this.l_copyFinder_searchedFolder);
            this.Controls.Add(this.listBox_copyFinder_list);
            this.Name = "CustomPanel";
            this.Size = new System.Drawing.Size(1072, 549);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void close() {

        }
    }
}
