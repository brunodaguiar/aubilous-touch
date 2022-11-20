using AubilousTouch.Core.Models;
using CsvHelper.Configuration;

namespace AubilousTouch.Intra.Readers.CSVHelper
{
    public class ContactCSVHelperMapper : ClassMap<ContactFileItem>
    {
        public ContactCSVHelperMapper()
        {
                          
            Map(m => m.AubilousId).Name("Aubay ID");
            Map(m => m.Name).Name("Nome Completo");
            Map(m => m.SMS).Name("SMS");
            Map(m => m.Telegram).Name("Telegram");
            Map(m => m.Email).Name("E-mail");
            Map(m => m.Whatsapp).Name("WhatsApp");
            Map(m => m.Slack).Name("Slack");
        }
    }
}
