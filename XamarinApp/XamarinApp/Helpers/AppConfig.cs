using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace XamarinApp.Helpers
{
    public static class AppConfig
    {
        public static string GetEBayAppName()
        {
            return GetBase("ebay-app-name");
        }

        static string GetBase(string configKey)
        {
            var type = typeof(AppConfig);
            var resource = string.Format("XamarinApp.Android.config.xml");

            //test for resource files
            //string[] names = type.Assembly.GetManifestResourceNames();

            using (var stream = type.Assembly.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                var doc = XDocument.Parse(reader.ReadToEnd());

                return doc.Element("config").Element(configKey).Value;
            }
        }
    }
}
