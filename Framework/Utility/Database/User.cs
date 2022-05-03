using System;
using System.Collections.Generic;

namespace Calendar.Framework.Entity
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LasstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte? UserType { get; set; }
        public byte? UserSource { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? OrganizationId { get; set; }
        public bool? IsActive { get; set; }

        public Organization Organization { get; set; }
    }
}
