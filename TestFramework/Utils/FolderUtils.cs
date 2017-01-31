using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSitePOM.Utils
{
    public static class FolderUtils
    {
        public static string GetPathAsLocalFileUri(string localRelativePath)
        {
            var testExecutionPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var path = Path.Combine(testExecutionPath, localRelativePath);
            var uri = new System.Uri(path);
            var convertedUri = uri.AbsoluteUri;
            return convertedUri;
        }
    }
}
