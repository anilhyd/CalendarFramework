using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Framework
{
    public static class UtilityManager
    {
        #region Framework Keys
        internal const string OrganizatoinId = "OrganizationId";
        
        #endregion

        #region ParseNullableInt
        /// <summary>
        /// Extension method will parse the nullable int.
        /// </summary>
        /// <param name="value">String value to be checked.</param>
        /// <returns>Retusn nulable int.</returns>
        public static int? ParseNullableInt(this string value)
        {
            int intValue;
            if (int.TryParse(value, out intValue))
                return intValue;
            return null;
        }
        #endregion
    }
}
