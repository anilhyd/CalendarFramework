using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Framework.Configuration
{
    public class FileConfig
    {
        /// <summary>
        /// Uploaded file storage path, this would be a deployment server path.
        /// </summary>
        public string UploadsFolder { get; set; }

        /// <summary>
        /// Name of the sql connection string.  This property is mandatory if the Provider Name is Database or if SaveMetaData property has been set to true.
        /// </summary>
        public string ConnectionName { get; set; }

        /// <summary>
        /// Gets or sets the userid value.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the password value.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Amazon S3 Properties.
        /// Name of the Bucket
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// Amazon S3 Properties.
        /// Name of the AccessKey
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Amazon S3 Properties.
        /// Name of the SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Amazon S3 Properties.
        /// Name of the Region
        /// </summary>
        public string Region { get; set; }
    }
}
