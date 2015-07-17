namespace AllInOneHelper.Modules.CopyFinder {
    class CopyFinderController {
        private readonly CopyFinderPanel _basePanel;
        private readonly CopyFinderModel _model = new CopyFinderModel();

        public CopyFinderController(CopyFinderPanel panel) {
            this._basePanel = panel;
        }
    }
}
