using System;

namespace AubilousTouch.Core.Models
{
    public class Employee : EntityBase
    {
        public int EmployeeId { get; set; }
        public string AubayId { get; set; }
        public string Addres { get; set; }
        public string Role { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string TaxNumber { get; set; }
        public bool? HasChildren { get; set; }
        public string Nationality { get; set; }
        public string PreferredCommunicationLanguage { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? CessationDate { get; set; }
        public bool? IsActive { get; set; }
    }

}
