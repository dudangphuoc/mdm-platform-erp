using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;
using MDM.Shared.AuthorizationModule;

namespace MDM.Shared.Localization.CustomerModule;
public static class CustomerLocalizationConfigurer
{
    public static void Configure(ILocalizationConfiguration localizationConfiguration)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(GlobalConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(CustomerLocalizationConfigurer).GetAssembly(),
                    "MDM.Shared.Localization.CustomerModule.SourceFiles"
                )
            )
        );

    }

    public static void Configure(ILocalizationConfiguration localizationConfiguration, string rootNamespace)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(GlobalConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(CustomerLocalizationConfigurer).GetAssembly(),
                    rootNamespace
                )
            )
        );
    }

}
