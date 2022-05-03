using System;
using System.Collections.Generic;

namespace Calendar.Framework.Entity
{
    public partial class OrganizationConfig
    {
        public Guid ConfigId { get; set; }
        public string CacheSource { get; set; }
        public string CacheConnection { get; set; }
        public string DatabaseSource { get; set; }
        public string DatabasConnection { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? OrganizationId { get; set; }
        public bool? IsActive { get; set; }

        public Organization Organization { get; set; }
    }
}
