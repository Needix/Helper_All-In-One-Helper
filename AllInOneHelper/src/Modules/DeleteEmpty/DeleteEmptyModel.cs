﻿using System;
using AllInOneHelper.Modules.Base;

namespace AllInOneHelper.Modules.DeleteEmpty {
    public class DeleteEmptyModel : BaseModel {
        public String FAF_Option { get; set; }
        public Boolean CountFirst { get; set; }
        public Boolean IncludeSubDirs { get; set; }
    }
}
