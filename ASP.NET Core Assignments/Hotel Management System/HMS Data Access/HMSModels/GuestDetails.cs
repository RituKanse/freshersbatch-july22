using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMS_Data_Access.HMSModels
{
    public partial class GuestDetails
    {
        public GuestDetails()
        {
            Bill = new HashSet<Bill>();
            Reservation = new HashSet<Reservation>();
        }
        [Key]
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public decimal? PhoneNumber { get; set; }
        public int? Company { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string GuestAddress { get; set; }
        public int? RoomId { get; set; }

        public virtual RoomDetails Room { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
