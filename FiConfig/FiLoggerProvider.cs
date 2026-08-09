using Microsoft.Extensions.Logging;

namespace OrakUtilDotNetCore.FiConfig
{
    /// <summary>
    /// Global olarak logger'e statik erişim sağlayan provider
    /// </summary>
    public static class FiLoggerProvider
    {
        private static ILoggerFactory? _loggerFactory;

        /// <summary>
        /// Logger Factory'i initialize et (Program.cs içinde çağrılmalı)
        /// </summary>
        public static void Initialize(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        /// <summary>
        /// Belirtilen type için logger alır
        /// </summary>
        public static ILogger<T> GetLogger<T>() where T : class
        {
            if (_loggerFactory == null)
                throw new InvalidOperationException("FiLoggerProvider henüz initialize edilmemiş. Program.cs içinde FiLoggerProvider.Initialize() çağrısını yapınız.");

            return _loggerFactory.CreateLogger<T>();
        }

        /// <summary>
        /// String ismi ile logger alır
        /// </summary>
        public static ILogger GetLogger(string categoryName)
        {
            if (_loggerFactory == null)
                throw new InvalidOperationException("FiLoggerProvider henüz initialize edilmemiş. Program.cs içinde FiLoggerProvider.Initialize() çağrısını yapınız.");

            return _loggerFactory.CreateLogger(categoryName);
        }

        /// <summary>
        /// Logger Factory'i sıfırla (test amaçlı)
        /// </summary>
        public static void Reset()
        {
            _loggerFactory = null;
        }

        /// <summary>
        /// Logger Factory'nin initialize edilip edilmediğini kontrol et
        /// </summary>
        public static bool IsInitialized => _loggerFactory != null;
    }
}
