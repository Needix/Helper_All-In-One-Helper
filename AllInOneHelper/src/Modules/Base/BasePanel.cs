using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace AllInOneHelper.Modules.Base {
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BasePanel, UserControl>))]
    public abstract class BasePanel : UserControl {//, IBasePanel  {
        public TabPage Page { get; set; }
        public BaseController Controller { get; set; }

        protected BasePanel() { }
        protected BasePanel(TabPage page) {
            this.Page = page;

            InitializeComponent();
            RegisterEvents();
        }

        protected abstract void InitializeComponent(); 
        protected abstract void RegisterEvents();
        public abstract void Close();
    }
}
