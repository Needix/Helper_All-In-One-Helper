using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.BPM {
    class MouseRecordPanel : UserControl {
        private GroupBox groupBox_mouseRec_playback;
        private CheckBox cbox_mouseRec_playback_showAllFrames;
        private TrackBar slider_mouseRec_playback_progress;
        private Button b_mouseRec_playback_stop;
        private Button b_mouseRec_playback_start;
        private GroupBox groupBox_mouseRec_record;
        private Label l_mouseRec_rec_recFrames;
        private Button b_mouseRec_rec_reset;
        private Button b_mouseRec_rec_stop;
        private Button b_mouseRec_rec_pause;
        private Button b_mouseRec_rec_start;

        public MouseRecordPanel() {
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
            this.groupBox_mouseRec_playback = new System.Windows.Forms.GroupBox();
            this.cbox_mouseRec_playback_showAllFrames = new System.Windows.Forms.CheckBox();
            this.slider_mouseRec_playback_progress = new System.Windows.Forms.TrackBar();
            this.b_mouseRec_playback_stop = new System.Windows.Forms.Button();
            this.b_mouseRec_playback_start = new System.Windows.Forms.Button();
            this.groupBox_mouseRec_record = new System.Windows.Forms.GroupBox();
            this.l_mouseRec_rec_recFrames = new System.Windows.Forms.Label();
            this.b_mouseRec_rec_reset = new System.Windows.Forms.Button();
            this.b_mouseRec_rec_stop = new System.Windows.Forms.Button();
            this.b_mouseRec_rec_pause = new System.Windows.Forms.Button();
            this.b_mouseRec_rec_start = new System.Windows.Forms.Button();
            this.groupBox_mouseRec_playback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_mouseRec_playback_progress)).BeginInit();
            this.groupBox_mouseRec_record.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_mouseRec_playback
            // 
            this.groupBox_mouseRec_playback.Controls.Add(this.cbox_mouseRec_playback_showAllFrames);
            this.groupBox_mouseRec_playback.Controls.Add(this.slider_mouseRec_playback_progress);
            this.groupBox_mouseRec_playback.Controls.Add(this.b_mouseRec_playback_stop);
            this.groupBox_mouseRec_playback.Controls.Add(this.b_mouseRec_playback_start);
            this.groupBox_mouseRec_playback.Location = new System.Drawing.Point(533, 340);
            this.groupBox_mouseRec_playback.Name = "groupBox_mouseRec_playback";
            this.groupBox_mouseRec_playback.Size = new System.Drawing.Size(530, 113);
            this.groupBox_mouseRec_playback.TabIndex = 3;
            this.groupBox_mouseRec_playback.TabStop = false;
            this.groupBox_mouseRec_playback.Text = "Playback";
            // 
            // cbox_mouseRec_playback_showAllFrames
            // 
            this.cbox_mouseRec_playback_showAllFrames.AutoSize = true;
            this.cbox_mouseRec_playback_showAllFrames.Location = new System.Drawing.Point(7, 87);
            this.cbox_mouseRec_playback_showAllFrames.Name = "cbox_mouseRec_playback_showAllFrames";
            this.cbox_mouseRec_playback_showAllFrames.Size = new System.Drawing.Size(100, 17);
            this.cbox_mouseRec_playback_showAllFrames.TabIndex = 3;
            this.cbox_mouseRec_playback_showAllFrames.Text = "Show all frames";
            this.cbox_mouseRec_playback_showAllFrames.UseVisualStyleBackColor = true;
            // 
            // slider_mouseRec_playback_progress
            // 
            this.slider_mouseRec_playback_progress.Location = new System.Drawing.Point(169, 20);
            this.slider_mouseRec_playback_progress.Name = "slider_mouseRec_playback_progress";
            this.slider_mouseRec_playback_progress.Size = new System.Drawing.Size(355, 45);
            this.slider_mouseRec_playback_progress.TabIndex = 2;
            // 
            // b_mouseRec_playback_stop
            // 
            this.b_mouseRec_playback_stop.Location = new System.Drawing.Point(88, 32);
            this.b_mouseRec_playback_stop.Name = "b_mouseRec_playback_stop";
            this.b_mouseRec_playback_stop.Size = new System.Drawing.Size(75, 23);
            this.b_mouseRec_playback_stop.TabIndex = 1;
            this.b_mouseRec_playback_stop.Text = "Stop";
            this.b_mouseRec_playback_stop.UseVisualStyleBackColor = true;
            // 
            // b_mouseRec_playback_start
            // 
            this.b_mouseRec_playback_start.Location = new System.Drawing.Point(7, 32);
            this.b_mouseRec_playback_start.Name = "b_mouseRec_playback_start";
            this.b_mouseRec_playback_start.Size = new System.Drawing.Size(75, 23);
            this.b_mouseRec_playback_start.TabIndex = 0;
            this.b_mouseRec_playback_start.Text = "Start";
            this.b_mouseRec_playback_start.UseVisualStyleBackColor = true;
            // 
            // groupBox_mouseRec_record
            // 
            this.groupBox_mouseRec_record.Controls.Add(this.l_mouseRec_rec_recFrames);
            this.groupBox_mouseRec_record.Controls.Add(this.b_mouseRec_rec_reset);
            this.groupBox_mouseRec_record.Controls.Add(this.b_mouseRec_rec_stop);
            this.groupBox_mouseRec_record.Controls.Add(this.b_mouseRec_rec_pause);
            this.groupBox_mouseRec_record.Controls.Add(this.b_mouseRec_rec_start);
            this.groupBox_mouseRec_record.Location = new System.Drawing.Point(3, 340);
            this.groupBox_mouseRec_record.Name = "groupBox_mouseRec_record";
            this.groupBox_mouseRec_record.Size = new System.Drawing.Size(524, 113);
            this.groupBox_mouseRec_record.TabIndex = 2;
            this.groupBox_mouseRec_record.TabStop = false;
            this.groupBox_mouseRec_record.Text = "Recording";
            // 
            // l_mouseRec_rec_recFrames
            // 
            this.l_mouseRec_rec_recFrames.AutoSize = true;
            this.l_mouseRec_rec_recFrames.Location = new System.Drawing.Point(6, 58);
            this.l_mouseRec_rec_recFrames.Name = "l_mouseRec_rec_recFrames";
            this.l_mouseRec_rec_recFrames.Size = new System.Drawing.Size(134, 13);
            this.l_mouseRec_rec_recFrames.TabIndex = 4;
            this.l_mouseRec_rec_recFrames.Text = "Amount recorded frames: 0";
            // 
            // b_mouseRec_rec_reset
            // 
            this.b_mouseRec_rec_reset.Location = new System.Drawing.Point(249, 19);
            this.b_mouseRec_rec_reset.Name = "b_mouseRec_rec_reset";
            this.b_mouseRec_rec_reset.Size = new System.Drawing.Size(75, 23);
            this.b_mouseRec_rec_reset.TabIndex = 3;
            this.b_mouseRec_rec_reset.Text = "Reset";
            this.b_mouseRec_rec_reset.UseVisualStyleBackColor = true;
            // 
            // b_mouseRec_rec_stop
            // 
            this.b_mouseRec_rec_stop.Location = new System.Drawing.Point(168, 19);
            this.b_mouseRec_rec_stop.Name = "b_mouseRec_rec_stop";
            this.b_mouseRec_rec_stop.Size = new System.Drawing.Size(75, 23);
            this.b_mouseRec_rec_stop.TabIndex = 2;
            this.b_mouseRec_rec_stop.Text = "Stop";
            this.b_mouseRec_rec_stop.UseVisualStyleBackColor = true;
            // 
            // b_mouseRec_rec_pause
            // 
            this.b_mouseRec_rec_pause.Location = new System.Drawing.Point(87, 19);
            this.b_mouseRec_rec_pause.Name = "b_mouseRec_rec_pause";
            this.b_mouseRec_rec_pause.Size = new System.Drawing.Size(75, 23);
            this.b_mouseRec_rec_pause.TabIndex = 1;
            this.b_mouseRec_rec_pause.Text = "Pause";
            this.b_mouseRec_rec_pause.UseVisualStyleBackColor = true;
            // 
            // b_mouseRec_rec_start
            // 
            this.b_mouseRec_rec_start.Location = new System.Drawing.Point(6, 19);
            this.b_mouseRec_rec_start.Name = "b_mouseRec_rec_start";
            this.b_mouseRec_rec_start.Size = new System.Drawing.Size(75, 23);
            this.b_mouseRec_rec_start.TabIndex = 0;
            this.b_mouseRec_rec_start.Text = "Start";
            this.b_mouseRec_rec_start.UseVisualStyleBackColor = true;
            // 
            // MouseRecordPanel
            // 
            this.Controls.Add(this.groupBox_mouseRec_playback);
            this.Controls.Add(this.groupBox_mouseRec_record);
            this.Name = "MouseRecordPanel";
            this.Size = new System.Drawing.Size(1074, 464);
            this.groupBox_mouseRec_playback.ResumeLayout(false);
            this.groupBox_mouseRec_playback.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_mouseRec_playback_progress)).EndInit();
            this.groupBox_mouseRec_record.ResumeLayout(false);
            this.groupBox_mouseRec_record.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
