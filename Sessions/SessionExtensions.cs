using System;
using System.Text.Json;

namespace Sessions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize<T>(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.Get(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}
