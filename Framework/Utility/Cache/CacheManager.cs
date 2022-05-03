using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Framework.Cache
{
    internal static class CacheManager
    {
        /// <summary>
        /// Readonly Cache Interface.
        /// </summary>
        private static readonly Dictionary<string, ICache> cacheProvider = new Dictionary<string, ICache>();

        //internal static async Task<string> Get(string orgkey, string key)
        //{

        //    ICache cache = GetCacheManager(orgkey);
        //    var name = await cache.GetAsync("Name");
        //    if (name != null)
        //        return Encoding.UTF8.GetString(name);
        //    else
        //        return null;
        //}

        //internal static async Task<string> GetMem(string key)
        //{
        //    ICache cache = GetCacheManager(key);

        //    var name = await cache.GetAsync("Name");
        //    if (name != null)
        //        return Encoding.UTF8.GetString(name);
        //    else
        //        return null;
        //}

        /// <summary>
        /// Initializes static members of the <see cref="CacheManager"/> class.
        /// </summary>
        /// <param name="organizationkey">Organizaiton Key.</param>
        /// <returns>Returns Cache Object.</returns>
        private static ICache GetCacheManager()
        {
            string cachetype = "Memory";
            //string s = HttpContext.Request.Headers[""].ToString();
            //string code = HttpContext.Session.GetString("");
            ICache cache = null;
            string orgkey = "org1";
            if (cacheProvider.ContainsKey(orgkey))
                cache = cacheProvider[orgkey];
            else
            {
                switch (cachetype)
                {
                    case "Redis":
                        cache = new RedisCache(null);
                        cacheProvider.Add(orgkey, cache);
                        break;

                    case "DistributeMemory":
                        cache = new DistributeMemoryCache();
                        cacheProvider.Add(orgkey, cache);
                        break;

                    case "Memory":
                        if (cacheProvider.ContainsKey("InMemory"))
                            cache = cacheProvider["InMemory"];
                        else
                        {
                            cache = new MemoryCache();
                            cacheProvider.Add("InMemory", cache);
                        }
                        break;
                    case "SqlServer":
                        cache = new SQLCache();
                        cacheProvider.Add(orgkey, cache);
                        break;

                }
            }

            return cache;
        }


        #region Add

        /// <summary>
        /// Adds object to the cache for the max amount of time.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="value">Object value.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        internal static bool AddString(string key, string value, string region = null) {
            return GetCacheManager().AddString(key, value, region);
        }

        /// <summary>
        /// Adds object to the cache for the max amount of time.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="value">Object value.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        internal static bool AddType<T>(string key, T value, string region = null) {
            return GetCacheManager().AddType<T>(key, value, region);
        }

        /// <summary>
        /// Adds the object collection to cahce for  the max amount of time.
        /// </summary>
        /// <param name="values">List of Key Pair Values.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        internal static bool BulkAdd(List<KeyValuePair<string, object>> values, string region = null)
        {
            return GetCacheManager().BulkAdd(values, region);
        }

        /// <summary>
        /// Adds the object collection to cahce for  the max amount of time.
        /// </summary>
        /// <param name="values">List of Key Pair Values.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        internal static bool BulkAddString(List<KeyValuePair<string, string>> values, string region = null)
        {
            return GetCacheManager().BulkAddString(values, region);
        }

        #endregion

        #region Get

        /// <summary>
        /// Return the object from cached based on the key otherwise just returns null.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns Object form the cache.</returns>
        internal static string GetString(string key, string region = null)
        {
            return GetCacheManager().GetString(key, region);
        }

        internal static T GetType<T>(string key, string region = null)
        {
            return GetCacheManager().GetType<T>(key, region);
        }

        /// <summary>
        /// Return the object collection for specified keys.
        /// </summary>
        /// <param name="keys">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns IEnumerable Key Value pair objects.</returns>
        internal static IEnumerable<KeyValuePair<string, object>> BulkGet(IEnumerable<string> keys, string region = null)
        {
            return GetCacheManager().BulkGet(keys, region);
        }

        /// <summary>
        /// Return the object collection for specified keys.
        /// </summary>
        /// <param name="keys">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns IEnumerable Key Value pair objects.</returns>
        internal static IEnumerable<KeyValuePair<string, string>> BulkGetString(IEnumerable<string> keys, string region = null)
        {
            return GetCacheManager().BulkGetString(keys, region);
        }

        /// <summary>
        /// Return all object belongs to the region.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>IEnumerable Key Value pair.</returns>
        internal static IEnumerable<KeyValuePair<string, object>> GetObjectsByRegion(string region)
        {
            return GetCacheManager().GetObjectsByRegion(region);
        }

        /// <summary>
        /// Return all object belongs to the region.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>IEnumerable Key Value pair.</returns>
        internal static IEnumerable<KeyValuePair<string, string>> GetStringByRegion(string region)
        {
            return GetCacheManager().GetStringByRegion(region);

        }

        #endregion

        #region Remove

        /// <summary>
        /// Clears everything from the cache on all servers.
        /// </summary>
        /// <returns>Returns tru/fase.</returns>
        internal static bool RemoveAll()
        {
            return GetCacheManager().RemoveAll();
        }

        /// <summary>
        /// Removes the an object from cache.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns removed object.</returns>
        internal static object Remove(string key, string region = null)
        {
            return GetCacheManager().Remove(key, region);

        }

        /// <summary>
        /// Removes the an objects within the region from cache.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>Returns true/false based on the success.</returns>
        internal static bool RemoveRegion(string region)
        {
            return GetCacheManager().RemoveRegion(region);
        }

        #endregion

        #region KeyExists

        /// <summary>
        /// Checks if the key exists in memory.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true if exists, otherwise returns false.</returns>
        internal static bool KeyExists(string key, string region = null)
        {
            return GetCacheManager().KeyExists(key, region);
        }

        #endregion
    }
}
