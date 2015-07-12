using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace AllInOneHelper.Modules.Base {
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BasePanel, UserControl>))]
    abstract class BasePanel : UserControl, ISerializable {//, IBasePanel  {
        private readonly TabPage _page; public TabPage Page {get { return _page; } }

        protected BasePanel(TabPage page) {
            this._page = page;

            InitializeComponent();
            RegisterEvents();
        }

        protected abstract void InitializeComponent(); 
        protected abstract void RegisterEvents();
        public abstract void Close();
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            // Use the AddValue method to specify serialized values.
            //info.AddValue("minimizeIntoTray", minimizeIntoTray, typeof(Boolean));

        }
    }
}
