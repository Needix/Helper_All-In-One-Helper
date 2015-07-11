using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AllInOneHelper.src.Modules.Base {
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BasePanel, UserControl>))]
    abstract class BasePanel : UserControl {//, IBasePanel  {
        public BasePanel() {
            InitializeComponent();
            RegisterEvents();
        }

        protected abstract void InitializeComponent(); 
        protected abstract void RegisterEvents();
        public abstract void Close();
    }
}
