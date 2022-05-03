using System;
using System.Collections.Generic;

namespace Calendar.Framework.Entity
{
    public partial class Organization
    {
        public Organization()
        {
            OrganizationConfig = new HashSet<OrganizationConfig>();
            User = new HashSet<User>();
        }

        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public DateTime? ActivationDate { get; set; }
        public short? ExpireDays { get; set; }
        public string Address1 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
        public Guid? CountryId { get; set; }
        public bool? IsEap { get; set; }
        public bool? IsKol { get; set; }
        public bool? IsMed { get; set; }
        public bool? IsIst { get; set; }
        public bool? IsHeor { get; set; }
        public bool? IsGrants { get; set; }
        public bool? IsPp { get; set; }
        public string RepresentName { get; set; }
        public string RepresentEmail { get; set; }
        public string RepresentPhone { get; set; }
        public byte? RepresentExt { get; set; }
        public string RepresentAddress1 { get; set; }
        public string RepresentAddress2 { get; set; }
        public string RepresentCity { get; set; }
        public string RepresentState { get; set; }
        public string RepresentPin { get; set; }
        public Guid? RepresentCountryId { get; set; }
        public string SuperAdminName { get; set; }
        public string SuperAdminEmail { get; set; }
        public string SuperAdminPhone { get; set; }
        public byte? SuperAdminExt { get; set; }
        public string SuperAdminAddress1 { get; set; }
        public string SuperAdminAddress2 { get; set; }
        public string SuperAdminCity { get; set; }
        public string SuperAdminState { get; set; }
        public string SuperAdminPin { get; set; }
        public Guid? SuperAdminCountryId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<OrganizationConfig> OrganizationConfig { get; set; }
        public ICollection<User> User { get; set; }
    }
}
