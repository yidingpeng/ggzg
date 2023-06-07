using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace RW.PMS.Utils.Driver
{
    public class OPCConfigHelper
    {
        public static void Load(string filename, OPCDriver driver)
        {
            if (!File.Exists(filename))
                return;
            using (StreamReader reader = new StreamReader(filename))
            {
                object obj = serializer.Deserialize(reader);
                OPCConfig config = obj as OPCConfig;
                driver.LoadConfig(config);
                //return config;
            }
        }

        static XmlSerializer serializer = new XmlSerializer(typeof(OPCConfig));
        public static void Save(string filename, OPCDriver driver)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                OPCConfig config = new OPCConfig();
                driver.SaveConfig(config);
                serializer.Serialize(writer, config);
            }
        }
    }
}
