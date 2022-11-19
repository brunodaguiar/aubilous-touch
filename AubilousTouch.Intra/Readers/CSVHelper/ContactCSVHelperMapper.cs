using AubilousTouch.Core.Models;
using CsvHelper.Configuration;

namespace AubilousTouch.Intra.Readers.CSVHelper
{
    public class ContactCSVHelperMapper : ClassMap<Employee>
    {
        public ContactCSVHelperMapper()
        {
            Map(m => m.IsActive).Name("isactive");
            Map(m => m.AubayId).Name("aubayid");
            Map(m => m.Role).Name("role");
            Map(m => m.BirthDate).Name("birthdate");
            Map(m => m.TaxNumber).Name("taxnumber");
            Map(m => m.HasChildren).Name("haschildren");
            Map(m => m.Nationality).Name("nationality");
            Map(m => m.AdmissionDate).Name("admissiondate");
        }
    }
}
