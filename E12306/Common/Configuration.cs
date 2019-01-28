using E12306.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.Common
{
    public class Configuration
    {
        static Configuration()
        {
            AppSettings = FileHelper.ReadFile<AppSettings>("appsettings.json");
        }
        public static AppSettings AppSettings { get; }
    }
}
