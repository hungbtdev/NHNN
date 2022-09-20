using Microsoft.Extensions.Logging;
using System.IO;
using Vinorsoft.NHNN.Report.Service.Interface;

namespace Vinorsoft.NHNN.Report.Service
{
    public class CleanService : ICleanService
    {
        ILogger<CleanService> logger;
        public CleanService(ILogger<CleanService> logger)
        {
            this.logger = logger;
        }
        public void CleanFolder(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    foreach (FileInfo file in di.EnumerateFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.EnumerateDirectories())
                    {
                        dir.Delete(true);
                    }
                }
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex.Message, ex, new string[] { });
            }
        }
    }
}
