using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
namespace Calendar.Framework.Cache
{
    internal class MemoryCache : ICache
    {
        static readonly Microsoft.Extensions.Caching.Memory.IMemoryCache cache = null;

        #region Static Constructor
        /// <summary>
        /// Default static constructor
        /// </summary>
        static MemoryCache()
        {
            cache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions());
        }

        #endregion

        public object this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public long DefaultExpirationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #region Add

        /// <summary>
        /// Adds object to the cache for the max amount of time.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="value">Object value.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        public bool AddString(string key, string value, string region = null)
        {
            string val = cache.Set<string>(key, value);
            return !string.IsNullOrEmpty(val);
        }

        /// <summary>
        /// Adds object to the cache for the max amount of time.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="value">Object value.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        public bool AddType<T>(string key, T value, string region = null)
        {
            T val = cache.Set<T>(key, value);
            return val != null ? true : false;
        }

        /// <summary>
        /// Adds the object collection to cahce for  the max amount of time.
        /// </summary>
        /// <param name="values">List of Key Pair Values.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        public bool BulkAdd(List<KeyValuePair<string, object>> values, string region = null)
        {
            object val = null;
            foreach (KeyValuePair<string, object> value in values)
            {
                val = cache.Set<object>(value.Key, value.Value);
            }
            return true;
        }

        /// <summary>
        /// Adds the object collection to cahce for  the max amount of time.
        /// </summary>
        /// <param name="values">List of Key Pair Values.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        public bool BulkAddString(List<KeyValuePair<string, string>> values, string region = null)
        {
            string val = string.Empty;
            foreach (KeyValuePair<string, string> value in values)
            {
                val = cache.Set<string>(value.Key, value.Value);
            }
            return true;
        }

        #endregion

        #region Get
        /// <summary>
        /// Return the object collection for specified keys.
        /// </summary>
        /// <param name="keys">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns IEnumerable Key Value pair objects.</returns>
        public IEnumerable<KeyValuePair<string, object>> BulkGet(IEnumerable<string> keys, string region = null)
        {
            object val = null;
            List<KeyValuePair<string, object>> values = new List<KeyValuePair<string, object>>();
            foreach (string key in keys)
            {
                val = cache.Get<object>(key);
                values.Add(new KeyValuePair<string, object>(key, val));
            }
            return values;
        }

        /// <summary>
        /// Return the object collection for specified keys.
        /// </summary>
        /// <param name="keys">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns IEnumerable Key Value pair objects.</returns>
        public IEnumerable<KeyValuePair<string, string>> BulkGetString(IEnumerable<string> keys, string region = null)
        {
            string val = string.Empty;
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
            foreach (string key in keys)
            {
                val = cache.Get<string>(key);
                values.Add(new KeyValuePair<string, string>(key, val));
            }
            return values;
        }

        /// <summary>
        /// Return all object belongs to the region.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>IEnumerable Key Value pair.</returns>
        public IEnumerable<KeyValuePair<string, object>> GetObjectsByRegion(string region)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Return the object from cached based on the key otherwise just returns null.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns Object form the cache.</returns>
        public string GetString(string key, string region = null)
        {
            return cache.Get<string>(key);
        }

        /// <summary>
        /// Return all object belongs to the region.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>IEnumerable Key Value pair.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetStringByRegion(string region)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the object from cached based on the key otherwise just returns null.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns Object form the cache.</returns>
        public T GetType<T>(string key, string region = null)
        {
            return cache.Get<T>(key);
        }
        #endregion

        #region Key Exists

        /// <summary>
        /// Checks if the key exists in memory.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true if exists, otherwise returns false.</returns>
        public bool KeyExists(string key, string region = null)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes the an object from cache.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns removed object.</returns>
        public object Remove(string key, string region = null)
        {
            object val = cache.Get(key);
            cache.Remove(key);
            return val;
        }

        /// <summary>
        /// Clears everything from the cache on all servers.
        /// </summary>
        /// <returns>Returns tru/fase.</returns>
        public bool RemoveAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the an objects within the region from cache.
        /// </summary>
        /// <param name="region">Name of the region.</param>
        /// <returns>Returns true/false based on the success.</returns>
        public bool RemoveRegion(string region)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
