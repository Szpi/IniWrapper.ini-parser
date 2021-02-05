using System.Text;
using IniParser;
using IniParser.Model;
using IniWrapper.ParserWrapper;
using IniWrapper.Settings;

namespace IniWrapper.ini_parser
{
    public class IniParserAdapter : IIniParser
    {
        private readonly IniSettings _iniSettings;
        private readonly IniData _iniSaveData;
        private readonly FileIniDataParser _fileIniDataParser;

        private IniData _iniReadData;
        public IniParserAdapter(IniSettings iniSettings)
        {
            _iniSettings = iniSettings;
            _iniSaveData = new IniData();
            _fileIniDataParser = new FileIniDataParser();
        }

        public string Read(string section, string key)
        {
            ReadFromFile();

            // If no key has been specified, all key-value pairs (separated by \0) from the given section need to be returned.
            if (string.IsNullOrEmpty(key))
            {
                var sb = new StringBuilder();
                var sectionDataCollection = _iniReadData.Sections[section];

                if (sectionDataCollection != null)
                {
                    foreach (var sec in sectionDataCollection)
                    {
                        sb.Append($"{sec.KeyName}={sec.Value}\0");
                    }
                }

                var result = sb.ToString().Trim('\0');
                return result;
            }

            return _iniReadData[section][key];
        }

        public void Write(string section, string key, string value)
        {
            _iniSaveData[section][key] = value;
            _fileIniDataParser.WriteFile(_iniSettings.IniFilePath, _iniSaveData);
        }

        private void ReadFromFile()
        {
            if (_iniReadData != null)
            {
                return;
            }

            _iniReadData = _fileIniDataParser.ReadFile(_iniSettings.IniFilePath);
        }
    }
}