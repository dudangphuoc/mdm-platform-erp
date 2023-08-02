using System;
using System.IO;
using System.Linq;
using Abp.Reflection.Extensions;

namespace MDMPlatform.Web
{
    /// <summary>
    /// This class is used to find root projectName of the web project in;
    /// unit tests (to find views) and entity framework core command line commands (to find conn string).
    /// </summary>
    public static class WebContentDirectoryFinder
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectName">[MDMPlatform.Web.Host, MDMPlatform.Web.Mvc, self host projectName]</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string CalculateContentRootFolder(string serviceName, string projectName)
        {
            var coreAssemblyDirectoryPath = Path.GetDirectoryName(typeof(MDMPlatformCoreModule).GetAssembly().Location);
            if (coreAssemblyDirectoryPath == null)
            {
                throw new Exception("Could not find location of MDMPlatform.Core assembly!");
            }

            var directoryInfo = new DirectoryInfo(coreAssemblyDirectoryPath);
            while (!DirectoryContains(directoryInfo.FullName, "MDMPlatform.sln"))
            {
                if (directoryInfo.Parent == null)
                    throw new Exception("Could not find content root folder!");

                directoryInfo = directoryInfo.Parent;
            }

            var webHostFolder = Path.Combine(directoryInfo.FullName, "src", "services", serviceName, projectName);
            if (Directory.Exists(webHostFolder))
                return webHostFolder;

            throw new Exception("Could not find root folder of the web project!");
        }

        private static bool DirectoryContains(string directory, string fileName)
        {
            return Directory.GetFiles(directory).Any(filePath => string.Equals(Path.GetFileName(filePath), fileName));
        }
    }
}
