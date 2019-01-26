using System;
using IniWrapper.Settings;
using IniWrapper.Wrapper;

namespace IniWrapper.ini_parser
{
    public static class IniWrapperExtension
    {
        public static IIniWrapper CreateWithIniParser(this IIniWrapperFactory iniWrapperFactory, IniSettings iniSettings)
        {
            var parser = new IniParserAdapter(iniSettings);
            return iniWrapperFactory.Create(iniSettings, parser);
        }

        public static IIniWrapper CreateWithIniParser(this IIniWrapperFactory iniWrapperFactory, Action<IniSettings> iniSettings)
        {
            var settings = new IniSettings();

            iniSettings(settings);

            return iniWrapperFactory.CreateWithIniParser(settings);
        }
    }
}