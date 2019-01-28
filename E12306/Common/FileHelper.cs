using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace E12306.Common
{
    public class FileHelper
    {
        public static async Task<T> ReadFileAsync<T>(string path)
        {
            var text = await File.ReadAllTextAsync(path);
            return JsonConvert.DeserializeObject<T>(text);

        }

        public static T ReadFile<T>(string path)
        {
            var text = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(text);

        }
    }
}
