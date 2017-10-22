using System;
using System.Collections.Specialized;
using System.Configuration;

namespace DaiQuery
{
    /// <summary>
    /// Singleton class that loads and exposes the various rendering settings.
    /// </summary>
    internal class Settings
    {
        /// <summary>
        /// Represents the translation of a key string, typically read from a configuration file, into its intended in-memory value of type <typeparamref name="T"/>.
        /// Used in synergy with the method <see cref="ReadSettingValue{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the setting.</typeparam>
        private class Case<T> : Tuple<string, T>
        {
            public Case(string key, T value)
                : base(key, value)
            { }
        }

        private RenderMode? defaultRenderMode;
        private KeywordCase? keywordCase;
        private IRendererFactory rendererFactory;
        private ErrorHandlingMode? errorHandlingMode;

        #region Implementation of the singleton pattern
        private static Settings settingsMgr;
        /// <summary>
        /// Singleton instance of this class.
        /// </summary>
        public static Settings Manager
        {
            get
            {
                if (settingsMgr == null)
                    settingsMgr = new Settings();

                return settingsMgr;
            }
        }

        private static NameValueCollection nameValueCollection;
        private Settings() 
        {
            nameValueCollection = ConfigurationManager.AppSettings;
        }
        #endregion Implementation of the singleton pattern

        /// <summary>
        /// Looks up a setting named <paramref name="settingName"/> and, if it finds it, tries to match the found string against the given <paramref name="cases"/>, in order.
        /// The first good match yields the return value.
        /// </summary>
        /// <typeparam name="T">The type of the setting.</typeparam>
        /// <param name="settingName">The key used to look up the setting's value.</param>
        /// <param name="defaultValue">The value to return if the setting is not found, or if no match is found for the setting's string value.</param>
        /// <param name="cases">A key-value collection that describes how to associate every acceptable string value for the setting with its <typeparamref name="T"/> value.</param>
        /// <returns>One of the values of <paramref name="cases"/>, or <paramref name="defaultValue"/> if no match is found.</returns>
        private static T ReadSettingValue<T>(string settingName, T defaultValue, params Case<T>[] cases)
        {
            T result = defaultValue;
            string fromConfig = nameValueCollection[settingName];
            bool configHasValue = !string.IsNullOrWhiteSpace(fromConfig);
            if (configHasValue)
                fromConfig = fromConfig.Trim();

            foreach (Case<T> c in cases)
            {
                if (configHasValue && string.Equals(fromConfig, c.Item1, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = c.Item2;
                    break;
                }
            }
            return result;
        }

        public ErrorHandlingMode ErrorHandlingMode
        {
            get
            {
                if (!errorHandlingMode.HasValue)
                    errorHandlingMode = ReadSettingValue<ErrorHandlingMode>("ErrorHandlingMode", ErrorHandlingMode.ThrowException,
                        new Case<ErrorHandlingMode>("ThrowException", ErrorHandlingMode.ThrowException),
                        new Case<ErrorHandlingMode>("PrintComment", ErrorHandlingMode.PrintWarning));

                return errorHandlingMode.Value; 
            }
        }

        public IRendererFactory RendererFactory
        {
            get 
            {
                if (rendererFactory == null)
                    rendererFactory = ReadSettingValue<IRendererFactory>("SqlDialect", new StandardRendererFactory(),
                        new Case<IRendererFactory>("MSSQL", new MsSqlRendererFactory()),
                        new Case<IRendererFactory>("Standard", new StandardRendererFactory()));

                return rendererFactory;
            }
        }

        public RenderMode DefaultRenderMode
        {
            get 
            {
                if (!defaultRenderMode.HasValue)
                    defaultRenderMode = ReadSettingValue<RenderMode>("DefaultRenderMode", RenderMode.Plain,
                        new Case<RenderMode>("Plain", RenderMode.Plain),
                        new Case<RenderMode>("Pretty", RenderMode.Pretty));

                return defaultRenderMode.Value;
            }
        }

        public KeywordCase KeywordCase
        {
            get
            {
                if (!keywordCase.HasValue)
                    keywordCase = ReadSettingValue<KeywordCase>("KeywordCase", KeywordCase.UpperCase,
                        new Case<KeywordCase>("LowerCase", KeywordCase.LowerCase),
                        new Case<KeywordCase>("ProperCase", KeywordCase.ProperCase),
                        new Case<KeywordCase>("UpperCase", KeywordCase.UpperCase));
                
                return keywordCase.Value;
            }
        }
    }
}