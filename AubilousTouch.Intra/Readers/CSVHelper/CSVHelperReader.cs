using AubilousTouch.Core.Interfaces;
using AubilousTouch.Core.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace AubilousTouch.Intra.Readers.CSVHelper
{
    public class CSVHelperReader : IFileReader
    {
        public IEnumerable<Contact> Read(byte[] file)
        {
            using (Stream stream = new MemoryStream(file))
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    using (CsvHelper.CsvReader csvReader = new CsvHelper.CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        csvReader.Context.RegisterClassMap<ContactCSVHelperMapper>();

                        var records = csvReader.GetRecords<Contact>();

                        return records;
                    }
                }
            }
        }
    }
}
