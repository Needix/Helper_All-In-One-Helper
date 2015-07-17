using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.ClipboardHistory {
    class ClipboardController : BaseController {
        //Thread
        private readonly Thread _clipboardThread;
        private volatile Boolean _abort = false;
        private Boolean _active = true;
        private Boolean _autoScroll = true;

        private readonly List<ClipboardElement> _elementList = new List<ClipboardElement>();

        private readonly ClipboardPanel _clipboardPanel;
        private readonly ClipboardModel _model = new ClipboardModel();

        public ClipboardController(ClipboardPanel panel) {
            _clipboardPanel = panel;

            _clipboardThread = new Thread(Run);
            _clipboardThread.Name = "ClipboardThread";
            _clipboardThread.SetApartmentState(ApartmentState.STA);
            _clipboardThread.Start();
        }

        private void Run() {
            while(!_abort) {
                try { Thread.Sleep(100); } catch(ThreadInterruptedException) { return; } //Thread interrupted
                if(!this._active || !Clipboard.ContainsData(DataFormats.Text)) continue; //Histroy is not active or contains no text

                String data = (String)Clipboard.GetData(DataFormats.Text);
                if(_elementList.Count != 0 && data == _elementList[_elementList.Count - 1].Data) continue; //Current data is already last element

                ClipboardElement element = new ClipboardElement(data, DateTime.Now);
                _elementList.Add(element);
                _clipboardPanel.listBox_clipboard_list.Invoke(
                    (MethodInvoker)delegate {
                        _clipboardPanel.listBox_clipboard_list.Items.Add(element.DateTime + ": " + element.Data);
                        if(_autoScroll) _clipboardPanel.listBox_clipboard_list.SelectedIndex = _clipboardPanel.listBox_clipboard_list.Items.Count - 1;
                    }
                );
            }
        }

        #region Events
        public void ChangeStatus(object sender, EventArgs e) {
            _active = !_active;
        }

        public void CopySelectedIntoClipboard(object sender, EventArgs e) {
            int index = _clipboardPanel.listBox_clipboard_list.SelectedIndex;
            if(index == -1) return;

            ClipboardElement element = _elementList[index];
            Clipboard.SetText(element.Data);
        }

        public void DeleteAll(object sender, EventArgs e) {
            _clipboardPanel.listBox_clipboard_list.Items.Clear();
            _elementList.Clear();
        }

        public void DeleteSelected(object sender, EventArgs e) {
            int index = _clipboardPanel.listBox_clipboard_list.SelectedIndex;
            if(index == -1) return;

            _clipboardPanel.listBox_clipboard_list.Items.RemoveAt(index);
            _elementList.RemoveAt(index);
        }

        public void AutoScrollChange(object sender, EventArgs e) {
            _autoScroll = ((CheckBox)sender).Checked;
            if(_autoScroll) _clipboardPanel.listBox_clipboard_list.SelectedIndex = _clipboardPanel.listBox_clipboard_list.Items.Count - 1;
        }
        #endregion

        public override void Update() {
            throw new NotImplementedException();
        }

        public override void Close() {
            this._abort = true;
            _clipboardThread.Interrupt();
        }
    }
}
