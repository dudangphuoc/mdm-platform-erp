﻿using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;
using MDM.Shared.AuthorizationModule;

namespace MDM.Shared.Localization.AuthorizationModule
{
    public static class AuthorizationLocalizationConfigurer
    {
        //"MDM.Shared.Localization.CustomerModule.SourceFiles"
        //"AuthorizationModule.Localization.SourceFiles"
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(GlobalConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AuthorizationLocalizationConfigurer).GetAssembly(),
                        "MDM.Shared.Localization.AuthorizationModule.SourceFiles"
                    )
                )
            );

        }
        public static void Configure(ILocalizationConfiguration localizationConfiguration, string rootNamespace)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(GlobalConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AuthorizationLocalizationConfigurer).GetAssembly(),
                        rootNamespace
                    )
                )
            );
        }

    }
}