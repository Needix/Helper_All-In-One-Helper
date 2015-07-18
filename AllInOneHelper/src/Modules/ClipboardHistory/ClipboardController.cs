using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using AllInOneHelper.Modules.BaseModule;

namespace AllInOneHelper.Modules.ClipboardHistory {
    class ClipboardController : IBaseController {
        //Thread
        private readonly Thread _clipboardThread;
        private volatile Boolean _abort = false;
        private Boolean _active = true;
        private Boolean _autoScroll = true;

        private readonly List<ClipboardElement> _elementList = new List<ClipboardElement>();

        private readonly ClipboardPanel _basePanel;
        private ClipboardModel _model = new ClipboardModel();

        public ClipboardController(ClipboardPanel panel) {
            _basePanel = panel;

            _clipboardThread = new Thread(Run);
            _clipboardThread.Name = "ClipboardThread";
            _clipboardThread.SetApartmentState(ApartmentState.STA);
            _clipboardThread.Start();
        }

        private void Run() {
            while(!_abort) {
                try { Thread.Sleep(100); } catch(ThreadInterruptedException) { return; } //Thread interrupted
                if(!this._active || !Clipboard.ContainsData(DataFormats.Text) || !_basePanel.Created) continue; //Histroy is not active or contains no text

                String data = (String)Clipboard.GetData(DataFormats.Text);
                if(_elementList.Count != 0 && data == _elementList[_elementList.Count - 1].Data) continue; //Current data is already last element

                ClipboardElement element = new ClipboardElement(data, DateTime.Now);
                _elementList.Add(element);
                _basePanel.listBox_clipboard_list.Invoke(
                    (MethodInvoker)delegate {
                        _basePanel.listBox_clipboard_list.Items.Add(element.DateTime + ": " + element.Data);
                        if(_autoScroll) _basePanel.listBox_clipboard_list.SelectedIndex = _basePanel.listBox_clipboard_list.Items.Count - 1;
                    }
                );
            }
        }

        #region Events
        public void ChangeStatus(object sender, EventArgs e) {
            _active = !_active;
        }

        public void CopySelectedIntoClipboard(object sender, EventArgs e) {
            int index = _basePanel.listBox_clipboard_list.SelectedIndex;
            if(index == -1) return;

            ClipboardElement element = _elementList[index];
            Clipboard.SetText(element.Data);
        }

        public void DeleteAll(object sender, EventArgs e) {
            _basePanel.listBox_clipboard_list.Items.Clear();
            _elementList.Clear();
        }

        public void DeleteSelected(object sender, EventArgs e) {
            int index = _basePanel.listBox_clipboard_list.SelectedIndex;
            if(index == -1) return;

            _basePanel.listBox_clipboard_list.Items.RemoveAt(index);
            _elementList.RemoveAt(index);
        }

        public void AutoScrollChange(object sender, EventArgs e) {
            _autoScroll = ((CheckBox)sender).Checked;
            if(_autoScroll) _basePanel.listBox_clipboard_list.SelectedIndex = _basePanel.listBox_clipboard_list.Items.Count - 1;
        }
        #endregion

        public virtual BaseModel Model(BaseModel model = null) {
            if(model == null)
                return _model;
            else {
                _model = (ClipboardModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }

        public virtual void Close() {
            this._abort = true;
            _clipboardThread.Interrupt();
        }
    }
}
