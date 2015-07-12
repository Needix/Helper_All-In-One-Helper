using System;

namespace AllInOneHelper.Modules.ClipboardHistory {
    class ClipboardElement {
        private String data; public String Data { get { return this.data; } set { this.data = value; } }
        private DateTime dateTime; public DateTime DateTime { get { return this.dateTime; } set { this.dateTime = value; } }

        public ClipboardElement(String data, DateTime dateTime) {
            this.data = data;
            this.dateTime = dateTime;
        }
    }
}
