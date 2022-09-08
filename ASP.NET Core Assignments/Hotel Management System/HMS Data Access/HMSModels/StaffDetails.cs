using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMS_Data_Access.HMSModels
{
    public partial class StaffDetails
    {
        [Key]
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffAddress { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Nic { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
