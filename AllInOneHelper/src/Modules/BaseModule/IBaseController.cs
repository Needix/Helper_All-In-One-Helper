namespace AllInOneHelper.Modules.BaseModule {
    public interface IBaseController {
        void Close();
        BaseModel Model(BaseModel model = null);
    }
}
