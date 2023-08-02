namespace MDM.Shared.AuthorizationModule
{
    public class GlobalConsts
    {
        private static readonly string KEY = "KEY_AuthorizationModule";

        public const string LocalizationSourceName = "AuthorizationModule";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;

        public static string RandomKey
        {
            get
            {
                return string.Format("{0}_{1:N}", KEY, Guid.NewGuid());
            }
        }

        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "fa43096c414c4d78ae66c7b8931c9bdb";

        // Define the cancellation token.
        public static CancellationToken CancellationToken
        {
            get
            {
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;
                return token;
            }
        }
    }
}
