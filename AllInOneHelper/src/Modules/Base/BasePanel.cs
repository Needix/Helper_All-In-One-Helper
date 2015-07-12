using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace AllInOneHelper.Modules.Base {
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BasePanel, UserControl>))]
    public abstract class BasePanel : UserControl, ISerializable {//, IBasePanel  {
        public TabPage Page { get; set; }

        protected BasePanel() { }
        protected BasePanel(TabPage page) {
            this.Page = page;

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
