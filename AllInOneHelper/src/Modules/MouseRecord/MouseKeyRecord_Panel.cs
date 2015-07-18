using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.MouseRecord {
    class MouseKeyRecord_Panel : BasePanel {
        private GroupBox groupBox_mouseRec_playback;
        private CheckBox cbox_mouseRec_playback_showAllFrames;
        private TrackBar slider_mouseRec_playback_progress;
        private Button b_mouseRec_playback_stop;
        private Button b_mouseRec_playback_start;

        private GroupBox groupBox_mouseRec_record;
        private Label l_mouseRec_rec_recFrames;
        private Button b_mouseRec_rec_start;
        private CheckBox cbox_mouseRec_pause;
        private Button b_mouseRec_rec_stop;
        private Button b_mouseRec_rec_reset;

        private ListBox listBox_mouseRecord_keyRecord;
        private MouseKey_Playback_Panel panel_mouseRec_playbackPanel; 
        public MouseKey_Playback_Panel PlaybackPanel { get { return panel_mouseRec_playbackPanel;} }

        public MouseKeyRecord_Panel(TabPage tabPage) : base(tabPage) {
            this.panel_mouseRec_playbackPanel.MouseRecordPanel = this;

            cbox_mouseRec_pause.Enabled = false;
            b_mouseRec_rec_stop.Enabled = false;
            b_mouseRec_rec_reset.Enabled = false;
            b_mouseRec_playback_stop.Enabled = false;
        }

        protected override void RegisterEvents() {
            MouseKey_Recorder mouseKeyRecorder = panel_mouseRec_playbackPanel.MouseKeyRecorder;
            b_mouseRec_rec_start.Click +=           mouseKeyRecorder.StartRec;
            cbox_mouseRec_pause.CheckedChanged +=   mouseKeyRecorder.PauseRec;
            b_mouseRec_rec_stop.Click +=            mouseKeyRecorder.StopRec;
            b_mouseRec_rec_reset.Click +=           mouseKeyRecorder.ResetRec;

            b_mouseRec_playback_start.Click +=                      panel_mouseRec_playbackPanel.StartPlayback;
            b_mouseRec_playback_stop.Click +=                       panel_mouseRec_playbackPanel.StopPlayback;
            slider_mouseRec_playback_progress.ValueChanged +=       panel_mouseRec_playbackPanel.ChangePlaybackTime;
            cbox_mouseRec_playback_showAllFrames.CheckedChanged +=  panel_mouseRec_playbackPanel.ChangeShowAllFrames;
        }

        public override void UpdateView() {
            if (!this.Created) return;
            try {
                this.Invoke((MethodInvoker) delegate {
                    MouseKey_Model model = panel_mouseRec_playbackPanel.Model;

                    Debug.WriteLine(model.GetHashCode() +" / "+ panel_mouseRec_playbackPanel.MouseKeyRecorder.Model().GetHashCode());
                    
                    l_mouseRec_rec_recFrames.Text = "Recorded Frames: " + model.RecordedFrames;

                    b_mouseRec_rec_start.Enabled = model.RecStartEnabled;
                    cbox_mouseRec_pause.Enabled = model.RecPauseEnabled;
                    cbox_mouseRec_pause.Checked = model.RecPauseChecked;
                    b_mouseRec_rec_stop.Enabled = model.RecStopEnabled;
                    b_mouseRec_rec_reset.Enabled = model.RecResetEnabled;

                    b_mouseRec_playback_start.Enabled = model.PlaybackStartEnabled;
                    b_mouseRec_playback_stop.Enabled = model.PlaybackStopEnabled;

                    slider_mouseRec_playback_progress.Maximum = model.MaxPlaybackTime;
                    slider_mouseRec_playback_progress.Value = model.CurPlaybackTime;

                    listBox_mouseRecord_keyRecord.Items.Clear();
                    if (model.PressedKeys != null)
                        listBox_mouseRecord_keyRecord.Items.AddRange(model.PressedKeys);
                });
            } catch (ThreadInterruptedException) {} //HACK Find out why ThreadInterruptedException/ObjectDisposedException is thrown
        }

        public void StopPlayback() {
            b_mouseRec_playback_stop.PerformClick(); 
        }

        public override BaseController GetController() {
            return panel_mouseRec_playbackPanel.MouseKeyRecorder;
        }

        public override void Close() {
            panel_mouseRec_playbackPanel.Close();
            panel_mouseRec_playbackPanel.MouseKeyRecorder.Close();
        }

        protected override void InitializeComponent() {
            this.groupBox_mouseRec_playback = new GroupBox();
            this.cbox_mouseRec_playback_showAllFrames = new CheckBox();
            this.slider_mouseRec_playback_progress = new TrackBar();
            this.b_mouseRec_playback_stop = new Button();
            this.b_mouseRec_playback_start = new Button();
            this.groupBox_mouseRec_record = new GroupBox();
            this.cbox_mouseRec_pause = new CheckBox();
            this.l_mouseRec_rec_recFrames = new Label();
            this.b_mouseRec_rec_reset = new Button();
            this.b_mouseRec_rec_stop = new Button();
            this.b_mouseRec_rec_start = new Button();
            this.listBox_mouseRecord_keyRecord = new ListBox();
            this.panel_mouseRec_playbackPanel = new MouseKey_Playback_Panel();
            this.groupBox_mouseRec_playback.SuspendLayout();
            ((ISupportInitialize)(this.slider_mouseRec_playback_progress)).BeginInit();
            this.groupBox_mouseRec_record.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_mouseRec_playback
            // 
            this.groupBox_mouseRec_playback.Controls.Add(this.cbox_mouseRec_playback_showAllFrames);
            this.groupBox_mouseRec_playback.Controls.Add(this.slider_mouseRec_playback_progress);
            this.groupBox_mouseRec_playback.Controls.Add(this.b_mouseRec_playback_stop);
            this.groupBox_mouseRec_playback.Controls.Add(this.b_mouseRec_playback_start);
            this.groupBox_mouseRec_playback.Location = new Point(350, 340);
            this.groupBox_mouseRec_playback.Name = "groupBox_mouseRec_playback";
            this.groupBox_mouseRec_playback.Size = new Size(530, 113);
            this.groupBox_mouseRec_playback.TabIndex = 3;
            this.groupBox_mouseRec_playback.TabStop = false;
            this.groupBox_mouseRec_playback.Text = "Playback";
            // 
            // cbox_mouseRec_playback_showAllFrames
            // 
            this.cbox_mouseRec_playback_showAllFrames.AutoSize = true;
            this.cbox_mouseRec_playback_showAllFrames.Checked = true;
            this.cbox_mouseRec_playback_showAllFrames.CheckState = CheckState.Checked;
            this.cbox_mouseRec_playback_showAllFrames.Location = new Point(7, 87);
            this.cbox_mouseRec_playback_showAllFrames.Name = "cbox_mouseRec_playback_showAllFrames";
            this.cbox_mouseRec_playback_showAllFrames.Size = new Size(100, 17);
            this.cbox_mouseRec_playback_showAllFrames.TabIndex = 3;
            this.cbox_mouseRec_playback_showAllFrames.Text = "Show all frames";
            this.cbox_mouseRec_playback_showAllFrames.UseVisualStyleBackColor = true;
            // 
            // slider_mouseRec_playback_progress
            // 
            this.slider_mouseRec_playback_progress.Location = new Point(169, 20);
            this.slider_mouseRec_playback_progress.Name = "slider_mouseRec_playback_progress";
            this.slider_mouseRec_playback_progress.Size = new Size(355, 45);
            this.slider_mouseRec_playback_progress.TabIndex = 2;
            // 
            // b_mouseRec_playback_stop
            // 
            this.b_mouseRec_playback_stop.Location = new Point(88, 32);
            this.b_mouseRec_playback_stop.Name = "b_mouseRec_playback_stop";
            this.b_mouseRec_playback_stop.Size = new Size(75, 23);
            this.b_mouseRec_playback_stop.TabIndex = 1;
            this.b_mouseRec_playback_stop.Text = "Stop";
            this.b_mouseRec_playback_stop.UseVisualStyleBackColor = true;
            // 
            // b_mouseRec_playback_start
            // 
            this.b_mouseRec_playback_start.Location = new Point(7, 32);
            this.b_mouseRec_playback_start.Name = "b_mouseRec_playback_start";
            this.b_mouseRec_playback_start.Size = new Size(75, 23);
            this.b_mouseRec_playback_start.TabIndex = 0;
            this.b_mouseRec_playback_start.Text = "Start";
            this.b_mouseRec_playback_start.UseVisualStyleBackColor = true;
            // 
            // groupBox_mouseRec_record
            // 
            this.groupBox_mouseRec_record.Controls.Add(this.cbox_mouseRec_pause);
            this.groupBox_mouseRec_record.Controls.Add(this.l_mouseRec_rec_recFrames);
            this.groupBox_mouseRec_record.Controls.Add(this.b_mouseRec_rec_reset);
            this.groupBox_mouseRec_record.Controls.Add(this.b_mouseRec_rec_stop);
            this.groupBox_mouseRec_record.Controls.Add(this.b_mouseRec_rec_start);
            this.groupBox_mouseRec_record.Location = new Point(3, 340);
            this.groupBox_mouseRec_record.Name = "groupBox_mouseRec_record";
            this.groupBox_mouseRec_record.Size = new Size(341, 113);
            this.groupBox_mouseRec_record.TabIndex = 2;
            this.groupBox_mouseRec_record.TabStop = false;
            this.groupBox_mouseRec_record.Text = "Recording";
            // 
            // cbox_mouseRec_pause
            // 
            this.cbox_mouseRec_pause.Appearance = Appearance.Button;
            this.cbox_mouseRec_pause.Location = new Point(87, 19);
            this.cbox_mouseRec_pause.Name = "cbox_mouseRec_pause";
            this.cbox_mouseRec_pause.Size = new Size(75, 24);
            this.cbox_mouseRec_pause.TabIndex = 5;
            this.cbox_mouseRec_pause.Text = "Pause";
            this.cbox_mouseRec_pause.TextAlign = ContentAlignment.MiddleCenter;
            this.cbox_mouseRec_pause.UseVisualStyleBackColor = true;
            // 
            // l_mouseRec_rec_recFrames
            // 
            this.l_mouseRec_rec_recFrames.AutoSize = true;
            this.l_mouseRec_rec_recFrames.Location = new Point(6, 58);
            this.l_mouseRec_rec_recFrames.Name = "l_mouseRec_rec_recFrames";
            this.l_mouseRec_rec_recFrames.Size = new Size(134, 13);
            this.l_mouseRec_rec_recFrames.TabIndex = 4;
            this.l_mouseRec_rec_recFrames.Text = "Amount recorded frames: 0";
            // 
            // b_mouseRec_rec_reset
            // 
            this.b_mouseRec_rec_reset.Location = new Point(249, 19);
            this.b_mouseRec_rec_reset.Name = "b_mouseRec_rec_reset";
            this.b_mouseRec_rec_reset.Size = new Size(75, 23);
            this.b_mouseRec_rec_reset.TabIndex = 3;
            this.b_mouseRec_rec_reset.Text = "Reset";
            this.b_mouseRec_rec_reset.UseVisualStyleBackColor = true;
            // 
            // b_mouseRec_rec_stop
            // 
            this.b_mouseRec_rec_stop.Location = new Point(168, 19);
            this.b_mouseRec_rec_stop.Name = "b_mouseRec_rec_stop";
            this.b_mouseRec_rec_stop.Size = new Size(75, 23);
            this.b_mouseRec_rec_stop.TabIndex = 2;
            this.b_mouseRec_rec_stop.Text = "Stop";
            this.b_mouseRec_rec_stop.UseVisualStyleBackColor = true;
            // 
            // b_mouseRec_rec_start
            // 
            this.b_mouseRec_rec_start.Location = new Point(6, 19);
            this.b_mouseRec_rec_start.Name = "b_mouseRec_rec_start";
            this.b_mouseRec_rec_start.Size = new Size(75, 23);
            this.b_mouseRec_rec_start.TabIndex = 0;
            this.b_mouseRec_rec_start.Text = "Start";
            this.b_mouseRec_rec_start.UseVisualStyleBackColor = true;
            // 
            // listBox_mouseRecord_keyRecord
            // 
            this.listBox_mouseRecord_keyRecord.FormattingEnabled = true;
            this.listBox_mouseRecord_keyRecord.Location = new Point(886, 340);
            this.listBox_mouseRecord_keyRecord.Name = "listBox_mouseRecord_keyRecord";
            this.listBox_mouseRecord_keyRecord.Size = new Size(185, 121);
            this.listBox_mouseRecord_keyRecord.TabIndex = 4;
            // 
            // panel_mouseRec_playbackPanel
            // 
            this.panel_mouseRec_playbackPanel.Location = new Point(9, 3);
            this.panel_mouseRec_playbackPanel.Name = "panel_mouseRec_playbackPanel";
            this.panel_mouseRec_playbackPanel.Size = new Size(1062, 331);
            this.panel_mouseRec_playbackPanel.TabIndex = 5;
            // 
            // MouseRecord_Panel
            // 
            this.Controls.Add(this.panel_mouseRec_playbackPanel);
            this.Controls.Add(this.listBox_mouseRecord_keyRecord);
            this.Controls.Add(this.groupBox_mouseRec_playback);
            this.Controls.Add(this.groupBox_mouseRec_record);
            this.Name = "MouseRecord_Panel";
            this.Size = new Size(1074, 469);
            this.groupBox_mouseRec_playback.ResumeLayout(false);
            this.groupBox_mouseRec_playback.PerformLayout();
            ((ISupportInitialize)(this.slider_mouseRec_playback_progress)).EndInit();
            this.groupBox_mouseRec_record.ResumeLayout(false);
            this.groupBox_mouseRec_record.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
