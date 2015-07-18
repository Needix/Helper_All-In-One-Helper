namespace AllInOneHelper.Modules.BaseModule {
    public abstract class BaseController {
        //public BaseModel Model { get; set; }

        protected BaseController() {
            
        }

        public abstract void Close();

        public abstract BaseModel Model(BaseModel model = null);

        //public abstract void Serialize(FileStream fileStream);
        //public abstract BasePanel Deserialize();
    }
}
