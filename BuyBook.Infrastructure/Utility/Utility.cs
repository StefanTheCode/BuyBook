using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BuyBook.Infrastructure.Utility
{
    public class UtilityClass
    {
        public static string GetFullFilePath(string fileName)
        {
            string binFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvPath = Path.Combine(binFolderPath, "Files", fileName);

            return csvPath;
        }

        public static string LoadExcelData(string fileName)
        {
            try
            {
                string path = GetFullFilePath(fileName);
                
                if (!File.Exists(path))
                {
                    return string.Empty;
                }

                return File.ReadAllText(path);
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}
