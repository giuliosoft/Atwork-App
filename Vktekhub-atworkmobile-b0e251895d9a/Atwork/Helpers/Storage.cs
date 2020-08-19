using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Atwork.Helpers
{
    public class Storage
    {
        //public async Task SetKeyValueAsync(string key, string value)
        //{
        //    await SecureStorage.SetAsync(key, value);
        //}

        //public async Task<string> GetKeyValueAsync(string key)
        //{
        //    string value = await SecureStorage.GetAsync(key);
        //    return value;
        //}

        // storage keys
        // "useremail" is email address
        // "password"
        // "token"
        // "istouch" - have used touch before
        // "language" - default language
        // "setupcomplete" - has been onboarded

        public static void SetKeyValue(string key, string value)        {
            Preferences.Set(key, value);
        }

        public static string GetKeyValue(string key)
        {
            return Preferences.Get(key, string.Empty);
        }
    }
}
