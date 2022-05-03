using System;
using System.Collections.Generic;

namespace Calendar.Framework.Entity
{
    public partial class Country
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
