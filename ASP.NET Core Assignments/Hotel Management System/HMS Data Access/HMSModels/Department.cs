using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMS_Data_Access.HMSModels
{
    public partial class Department
    {
        public Department()
        {
            StaffDetails = new HashSet<StaffDetails>();
        }
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }

        public virtual ICollection<StaffDetails> StaffDetails { get; set; }
    }
}
