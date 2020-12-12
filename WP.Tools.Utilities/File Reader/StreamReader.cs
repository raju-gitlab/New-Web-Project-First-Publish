using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Tools.Utilities.File_Reader
{
    public class StreamReader
    {
        public static string ReadTXTFile(string Path)
        {
            try
            {
                string line;
                var sb = new StringBuilder();
                var file = new System.IO.StreamReader(Path);
                while ((line = file.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
                file.Close();
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Read File", ex);
            }
        }

        public static string ReadTextFile(string Path)
        {
            try
            {
                var text = string.Empty;
                var path = string.Empty;
                path = ConfigurationManager.AppSettings[Path].ToString();
                text = ReadTXTFile(path);
                return text;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

    }
}
