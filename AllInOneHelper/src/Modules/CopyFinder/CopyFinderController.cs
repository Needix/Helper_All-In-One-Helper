using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization.Configuration;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.CopyFinder {
    class CopyFinderController : BaseController {
        private readonly CopyFinderPanel _basePanel;
        private CopyFinderModel _model = new CopyFinderModel();

        public CopyFinderController(CopyFinderPanel panel) {
            this._basePanel = panel;
        }

        public void FindCopiesEverywhere(Object sender, EventArgs e) {
            _basePanel.ClearList();

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives) {
                DirectoryInfo dirInfo = drive.RootDirectory;
                StartRekThread(dirInfo);
            }
        }

        public void FindCopiesInFolder(Object sender, EventArgs e) {
            _basePanel.ClearList();

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                String path = dialog.SelectedPath;
                StartRekThread(new DirectoryInfo(path));
            }
        }

        public void DeleteAllFolder(Object sender, EventArgs e) {
            List<String> paths = _basePanel.GetAllPaths();
            foreach(string path in paths) {
                DeleteFileFolder(path);
            }
        }

        public void DeleteSelectedFolder(Object sender, EventArgs e) {
            List<String> paths = _basePanel.GetSelectedPaths();
            foreach(string path in paths) {
                DeleteFileFolder(path);
            }
        }

        private void DeleteFileFolder(String path) {
            if(File.Exists(path))
                try { File.Delete(path); } catch(FileNotFoundException) { } catch(UnauthorizedAccessException) { }
            if(Directory.Exists(path))
                try { Directory.Delete(path, true); } catch(DirectoryNotFoundException) { } catch(UnauthorizedAccessException) { }
        }

        public void AutomaticallyDeleteIfFoundChanged(Object sender, EventArgs e) {
            CheckBox cbox = (CheckBox) sender;
            _model.AutomaticallyDeleteIfFound = cbox.Checked; //TODO Check whether clicked event is occured before or after value change
        }

        private Thread StartRekThread(DirectoryInfo info) {
            ParameterizedThreadStart pts = new ParameterizedThreadStart(FindRek);
            Thread t = new Thread(pts);
            t.Name = "RekursiveFindCopies Thread";
            t.Start(info);
            return t;
        }

        private void FindRek(object param) {
            FindRek((DirectoryInfo)param, 0, _model.AutomaticallyDeleteIfFound);
        }
        private int FindRek(DirectoryInfo root, int searchedFolder, Boolean deleteIfFound) {
            try {
                DirectoryInfo[] directoryInfos = root.GetDirectories();
                FileInfo[] fileInfos = root.GetFiles();

                foreach (FileInfo curFileInfo in fileInfos) {
                    if (curFileInfo.Name.Contains(" - Copy") || curFileInfo.Name.Contains(" - Kopie")) {
                        if(deleteIfFound)
                            DeleteFileFolder(curFileInfo.FullName);
                        else
                            _basePanel.AddPathToList(curFileInfo.FullName);
                    }
                }

                foreach (DirectoryInfo curRoot in directoryInfos) {
                    if(curRoot.Name.Contains(" - Copy") || curRoot.Name.Contains(" - Kopie")) {
                        if(deleteIfFound)
                            DeleteFileFolder(curRoot.FullName);
                        else
                            _basePanel.AddPathToList(curRoot.FullName);
                    }
                    _basePanel.SetSearchedFolder(searchedFolder);
                    searchedFolder = FindRek(curRoot, searchedFolder + 1, deleteIfFound);
                }
            } catch (UnauthorizedAccessException) {
            } catch(IOException) { }
            return searchedFolder;
        }

        public override void Close() {
            throw new System.NotImplementedException();
        }

        public override BaseModel Model(BaseModel model = null) {
            if(model==null)
                return _model;
            else {
                _model = (CopyFinderModel)model;
                _basePanel.UpdateView();
                return null;
            }
        }
    }
}
