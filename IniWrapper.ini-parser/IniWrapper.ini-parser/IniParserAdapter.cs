using System;
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

        private IniData _iniReadData;
        public IniParserAdapter(IniSettings iniSettings)
        {
            _iniSettings = iniSettings;
            _iniSaveData = new IniData();
        }

        public string Read(string section, string key)
        {
            ReadFromFile();
            return _iniReadData[section][key];
        }

        public void Write(string section, string key, string value)
        {
            _iniSaveData[section][key] = value;
            var parser = new FileIniDataParser();
            parser.WriteFile(_iniSettings.IniFilePath, _iniSaveData);
        }

        private void ReadFromFile()
        {
            if (_iniReadData != null)
            {
                return;
            }

            var parser = new FileIniDataParser();
            _iniReadData = parser.ReadFile(_iniSettings.IniFilePath);
        }
    }
}