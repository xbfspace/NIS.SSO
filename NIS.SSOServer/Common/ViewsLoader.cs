using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NIS.SSOServer.Common
{
    public class ViewsLoader
    {
        private static readonly ConcurrentDictionary<string, string> ViewsCache = new ConcurrentDictionary<string, string>();

        public static string Load(string filePath) {
            string fileContent = string.Empty;
#if !DEBUG
            if (ViewsCache.TryGetValue(filePath,out fileContent)) {
                return fileContent;
            }
#endif
            if (File.Exists(filePath)) {
                fileContent = File.ReadAllText(filePath);
                ViewsCache.TryAdd(filePath, fileContent);
            }
            return fileContent;
        }
        public static Stream StringToStream(string s)
        {
            if (s == null) throw new ArgumentNullException("s");
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(s);
            sw.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}