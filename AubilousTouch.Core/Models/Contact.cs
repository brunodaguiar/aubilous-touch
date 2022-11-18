using System;

namespace AubilousTouch.Core.Models
{
    public class Contact
    {        
        public int Id { get; set; }
        public string AubayId { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string TaxNumber { get; set; }
        public bool HasChildren { get; set; }
        public string Nationality { get; set; }
        public string PreferredLanguage { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
