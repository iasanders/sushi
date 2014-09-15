using System;
using System.Collections.Generic;
using System.Text;

namespace SUSHI
{
    public class OldSharepointFile
    {
        public Guid UniqueId;
        public string FileName;
        public string DocumentLibName;

        public OldSharepointFile(Guid uniqueId, string fileName,string documentLibName)
        {
            this.UniqueId = uniqueId;
            this.FileName = fileName;
            this.DocumentLibName = documentLibName;
        }

    }
}
