using AubilousTouch.Core.Models;
using CsvHelper.Configuration;

namespace AubilousTouch.Intra.Readers.CSVHelper
{
    public class ContactCSVHelperMapper : ClassMap<Contact>
    {
        public ContactCSVHelperMapper()
        {
            Map(m => m.Address).Name("address");
            Map(m => m.IsActive).Name("isactive");
            Map(m => m.AubayId).Name("aubayid");
            Map(m => m.Role).Name("role");
            Map(m => m.Phone).Name("phone");
            Map(m => m.BirthDate).Name("birthdate");
            Map(m => m.TaxNumber).Name("taxnumber");
            Map(m => m.HasChildren).Name("haschildren");
            Map(m => m.Nationality).Name("nationality");
            Map(m => m.PreferredLanguage).Name("preferredlanguage");
            Map(m => m.AdmissionDate).Name("admissiondate");
            Map(m => m.EndDate).Name("enddate");
        }
    }
}
