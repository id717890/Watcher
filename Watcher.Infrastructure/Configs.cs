using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace Watcher.Infrastructure
{
    public class Configs
    {
        public static string AppFolder = AppDomain.CurrentDomain.BaseDirectory;
        public static string GroupListFolder => ConfigurationSettings.AppSettings.Get("GroupListFolder");
        public static string GroupListFilePrefix => ConfigurationSettings.AppSettings.Get("GroupListFilePrefix");
        public static string OpcConnectionString => ConfigurationSettings.AppSettings.Get("OpcConnectionString");

        //public static string FileCommandName => ConfigurationSettings.AppSettings.Get("FileCommandName");

        public static string[] GoodQualityVariants()
        {
            var data = ConfigurationSettings.AppSettings.Get("GoodQualityList");
            return data != null ? data.Split(',').Select(x => x.ToLower()).ToArray(): new string[] { };
        }

        public static string[] BadQualityVariants()
        {
            var data = ConfigurationSettings.AppSettings.Get("BadQualityList");
            return data != null ? data.Split(',').Select(x => x.ToLower()).ToArray() : new string[] { };
        }
    }
}
