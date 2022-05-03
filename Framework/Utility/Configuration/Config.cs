using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Framework.Configuration
{
    public class Config
    {
        /// <summary>
        /// Sets or gets the DBConnection configuration.
        /// </summary>
        public DBConnection DBConnection { get; set; }

        /// <summary>
        /// Sets or gets the FileConfig configuration.
        /// </summary>
        public FileConfig FileConfig { get; set; }

        /// <summary>
        /// Sets or gets the SessionConfig configuration.
        /// </summary>
        public SessionConfig SessionConfig { get; set; }
    }
}
