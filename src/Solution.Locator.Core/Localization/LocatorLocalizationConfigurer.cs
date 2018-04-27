using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Solution.Locator.Localization
{
    public static class LocatorLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(LocatorConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(LocatorLocalizationConfigurer).GetAssembly(),
                        "Solution.Locator.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
