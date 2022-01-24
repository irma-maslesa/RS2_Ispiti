using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace eProdaja.Database.Helpers
{
    public static class HelperClass
    {
        public static string GetFilePathJsonData(string fileName)
        {
            string exeFile = AppDomain.CurrentDomain.BaseDirectory;
            string exeDir = Path.GetDirectoryName(exeFile);
            string fullPath = exeDir.ToString() + "/DataSeedJson/" + fileName;
            return fullPath;
        }
        public static List<T> LoadJsonFromFile<T>(string fileName)
        {
            using (StreamReader r = new StreamReader(GetFilePathJsonData(fileName)))
            {
                string json = r.ReadToEnd();
                List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
                return items;
            }
        }
    }
}
