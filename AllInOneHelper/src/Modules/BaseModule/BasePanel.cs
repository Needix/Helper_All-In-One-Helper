using System.ComponentModel;
using System.Windows.Forms;

namespace AllInOneHelper.Modules.BaseModule {
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BasePanel, UserControl>))]
    public abstract class BasePanel : UserControl {//, IBasePanel  {
        public TabPage Page { get; set; }

        protected BasePanel(TabPage page) { //, BaseController controller) {
            this.Page = page;

            InitializeComponent();
            RegisterEvents();
        }

        protected abstract void InitializeComponent();
        protected abstract void RegisterEvents();

        public abstract void UpdateView();

        public abstract BaseController GetController();
        public abstract void Close();
    }
}
