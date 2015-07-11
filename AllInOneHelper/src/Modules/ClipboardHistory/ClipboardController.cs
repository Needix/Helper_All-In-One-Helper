using AllInOneHelper.src.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.ClipboardHistory {
    class ClipboardController : BaseController {
        //Thread
        private Thread clipboardThread;
        private volatile Boolean abort = false;
        private Boolean active = true;
        private Boolean autoScroll = true;

        private List<ClipboardElement> elementList = new List<ClipboardElement>();

        ClipboardPanel clipboardPanel;

        public ClipboardController(ClipboardPanel panel) {
            clipboardPanel = panel;

            clipboardThread = new Thread(Run);
            clipboardThread.Name = "ClipboardThread";
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.Start();
        }

        private void Run() {
            while(!abort) {
                try { Thread.Sleep(100); } catch(ThreadInterruptedException) { return; } //Thread interrupted
                if(!this.active || !Clipboard.ContainsData(DataFormats.Text)) continue; //Histroy is not active or contains no text

                String data = (String)Clipboard.GetData(DataFormats.Text);
                if(elementList.Count != 0 && data == elementList[elementList.Count - 1].Data) continue; //Current data is already last element

                ClipboardElement element = new ClipboardElement(data, DateTime.Now);
                elementList.Add(element);
                clipboardPanel.listBox_clipboard_list.Invoke(
                    (MethodInvoker)delegate {
                        clipboardPanel.listBox_clipboard_list.Items.Add(element.DateTime + ": " + element.Data);
                        if(autoScroll) clipboardPanel.listBox_clipboard_list.SelectedIndex = clipboardPanel.listBox_clipboard_list.Items.Count - 1;
                    }
                );
            }
        }

        #region Events
        public void ChangeStatus(object sender, System.EventArgs e) {
            active = !active;
        }

        public void CopySelectedIntoClipboard(object sender, System.EventArgs e) {
            int index = clipboardPanel.listBox_clipboard_list.SelectedIndex;
            if(index == -1) return;

            ClipboardElement element = elementList[index];
            Clipboard.SetText(element.Data);
        }

        public void DeleteAll(object sender, System.EventArgs e) {
            clipboardPanel.listBox_clipboard_list.Items.Clear();
            elementList.Clear();
        }

        public void DeleteSelected(object sender, System.EventArgs e) {
            int index = clipboardPanel.listBox_clipboard_list.SelectedIndex;
            if(index == -1) return;

            clipboardPanel.listBox_clipboard_list.Items.RemoveAt(index);
            elementList.RemoveAt(index);
        }

        public void AutoScrollChange(object sender, System.EventArgs e) {
            autoScroll = ((CheckBox)sender).Checked;
            if(autoScroll) clipboardPanel.listBox_clipboard_list.SelectedIndex = clipboardPanel.listBox_clipboard_list.Items.Count - 1;
        }
        #endregion

        public override void Close() {
            this.abort = true;
            clipboardThread.Interrupt();
        }
    }
}
