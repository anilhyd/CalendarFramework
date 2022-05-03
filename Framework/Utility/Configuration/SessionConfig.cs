using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Framework.Configuration
{
    public class SessionConfig
    {
        /// <summary>
        /// Gets or sets the Session Timeout value in minutes.
        /// </summary>
        public int Timeout { get; internal set; }
    }
}
