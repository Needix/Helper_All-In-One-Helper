using System.ComponentModel;
using System.Windows.Forms;

namespace AllInOneHelper.Modules.BaseModule {
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BasePanel, UserControl>))]
    public abstract class BasePanel : UserControl {
        public TabPage Page { get; set; }

        protected BasePanel(TabPage page) {
            this.Page = page;

            InitializeComponent();
            RegisterEvents();
        }

        protected abstract void InitializeComponent();
        protected abstract void RegisterEvents();

        public abstract void UpdateView();

        public abstract IBaseController GetController();
        public abstract void Close();
    }
}
