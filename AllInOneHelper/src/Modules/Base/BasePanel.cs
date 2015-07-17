using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace AllInOneHelper.Modules.Base {
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BasePanel, UserControl>))]
    public abstract class BasePanel : UserControl {//, IBasePanel  {
        public TabPage Page { get; set; }
        //public BaseController Controller { get; set;}

        //private static BasePanel _mainPanel;
        //public static BasePanel GetInstance { get { return _mainPanel; } set { if(GetInstance == null) _mainPanel = value; } }

        //protected BasePanel() { }
        protected BasePanel(TabPage page) { //, BaseController controller) {
            this.Page = page;
            //this.Controller = controller;
            //_mainPanel = this;

            InitializeComponent();
            RegisterEvents();
        }

        protected abstract void InitializeComponent(); 
        protected abstract void RegisterEvents();
        public abstract void Close();
    }
}
