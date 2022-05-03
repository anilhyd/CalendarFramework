using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Framework
{
    public class Common
    {
        #region Property : GuiID
        /// <summary>
        /// Returns the Formated String (yyyy-MM-ddTHH:mm:ss.fff).
        /// </summary>
        /// <returns>Returns the Formated String.</returns>
        internal static string GetUTCCurrentDate()
        {
            DateTime date = DateTime.UtcNow;
            return date.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }

        /// <summary>
        /// Returns the Formated String (yyyy-MM-ddTHH:mm:ss.fff).
        /// </summary>
        /// <param name="date">Datetime Object.</param>
        /// <returns>Returns the Formated String.</returns>
        internal static string GetUTCDate(DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }
        #endregion

    }
}
