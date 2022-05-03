using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Framework.Cache
{
    internal class SQLCache : ICache
    {
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the object collection to cahce for  the max amount of time.
        /// </summary>
        /// <param name="values">List of Key Pair Values.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        public bool BulkAdd(List<KeyValuePair<string, object>> values, string region = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the object collection to cahce for  the max amount of time.
        /// </summary>
        /// <param name="values">List of Key Pair Values.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Return true/false.</returns>
        public bool BulkAddString(List<KeyValuePair<string, string>> values, string region = null)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the object collection for specified keys.
        /// </summary>
        /// <param name="keys">String key.</param>
        /// <param name="region">Optional Name of the region.</param>
        /// <returns>Returns IEnumerable Key Value pair objects.</returns>
        public IEnumerable<KeyValuePair<string, string>> BulkGetString(IEnumerable<string> keys, string region = null)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
